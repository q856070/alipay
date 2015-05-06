using LitJson;
using System;
internal struct Struct1
{
	private Type type_0;
	private bool bool_0;
	private bool bool_1;
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
	public void method_3(bool bool_2)
	{
		this.bool_0 = bool_2;
	}
	public bool method_4()
	{
		return this.bool_1;
	}
	public void method_5(bool bool_2)
	{
		this.bool_1 = bool_2;
	}
}
