using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
namespace LitJson
{
	public class JsonData : IEquatable<JsonData>, IList, IJsonWrapper, IOrderedDictionary, IDictionary, ICollection, IEnumerable
	{
		private IList<JsonData> ilist_0;
		private bool bool_0;
		private double double_0;
		private int int_0;
		private long long_0;
		private IDictionary<string, JsonData> idictionary_0;
		private string string_0;
		private string string_1;
		private JsonType jsonType_0;
		private IList<KeyValuePair<string, JsonData>> ilist_1;
		public int Count
		{
			get
			{
				return this.method_0().Count;
			}
		}
		public bool IsArray
		{
			get
			{
				return this.jsonType_0 == JsonType.Array;
			}
		}
		public bool IsBoolean
		{
			get
			{
				return this.jsonType_0 == JsonType.Boolean;
			}
		}
		public bool IsDouble
		{
			get
			{
				return this.jsonType_0 == JsonType.Double;
			}
		}
		public bool IsInt
		{
			get
			{
				return this.jsonType_0 == JsonType.Int;
			}
		}
		public bool IsLong
		{
			get
			{
				return this.jsonType_0 == JsonType.Long;
			}
		}
		public bool IsObject
		{
			get
			{
				return this.jsonType_0 == JsonType.Object;
			}
		}
		public bool IsString
		{
			get
			{
				return this.jsonType_0 == JsonType.String;
			}
		}
		int ICollection.Count
		{
			get
			{
				return this.Count;
			}
		}
		bool ICollection.IsSynchronized
		{
			get
			{
				return this.method_0().IsSynchronized;
			}
		}
		object ICollection.SyncRoot
		{
			get
			{
				return this.method_0().SyncRoot;
			}
		}
		bool IDictionary.IsFixedSize
		{
			get
			{
				return this.HhlfuLpPh().IsFixedSize;
			}
		}
		bool IDictionary.IsReadOnly
		{
			get
			{
				return this.HhlfuLpPh().IsReadOnly;
			}
		}
		ICollection IDictionary.Keys
		{
			get
			{
				this.HhlfuLpPh();
				IList<string> list = new List<string>();
				foreach (KeyValuePair<string, JsonData> current in this.ilist_1)
				{
					list.Add(current.Key);
				}
				return (ICollection)list;
			}
		}
		ICollection IDictionary.Values
		{
			get
			{
				this.HhlfuLpPh();
				IList<JsonData> list = new List<JsonData>();
				foreach (KeyValuePair<string, JsonData> current in this.ilist_1)
				{
					list.Add(current.Value);
				}
				return (ICollection)list;
			}
		}
		bool IJsonWrapper.IsArray
		{
			get
			{
				return this.IsArray;
			}
		}
		bool IJsonWrapper.IsBoolean
		{
			get
			{
				return this.IsBoolean;
			}
		}
		bool IJsonWrapper.IsDouble
		{
			get
			{
				return this.IsDouble;
			}
		}
		bool IJsonWrapper.IsInt
		{
			get
			{
				return this.IsInt;
			}
		}
		bool IJsonWrapper.IsLong
		{
			get
			{
				return this.IsLong;
			}
		}
		bool IJsonWrapper.IsObject
		{
			get
			{
				return this.IsObject;
			}
		}
		bool IJsonWrapper.IsString
		{
			get
			{
				return this.IsString;
			}
		}
		bool IList.IsFixedSize
		{
			get
			{
				return this.method_1().IsFixedSize;
			}
		}
		bool IList.IsReadOnly
		{
			get
			{
				return this.method_1().IsReadOnly;
			}
		}
		object IDictionary.this[object key]
		{
			get
			{
				return this.HhlfuLpPh()[key];
			}
			set
			{
				if (!(key is string))
				{
					throw new ArgumentException("The key has to be a string");
				}
				JsonData value2 = this.method_2(value);
				this[(string)key] = value2;
			}
		}
		object IOrderedDictionary.this[int idx]
		{
			get
			{
				this.HhlfuLpPh();
				return this.ilist_1[idx].Value;
			}
			set
			{
				this.HhlfuLpPh();
				JsonData value2 = this.method_2(value);
				KeyValuePair<string, JsonData> keyValuePair = this.ilist_1[idx];
				this.idictionary_0[keyValuePair.Key] = value2;
				KeyValuePair<string, JsonData> value3 = new KeyValuePair<string, JsonData>(keyValuePair.Key, value2);
				this.ilist_1[idx] = value3;
			}
		}
		object IList.this[int index]
		{
			get
			{
				return this.method_1()[index];
			}
			set
			{
				this.method_1();
				JsonData value2 = this.method_2(value);
				this[index] = value2;
			}
		}
		public JsonData this[string prop_name]
		{
			get
			{
				this.HhlfuLpPh();
				return this.idictionary_0[prop_name];
			}
			set
			{
				this.HhlfuLpPh();
				KeyValuePair<string, JsonData> keyValuePair = new KeyValuePair<string, JsonData>(prop_name, value);
				if (this.idictionary_0.ContainsKey(prop_name))
				{
					for (int i = 0; i < this.ilist_1.Count; i++)
					{
						if (this.ilist_1[i].Key == prop_name)
						{
							this.ilist_1[i] = keyValuePair;
							break;
						}
					}
				}
				else
				{
					this.ilist_1.Add(keyValuePair);
				}
				this.idictionary_0[prop_name] = value;
				this.string_1 = null;
			}
		}
		public JsonData this[int index]
		{
			get
			{
				this.method_0();
				JsonData result;
				if (this.jsonType_0 == JsonType.Array)
				{
					result = this.ilist_0[index];
				}
				else
				{
					result = this.ilist_1[index].Value;
				}
				return result;
			}
			set
			{
				this.method_0();
				if (this.jsonType_0 == JsonType.Array)
				{
					this.ilist_0[index] = value;
				}
				else
				{
					KeyValuePair<string, JsonData> keyValuePair = this.ilist_1[index];
					KeyValuePair<string, JsonData> value2 = new KeyValuePair<string, JsonData>(keyValuePair.Key, value);
					this.ilist_1[index] = value2;
					this.idictionary_0[keyValuePair.Key] = value;
				}
				this.string_1 = null;
			}
		}
		public JsonData()
		{
			Class16.cwDXy7Qz9AoPt();
			
		}
		public JsonData(bool boolean)
		{
			Class16.cwDXy7Qz9AoPt();
			
			this.jsonType_0 = JsonType.Boolean;
			this.bool_0 = boolean;
		}
		public JsonData(double number)
		{
			Class16.cwDXy7Qz9AoPt();
			
			this.jsonType_0 = JsonType.Double;
			this.double_0 = number;
		}
		public JsonData(int number)
		{
			Class16.cwDXy7Qz9AoPt();
			
			this.jsonType_0 = JsonType.Int;
			this.int_0 = number;
		}
		public JsonData(long number)
		{
			Class16.cwDXy7Qz9AoPt();
			
			this.jsonType_0 = JsonType.Long;
			this.long_0 = number;
		}
		public JsonData(object obj)
		{
			Class16.cwDXy7Qz9AoPt();
			
			if (obj is bool)
			{
				this.jsonType_0 = JsonType.Boolean;
				this.bool_0 = (bool)obj;
			}
			else
			{
				if (obj is double)
				{
					this.jsonType_0 = JsonType.Double;
					this.double_0 = (double)obj;
				}
				else
				{
					if (obj is int)
					{
						this.jsonType_0 = JsonType.Int;
						this.int_0 = (int)obj;
					}
					else
					{
						if (obj is long)
						{
							this.jsonType_0 = JsonType.Long;
							this.long_0 = (long)obj;
						}
						else
						{
							if (!(obj is string))
							{
								throw new ArgumentException("Unable to wrap the given object with JsonData");
							}
							this.jsonType_0 = JsonType.String;
							this.string_0 = (string)obj;
						}
					}
				}
			}
		}
		public JsonData(string str)
		{
			Class16.cwDXy7Qz9AoPt();
			
			this.jsonType_0 = JsonType.String;
			this.string_0 = str;
		}
		public static implicit operator JsonData(bool data)
		{
			return new JsonData(data);
		}
		public static implicit operator JsonData(double data)
		{
			return new JsonData(data);
		}
		public static implicit operator JsonData(int data)
		{
			return new JsonData(data);
		}
		public static implicit operator JsonData(long data)
		{
			return new JsonData(data);
		}
		public static implicit operator JsonData(string data)
		{
			return new JsonData(data);
		}
		public static explicit operator bool(JsonData data)
		{
			if (data.jsonType_0 != JsonType.Boolean)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold a double");
			}
			return data.bool_0;
		}
		public static explicit operator double(JsonData data)
		{
			if (data.jsonType_0 != JsonType.Double)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold a double");
			}
			return data.double_0;
		}
		public static explicit operator int(JsonData data)
		{
			if (data.jsonType_0 != JsonType.Int)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold an int");
			}
			return data.int_0;
		}
		public static explicit operator long(JsonData data)
		{
			if (data.jsonType_0 != JsonType.Long)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold an int");
			}
			return data.long_0;
		}
		public static explicit operator string(JsonData data)
		{
			if (data.jsonType_0 != JsonType.String)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold a string");
			}
			return data.string_0;
		}
		void ICollection.CopyTo(Array array, int index)
		{
			this.method_0().CopyTo(array, index);
		}
		void IDictionary.Add(object key, object value)
		{
			JsonData value2 = this.method_2(value);
			this.HhlfuLpPh().Add(key, value2);
			KeyValuePair<string, JsonData> item = new KeyValuePair<string, JsonData>((string)key, value2);
			this.ilist_1.Add(item);
			this.string_1 = null;
		}
		void IDictionary.Clear()
		{
			this.HhlfuLpPh().Clear();
			this.ilist_1.Clear();
			this.string_1 = null;
		}
		bool IDictionary.Contains(object key)
		{
			return this.HhlfuLpPh().Contains(key);
		}
		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return ((IOrderedDictionary)this).GetEnumerator();
		}
		void IDictionary.Remove(object key)
		{
			this.HhlfuLpPh().Remove(key);
			for (int i = 0; i < this.ilist_1.Count; i++)
			{
				if (this.ilist_1[i].Key == (string)key)
				{
					this.ilist_1.RemoveAt(i);
					//IL_56:
					this.string_1 = null;
					return;
				}
			}
			//goto IL_56;
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.method_0().GetEnumerator();
		}
		bool IJsonWrapper.GetBoolean()
		{
			if (this.jsonType_0 != JsonType.Boolean)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold a boolean");
			}
			return this.bool_0;
		}
		double IJsonWrapper.GetDouble()
		{
			if (this.jsonType_0 != JsonType.Double)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold a double");
			}
			return this.double_0;
		}
		int IJsonWrapper.GetInt()
		{
			if (this.jsonType_0 != JsonType.Int)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold an int");
			}
			return this.int_0;
		}
		long IJsonWrapper.GetLong()
		{
			if (this.jsonType_0 != JsonType.Long)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold a long");
			}
			return this.long_0;
		}
		string IJsonWrapper.GetString()
		{
			if (this.jsonType_0 != JsonType.String)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold a string");
			}
			return this.string_0;
		}
		void IJsonWrapper.SetBoolean(bool val)
		{
			this.jsonType_0 = JsonType.Boolean;
			this.bool_0 = val;
			this.string_1 = null;
		}
		void IJsonWrapper.SetDouble(double val)
		{
			this.jsonType_0 = JsonType.Double;
			this.double_0 = val;
			this.string_1 = null;
		}
		void IJsonWrapper.SetInt(int val)
		{
			this.jsonType_0 = JsonType.Int;
			this.int_0 = val;
			this.string_1 = null;
		}
		void IJsonWrapper.SetLong(long val)
		{
			this.jsonType_0 = JsonType.Long;
			this.long_0 = val;
			this.string_1 = null;
		}
		void IJsonWrapper.SetString(string val)
		{
			this.jsonType_0 = JsonType.String;
			this.string_0 = val;
			this.string_1 = null;
		}
		string IJsonWrapper.ToJson()
		{
			return this.ToJson();
		}
		void IJsonWrapper.ToJson(JsonWriter writer)
		{
			this.ToJson(writer);
		}
		int IList.Add(object value)
		{
			return this.Add(value);
		}
		void IList.Clear()
		{
			this.method_1().Clear();
			this.string_1 = null;
		}
		bool IList.Contains(object value)
		{
			return this.method_1().Contains(value);
		}
		int IList.IndexOf(object value)
		{
			return this.method_1().IndexOf(value);
		}
		void IList.Insert(int index, object value)
		{
			this.method_1().Insert(index, value);
			this.string_1 = null;
		}
		void IList.Remove(object value)
		{
			this.method_1().Remove(value);
			this.string_1 = null;
		}
		void IList.RemoveAt(int index)
		{
			this.method_1().RemoveAt(index);
			this.string_1 = null;
		}
		IDictionaryEnumerator IOrderedDictionary.GetEnumerator()
		{
			this.HhlfuLpPh();
			return new Class1(this.ilist_1.GetEnumerator());
		}
		void IOrderedDictionary.Insert(int idx, object key, object value)
		{
			string text = (string)key;
			JsonData value2 = this.method_2(value);
			this[text] = value2;
			KeyValuePair<string, JsonData> item = new KeyValuePair<string, JsonData>(text, value2);
			this.ilist_1.Insert(idx, item);
		}
		void IOrderedDictionary.RemoveAt(int idx)
		{
			this.HhlfuLpPh();
			this.idictionary_0.Remove(this.ilist_1[idx].Key);
			this.ilist_1.RemoveAt(idx);
		}
		private ICollection method_0()
		{
			ICollection result;
			if (this.jsonType_0 == JsonType.Array)
			{
				result = (ICollection)this.ilist_0;
			}
			else
			{
				if (this.jsonType_0 != JsonType.Object)
				{
					throw new InvalidOperationException("The JsonData instance has to be initialized first");
				}
				result = (ICollection)this.idictionary_0;
			}
			return result;
		}
		private IDictionary HhlfuLpPh()
		{
			IDictionary result;
			if (this.jsonType_0 == JsonType.Object)
			{
				result = (IDictionary)this.idictionary_0;
			}
			else
			{
				if (this.jsonType_0 != JsonType.None)
				{
					throw new InvalidOperationException("Instance of JsonData is not a dictionary");
				}
				this.jsonType_0 = JsonType.Object;
				this.idictionary_0 = new Dictionary<string, JsonData>();
				this.ilist_1 = new List<KeyValuePair<string, JsonData>>();
				result = (IDictionary)this.idictionary_0;
			}
			return result;
		}
		private IList method_1()
		{
			IList result;
			if (this.jsonType_0 == JsonType.Array)
			{
				result = (IList)this.ilist_0;
			}
			else
			{
				if (this.jsonType_0 != JsonType.None)
				{
					throw new InvalidOperationException("Instance of JsonData is not a list");
				}
				this.jsonType_0 = JsonType.Array;
				this.ilist_0 = new List<JsonData>();
				result = (IList)this.ilist_0;
			}
			return result;
		}
		private JsonData method_2(object object_0)
		{
			JsonData result;
			if (object_0 == null)
			{
				result = null;
			}
			else
			{
				if (object_0 is JsonData)
				{
					result = (JsonData)object_0;
				}
				else
				{
					result = new JsonData(object_0);
				}
			}
			return result;
		}
		private static void smethod_0(IJsonWrapper ijsonWrapper_0, JsonWriter jsonWriter_0)
		{
			if (ijsonWrapper_0 == null)
			{
				jsonWriter_0.Write("null");
			}
			else
			{
				if (ijsonWrapper_0.IsString)
				{
					jsonWriter_0.Write(ijsonWrapper_0.GetString());
				}
				else
				{
					if (ijsonWrapper_0.IsBoolean)
					{
						jsonWriter_0.Write(ijsonWrapper_0.GetBoolean());
					}
					else
					{
						if (ijsonWrapper_0.IsDouble)
						{
							jsonWriter_0.Write(ijsonWrapper_0.GetDouble());
						}
						else
						{
							if (ijsonWrapper_0.IsInt)
							{
								jsonWriter_0.Write(ijsonWrapper_0.GetInt());
							}
							else
							{
								if (ijsonWrapper_0.IsLong)
								{
									jsonWriter_0.Write(ijsonWrapper_0.GetLong());
								}
								else
								{
									if (ijsonWrapper_0.IsArray)
									{
										jsonWriter_0.WriteArrayStart();
										foreach (object current in ijsonWrapper_0)
										{
											JsonData.smethod_0((JsonData)current, jsonWriter_0);
										}
										jsonWriter_0.WriteArrayEnd();
									}
									else
									{
										if (ijsonWrapper_0.IsObject)
										{
											jsonWriter_0.WriteObjectStart();
											foreach (DictionaryEntry dictionaryEntry in ijsonWrapper_0)
											{
												jsonWriter_0.WritePropertyName((string)dictionaryEntry.Key);
												JsonData.smethod_0((JsonData)dictionaryEntry.Value, jsonWriter_0);
											}
											jsonWriter_0.WriteObjectEnd();
										}
									}
								}
							}
						}
					}
				}
			}
		}
		public int Add(object value)
		{
			JsonData value2 = this.method_2(value);
			this.string_1 = null;
			return this.method_1().Add(value2);
		}
		public void Clear()
		{
			if (this.IsObject)
			{
				((IDictionary)this).Clear();
			}
			else
			{
				if (this.IsArray)
				{
					((IList)this).Clear();
				}
			}
		}
		public bool Equals(JsonData x)
		{
			bool result;
			if (x == null)
			{
				result = false;
			}
			else
			{
				if (x.jsonType_0 != this.jsonType_0)
				{
					result = false;
				}
				else
				{
					switch (this.jsonType_0)
					{
					case JsonType.None:
						result = true;
						break;
					case JsonType.Object:
						result = this.idictionary_0.Equals(x.idictionary_0);
						break;
					case JsonType.Array:
						result = this.ilist_0.Equals(x.ilist_0);
						break;
					case JsonType.String:
						result = this.string_0.Equals(x.string_0);
						break;
					case JsonType.Int:
						result = this.int_0.Equals(x.int_0);
						break;
					case JsonType.Long:
						result = this.long_0.Equals(x.long_0);
						break;
					case JsonType.Double:
						result = this.double_0.Equals(x.double_0);
						break;
					case JsonType.Boolean:
						result = this.bool_0.Equals(x.bool_0);
						break;
					default:
						result = false;
						break;
					}
				}
			}
			return result;
		}
		public JsonType GetJsonType()
		{
			return this.jsonType_0;
		}
		public void SetJsonType(JsonType type)
		{
			if (this.jsonType_0 != type)
			{
				switch (type)
				{
				case JsonType.Object:
					this.idictionary_0 = new Dictionary<string, JsonData>();
					this.ilist_1 = new List<KeyValuePair<string, JsonData>>();
					break;
				case JsonType.Array:
					this.ilist_0 = new List<JsonData>();
					break;
				case JsonType.String:
					this.string_0 = null;
					break;
				case JsonType.Int:
					this.int_0 = 0;
					break;
				case JsonType.Long:
					this.long_0 = 0L;
					break;
				case JsonType.Double:
					this.double_0 = 0.0;
					break;
				case JsonType.Boolean:
					this.bool_0 = false;
					break;
				}
				this.jsonType_0 = type;
			}
		}
		public string ToJson()
		{
			string result;
			if (this.string_1 != null)
			{
				result = this.string_1;
			}
			else
			{
				StringWriter stringWriter = new StringWriter();
				JsonData.smethod_0(this, new JsonWriter(stringWriter)
				{
					Validate = false
				});
				this.string_1 = stringWriter.ToString();
				result = this.string_1;
			}
			return result;
		}
		public void ToJson(JsonWriter writer)
		{
			bool validate = writer.Validate;
			writer.Validate = false;
			JsonData.smethod_0(this, writer);
			writer.Validate = validate;
		}
		public override string ToString()
		{
			string result;
			switch (this.jsonType_0)
			{
			case JsonType.Object:
				result = "JsonData object";
				break;
			case JsonType.Array:
				result = "JsonData array";
				break;
			case JsonType.String:
				result = this.string_0;
				break;
			case JsonType.Int:
				result = this.int_0.ToString();
				break;
			case JsonType.Long:
				result = this.long_0.ToString();
				break;
			case JsonType.Double:
				result = this.double_0.ToString();
				break;
			case JsonType.Boolean:
				result = this.bool_0.ToString();
				break;
			default:
				result = "Uninitialized JsonData";
				break;
			}
			return result;
		}
	}
}
