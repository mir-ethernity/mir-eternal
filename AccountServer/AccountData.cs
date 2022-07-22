using System;

namespace AccountServer
{
	// Token: 0x02000006 RID: 6
	public sealed class AccountData
	{
		// Token: 0x06000020 RID: 32 RVA: 0x000038E8 File Offset: 0x00001AE8
		public static string GenerateTickets()
		{
			string text = "ULS21-";
			for (int i = 0; i < 32; i++)
			{
				text += AccountData.RandomChars[AccountData.随机数.Next(AccountData.RandomChars.Length)].ToString();
			}
			return text;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00003930 File Offset: 0x00001B30
		public AccountData(string 账号, string 密码, string 问题, string 答案)
		{
			this.账号名字 = 账号;
			this.Password = 密码;
			this.Question = 问题;
			this.Answer = 答案;
			this.创建日期 = DateTime.Now;
		}

		// Token: 0x04000025 RID: 37
		private static Random 随机数 = new Random();

		// Token: 0x04000026 RID: 38
		private static char[] RandomChars = new char[]
		{
			'0',
			'1',
			'2',
			'3',
			'4',
			'5',
			'6',
			'7',
			'8',
			'9',
			'A',
			'B',
			'C',
			'D',
			'E',
			'F',
			'G',
			'H',
			'I',
			'J',
			'K',
			'L',
			'M',
			'N',
			'O',
			'P',
			'Q',
			'R',
			'S',
			'T',
			'U',
			'V',
			'W',
			'X',
			'Y',
			'Z',
			'a',
			'b',
			'c',
			'd',
			'e',
			'f',
			'g',
			'h',
			'i',
			'j',
			'k',
			'l',
			'm',
			'n',
			'o',
			'p',
			'q',
			'r',
			's',
			't',
			'u',
			'v',
			'w',
			'x',
			'y',
			'z'
		};

		// Token: 0x04000027 RID: 39
		public string 账号名字;

		// Token: 0x04000028 RID: 40
		public string Password;

		// Token: 0x04000029 RID: 41
		public string Question;

		// Token: 0x0400002A RID: 42
		public string Answer;

		// Token: 0x0400002B RID: 43
		public DateTime 创建日期;
	}
}
