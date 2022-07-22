using System.Runtime.CompilerServices;

namespace Launcher
{
  [CompilerGenerated]
  internal sealed class PrivateImplementationDetails
  {
    internal static uint ComputeStringHash(string s)
    {
      uint stringHash = 0;
      if (s != null)
      {
        stringHash = 2166136261U;
        for (int index = 0; index < s.Length; ++index)
          stringHash = (uint) (((int) s[index] ^ (int) stringHash) * 16777619);
      }
      return stringHash;
    }
  }
}
