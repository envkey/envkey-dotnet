using System;
using EnvKey;

namespace Test
{
  public class Program
  {
    public static int Main(string[] args)
    {
      if (args?.Length != 1)
      {
        Console.WriteLine("No EnvKey set!");
        return 1;
      }

      string envKeyToTest = args[0];

      var envKey = new EnvKeyConfig(new EnvKeyOptions());
      var canRead = envKey.TryReadRaw(envKeyToTest, out var config);
      Console.WriteLine("Can read as raw? " + canRead);
      Console.WriteLine("Config: " + config);

      canRead = envKey.TryRead(envKeyToTest, out var configDir);
      Console.WriteLine("Can read as json? " + canRead);
      Console.WriteLine("Config Count: " + configDir.Count);

      return 0;
    }
  }
}
