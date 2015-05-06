using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
internal class Class13
{
	public static uint uint_0;
	public static uint uint_1;
	public static uint uint_2;
	public static uint uint_3;
	[DllImport("user32")]
	public static extern int SendMessage(int int_0, int int_1, int int_2, ref int int_3);
	[DllImport("user32")]
	public static extern int RegisterWindowMessage(string string_0);
	[DllImport("OLEACC.DLL")]
	public static extern int ObjectFromLresult(int int_0, ref Guid guid_0, int int_1, [MarshalAs(UnmanagedType.Interface)] [In] [Out] ref object object_0);
	[DllImport("user32.dll")]
	public static extern bool RegisterHotKey(IntPtr intptr_0, int int_0, uint uint_4, Keys keys_0);
	[DllImport("user32.dll")]
	public static extern bool UnregisterHotKey(IntPtr intptr_0, int int_0);
	[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern int GlobalAddAtom(string string_0);
	public Class13()
	{
		Class16.cwDXy7Qz9AoPt();
		
	}
	static Class13()
	{
		Class16.cwDXy7Qz9AoPt();
		Class13.uint_0 = 1u;
		Class13.uint_1 = 2u;
		Class13.uint_2 = 4u;
		Class13.uint_3 = 8u;
	}
}
