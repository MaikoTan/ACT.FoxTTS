using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ACT.FoxTTS.engine.ai_cloud
{
    public class AiCloudSettings
    {
        [XmlElement]
        public int Speed = 10;

        [XmlElement]
        public int Pitch = 10;

        [XmlElement]
        public int Volume = 10;

        [XmlElement]
        public int Person = 0;

        [XmlElement]
        public string Proxy = "";
    }
}
