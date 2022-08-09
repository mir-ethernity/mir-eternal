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
				text += AccountData.RandomChars[AccountData.Random.Next(AccountData.RandomChars.Length)].ToString();
			}
			return text;
		}		
		public AccountData(string account, string password, string securityQuestion, string securityAnswer)
		{
			this.Account = account;
			this.Password = password;
			this.Question = securityQuestion;
			this.Answer = securityAnswer;
			this.CreatedDate = DateTime.Now;
		}		

		private static Random Random = new Random();		

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
		
		public string Account;		
		public string Password;		
		public string Question;		
		public string Answer;
		
		public DateTime CreatedDate;
	}
}
