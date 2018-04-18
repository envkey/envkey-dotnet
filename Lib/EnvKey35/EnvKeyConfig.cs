using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace EnvKey
{
  public class EnvKeyConfig : IEnvKeyConfig
  {
    private readonly EnvKeyOptions options;

    public EnvKeyConfig() : this(new EnvKeyOptions())
    {
    }

    public EnvKeyConfig(EnvKeyOptions options)
    {
      this.options = options;
    }

    public bool TryRead(out Dictionary<string, string> config)
    {
      if (!TryReadRaw(out var rawConfig))
      {
        config = null;

        return false;
      }

      config = JsonDeserializer.Deserialize<Dictionary<string, string>>(rawConfig);

      return true;
    }

    public bool TryReadRaw(out string config)
    {
      var fullEnvKeyExePath = options.GetEnvKeyExecutable();

      if (!File.Exists(fullEnvKeyExePath))
      {
        config = null;

        return false;
      }

      var envKey = options.EnvKey;

      var useCaching = options.UseCaching()
        ? "--cache"
        : "";

      const string clientName = "--client-name envkey-dotnet";

      var arguments = $"{envKey} {useCaching} {clientName}";
      var process = new Process
      {
        StartInfo = new ProcessStartInfo(fullEnvKeyExePath, arguments)
        {
          UseShellExecute = false,
          WindowStyle = ProcessWindowStyle.Hidden,
          RedirectStandardOutput = true
        }
      };

      process.Start();

      var output = process.StandardOutput.ReadToEnd();
      var successfulExit = process.WaitForExit((int)TimeSpan.FromSeconds(3).TotalMilliseconds);

      if (!successfulExit)
      {
        config = null;

        return false;
      }

      config = output;

      return true;
    }

    public bool TryLoadIntoEnvironment()
    {
      if (!TryRead(out var config))
      {
        return false;
      }

      foreach (var kvp in config)
      {
        Environment.SetEnvironmentVariable(kvp.Key, kvp.Value, EnvironmentVariableTarget.Process);
      }

      return true;
    }
  }
}
