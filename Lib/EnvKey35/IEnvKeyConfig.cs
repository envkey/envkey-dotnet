using System.Collections.Generic;

namespace EnvKey
{
  /// <summary>
  /// The EnvKey interface.
  /// </summary>
  public interface IEnvKeyConfig
  {
    /// <summary>
    /// Try loading the configuration as dictionary.
    /// </summary>
    bool TryLoad(out Dictionary<string, string> config);

    /// <summary>
    /// Try loading the configuration and returning it as it was downloaded.
    /// </summary>
    bool TryLoadRaw(out string config);

    /// <summary>
    /// Try loading the configuration and put it into the process environment variables.
    /// </summary>
    /// <returns></returns>
    bool TryLoadIntoEnvironment();
  }
}
