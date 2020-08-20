using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACT.FoxTTS.engine.ai_cloud
{
  class AiCloudEngine : ITTSEngine
  {
    private FoxTTSPlugin _plugin;
    private readonly AiCloudSettingsControl _settingsControl = new AiCloudSettingsControl();

    private Dictionary<string, Task> tasksMap = new Dictionary<string, Task>();

    private Dictionary<int, string> personTable = new Dictionary<int, string>()
    {
      { 0, "554" },      // 紲星 あかり   554
      { 1, "1206" },     // 結月 ゆかり   1206
      { 2, "1210" },     // 桜乃 そら     1210
      { 3, "552" },      // 琴葉 茜       552   # emotion
      { 4, "551" },      // 琴葉 葵       551   # emotion
      { 5, "1211" },     // 東北 イタコ   1211  # emotion
      { 6, "1202" },     // 東北 ずん子   1202
      { 7, "1209" },     // 東北 きりたん 1209
      { 8, "1208" },     // 京町 セイカ   1208
      { 9, "1207" },     // 水奈瀬 コウ   1207
      { 10, "1205" },    // 民安 ともえ   1205
      { 11, "1203" },    // 月読 アイ      1203
      { 12, "1204" },    // 月読 ショウタ   1204
      { 13, "1201" },    // 鷹の爪 吉田くん 1201
      { 14, "1212" },    // ついなちゃん(標準語) 1212
      { 15, "1213" },    // ついなちゃん(関西弁) 1213
      { 16, "1214" },    // 伊織弓鶴      1214  # emotion
    };

    public string Name => "AiClound";

    public void AttachToAct(FoxTTSPlugin plugin)
    {
      _plugin = plugin;
      _settingsControl.AttachToAct(plugin);
    }

    public void PostAttachToAct(FoxTTSPlugin plugin)
    {
      _settingsControl.PostAttachToAct(plugin);

      _settingsControl.DoLocalization();
    }

    public void Stop()
    {
      _settingsControl.RemoveFromAct();
    }

    public void Speak(string text, dynamic playDevice, bool isSync, float? volume)
    {
      var settings = _plugin.Settings.AiCloudTtsSettings;

      personTable.TryGetValue(settings.Person, out string person);

      var option = new Dictionary<string, string>()
      {
        { "speaker_id", person.ToString() },
        { "volume", (settings.Volume * 0.1).ToString() },
        { "speed", (settings.Speed * 0.1).ToString() },
        { "pitch", (settings.Pitch * 0.1).ToString() },
      };

      // Calculate hash
      var wave = this.GetCacheFileName(text.Replace(Environment.NewLine, "+"), "wav", option.GetString());
      var wave_origin = wave.Replace(".wav", ".origin.wav");


      lock (this)
      {
        if (!File.Exists(wave))
        {
          if (!tasksMap.ContainsKey(text + option.GetString()))
          {
            var task = Task.Run(async () =>
            {
              string body = $"speaker_id={person}&text={WebUtility.UrlEncode(text)}&ext=wav&volume={(settings.Volume * 0.1).ToString()}&speed={(settings.Speed * 0.1).ToString()}&pitch={(settings.Pitch * 0.1).ToString()}&callback=callback";

              string result = await DownLoadWaveManifest("https://cloud.ai-j.jp/demo/aitalk2webapi_nop.php", body, settings.Proxy);

              if (!string.IsNullOrWhiteSpace(result))
              {
                var url = "https://" + result.Replace("callback({\"url\":\"\\/\\/", "").Replace("\"})", "").Replace("\\", "");

                await DownloadWaveFile(url, wave_origin, settings.Proxy);
              }
              if (File.Exists(wave_origin))
              {
                new DemoParser(_plugin).Run(wave_origin, wave);
              }

              tasksMap.Remove(text + option.GetString());
              _plugin.SoundPlayer.Play(wave, playDevice, isSync, volume);
            });
            tasksMap.Add(text + option.GetString(), task);
          }
        }
      }
      if (File.Exists(wave))
      {
        if (File.Exists(wave_origin))
          File.Delete(wave_origin);
        _plugin.SoundPlayer.Play(wave, playDevice, isSync, volume);
      }
    }

    private async Task<string> DownLoadWaveManifest(string api, string body, string proxy)
    {
      var content = new StringContent(body);

      content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
      //content.Headers.Add("Host", "cloud.ai-j.jp");
      //content.Headers.Add("Origin", "https://www.ai-j.jp");
      //content.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36");

      HttpClientHandler httpClientHandler = new HttpClientHandler();
      if (!String.IsNullOrWhiteSpace(proxy))
      {
        httpClientHandler.Proxy = new WebProxy(proxy, true);
      }

      using (var httpClient = new HttpClient(httpClientHandler))
      {
        HttpResponseMessage responseMessage = await httpClient.PostAsync(api, content);
        if (responseMessage.IsSuccessStatusCode)
        {
          return await responseMessage.Content.ReadAsStringAsync();
        }
      }

      return string.Empty;
    }

    private async Task DownloadWaveFile(string url, string file_name, string proxy)
    {
      WebClient webClient = new WebClient();
      if (!string.IsNullOrWhiteSpace(proxy))
      {
        webClient.Proxy = new WebProxy(proxy);
      }
      await webClient.DownloadFileTaskAsync(new Uri(url), file_name);
    }
  }
}
