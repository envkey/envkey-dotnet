using System;

namespace EnvKey
{
  /// <summary>
  /// The EnvKey interface.
  /// </summary>
  public interface IEnvKeyConfig
  {
    /// <summary>
    /// Loads the configuration and adds missing items to the environment variables of the current process.
    /// </summary>
    /// <exception cref="InvalidOperationException">In case of any error. See inner exception for more details.</exception>
    void Load();
  }
}
