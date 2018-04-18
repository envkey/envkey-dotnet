using System.Collections.Generic;

namespace EnvKey
{
  public interface IEnvKeyConfig
  {
    bool TryRead(out Dictionary<string, string> config);

    bool TryReadRaw(out string config);

    bool TryLoadIntoEnvironment();
  }
}
