using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace EnvKey
{
  /// <inheritdoc />
  public class EnvKeyConfig : IEnvKeyConfig
  {
    private readonly EnvKeyOptions options;

    /// <inheritdoc />
    public EnvKeyConfig() : this(new EnvKeyOptions())
    {
    }

    /// <inheritdoc />
    public EnvKeyConfig(EnvKeyOptions options)
    {
      this.options = options;
    }

    /// <inheritdoc />
    public bool TryLoad(out Dictionary<string, string> config)
    {
      if (!TryLoadRaw(out var rawConfig))
      {
        config = null;

        return false;
      }

      config = JsonDeserializer.Deserialize<Dictionary<string, string>>(rawConfig);

      return true;
    }

    /// <inheritdoc />
    public bool TryLoadRaw(out string config)
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
          RedirectStandardOutput = true,
          RedirectStandardError = true,
          StandardErrorEncoding = Encoding.UTF8,
          StandardOutputEncoding = Encoding.UTF8
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

    /// <inheritdoc />
    public bool TryLoadIntoEnvironment()
    {
      if (!TryLoad(out var config))
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
