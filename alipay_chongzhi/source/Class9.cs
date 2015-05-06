using System;
using System.Security.Cryptography;
using System.Text;
internal class Class9
{
	public static string smethod_0(string string_0)
	{
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		byte[] array = mD5CryptoServiceProvider.ComputeHash(Encoding.Default.GetBytes(string_0));
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString("x2"));
		}
		return stringBuilder.ToString();
	}
	public static string smethod_1(string string_0, string string_1)
	{
		string text = Class9.smethod_0(DateTime.Now.Ticks.ToString()).Substring(0, 8);
		string_1 = Class9.smethod_0(string_1 + text);
		byte[] bytes = Encoding.UTF8.GetBytes(string_0);
		for (int i = 0; i < bytes.Length; i++)
		{
			bytes[i] = (byte)((char)bytes[i] ^ string_1[i % string_1.Length]);
		}
		string text2 = text + Convert.ToBase64String(bytes);
		return Class9.smethod_0(text2).Substring(0, 8) + text2;
	}
	public static string smethod_2(string string_0, string string_1)
	{
		string result;
		try
		{
			if (string_0.Length <= 8)
			{
				result = null;
			}
			else
			{
				string a = string_0.Substring(0, 8);
				string_0 = string_0.Substring(8, string_0.Length - 8);
				if (a != Class9.smethod_0(string_0).Substring(0, 8))
				{
					result = null;
				}
				else
				{
					if (string_0.Length <= 8)
					{
						result = null;
					}
					else
					{
						string str = string_0.Substring(0, 8);
						string_1 = Class9.smethod_0(string_1 + str);
						string_0 = string_0.Substring(8, string_0.Length - 8);
						byte[] array = Convert.FromBase64String(string_0);
						for (int i = 0; i < array.Length; i++)
						{
							array[i] = (byte)((char)array[i] ^ string_1[i % string_1.Length]);
						}
						string @string = Encoding.UTF8.GetString(array);
						result = @string;
					}
				}
			}
		}
		catch
		{
			result = null;
		}
		return result;
	}
	public Class9()
	{
		Class16.cwDXy7Qz9AoPt();
		
	}
}
