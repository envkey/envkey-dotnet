using System.Collections.Generic;

namespace EnvKey
{
  /// <summary>
  /// Extensions to EnvKeyConfig
  /// </summary>
  public static class EnvKeyConfigExtensions
  {
    /// <summary>
    /// Try loading the configuration and returning it as it was downloaded.
    /// </summary>
    public static bool TryLoadRaw(this EnvKeyConfig self, out string config)
    {
      try
      {
        config = self.InnerLoadRaw();

        return true;
      }
      catch
      {
        config = null;

        return false;
      }
    }

    /// <summary>
    /// Try loading the configuration as dictionary.
    /// </summary>
    public static bool TryLoad(this EnvKeyConfig self, out Dictionary<string, string> config)
    {
      try
      {
        config = self.InnerLoad();

        return true;
      }
      catch
      {
        config = null;

        return false;
      }
    }

    /// <summary>
    /// Try loading the configuration and adds missing items to the environment variables of the current process.
    /// </summary>
    public static bool TryLoadIntoEnvironment(this EnvKeyConfig self)
    {
      return TryLoadIntoEnvironment(self, false);
    }

    /// <summary>
    /// Try loading the configuration and adds it to the environment variables of the current process.
    /// </summary>
    /// <param name="self"></param>
    /// <param name="forceUpdate">Defines if existing environment variables should be updated.</param>
    public static bool TryLoadIntoEnvironment(this EnvKeyConfig self, bool forceUpdate)
    {
      if (!self.TryLoad(out var config))
      {
        return false;
      }

      EnvKeyConfig.PatchEnvironmentVariables(config, forceUpdate);

      return true;
    }
  }
}