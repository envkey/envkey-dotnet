using System.Collections.Generic;

namespace EnvKey
{
  public interface IEnvKeyConfig
  {
    bool TryRead(string envKey, out Dictionary<string, string> config);

    bool TryReadRaw(string envKey, out string config);
  }
}
