using System.Collections.Generic;
using Newtonsoft.Json;

namespace EnvKey
{
  public static class JsonDeserializer
  {
    public static T Deserialize<T>(string jsonData)
    {
      return JsonConvert.DeserializeObject<T>(jsonData);
    }
  }
}
