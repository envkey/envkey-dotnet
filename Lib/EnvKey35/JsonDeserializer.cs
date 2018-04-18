using System.Web.Script.Serialization;

namespace EnvKey
{
  internal static class JsonDeserializer
  {
    internal static T Deserialize<T>(string jsonData)
    {
      var serializer = new JavaScriptSerializer();
      return serializer.Deserialize<T>(jsonData);
    }
  }
}
