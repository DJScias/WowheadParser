using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace WowHeadParser.Models
{
    
    public partial struct Modes
    {
        public int[] mode;
        public System.Collections.Generic.Dictionary<string, DropRate> ModeMap;
        public static implicit operator Modes(System.Collections.Generic.Dictionary<string, DropRate> MapNodeMap) => new Modes { ModeMap = MapNodeMap };
    }

    public class DropRate
    {
        public long count { get; set; }
        public long outof { get; set; }
        
        [JsonIgnore]
        public float Percent { get
                {
                    float percent = ((float)count * 100f) / (float)outof;

                    // Normalize
                    if (percent > 99.0f)
                        percent = 100.0f;

                    return percent;
                } 
        }
    }

    public static class Converter
    {
        public static readonly JsonSerializerSettings SettingsDropConverter = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                DropRateValueConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };

        public static readonly JsonSerializerSettings SettingsMapNodes = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                MapNodesValueConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }


    public class DropRateValueConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Modes) || t == typeof(Modes?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            var modes = new Modes();
            modes.ModeMap = new Dictionary<string, DropRate>();
            
            foreach (JProperty property in jo.Properties())
            {
                if (property.Name == "mode")
                {
                    modes.mode = property.Value.ToObject<int[]>();
                }
                else
                {
                    DropRate mode = property.Value.ToObject<DropRate>();
                    modes.ModeMap[property.Name] = mode;
                }
            }

            return modes;   
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Modes)untypedValue;
            if (value.mode != null)
            {
                serializer.Serialize(writer, value.mode);
                return;
            }
            if (value.ModeMap != null)
            {
                serializer.Serialize(writer, value.ModeMap);
                return;
            }
            throw new Exception("Cannot marshal type DropRateValueConverter");
        }

        public static readonly DropRateValueConverter Singleton = new DropRateValueConverter();
    }
}
