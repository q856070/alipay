using System;
using System.IO;
using System.IO.Compression;
using System.Management;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
internal class Class10
{
	public enum Enum2
	{

	}
	public struct Struct3
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
		public byte[] byte_0;
		public byte byte_1;
		public byte byte_2;
		public byte byte_3;
		public byte byte_4;
		public ushort ushort_0;
		public ushort ushort_1;
		public ushort ushort_2;
		public ushort ushort_3;
		public ushort ushort_4;
		public uint uint_0;
		public uint uint_1;
		public ushort ushort_5;
		public ushort ushort_6;
		public ushort Jxukyqxiiy;
		public ushort ushort_7;
		public uint uint_2;
		public ushort ushort_8;
		public ushort ushort_9;
		public ushort ushort_10;
		public ushort ushort_11;
		public ushort ushort_12;
		public ushort ushort_13;
		public ushort ushort_14;
		public ushort ushort_15;
		public ushort ushort_16;
		public ushort ushort_17;
	}
	public struct Struct4
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] byte_0;
		public byte byte_1;
		public byte byte_2;
	}
	public struct Struct5
	{
		public byte byte_0;
		public byte byte_1;
		public byte byte_2;
		public byte byte_3;
		public IntPtr intptr_0;
		public ushort ushort_0;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] byte_4;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] byte_5;
		public byte byte_6;
		public byte byte_7;
		public IntPtr intptr_1;
		public byte byte_8;
		public byte byte_9;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
		public byte[] byte_10;
		public IntPtr intptr_2;
	}
	public struct Struct6
	{
		public byte byte_0;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 254)]
		public byte[] byte_1;
	}
	[StructLayout(LayoutKind.Auto)]
	public struct Struct7
	{
		public Class10.Struct3 struct3_0;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
		public Class10.Struct4[] struct4_0;
	}
	public class Class11
	{
		[DllImport("NETAPI32.DLL")]
		public static extern char Netbios(ref Class10.Struct5 struct5_0);
		public Class11()
		{
			Class16.cwDXy7Qz9AoPt();
			
		}
	}
	private static string string_0;
	public static string string_1;
	private static DateTime dateTime_0;
	private static string string_2;
	[CompilerGenerated]
	private static DateTime dateTime_1;
	[CompilerGenerated]
	public static DateTime smethod_0()
	{
		return Class10.dateTime_1;
	}
	[CompilerGenerated]
	public static void smethod_1(DateTime dateTime_2)
	{
		Class10.dateTime_1 = dateTime_2;
	}
	public static DateTime smethod_2(long long_0)
	{
		long ticks = new DateTime(1970, 1, 1).Ticks + long_0 * 10000L + 288000000000L;
		return new DateTime(ticks);
	}
	private static DateTime smethod_3()
	{
		string input = Class10.smethod_4("http://open.baidu.com/special/time/");
		Match match = Regex.Match(input, "window\\.baidu_time\\((\\d+)\\);");
		DateTime result;
		if (!match.Success)
		{
			result = DateTime.Now;
		}
		else
		{
			result = Class10.smethod_2(long.Parse(match.Groups[1].Value));
		}
		return result;
	}
	public static string smethod_4(string string_3)
	{
		HttpWebRequest httpWebRequest = null;
		HttpWebResponse httpWebResponse = null;
		httpWebRequest = (WebRequest.Create(string_3) as HttpWebRequest);
		httpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml,*/*";
		httpWebRequest.Headers.Add("Accept-Encoding: gzip, deflate");
		httpWebRequest.Headers.Add("Accept-Language: zh-CN,zh");
		httpWebRequest.Headers.Add("Cache-Control: max-age=0");
		httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; Trident/4.0)";
		httpWebRequest.Timeout = 20000;
		httpWebRequest.KeepAlive = true;
		httpWebRequest.Proxy = null;
		string result;
		try
		{
			httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			Stream stream;
			if (httpWebResponse.ContentEncoding == "deflate")
			{
				stream = new DeflateStream(httpWebResponse.GetResponseStream(), CompressionMode.Decompress);
			}
			if (httpWebResponse.ContentEncoding == "gzip")
			{
				stream = new GZipStream(httpWebResponse.GetResponseStream(), CompressionMode.Decompress);
			}
			else
			{
				stream = httpWebResponse.GetResponseStream();
			}
			StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
			string text = streamReader.ReadToEnd();
			streamReader.Close();
			streamReader.Dispose();
			stream.Close();
			stream.Dispose();
			result = text;
		}
		catch (Exception)
		{
			result = "";
		}
		finally
		{
			if (httpWebResponse != null)
			{
				httpWebResponse.Close();
			}
			httpWebRequest.Abort();
		}
		return result;
	}
	public static string smethod_5()
	{
		string result;
		try
		{
			ManagementClass managementClass = new ManagementClass("Win32_Processor");
			ManagementObjectCollection instances = managementClass.GetInstances();
			string text = null;
			using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					ManagementObject managementObject = (ManagementObject)enumerator.Current;
					text = managementObject.Properties["ProcessorId"].Value.ToString();
				}
			}
			result = text;
		}
		catch
		{
			result = "";
		}
		return result;
	}
	public static string smethod_6()
	{
		string result;
		try
		{
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BIOS");
			string text = null;
			using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ManagementObject managementObject = (ManagementObject)enumerator.Current;
					text = managementObject["SerialNumber"].ToString().Trim();
				}
			}
			result = text;
		}
		catch
		{
			result = "";
		}
		return result;
	}
	public static string smethod_7()
	{
		string text = "";
		string result;
		try
		{
			Class10.Struct5 @struct = default(Class10.Struct5);
			@struct.byte_0 = 55;
			int num = Marshal.SizeOf(typeof(Class10.Struct6));
			@struct.intptr_0 = Marshal.AllocHGlobal(num);
			@struct.ushort_0 = (ushort)num;
			char c = Class10.Class11.Netbios(ref @struct);
			Class10.Struct6 struct2 = (Class10.Struct6)Marshal.PtrToStructure(@struct.intptr_0, typeof(Class10.Struct6));
			Marshal.FreeHGlobal(@struct.intptr_0);
			if (c != '\0')
			{
				result = "";
				return result;
			}
			for (int i = 0; i < (int)struct2.byte_0; i++)
			{
				@struct.byte_0 = 50;
				@struct.byte_8 = struct2.byte_1[i];
				c = Class10.Class11.Netbios(ref @struct);
				if (c != '\0')
				{
					result = "";
					return result;
				}
				@struct.byte_0 = 51;
				@struct.byte_8 = struct2.byte_1[i];
				@struct.byte_4[0] = 42;
				num = Marshal.SizeOf(typeof(Class10.Struct3)) + Marshal.SizeOf(typeof(Class10.Struct4)) * 30;
				@struct.intptr_0 = Marshal.AllocHGlobal(num);
				@struct.ushort_0 = (ushort)num;
				c = Class10.Class11.Netbios(ref @struct);
				Class10.Struct7 struct3;
				struct3.struct3_0 = (Class10.Struct3)Marshal.PtrToStructure(@struct.intptr_0, typeof(Class10.Struct3));
				Marshal.FreeHGlobal(@struct.intptr_0);
				if (c == '\0')
				{
					if (i > 0)
					{
						text += ":";
					}
					text = string.Format("{0,2:X}{1,2:X}{2,2:X}{3,2:X}{4,2:X}{5,2:X}", new object[]
					{
						struct3.struct3_0.byte_0[0],
						struct3.struct3_0.byte_0[1],
						struct3.struct3_0.byte_0[2],
						struct3.struct3_0.byte_0[3],
						struct3.struct3_0.byte_0[4],
						struct3.struct3_0.byte_0[5]
					});
				}
			}
		}
		catch
		{
		}
		result = text.Replace(' ', '0');
		return result;
	}
	public static string smethod_8()
	{
		if (Class10.string_2 == null)
		{
			string str = Class10.smethod_5();
			string str2 = Class10.smethod_7();
			Class10.string_2 = Class9.smethod_0(str + str2 + Class10.string_1);
		}
		return Class10.string_2;
	}
	public static bool smethod_9()
	{
		DateTime t = Class10.smethod_3();
		return !(t > DateTime.Parse("2016-04-09 01:00:00"));
	}
	public Class10()
	{
		Class16.cwDXy7Qz9AoPt();
		
	}
	static Class10()
	{
		Class16.cwDXy7Qz9AoPt();
		Class10.string_0 = "alipay_chongzhi";
		Class10.string_1 = "autoAlipay";
		Class10.dateTime_0 = default(DateTime);
		Class10.string_2 = null;
	}
}
