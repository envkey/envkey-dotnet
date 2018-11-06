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

      var success = envKey.TryLoadRaw(out var config);
      Console.WriteLine($"Can load as raw? {success}");
      if (success)
      {
        Console.WriteLine($"Config: {config.Trim()}");
      }

      success = envKey.TryLoad(out var configDir);
      Console.WriteLine($"Can load as json? {success}");
      if (success)
      {
        Console.WriteLine($"Config Count: {configDir.Count}");
        foreach (var kvp in configDir)
        {
          Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
      }

      var countBefore = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process).Count;
      success = envKey.TryLoadIntoEnvironment();
      Console.WriteLine($"Can load into environment variables? {success}");
      if (success)
      {
        var countAfter = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process).Count;
        Console.WriteLine($"Process EnvVars changed? {(countAfter - countBefore) > 0}");
      }

      return 0;
    }
  }
}
