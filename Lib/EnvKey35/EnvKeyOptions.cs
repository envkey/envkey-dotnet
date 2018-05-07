using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace EnvKey
{
  /// <summary>
  /// Options for the functionality of EnvKey.
  /// </summary>
  public class EnvKeyOptions
  {
    /// <summary>
    /// Overrides the environment key to use.
    /// Default is the "ENVKEY" environment variable.
    /// </summary>
    public string EnvKey { get; set; } = Environment.GetEnvironmentVariable("ENVKEY");

    /// <summary>
    /// The path to the envkey-fetch.exe file.
    /// Default path is the executing assembly path + "envkey-fetch.exe".
    /// </summary>
    public string EnvKeyPath { get; set; }

    /// <summary>
    /// Defines if the caching option should be used.
    /// Default true when in DEBUG mode, otherwise false.
    /// </summary>
    public bool? UseCache { get; set; }

    internal string GetEnvKeyExecutable()
    {
      if (EnvKeyPath != null)
      {
        return EnvKeyPath;
      }

      var searchPath = getEntryAssemblyLocation()
                    ?? getCurrentDirectoryLocation();

      if (searchPath == null)
      {
        Trace.WriteLine("Can't determine the executable path of envkey-fetch.");
        return null;
      }

      const string envKeyExe = "envkey-fetch.exe";

      var fullEnvKeyExePath = Path.Combine(searchPath, envKeyExe);
      Trace.WriteLine($"Using '{fullEnvKeyExePath}' as envkey executable.");

      return fullEnvKeyExePath;
    }

    private static string getEntryAssemblyLocation()
    {
      var assembly = Assembly.GetEntryAssembly();

      return assembly == null
        ? null
        : Path.GetDirectoryName(assembly.Location);
    }

    private static string getCurrentDirectoryLocation()
    {
      return Directory.GetCurrentDirectory();
    }

    internal bool UseCaching()
    {
      if (UseCache.HasValue)
      {
        return UseCache.Value;
      }

#if DEBUG
      return true;
#else
      return false;
#endif
    }
  }
}
