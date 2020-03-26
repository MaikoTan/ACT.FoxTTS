using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace ACT.FoxTTS.engine.ai_cloud
{
    class DemoParser
    {
        private FoxTTSPlugin _plugin;

        public DemoParser(FoxTTSPlugin plugin)
        {
            this._plugin = plugin;
        }

        /// <summary>
        /// cut the trash time before tts result
        /// </summary>
        /// <param name="reader">source</param>
        /// <param name="writer">destination</param>
        /// <param name="cutFromStart">start time</param>
        /// <param name="cutFromEnd">end time</param>
        public void TrimWave(WaveFileReader reader, WaveFileWriter writer, TimeSpan cutFromStart, TimeSpan cutFromEnd)
        {

            int bytesPerMillisecond = reader.WaveFormat.AverageBytesPerSecond / 1000;

            int startPos = (int)cutFromStart.TotalMilliseconds * bytesPerMillisecond;
            startPos = startPos - startPos % reader.WaveFormat.BlockAlign;

            int endBytes = (int)cutFromEnd.TotalMilliseconds * bytesPerMillisecond;
            endBytes = endBytes - endBytes % reader.WaveFormat.BlockAlign;
            int endPos = (int)reader.Length - endBytes;

            reader.Position = startPos;
            byte[] buffer = new byte[1024];
            while (reader.Position < endPos)
            {
                int bytesRequired = (int)(endPos - reader.Position);
                if (bytesRequired > 0)
                {
                    int bytesToRead = Math.Min(bytesRequired, buffer.Length);
                    int bytesRead = reader.Read(buffer, 0, bytesToRead);
                    if (bytesRead > 0)
                    {
                        writer.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }

        /// <summary>
        /// determine where is the trash time to cut
        /// </summary>
        /// <param name="wave">source</param>
        /// <returns>TimeSpan</returns>
        public TimeSpan DetermineTrashWave(WaveFileReader wave)
        {
            int bytesPerMillisecond = wave.WaveFormat.AverageBytesPerSecond / 1000;
            wave.Position = 0;
            int count = 0, maxcount = 0;

            float[] frameRead;
            while ((frameRead = wave.ReadNextSampleFrame()) != null)
            {
                count++;
                if (count > maxcount) maxcount = count;
                foreach (var i in frameRead)
                {
                    if (Math.Abs(i - 0) > 1e-6)
                    {
                        count = 0;
                        break;
                    }
                }
                if (count > wave.WaveFormat.SampleRate * 0.7)
                {
                    return wave.CurrentTime;
                }
            }
            return TimeSpan.FromMilliseconds(0);
        }

        /// <summary>
        /// runs the main senario
        /// </summary>
        /// <param name="inPath">source file name</param>
        /// <param name="outPath">destination file name</param>
        public void Run(string inPath, string outPath)
        {
            using (var wavein = new WaveFileReader(inPath))
            {
                using (var waveout = new WaveFileWriter(outPath, wavein.WaveFormat))
                {
                    TrimWave(wavein, waveout,
                        DetermineTrashWave(wavein),
                        TimeSpan.FromMilliseconds(0));
                    waveout.Dispose();
                }
            }
        }
    }
}
