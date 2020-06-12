﻿using ACT.FoxCommon.localization;
using ACT.FoxTTS.engine.baidu;
using ACT.FoxTTS.engine.ai_cloud;
using ACT.FoxTTS.localization;
using ACT.FoxTTS.engine.sapi5;

namespace ACT.FoxTTS.engine
{
    class TTSEngineDef
    {
        public string Name { get; }
        public string DisplayName => LocalizationBase.GetString(Name) ?? Name;

        public TTSEngineDef(string name)
        {
            Name = name;
        }
    }

    class TTSEngineFactory
    {
        public static TTSEngineDef[] Engines =
        {
            new TTSEngineDef("ttsEngineAiCloud"),
            new TTSEngineDef("ttsEngineBaidu"),
            new TTSEngineDef("ttsEngineSAPI5"),
        };

        public static ITTSEngine CreateEngine(string engine)
        {
            switch (engine)
            {
                case "ttsEngineSAPI5":
                    return new SAPI5Engine();
                case "ttsEngineBaidu":
                    return new BaiduTTSEngine();
                case "ttsEngineAiCloud":
                default:
                    return new AiCloudEngine();
            }
        }
    }
}
