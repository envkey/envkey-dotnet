using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace EnvKey
{
  public class EnvKeyConfig
  {
    private readonly EnvKeyOptions options;

    public EnvKeyConfig(EnvKeyOptions options)
    {
      this.options = options;
    }

    public bool TryRead(string envKey, out Dictionary<string, string> config)
    {
      if (!TryReadRaw(envKey, out var rawConfig))
      {
        config = null;

        return false;
      }

      config = JsonDeserializer.Deserialize<Dictionary<string, string>>(rawConfig);

      return true;
    }

    public bool TryReadRaw(string envKey, out string config)
    {
      var fullEnvKeyExePath = options.GetEnvKeyExecutable();

      if (!File.Exists(fullEnvKeyExePath))
      {
        config = null;

        return false;
      }

      var process = new Process
      {
        StartInfo = new ProcessStartInfo(fullEnvKeyExePath, envKey)
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
  }
}
