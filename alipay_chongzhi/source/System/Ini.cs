using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
namespace System
{
	public class Ini
	{
		private string string_0;
		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string string_1, string string_2, string string_3, string string_4);
		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string string_1, string string_2, string string_3, byte[] byte_0, int int_0, string string_4);
		public Ini(string path)
		{
			Class16.cwDXy7Qz9AoPt();
			this.string_0 = null;
			
			this.string_0 = path;
		}
		public void WriteValue(string section, string key, string value)
		{
			Ini.WritePrivateProfileString(section, key, value, this.string_0);
		}
		public string ReadValue(string section, string key)
		{
			byte[] array = new byte[20480];
			int privateProfileString = Ini.GetPrivateProfileString(section, key, "", array, 20480, this.string_0);
			return Encoding.Default.GetString(array, 0, privateProfileString);
		}
		public string[] ReadSections()
		{
			string string_ = this.string_0;
			List<string> list = new List<string>();
			byte[] array = new byte[65536];
			int privateProfileString = Ini.GetPrivateProfileString(null, null, null, array, array.Length, string_);
			int num = 0;
			for (int i = 0; i < privateProfileString; i++)
			{
				if (array[i] == 0)
				{
					list.Add(Encoding.Default.GetString(array, num, i - num));
					num = i + 1;
				}
			}
			return list.ToArray();
		}
		public string[] ReadSingleSection(string Section)
		{
			string string_ = this.string_0;
			List<string> list = new List<string>();
			byte[] array = new byte[65536];
			int privateProfileString = Ini.GetPrivateProfileString(Section, null, null, array, array.Length, string_);
			int num = 0;
			for (int i = 0; i < privateProfileString; i++)
			{
				if (array[i] == 0)
				{
					list.Add(Encoding.Default.GetString(array, num, i - num));
					num = i + 1;
				}
			}
			return list.ToArray();
		}
	}
}
