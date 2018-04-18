using System.IO;

namespace EnvKey
{
  public class EnvKeyOptions
  {
    public string EnvKeyPath { get; set; }

    internal string GetEnvKeyExecutable()
    {
      if (EnvKeyPath != null)
      {
        return EnvKeyPath;
      }

      var currentWorkingDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) 
                                 ?? Directory.GetCurrentDirectory();

      const string envKeyExe = "envkey-fetch.exe";

      var fullEnvKeyExePath = Path.Combine(currentWorkingDirectory, envKeyExe);

      return fullEnvKeyExePath;
    }
  }
}