using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace WowHeadParser.Models
{
    public partial class MapData
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("coords")]
        public double[][] Coords { get; set; }

        [JsonProperty("uiMapId", NullValueHandling = NullValueHandling.Ignore)]
        public long? UiMapId { get; set; }

        [JsonProperty("uiMapName", NullValueHandling = NullValueHandling.Ignore)]
        public string UiMapName { get; set; }
    }

    public partial struct MapNodesValue
    {
        public MapData[] MapNodeArray;
        public System.Collections.Generic.Dictionary<string, MapData> MapNodeMap;

        public static implicit operator MapNodesValue(MapData[] MapNodeArray) => new MapNodesValue { MapNodeArray = MapNodeArray };
        public static implicit operator MapNodesValue(System.Collections.Generic.Dictionary<string, MapData> MapNodeMap) => new MapNodesValue { MapNodeMap = MapNodeMap };
    }

    internal class MapNodesValueConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(MapNodesValue) || t == typeof(MapNodesValue?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<System.Collections.Generic.Dictionary<string, MapData>>(reader);
                    return new MapNodesValue { MapNodeMap = objectValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<MapData[]>(reader);
                    return new MapNodesValue { MapNodeArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type MapNodesValue");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (MapNodesValue)untypedValue;
            if (value.MapNodeArray != null)
            {
                serializer.Serialize(writer, value.MapNodeArray);
                return;
            }
            if (value.MapNodeMap != null)
            {
                serializer.Serialize(writer, value.MapNodeMap);
                return;
            }
            throw new Exception("Cannot marshal type MapNodesValue");
        }

        public static readonly MapNodesValueConverter Singleton = new MapNodesValueConverter();
    }
}
