using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GameServer
{
	[CompilerGenerated]
	internal sealed class PrivateImplementationDetails
	{
		// Token: 0x06000C71 RID: 3185 RVA: 0x0002C110 File Offset: 0x0002A310
		internal static uint ComputeStringHash(string s)
		{
			uint num = 0;
			if (s != null)
			{
				num = 2166136261U;
				for (int i = 0; i < s.Length; i++)
				{
					num = ((uint)s[i] ^ num) * 16777619U;
				}
			}
			return num;
		}
	}
}
