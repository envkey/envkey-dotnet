using System.IO;
using System.Runtime.Serialization.Json;

namespace EnvKey
{
  internal static class JsonDeserializer
  {
    internal static T Deserialize<T>(string jsonData)
    {
      var array = System.Text.Encoding.UTF8.GetBytes(jsonData);
      using (var mem = new MemoryStream(array))
      {
        var settings = new DataContractJsonSerializerSettings
        {
          UseSimpleDictionaryFormat = true
        };
        var ser = new DataContractJsonSerializer(typeof(T), settings);
        var config = (T)ser.ReadObject(mem);

        return config;
      }
    }
  }
}
