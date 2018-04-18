using System.IO;
using System.Runtime.Serialization.Json;

namespace EnvKey
{
  public static class JsonDeserializer
  {
    public static T Deserialize<T>(string jsonData)
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
