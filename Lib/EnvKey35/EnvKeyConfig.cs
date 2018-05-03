using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

    internal string InnerLoadRaw()
    {
      var fullEnvKeyExePath = options.GetEnvKeyExecutable();

      if (!File.Exists(fullEnvKeyExePath))
      {
        throw new FileNotFoundException("EnvKey executable was not found.", fullEnvKeyExePath);
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
      var successfulExit = process.WaitForExit((int)TimeSpan.FromSeconds(5).TotalMilliseconds);

      if (!successfulExit)
      {
        throw new InvalidOperationException("EnvKey process timed out.");
      }

      if (!output.StartsWith("{"))
      {
        throw new InvalidOperationException($"EnvKey returned a non-config object: '{output}'.");
      }

      return output;
    }

    internal Dictionary<string, string> InnerLoad()
    {
      var config = InnerLoadRaw();
      var dict = JsonDeserializer.Deserialize<Dictionary<string, string>>(config);

      return dict;
    }

    /// <inheritdoc />
    public void Load()
    {
      try
      {
        var config = InnerLoad();
        PatchEnvironmentVariables(config);
      }
      catch (Exception ex)
      {
        throw new InvalidOperationException("An error occurred while fetching EnvKey configuration.", ex);
      }
    }

    internal static void PatchEnvironmentVariables(Dictionary<string, string> config)
    {
      var existingKeys = Environment.GetEnvironmentVariables().Keys.Cast<object>().Select(k => k.ToString().ToUpper()).ToArray();

      foreach (var kvp in config)
      {
        if (existingKeys.Contains(kvp.Key.ToUpper()))
          continue;

        Environment.SetEnvironmentVariable(kvp.Key, kvp.Value, EnvironmentVariableTarget.Process);
      }
    }
  }
}
