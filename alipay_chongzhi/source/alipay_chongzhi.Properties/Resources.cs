using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
namespace alipay_chongzhi.Properties
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"), DebuggerNonUserCode, CompilerGenerated]
	internal class Resources
	{
		private static ResourceManager resourceManager_0;
		private static CultureInfo cultureInfo_0;
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager_0
		{
			get
			{
				if (object.ReferenceEquals(Resources.resourceManager_0, null))
				{
					ResourceManager resourceManager = new ResourceManager("alipay_chongzhi.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceManager_0 = resourceManager;
				}
				return Resources.resourceManager_0;
			}
		}
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo CultureInfo_0
		{
			get
			{
				return Resources.cultureInfo_0;
			}
			set
			{
				Resources.cultureInfo_0 = value;
			}
		}
		internal static string cert
		{
			get
			{
				return Resources.ResourceManager_0.GetString("cert", Resources.cultureInfo_0);
			}
		}
		internal static string key
		{
			get
			{
				return Resources.ResourceManager_0.GetString("key", Resources.cultureInfo_0);
			}
		}
		internal Resources()
		{
			Class16.cwDXy7Qz9AoPt();
			
		}
		internal static byte[] smethod_0()
		{
			object @object = Resources.ResourceManager_0.GetObject("AliTest", Resources.cultureInfo_0);
			return (byte[])@object;
		}
	}
}
