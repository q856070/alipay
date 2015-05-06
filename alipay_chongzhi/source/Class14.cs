using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
internal class Class14
{
	private static int int_0;
	[DllImport("wininet.dll", SetLastError = true)]
	public static extern bool InternetGetCookie(string string_0, string string_1, StringBuilder stringBuilder_0, ref int int_1);
	[DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern bool InternetSetCookie(string string_0, string string_1, string string_2);
	[DllImport("kernel32.dll", SetLastError = true)]
	internal static extern int GetLastError();
	[DllImport("kernel32.dll")]
	private static extern int FormatMessage(uint uint_0, IntPtr intptr_0, uint uint_1, uint uint_2, [Out] StringBuilder stringBuilder_0, uint uint_3, IntPtr intptr_1);
	[DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern bool InternetGetCookieEx(string string_0, string string_1, StringBuilder stringBuilder_0, ref int int_1, int int_2, IntPtr intptr_0);
	[DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern int InternetSetCookieEx(string string_0, string string_1, string string_2, int int_1, IntPtr intptr_0);
	public static void smethod_0(string string_0)
	{
		new StringBuilder();
		Uri uri = new Uri(string_0);
		string text = Class14.smethod_1(string_0);
		string[] array = text.Split(new char[]
		{
			';'
		});
		string text2 = uri.Host.Split(new char[]
		{
			'.'
		})[0];
		string[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			string text3 = array2[i];
			string[] array3 = text3.Split(new char[]
			{
				'='
			});
			if (array3.Length >= 2)
			{
				string text4 = array3[0].Trim();
				array3[1].Trim();
				Class14.InternetSetCookieEx(string_0, null, text4 + "=null;path=/;expires=Thu, 01-Jan-1970 00:00:01 GMT; domain=" + uri.Host.Replace(text2, ""), Class14.int_0, IntPtr.Zero);
				Class14.InternetSetCookieEx(string_0, null, text4 + "=null;path=/;expires=Thu, 01-Jan-1970 00:00:01 GMT; domain=" + uri.Host.Replace(text2 + ".", ""), Class14.int_0, IntPtr.Zero);
				Class14.InternetSetCookieEx(string_0, null, text4 + "=null;path=/;expires=Thu, 01-Jan-1970 00:00:01 GMT; domain=" + uri.Host, Class14.int_0, IntPtr.Zero);
				Class14.InternetSetCookieEx(string_0, text4, "=null;path=/; expires=Sun,22-Feb-1970 00:00:00 GMT", Class14.int_0, IntPtr.Zero);
				Class14.InternetSetCookie(string_0, null, text4 + "=null;path=/;expires=Thu, 01-Jan-1970 00:00:01 GMT; domain=" + uri.Host.Replace(text2, ""));
				Class14.InternetSetCookie(string_0, null, text4 + "=null;path=/;expires=Thu, 01-Jan-1970 00:00:01 GMT; domain=" + uri.Host.Replace(text2 + ".", ""));
				Class14.InternetSetCookie(string_0, null, text4 + "=null;path=/;expires=Thu, 01-Jan-1970 00:00:01 GMT; domain=" + uri.Host);
				Class14.InternetSetCookie(string_0, text4, "=null;path=/; expires=Sun,22-Feb-1970 00:00:00 GMT");
			}
		}
	}
	public static string smethod_1(string string_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int capacity = 0;
		Class14.InternetGetCookieEx(string_0, null, stringBuilder, ref capacity, Class14.int_0, IntPtr.Zero);
		new StringBuilder(260);
		int lastError = Class14.GetLastError();
		if (lastError == 122)
		{
			stringBuilder = new StringBuilder(capacity);
			Class14.InternetGetCookieEx(string_0, null, stringBuilder, ref capacity, Class14.int_0, IntPtr.Zero);
		}
		return stringBuilder.ToString();
	}
	public static void smethod_2(string string_0, string string_1)
	{
		string[] array = string_1.ToString().Split(new char[]
		{
			';'
		});
		Uri uri = new Uri(string_0);
		string arg_3A_0 = uri.Host.Split(new char[]
		{
			'.'
		})[0];
		string[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			string text = array2[i];
			string[] array3 = text.Split(new char[]
			{
				'='
			});
			if (array3.Length >= 2)
			{
				string string_2 = array3[0].Trim();
				string str = array3[1].Trim();
				Class14.InternetSetCookie(string_0, string_2, "=" + str + ";path=/; expires=Sun,22-Feb-2070 00:00:00 GMT");
			}
		}
	}
	public static void smethod_3(string string_0, CookieContainer cookieContainer_0)
	{
		Uri uri = new Uri(string_0);
		CookieCollection cookies = cookieContainer_0.GetCookies(uri);
		foreach (Cookie cookie in cookies)
		{
			Class14.InternetSetCookie(string_0, cookie.Name, "=" + cookie.Value + ";path=/; expires=Sun,22-Feb-2070 00:00:00 GMT");
		}
	}
	public Class14()
	{
		Class16.cwDXy7Qz9AoPt();
		
	}
	static Class14()
	{
		Class16.cwDXy7Qz9AoPt();
		Class14.int_0 = 8192;
	}
}
