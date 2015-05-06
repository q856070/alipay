using System;
using System.Reflection;
internal class Class15
{
	internal delegate void Delegate4(object o);
	internal static Module module_0;
	internal static void cXdXy7QQTEARw(int typemdt)
	{
		Type type = Class15.module_0.ResolveType(33554432 + typemdt);
		FieldInfo[] fields = type.GetFields();
		for (int i = 0; i < fields.Length; i++)
		{
			FieldInfo fieldInfo = fields[i];
			MethodInfo method = (MethodInfo)Class15.module_0.ResolveMethod(fieldInfo.MetadataToken + 100663296);
			fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, method));
		}
	}
	public Class15()
	{
		Class16.cwDXy7Qz9AoPt();
		
	}
	static Class15()
	{
		Class16.cwDXy7Qz9AoPt();
		Class15.module_0 = typeof(Class15).Assembly.ManifestModule;
	}
}
