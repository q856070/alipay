using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
internal class Class7
{
	public static void smethod_0(CookieContainer cookieContainer_0)
	{
		Type typeFromHandle = typeof(CookieContainer);
		Hashtable hashtable = (Hashtable)typeFromHandle.InvokeMember("m_domainTable", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField, null, cookieContainer_0, new object[0]);
		ArrayList arrayList = new ArrayList(hashtable.Keys);
		foreach (Cookie current in Class7.smethod_3(cookieContainer_0))
		{
			if (Regex.IsMatch(current.Domain, "^\\w+.\\w+$"))
			{
				current.Domain = "." + current.Domain;
				cookieContainer_0.Add(current);
			}
		}
		foreach (string text in arrayList)
		{
			string text2 = text;
			if (text2[0] == '.')
			{
				string key = text2.Remove(0, 1);
				hashtable[key] = hashtable[text];
			}
		}
	}
	public static CookieContainer smethod_1(string string_0)
	{
		CookieContainer cookieContainer = new CookieContainer();
		cookieContainer.PerDomainCapacity = 100;
		string[] array = Encoding.UTF8.GetString(Convert.FromBase64String(string_0)).Split(new string[]
		{
			"\r\n"
		}, 100, StringSplitOptions.RemoveEmptyEntries);
		CookieCollection cookieCollection = new CookieCollection();
		string[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			string text = array2[i];
			string[] array3 = text.Split(new string[]
			{
				"|,|"
			}, StringSplitOptions.RemoveEmptyEntries);
			if (array3.Length >= 5)
			{
				Cookie cookie = new Cookie();
				cookie.Name = array3[0];
				cookie.Value = array3[1];
				if (array3[2] != "0")
				{
					cookie.Expires = new DateTime(Convert.ToInt64(array3[2]));
				}
				cookie.TimeStamp.AddDays(30.0);
				cookie.Expires = DateTime.Now.AddDays(31.0);
				if (Regex.IsMatch(array3[3], "^\\w+.\\w+$"))
				{
					array3[3] = "." + array3[3].Trim();
				}
				cookie.Domain = array3[3].Trim();
				cookie.Path = array3[4];
				cookieCollection.Add(cookie);
			}
		}
		cookieContainer.Add(cookieCollection);
		Class7.smethod_0(cookieContainer);
		return cookieContainer;
	}
	public static string smethod_2(CookieContainer cookieContainer_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		List<Cookie> list = Class7.smethod_3(cookieContainer_0);
		foreach (Cookie current in list)
		{
			stringBuilder.AppendFormat("{0}|,|{1}|,|{2}|,|{3}|,|{4}\r\n", new object[]
			{
				current.Name,
				current.Value,
				current.Expires.Ticks,
				current.Domain,
				current.Path
			});
		}
		return Convert.ToBase64String(Encoding.UTF8.GetBytes(stringBuilder.ToString()));
	}
	public static List<Cookie> smethod_3(CookieContainer cookieContainer_0)
	{
		List<Cookie> list = new List<Cookie>();
		Hashtable hashtable = (Hashtable)cookieContainer_0.GetType().InvokeMember("m_domainTable", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField, null, cookieContainer_0, new object[0]);
		foreach (object current in hashtable.Values)
		{
			SortedList sortedList = (SortedList)current.GetType().InvokeMember("m_list", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField, null, current, new object[0]);
			foreach (CookieCollection cookieCollection in sortedList.Values)
			{
				foreach (Cookie item in cookieCollection)
				{
					if (!list.Contains(item))
					{
						list.Add(item);
					}
				}
			}
		}
		return list;
	}
	public static CookieContainer smethod_4(string string_0, string string_1)
	{
		CookieContainer cookieContainer = new CookieContainer();
		cookieContainer.PerDomainCapacity = 100;
		string[] array = string_1.ToString().Split(new char[]
		{
			';'
		});
		Uri uri = new Uri(string_0);
		try
		{
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
					Cookie cookie = new Cookie();
					cookie.Name = array3[0].Trim();
					string text2 = array3[1].Trim();
					for (int j = 2; j < array3.Length; j++)
					{
						text2 = text2 + "=" + array3[j].Trim();
					}
					text2 = text2.Replace(",", "%2C");
					cookie.Value = text2;
					cookie.Expires = DateTime.Now + new TimeSpan(24, 1, 1);
					string oldValue = uri.Host.Split(new char[]
					{
						'.'
					})[0];
					cookie.Domain = uri.Host.Replace(oldValue, "");
					cookie.Path = "/";
					Class7.smethod_0(cookieContainer);
					cookieContainer.Add(cookie);
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
		return cookieContainer;
	}
	public Class7()
	{
		Class16.cwDXy7Qz9AoPt();
		
	}
}
