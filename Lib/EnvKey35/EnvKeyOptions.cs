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
    public string EnvKey { get; set; } = Environment.GetEnvironmentVariable("ENVKEY", EnvironmentVariableTarget.Process);

    /// <summary>
    /// The path to the envkey-source.exe file.
    /// Default path is the executing assembly path + "envkey-source.exe".
    /// </summary>
    public string EnvKeyPath { get; set; }

    /// <summary>
    /// Defines if the caching option should be used.
    /// Default true when in DEBUG mode, otherwise false.
    /// </summary>
    public bool? UseCache { get; set; }

    /// <summary>
    /// Timeout in seconds for http requests.
    /// Default 15.
    /// </summary>
    public int Timeout { get; set; } = 15;

    /// <summary>
    /// Number of times to retry requests on failure.
    /// Default 3.
    /// </summary>
    public int Retries { get; set; } = 3;

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
        Trace.WriteLine("Can't determine the executable path of envkey-source.");
        return null;
      }

      string envKeyExecutable;
      switch (GetOsPlatform())
      {
        case OsPlatformType.Windows:
          envKeyExecutable = "envkey-source_win64.exe";
          break;
        case OsPlatformType.Linux:
          envKeyExecutable = "envkey-source_linux64";
          break;
        case OsPlatformType.Osx:
          envKeyExecutable = "envkey-source_darwin64";
          break;
        default:

          throw new ArgumentOutOfRangeException();
      }

      var fullEnvKeyExePath = Path.Combine(searchPath, envKeyExecutable);
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

    /// <summary>
    /// Get the current os platform.
    /// </summary>
    public static OsPlatformType GetOsPlatform()
    {
#if !NET35
      //https://github.com/dotnet/runtime/issues/21660#issuecomment-633628590
      // For compatibility reasons with Mono, PlatformID.Unix is returned on MacOSX. PlatformID.MacOSX
      // is hidden from the editor and shouldn't be used.
      if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.OSX))
      {
        return OsPlatformType.Osx;
      }
#endif

      OperatingSystem os = Environment.OSVersion;
      PlatformID pid = os.Platform;
      switch (pid)
      {
        case PlatformID.Win32NT:
        case PlatformID.Win32S:
        case PlatformID.Win32Windows:
        case PlatformID.WinCE:

          return OsPlatformType.Windows;
        case PlatformID.Unix:
          
          return OsPlatformType.Linux;
          
        default:

          throw new PlatformNotSupportedException($"'{pid} is not supported.");
      }
    }
  }
}
