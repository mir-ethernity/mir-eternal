using System;

namespace AccountServer
{
	
	public sealed class AccountData
	{
		
		public static string GenerateTickets()
		{
			string text = "ULS21-";
			for (int i = 0; i < 32; i++)
			{
				text += AccountData.RandomChars[AccountData.随机数.Next(AccountData.RandomChars.Length)].ToString();
			}
			return text;
		}

		
		public AccountData(string 账号, string 密码, string 问题, string 答案)
		{
			this.账号名字 = 账号;
			this.Password = 密码;
			this.Question = 问题;
			this.Answer = 答案;
			this.创建日期 = DateTime.Now;
		}

		
		private static Random 随机数 = new Random();

		
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

		
		public string 账号名字;

		
		public string Password;

		
		public string Question;

		
		public string Answer;

		
		public DateTime 创建日期;
	}
}
