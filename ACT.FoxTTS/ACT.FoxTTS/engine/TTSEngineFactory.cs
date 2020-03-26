﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACT.FoxCommon.localization;
using ACT.FoxTTS.engine.baidu;
using ACT.FoxTTS.engine.ai_cloud;
using ACT.FoxTTS.localization;

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
        public static TTSEngineDef[] Engines = {new TTSEngineDef("ttsEngineBaidu"), new TTSEngineDef("ttsEngineAiCloud")};

        public static ITTSEngine CreateEngine(string engine)
        {
            switch (engine)
            {
                case "ttsEngineBaidu":
                    return new BaiduTTSEngine();
                case "ttsEngineAiCloud":
                default:
                    return new AiCloudEngine();
            }
        }
    }
}
