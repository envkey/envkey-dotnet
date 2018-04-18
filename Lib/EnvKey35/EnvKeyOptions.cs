using System;
using System.IO;
using System.Reflection;

namespace EnvKey
{
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

      var currentWorkingDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)
                                 ?? Directory.GetCurrentDirectory();

      const string envKeyExe = "envkey-fetch.exe";

      var fullEnvKeyExePath = Path.Combine(currentWorkingDirectory, envKeyExe);

      return fullEnvKeyExePath;
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
