using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using Microsoft.Win32;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Security;

namespace GameServer
{
	// Token: 0x02000023 RID: 35
	public class SoftwareVerfication
	{
		// Token: 0x06000083 RID: 131 RVA: 0x00011D54 File Offset: 0x0000FF54
		public static void 注册验证()
		{
			try
			{
				SoftwareVerfication.错误提示 = null;
				SoftwareVerfication.系统标识 = null;
				if (!SoftwareVerfication.读注册表(out SoftwareVerfication.系统标识))
				{
					SoftwareVerfication.错误提示 = SoftwareVerfication.数据解密("CU8YA0nFb//A1jyoeVmNspR+j+e37F0rnbxCA5XXyuoawzqYFv9B80YFdaAyCtQ1FtW76LtWuKTTFL6XgY7/UaBWUmcSKJAFZNXmnEyPF5cV9tG84bmp7clv87Nq5QSn5fR0tqh4BRdKPn6L3kinBGaOUw6agJOVxL5m9yavmSkU2uUGxojE2/MRd7J0Q/ab4zbasqtJIVAZTvAUuFw1o9IAKHA+GADv3QWxJTU7mlV0qtyHqtjb9IZ7yT0cyYOqHxShHQJhHPUCKB0qhJaYqUuTLMcQ8EwtQvGL1dNNoASuc7kcal5AuNta5rDkp7pkSboMVXqdapB9tPFwtAT7ZQ==");
				}
				else
				{
					string[] array = SoftwareVerfication.数据解密(CustomClass.软件注册代码.Trim()).Split(new char[]
					{
						'/'
					});
					SmtpClient smtpClient = new SmtpClient("smtp.office365.com", 587);
					smtpClient.Credentials = new NetworkCredential(array[0], array[1]);
					smtpClient.EnableSsl = true;
					MailAddress from = new MailAddress(array[0]);
					MailAddress to = new MailAddress(array[2]);
					MailMessage message = new MailMessage(from, to)
					{
						Body = CustomClass.软件注册代码,
						Subject = "SoftwareVerfication:" + SoftwareVerfication.系统标识,
						BodyEncoding = Encoding.UTF8
					};
					smtpClient.Send(message);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				SoftwareVerfication.错误提示 = SoftwareVerfication.数据解密("hzHzukJZQRWEs2nSs8tR5fGOK7Q4lyqRmlaNmmw3abGDCHIaYkKcG/gBZy/N4o2gX9A78TRuYNKI/OAk/FVwQlMQx9vc+6JqUv4kldqCHXJdQEj1EjXSmB6kep6Tiq0adBjyLlGpmTuDNuM3GG4JuZ/CtEEWAOYiaeceh4Y4YT+716BybUy7uVfvE0lx8sl95jOgaEjPOlzG4zhJqe1WqKN7tV4Wvo9V4ltCZkxxQVXwY7IPVNtZ6RR7i+bkEh6ht7lt5v0szXFFGnn3QJMFSP2P3Y1Z8iwUlJ3RfOFXUl/BFYcMHBSWkGKBV5QY6eMrGblXKqpfeCZFXtXGnOp8Jw==");
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00011E4C File Offset: 0x0001004C
		public static bool 读注册表(out string 内容)
		{
			内容 = null;
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Registration");
			if (registryKey != null)
			{
				string text;
				内容 = (text = (string)registryKey.GetValue("ProductId", null));
				return text != null;
			}
			return false;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00011E8C File Offset: 0x0001008C
		public static string 数据解密(string 密文)
		{
			string result;
			try
			{
				密文 = 密文.Replace("\r", "").Replace("\n", "").Replace(" ", "");
				Pkcs1Encoding pkcs1Encoding = new Pkcs1Encoding(new RsaEngine());
				pkcs1Encoding.Init(false, SoftwareVerfication.获取公钥("MIIBIDANBgkqhkiG9w0BAQEFAAOCAQ0AMIIBCAKCAQEAsMIB/gekqRr1R6lnMv34UEyeZdpzg0s51uYrBkr7mhApVzcIrYyFi7VOS8HeVpo1BomNVrK8dhVCjKuz4VttWuV3GPQGsDeyrOP6H3Sej7jR3HH0Z3wzt3cH16kFl+RKR8hmUawHVacicqdDVSpMbIbG8W/nuGjHq1IuS10x8B/YHvCI7xG3qD8jkc0Wick7iSWNWsYFHxzBQy0yRGEK4wPqsMnNDQu3KKeC6LopYMDDXZzwl9Kro+7hgwFwhg84ccxLBzVlRZKe9jNA3IsOqajdLXiZN/swJPZzmkgiI3aN/uU643CsSX6pIUs8jS7egKZQqDQQCGKFkIVAtpGY5wIBAw=="));
				byte[] array = Convert.FromBase64String(密文);
				byte[] bytes = pkcs1Encoding.ProcessBlock(array, 0, array.Length);
				result = Encoding.UTF8.GetString(bytes);
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			return result;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00002AD8 File Offset: 0x00000CD8
		private static AsymmetricKeyParameter 获取公钥(string 密文)
		{
			密文 = 密文.Replace("\r", "").Replace("\n", "").Replace(" ", "");
			return PublicKeyFactory.CreateKey(Convert.FromBase64String(密文));
		}

		// Token: 0x06000087 RID: 135 RVA: 0x000027D8 File Offset: 0x000009D8
		public SoftwareVerfication()
		{
			
			
		}

		// Token: 0x04000049 RID: 73
		public static string 错误提示;

		// Token: 0x0400004A RID: 74
		public static string 系统标识;
	}
}
