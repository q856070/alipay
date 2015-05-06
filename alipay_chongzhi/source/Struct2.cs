using LitJson;
using System;
using System.Collections.Generic;
internal struct Struct2
{
	private Type type_0;
	private bool bool_0;
	private IDictionary<string, Struct0> idictionary_0;
	public Type method_0()
	{
		Type typeFromHandle;
		if (this.type_0 == null)
		{
			typeFromHandle = typeof(JsonData);
		}
		else
		{
			typeFromHandle = this.type_0;
		}
		return typeFromHandle;
	}
	public void method_1(Type type_1)
	{
		this.type_0 = type_1;
	}
	public bool method_2()
	{
		return this.bool_0;
	}
	public void SmDhqmnHe(bool bool_1)
	{
		this.bool_0 = bool_1;
	}
	public IDictionary<string, Struct0> method_3()
	{
		return this.idictionary_0;
	}
	public void method_4(IDictionary<string, Struct0> value)
	{
		this.idictionary_0 = value;
	}
}
