using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
internal class Class12
{
	public enum Enum3 : uint
	{

	}
	private delegate bool Delegate3(IntPtr handleWindow, ArrayList handles);
	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern IntPtr GetDesktopWindow();
	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool EnumWindows(Class12.Delegate3 delegate3_0, ArrayList arrayList_0);
	[DllImport("user32")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool EnumChildWindows(IntPtr intptr_0, Class12.Delegate3 delegate3_0, ArrayList arrayList_0);
	[DllImport("user32.dll", SetLastError = true)]
	public static extern IntPtr FindWindow(string string_0, string string_1);
	[DllImport("user32.dll", SetLastError = true)]
	public static extern IntPtr FindWindowEx(IntPtr intptr_0, int int_0, string string_0, string string_1);
	[DllImport("user32.dll", SetLastError = true)]
	public static extern IntPtr GetWindow(IntPtr intptr_0, Class12.Enum3 enum3_0);
	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern int GetWindowText(IntPtr intptr_0, StringBuilder stringBuilder_0, int int_0);
	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern int GetClassName(IntPtr intptr_0, StringBuilder stringBuilder_0, int int_0);
	public static ArrayList smethod_0()
	{
		ArrayList arrayList = new ArrayList();
		Class12.Delegate3 delegate3_ = new Class12.Delegate3(Class12.smethod_5);
		Class12.EnumWindows(delegate3_, arrayList);
		object[] array = arrayList.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			IntPtr intptr_ = (IntPtr)array[i];
			Class12.EnumChildWindows(intptr_, delegate3_, arrayList);
		}
		return arrayList;
	}
	public static IntPtr smethod_1(string string_0)
	{
		ArrayList arrayList = new ArrayList();
		Class12.Delegate3 delegate3_ = new Class12.Delegate3(Class12.smethod_5);
		Class12.EnumWindows(delegate3_, arrayList);
		object[] array = arrayList.ToArray();
		IntPtr result;
		for (int i = 0; i < array.Length; i++)
		{
			IntPtr intPtr = (IntPtr)array[i];
			StringBuilder stringBuilder = new StringBuilder(1020);
			Class12.GetWindowText(intPtr, stringBuilder, stringBuilder.Capacity);
			string text = stringBuilder.ToString().Trim();
			if (text.Contains(string_0))
			{
				result = intPtr;
				return result;
			}
		}
		result = IntPtr.Zero;
		return result;
	}
	public static IntPtr smethod_2(IntPtr intptr_0, string string_0)
	{
		ArrayList arrayList = new ArrayList();
		IntPtr zero = IntPtr.Zero;
		Class12.EnumChildWindows(intptr_0, new Class12.Delegate3(Class12.smethod_5), arrayList);
		IntPtr result;
		foreach (IntPtr intPtr in arrayList)
		{
			StringBuilder stringBuilder = new StringBuilder(1020);
			Class12.GetWindowText(intPtr, stringBuilder, stringBuilder.Capacity);
			string text = stringBuilder.ToString().Trim();
			if (text.Contains(string_0))
			{
				result = intPtr;
				return result;
			}
		}
		result = zero;
		return result;
	}
	public static IntPtr smethod_3(IntPtr intptr_0, string string_0)
	{
		ArrayList arrayList = new ArrayList();
		IntPtr zero = IntPtr.Zero;
		Class12.EnumChildWindows(intptr_0, new Class12.Delegate3(Class12.smethod_5), arrayList);
		IntPtr result;
		foreach (IntPtr intPtr in arrayList)
		{
			StringBuilder stringBuilder = new StringBuilder(1020);
			Class12.GetClassName(intPtr, stringBuilder, stringBuilder.Capacity);
			string text = stringBuilder.ToString().Trim();
			if (text.Contains(string_0))
			{
				result = intPtr;
				return result;
			}
		}
		result = zero;
		return result;
	}
	public static List<IntPtr> smethod_4(IntPtr intptr_0, string string_0)
	{
		ArrayList arrayList = new ArrayList();
		List<IntPtr> list = new List<IntPtr>();
		Class12.EnumChildWindows(intptr_0, new Class12.Delegate3(Class12.smethod_5), arrayList);
		foreach (IntPtr intPtr in arrayList)
		{
			StringBuilder stringBuilder = new StringBuilder(1020);
			Class12.GetClassName(intPtr, stringBuilder, stringBuilder.Capacity);
			string text = stringBuilder.ToString().Trim();
			if (text.Contains(string_0))
			{
				list.Add(intPtr);
			}
		}
		return list;
	}
	private static bool smethod_5(IntPtr intptr_0, ArrayList arrayList_0)
	{
		arrayList_0.Add(intptr_0);
		return true;
	}
	public Class12()
	{
		Class16.cwDXy7Qz9AoPt();
		
	}
}
