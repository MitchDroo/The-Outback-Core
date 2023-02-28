using System.Collections.Generic;
using Newtonsoft.Json;

namespace Outback
{
    public class JsonConverter
    {
        private JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Objects
       };

        public string ToJson(HashSet<ExampleItem> values)
        {
            return JsonConvert.SerializeObject(values, _settings);
        }

        public HashSet<ExampleItem> FromJson(string json)
        {
            return JsonConvert.DeserializeObject<HashSet<ExampleItem>>(json, _settings);
        }
    }
}