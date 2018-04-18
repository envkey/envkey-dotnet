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

      var envKeyToTest = args[0];

      var options = new EnvKeyOptions
      {
        EnvKey = envKeyToTest,
        UseCache = false
      };
      var envKey = new EnvKeyConfig(options);

      var success = envKey.TryReadRaw(out var config);
      Console.WriteLine($"Can read as raw? {success}");
      Console.WriteLine($"Config: {config.Trim()}");

      success = envKey.TryRead(out var configDir);
      Console.WriteLine($"Can read as json? {success}");
      Console.WriteLine($"Config Count: {configDir.Count}");

      var countBefore = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process).Count;
      success = envKey.TryLoadIntoEnvironment();
      var countAfter = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process).Count;
      Console.WriteLine($"Can load into environment variables? {success}");
      Console.WriteLine($"Process EnvVars changed? {(countAfter - countBefore) > 0}");

      return 0;
    }
  }
}
