using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
internal class Class1 : IDictionaryEnumerator, IEnumerator
{
	private IEnumerator<KeyValuePair<string, JsonData>> ienumerator_0;
	public object Current
	{
		get
		{
			return this.Entry;
		}
	}
	public DictionaryEntry Entry
	{
		get
		{
			KeyValuePair<string, JsonData> current = this.ienumerator_0.Current;
			return new DictionaryEntry(current.Key, current.Value);
		}
	}
	public object Key
	{
		get
		{
			KeyValuePair<string, JsonData> current = this.ienumerator_0.Current;
			return current.Key;
		}
	}
	public object Value
	{
		get
		{
			KeyValuePair<string, JsonData> current = this.ienumerator_0.Current;
			return current.Value;
		}
	}
	public Class1(IEnumerator<KeyValuePair<string, JsonData>> enumerator)
	{
		Class16.cwDXy7Qz9AoPt();
		
		this.ienumerator_0 = enumerator;
	}
	public bool MoveNext()
	{
		return this.ienumerator_0.MoveNext();
	}
	public void Reset()
	{
		this.ienumerator_0.Reset();
	}
}
