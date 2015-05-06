using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
namespace LitJson
{
	public class JsonMapper
	{
		private static int int_0;
		private static IFormatProvider iformatProvider_0;
		private static IDictionary<Type, Delegate0> idictionary_0;
		private static IDictionary<Type, Delegate0> idictionary_1;
		private static IDictionary<Type, IDictionary<Type, Delegate1>> idictionary_2;
		private static IDictionary<Type, IDictionary<Type, Delegate1>> idictionary_3;
		private static IDictionary<Type, Struct1> idictionary_4;
		private static readonly object object_0;
		private static IDictionary<Type, IDictionary<Type, MethodInfo>> idictionary_5;
		private static readonly object object_1;
		private static IDictionary<Type, Struct2> idictionary_6;
		private static readonly object object_2;
		private static IDictionary<Type, IList<Struct0>> idictionary_7;
		private static readonly object object_3;
		private static JsonWriter jsonWriter_0;
		private static readonly object object_4;
		[CompilerGenerated]
		private static Delegate0 delegate0_0;
		[CompilerGenerated]
		private static Delegate0 delegate0_1;
		[CompilerGenerated]
		private static Delegate0 delegate0_2;
		[CompilerGenerated]
		private static Delegate0 delegate0_3;
		[CompilerGenerated]
		private static Delegate0 delegate0_4;
		[CompilerGenerated]
		private static Delegate0 delegate0_5;
		[CompilerGenerated]
		private static Delegate0 delegate0_6;
		[CompilerGenerated]
		private static Delegate0 delegate0_7;
		[CompilerGenerated]
		private static Delegate0 delegate0_8;
		[CompilerGenerated]
		private static Delegate1 delegate1_0;
		[CompilerGenerated]
		private static Delegate1 delegate1_1;
		[CompilerGenerated]
		private static Delegate1 delegate1_2;
		[CompilerGenerated]
		private static Delegate1 delegate1_3;
		[CompilerGenerated]
		private static Delegate1 delegate1_4;
		[CompilerGenerated]
		private static Delegate1 delegate1_5;
		[CompilerGenerated]
		private static Delegate1 delegate1_6;
		[CompilerGenerated]
		private static Delegate1 delegate1_7;
		[CompilerGenerated]
		private static Delegate1 delegate1_8;
		[CompilerGenerated]
		private static Delegate1 delegate1_9;
		[CompilerGenerated]
		private static Delegate1 delegate1_10;
		[CompilerGenerated]
		private static Delegate1 delegate1_11;
		[CompilerGenerated]
		private static WrapperFactory wrapperFactory_0;
		[CompilerGenerated]
		private static WrapperFactory wrapperFactory_1;
		[CompilerGenerated]
		private static WrapperFactory wrapperFactory_2;
		static JsonMapper()
		{
			Class16.cwDXy7Qz9AoPt();
			JsonMapper.object_0 = new object();
			JsonMapper.object_1 = new object();
			JsonMapper.object_2 = new object();
			JsonMapper.object_3 = new object();
			JsonMapper.object_4 = new object();
			JsonMapper.int_0 = 100;
			JsonMapper.idictionary_4 = new Dictionary<Type, Struct1>();
			JsonMapper.idictionary_5 = new Dictionary<Type, IDictionary<Type, MethodInfo>>();
			JsonMapper.idictionary_6 = new Dictionary<Type, Struct2>();
			JsonMapper.idictionary_7 = new Dictionary<Type, IList<Struct0>>();
			JsonMapper.jsonWriter_0 = new JsonWriter();
			JsonMapper.iformatProvider_0 = DateTimeFormatInfo.InvariantInfo;
			JsonMapper.idictionary_0 = new Dictionary<Type, Delegate0>();
			JsonMapper.idictionary_1 = new Dictionary<Type, Delegate0>();
			JsonMapper.idictionary_2 = new Dictionary<Type, IDictionary<Type, Delegate1>>();
			JsonMapper.idictionary_3 = new Dictionary<Type, IDictionary<Type, Delegate1>>();
			JsonMapper.smethod_4();
			JsonMapper.smethod_5();
		}
		private static void MopamXdeg(Type type_0)
		{
			if (!JsonMapper.idictionary_4.ContainsKey(type_0))
			{
				Struct1 value = default(Struct1);
				value.method_3(type_0.IsArray);
				if (type_0.GetInterface("System.Collections.IList") != null)
				{
					value.method_5(true);
				}
				PropertyInfo[] properties = type_0.GetProperties();
				for (int i = 0; i < properties.Length; i++)
				{
					PropertyInfo propertyInfo = properties[i];
					if (!(propertyInfo.Name != "Item"))
					{
						ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
						if (indexParameters.Length == 1 && indexParameters[0].ParameterType == typeof(int))
						{
							value.method_1(propertyInfo.PropertyType);
						}
					}
				}
				object obj;
				Monitor.Enter(obj = JsonMapper.object_0);
				try
				{
					JsonMapper.idictionary_4.Add(type_0, value);
				}
				catch (ArgumentException)
				{
				}
				finally
				{
					Monitor.Exit(obj);
				}
			}
		}
		private static void smethod_0(Type type_0)
		{
			if (!JsonMapper.idictionary_6.ContainsKey(type_0))
			{
				Struct2 value = default(Struct2);
				if (type_0.GetInterface("System.Collections.IDictionary") != null)
				{
					value.SmDhqmnHe(true);
				}
				value.method_4(new Dictionary<string, Struct0>());
				PropertyInfo[] properties = type_0.GetProperties();
				for (int i = 0; i < properties.Length; i++)
				{
					PropertyInfo propertyInfo = properties[i];
					if (propertyInfo.Name == "Item")
					{
						ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
						if (indexParameters.Length == 1 && indexParameters[0].ParameterType == typeof(string))
						{
							value.method_1(propertyInfo.PropertyType);
						}
					}
					else
					{
						Struct0 value2 = default(Struct0);
						value2.memberInfo_0 = propertyInfo;
						value2.type_0 = propertyInfo.PropertyType;
						value.method_3().Add(propertyInfo.Name, value2);
					}
				}
				FieldInfo[] fields = type_0.GetFields();
				for (int i = 0; i < fields.Length; i++)
				{
					FieldInfo fieldInfo = fields[i];
					Struct0 value2 = default(Struct0);
					value2.memberInfo_0 = fieldInfo;
					value2.bool_0 = true;
					value2.type_0 = fieldInfo.FieldType;
					value.method_3().Add(fieldInfo.Name, value2);
				}
				object obj;
				Monitor.Enter(obj = JsonMapper.object_2);
				try
				{
					JsonMapper.idictionary_6.Add(type_0, value);
				}
				catch (ArgumentException)
				{
				}
				finally
				{
					Monitor.Exit(obj);
				}
			}
		}
		private static void smethod_1(Type type_0)
		{
			if (!JsonMapper.idictionary_7.ContainsKey(type_0))
			{
				IList<Struct0> list = new List<Struct0>();
				PropertyInfo[] properties = type_0.GetProperties();
				for (int i = 0; i < properties.Length; i++)
				{
					PropertyInfo propertyInfo = properties[i];
					if (!(propertyInfo.Name == "Item"))
					{
						list.Add(new Struct0
						{
							memberInfo_0 = propertyInfo,
							bool_0 = false
						});
					}
				}
				FieldInfo[] fields = type_0.GetFields();
				for (int i = 0; i < fields.Length; i++)
				{
					FieldInfo memberInfo_ = fields[i];
					list.Add(new Struct0
					{
						memberInfo_0 = memberInfo_,
						bool_0 = true
					});
				}
				object obj;
				Monitor.Enter(obj = JsonMapper.object_3);
				try
				{
					JsonMapper.idictionary_7.Add(type_0, list);
				}
				catch (ArgumentException)
				{
				}
				finally
				{
					Monitor.Exit(obj);
				}
			}
		}
		private static MethodInfo smethod_2(Type type_0, Type type_1)
		{
			object obj;
			Monitor.Enter(obj = JsonMapper.object_1);
			try
			{
				if (!JsonMapper.idictionary_5.ContainsKey(type_0))
				{
					JsonMapper.idictionary_5.Add(type_0, new Dictionary<Type, MethodInfo>());
				}
			}
			finally
			{
				Monitor.Exit(obj);
			}
			MethodInfo result;
			if (JsonMapper.idictionary_5[type_0].ContainsKey(type_1))
			{
				result = JsonMapper.idictionary_5[type_0][type_1];
			}
			else
			{
				MethodInfo method = type_0.GetMethod("op_Implicit", new Type[]
				{
					type_1
				});
				Monitor.Enter(obj = JsonMapper.object_1);
				try
				{
					JsonMapper.idictionary_5[type_0].Add(type_1, method);
				}
				catch (ArgumentException)
				{
					result = JsonMapper.idictionary_5[type_0][type_1];
					return result;
				}
				finally
				{
					Monitor.Exit(obj);
				}
				result = method;
			}
			return result;
		}
		private static object smethod_3(Type type_0, JsonReader jsonReader_0)
		{
			jsonReader_0.Read();
			object result;
			if (jsonReader_0.Token == JsonToken.ArrayEnd)
			{
				result = null;
			}
			else
			{
				if (jsonReader_0.Token == JsonToken.Null)
				{
					if (!type_0.IsClass)
					{
						throw new JsonException(string.Format("Can't assign null to an instance of type {0}", type_0));
					}
					result = null;
				}
				else
				{
					if (jsonReader_0.Token == JsonToken.Double || jsonReader_0.Token == JsonToken.Int || jsonReader_0.Token == JsonToken.Long || jsonReader_0.Token == JsonToken.String || jsonReader_0.Token == JsonToken.Boolean)
					{
						Type type = jsonReader_0.Value.GetType();
						if (type_0.IsAssignableFrom(type))
						{
							result = jsonReader_0.Value;
						}
						else
						{
							if (JsonMapper.idictionary_3.ContainsKey(type) && JsonMapper.idictionary_3[type].ContainsKey(type_0))
							{
								Delegate1 @delegate = JsonMapper.idictionary_3[type][type_0];
								result = @delegate(jsonReader_0.Value.ToString());
							}
							else
							{
								if (JsonMapper.idictionary_2.ContainsKey(type) && JsonMapper.idictionary_2[type].ContainsKey(type_0))
								{
									Delegate1 @delegate = JsonMapper.idictionary_2[type][type_0];
									result = @delegate(jsonReader_0.Value.ToString());
								}
								else
								{
									if (type_0.IsEnum)
									{
										result = Enum.ToObject(type_0, jsonReader_0.Value);
									}
									else
									{
										MethodInfo methodInfo = JsonMapper.smethod_2(type_0, type);
										if (methodInfo == null)
										{
											throw new JsonException(string.Format("Can't assign value '{0}' (type {1}) to type {2}", jsonReader_0.Value, type, type_0));
										}
										result = methodInfo.Invoke(null, new object[]
										{
											jsonReader_0.Value
										});
									}
								}
							}
						}
					}
					else
					{
						object obj = null;
						if (jsonReader_0.Token == JsonToken.ArrayStart)
						{
							JsonMapper.MopamXdeg(type_0);
							Struct1 @struct = JsonMapper.idictionary_4[type_0];
							if (!@struct.method_2() && !@struct.method_4())
							{
								throw new JsonException(string.Format("Type {0} can't act as an array", type_0));
							}
							IList list;
							Type type2;
							if (!@struct.method_2())
							{
								list = (IList)Activator.CreateInstance(type_0);
								type2 = @struct.method_0();
							}
							else
							{
								list = new ArrayList();
								type2 = type_0.GetElementType();
							}
							while (true)
							{
								object value = JsonMapper.smethod_3(type2, jsonReader_0);
								if (jsonReader_0.Token == JsonToken.ArrayEnd)
								{
									break;
								}
								list.Add(value);
							}
							if (@struct.method_2())
							{
								int count = list.Count;
								obj = Array.CreateInstance(type2, count);
								for (int i = 0; i < count; i++)
								{
									((Array)obj).SetValue(list[i], i);
								}
							}
							else
							{
								obj = list;
							}
						}
						else
						{
							if (jsonReader_0.Token == JsonToken.ObjectStart)
							{
								JsonMapper.smethod_0(type_0);
								Struct2 struct2 = JsonMapper.idictionary_6[type_0];
								obj = Activator.CreateInstance(type_0);
								string text;
								while (true)
								{
									jsonReader_0.Read();
									if (jsonReader_0.Token == JsonToken.ObjectEnd)
									{
										break;
									}
									text = (string)jsonReader_0.Value;
									if (struct2.method_3().ContainsKey(text))
									{
										Struct0 struct3 = struct2.method_3()[text];
										if (struct3.bool_0)
										{
											((FieldInfo)struct3.memberInfo_0).SetValue(obj, JsonMapper.smethod_3(struct3.type_0, jsonReader_0));
										}
										else
										{
											PropertyInfo propertyInfo = (PropertyInfo)struct3.memberInfo_0;
											if (propertyInfo.CanWrite)
											{
												propertyInfo.SetValue(obj, JsonMapper.smethod_3(struct3.type_0, jsonReader_0), null);
											}
											else
											{
												JsonMapper.smethod_3(struct3.type_0, jsonReader_0);
											}
										}
									}
									else
									{
										if (!struct2.method_2())
										{
											goto IL_3AD;
										}
										((IDictionary)obj).Add(text, JsonMapper.smethod_3(struct2.method_0(), jsonReader_0));
									}
								}
								goto IL_3C0;
								IL_3AD:
								throw new JsonException(string.Format("The type {0} doesn't have the property '{1}'", type_0, text));
							}
						}
						IL_3C0:
						result = obj;
					}
				}
			}
			return result;
		}
		private static IJsonWrapper Vhmpjjblo(WrapperFactory wrapperFactory_3, JsonReader jsonReader_0)
		{
			jsonReader_0.Read();
			IJsonWrapper result;
			if (jsonReader_0.Token == JsonToken.ArrayEnd || jsonReader_0.Token == JsonToken.Null)
			{
				result = null;
			}
			else
			{
				IJsonWrapper jsonWrapper = wrapperFactory_3();
				if (jsonReader_0.Token == JsonToken.String)
				{
					jsonWrapper.SetString((string)jsonReader_0.Value);
					result = jsonWrapper;
				}
				else
				{
					if (jsonReader_0.Token == JsonToken.Double)
					{
						jsonWrapper.SetDouble((double)jsonReader_0.Value);
						result = jsonWrapper;
					}
					else
					{
						if (jsonReader_0.Token == JsonToken.Int)
						{
							jsonWrapper.SetInt((int)jsonReader_0.Value);
							result = jsonWrapper;
						}
						else
						{
							if (jsonReader_0.Token == JsonToken.Long)
							{
								jsonWrapper.SetLong((long)jsonReader_0.Value);
								result = jsonWrapper;
							}
							else
							{
								if (jsonReader_0.Token == JsonToken.Boolean)
								{
									jsonWrapper.SetBoolean((bool)jsonReader_0.Value);
									result = jsonWrapper;
								}
								else
								{
									if (jsonReader_0.Token == JsonToken.ArrayStart)
									{
										jsonWrapper.SetJsonType(JsonType.Array);
										while (true)
										{
											IJsonWrapper value = JsonMapper.Vhmpjjblo(wrapperFactory_3, jsonReader_0);
											if (jsonReader_0.Token == JsonToken.ArrayEnd)
											{
												break;
											}
											jsonWrapper.Add(value);
										}
									}
									else
									{
										if (jsonReader_0.Token == JsonToken.ObjectStart)
										{
											jsonWrapper.SetJsonType(JsonType.Object);
											while (true)
											{
												jsonReader_0.Read();
												if (jsonReader_0.Token == JsonToken.ObjectEnd)
												{
													break;
												}
												string key = (string)jsonReader_0.Value;
												jsonWrapper[key] = JsonMapper.Vhmpjjblo(wrapperFactory_3, jsonReader_0);
											}
										}
									}
									result = jsonWrapper;
								}
							}
						}
					}
				}
			}
			return result;
		}
		private static void smethod_4()
		{
			IDictionary<Type, Delegate0> arg_2D_0 = JsonMapper.idictionary_0;
			Type arg_2D_1 = typeof(byte);
			if (JsonMapper.delegate0_0 == null)
			{
				JsonMapper.delegate0_0 = new Delegate0(JsonMapper.smethod_8);
			}
			arg_2D_0[arg_2D_1] = JsonMapper.delegate0_0;
			IDictionary<Type, Delegate0> arg_5F_0 = JsonMapper.idictionary_0;
			Type arg_5F_1 = typeof(char);
			if (JsonMapper.delegate0_1 == null)
			{
				JsonMapper.delegate0_1 = new Delegate0(JsonMapper.maFsHonKI);
			}
			arg_5F_0[arg_5F_1] = JsonMapper.delegate0_1;
			IDictionary<Type, Delegate0> arg_91_0 = JsonMapper.idictionary_0;
			Type arg_91_1 = typeof(DateTime);
			if (JsonMapper.delegate0_2 == null)
			{
				JsonMapper.delegate0_2 = new Delegate0(JsonMapper.smethod_9);
			}
			arg_91_0[arg_91_1] = JsonMapper.delegate0_2;
			IDictionary<Type, Delegate0> arg_C3_0 = JsonMapper.idictionary_0;
			Type arg_C3_1 = typeof(decimal);
			if (JsonMapper.delegate0_3 == null)
			{
				JsonMapper.delegate0_3 = new Delegate0(JsonMapper.smethod_10);
			}
			arg_C3_0[arg_C3_1] = JsonMapper.delegate0_3;
			IDictionary<Type, Delegate0> arg_F5_0 = JsonMapper.idictionary_0;
			Type arg_F5_1 = typeof(sbyte);
			if (JsonMapper.delegate0_4 == null)
			{
				JsonMapper.delegate0_4 = new Delegate0(JsonMapper.smethod_11);
			}
			arg_F5_0[arg_F5_1] = JsonMapper.delegate0_4;
			IDictionary<Type, Delegate0> arg_127_0 = JsonMapper.idictionary_0;
			Type arg_127_1 = typeof(short);
			if (JsonMapper.delegate0_5 == null)
			{
				JsonMapper.delegate0_5 = new Delegate0(JsonMapper.smethod_12);
			}
			arg_127_0[arg_127_1] = JsonMapper.delegate0_5;
			IDictionary<Type, Delegate0> arg_159_0 = JsonMapper.idictionary_0;
			Type arg_159_1 = typeof(ushort);
			if (JsonMapper.delegate0_6 == null)
			{
				JsonMapper.delegate0_6 = new Delegate0(JsonMapper.smethod_13);
			}
			arg_159_0[arg_159_1] = JsonMapper.delegate0_6;
			IDictionary<Type, Delegate0> arg_18B_0 = JsonMapper.idictionary_0;
			Type arg_18B_1 = typeof(uint);
			if (JsonMapper.delegate0_7 == null)
			{
				JsonMapper.delegate0_7 = new Delegate0(JsonMapper.smethod_14);
			}
			arg_18B_0[arg_18B_1] = JsonMapper.delegate0_7;
			IDictionary<Type, Delegate0> arg_1BD_0 = JsonMapper.idictionary_0;
			Type arg_1BD_1 = typeof(ulong);
			if (JsonMapper.delegate0_8 == null)
			{
				JsonMapper.delegate0_8 = new Delegate0(JsonMapper.smethod_15);
			}
			arg_1BD_0[arg_1BD_1] = JsonMapper.delegate0_8;
		}
		private static void smethod_5()
		{
			if (JsonMapper.delegate1_0 == null)
			{
				JsonMapper.delegate1_0 = new Delegate1(JsonMapper.smethod_16);
			}
			Delegate1 delegate1_ = JsonMapper.delegate1_0;
			JsonMapper.smethod_6(JsonMapper.idictionary_2, typeof(int), typeof(byte), delegate1_);
			if (JsonMapper.delegate1_1 == null)
			{
				JsonMapper.delegate1_1 = new Delegate1(JsonMapper.smethod_17);
			}
			delegate1_ = JsonMapper.delegate1_1;
			JsonMapper.smethod_6(JsonMapper.idictionary_2, typeof(int), typeof(ulong), delegate1_);
			if (JsonMapper.delegate1_2 == null)
			{
				JsonMapper.delegate1_2 = new Delegate1(JsonMapper.smethod_18);
			}
			delegate1_ = JsonMapper.delegate1_2;
			JsonMapper.smethod_6(JsonMapper.idictionary_2, typeof(int), typeof(sbyte), delegate1_);
			if (JsonMapper.delegate1_3 == null)
			{
				JsonMapper.delegate1_3 = new Delegate1(JsonMapper.smethod_19);
			}
			delegate1_ = JsonMapper.delegate1_3;
			JsonMapper.smethod_6(JsonMapper.idictionary_2, typeof(int), typeof(short), delegate1_);
			if (JsonMapper.delegate1_4 == null)
			{
				JsonMapper.delegate1_4 = new Delegate1(JsonMapper.smethod_20);
			}
			delegate1_ = JsonMapper.delegate1_4;
			JsonMapper.smethod_6(JsonMapper.idictionary_2, typeof(int), typeof(ushort), delegate1_);
			if (JsonMapper.delegate1_5 == null)
			{
				JsonMapper.delegate1_5 = new Delegate1(JsonMapper.smethod_21);
			}
			delegate1_ = JsonMapper.delegate1_5;
			JsonMapper.smethod_6(JsonMapper.idictionary_2, typeof(int), typeof(uint), delegate1_);
			if (JsonMapper.delegate1_6 == null)
			{
				JsonMapper.delegate1_6 = new Delegate1(JsonMapper.smethod_22);
			}
			delegate1_ = JsonMapper.delegate1_6;
			JsonMapper.smethod_6(JsonMapper.idictionary_2, typeof(int), typeof(float), delegate1_);
			if (JsonMapper.delegate1_7 == null)
			{
				JsonMapper.delegate1_7 = new Delegate1(JsonMapper.smethod_23);
			}
			delegate1_ = JsonMapper.delegate1_7;
			JsonMapper.smethod_6(JsonMapper.idictionary_2, typeof(int), typeof(double), delegate1_);
			if (JsonMapper.delegate1_8 == null)
			{
				JsonMapper.delegate1_8 = new Delegate1(JsonMapper.smethod_24);
			}
			delegate1_ = JsonMapper.delegate1_8;
			JsonMapper.smethod_6(JsonMapper.idictionary_2, typeof(double), typeof(decimal), delegate1_);
			if (JsonMapper.delegate1_9 == null)
			{
				JsonMapper.delegate1_9 = new Delegate1(JsonMapper.smethod_25);
			}
			delegate1_ = JsonMapper.delegate1_9;
			JsonMapper.smethod_6(JsonMapper.idictionary_2, typeof(long), typeof(uint), delegate1_);
			if (JsonMapper.delegate1_10 == null)
			{
				JsonMapper.delegate1_10 = new Delegate1(JsonMapper.smethod_26);
			}
			delegate1_ = JsonMapper.delegate1_10;
			JsonMapper.smethod_6(JsonMapper.idictionary_2, typeof(string), typeof(char), delegate1_);
			if (JsonMapper.delegate1_11 == null)
			{
				JsonMapper.delegate1_11 = new Delegate1(JsonMapper.smethod_27);
			}
			delegate1_ = JsonMapper.delegate1_11;
			JsonMapper.smethod_6(JsonMapper.idictionary_2, typeof(string), typeof(DateTime), delegate1_);
		}
		private static void smethod_6(IDictionary<Type, IDictionary<Type, Delegate1>> table, Type type_0, Type type_1, Delegate1 delegate1_12)
		{
			if (!table.ContainsKey(type_0))
			{
				table.Add(type_0, new Dictionary<Type, Delegate1>());
			}
			table[type_0][type_1] = delegate1_12;
		}
		private static void smethod_7(object object_5, JsonWriter jsonWriter_1, bool bool_0, int int_1)
		{
			if (int_1 > JsonMapper.int_0)
			{
				throw new JsonException(string.Format("Max allowed object depth reached while trying to export from type {0}", object_5.GetType()));
			}
			if (object_5 == null)
			{
				jsonWriter_1.Write(null);
			}
			else
			{
				if (object_5 is IJsonWrapper)
				{
					if (bool_0)
					{
						jsonWriter_1.TextWriter.Write(((IJsonWrapper)object_5).ToJson());
					}
					else
					{
						((IJsonWrapper)object_5).ToJson(jsonWriter_1);
					}
				}
				else
				{
					if (object_5 is string)
					{
						jsonWriter_1.Write((string)object_5);
					}
					else
					{
						if (object_5 is double)
						{
							jsonWriter_1.Write((double)object_5);
						}
						else
						{
							if (object_5 is int)
							{
								jsonWriter_1.Write((int)object_5);
							}
							else
							{
								if (object_5 is bool)
								{
									jsonWriter_1.Write((bool)object_5);
								}
								else
								{
									if (object_5 is long)
									{
										jsonWriter_1.Write((long)object_5);
									}
									else
									{
										if (object_5 is Array)
										{
											jsonWriter_1.WriteArrayStart();
											foreach (object current in (Array)object_5)
											{
												JsonMapper.smethod_7(current, jsonWriter_1, bool_0, int_1 + 1);
											}
											jsonWriter_1.WriteArrayEnd();
										}
										else
										{
											if (object_5 is IList)
											{
												jsonWriter_1.WriteArrayStart();
												foreach (object current in (IList)object_5)
												{
													JsonMapper.smethod_7(current, jsonWriter_1, bool_0, int_1 + 1);
												}
												jsonWriter_1.WriteArrayEnd();
											}
											else
											{
												if (object_5 is IDictionary)
												{
													jsonWriter_1.WriteObjectStart();
													foreach (DictionaryEntry dictionaryEntry in (IDictionary)object_5)
													{
														jsonWriter_1.WritePropertyName((string)dictionaryEntry.Key);
														JsonMapper.smethod_7(dictionaryEntry.Value, jsonWriter_1, bool_0, int_1 + 1);
													}
													jsonWriter_1.WriteObjectEnd();
												}
												else
												{
													Type type = object_5.GetType();
													if (JsonMapper.idictionary_1.ContainsKey(type))
													{
														Delegate0 @delegate = JsonMapper.idictionary_1[type];
														@delegate(object_5, jsonWriter_1);
													}
													else
													{
														if (JsonMapper.idictionary_0.ContainsKey(type))
														{
															Delegate0 @delegate = JsonMapper.idictionary_0[type];
															@delegate(object_5, jsonWriter_1);
														}
														else
														{
															if (object_5 is Enum)
															{
																Type underlyingType = Enum.GetUnderlyingType(type);
																if (underlyingType == typeof(long) || underlyingType == typeof(uint) || underlyingType == typeof(ulong))
																{
																	jsonWriter_1.Write((ulong)object_5);
																}
																else
																{
																	jsonWriter_1.Write((int)object_5);
																}
															}
															else
															{
																JsonMapper.smethod_1(type);
																IList<Struct0> list = JsonMapper.idictionary_7[type];
																jsonWriter_1.WriteObjectStart();
																foreach (Struct0 current2 in list)
																{
																	if (current2.bool_0)
																	{
																		jsonWriter_1.WritePropertyName(current2.memberInfo_0.Name);
																		JsonMapper.smethod_7(((FieldInfo)current2.memberInfo_0).GetValue(object_5), jsonWriter_1, bool_0, int_1 + 1);
																	}
																	else
																	{
																		PropertyInfo propertyInfo = (PropertyInfo)current2.memberInfo_0;
																		if (propertyInfo.CanRead)
																		{
																			jsonWriter_1.WritePropertyName(current2.memberInfo_0.Name);
																			JsonMapper.smethod_7(propertyInfo.GetValue(object_5, null), jsonWriter_1, bool_0, int_1 + 1);
																		}
																	}
																}
																jsonWriter_1.WriteObjectEnd();
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		public static string ToJson(object obj)
		{
			object obj2;
			Monitor.Enter(obj2 = JsonMapper.object_4);
			string result;
			try
			{
				JsonMapper.jsonWriter_0.Reset();
				JsonMapper.smethod_7(obj, JsonMapper.jsonWriter_0, true, 0);
				result = JsonMapper.jsonWriter_0.ToString();
			}
			finally
			{
				Monitor.Exit(obj2);
			}
			return result;
		}
		public static void ToJson(object obj, JsonWriter writer)
		{
			JsonMapper.smethod_7(obj, writer, false, 0);
		}
		public static JsonData ToObject(JsonReader reader)
		{
			if (JsonMapper.wrapperFactory_0 == null)
			{
				JsonMapper.wrapperFactory_0 = new WrapperFactory(JsonMapper.smethod_28);
			}
			return (JsonData)JsonMapper.ToWrapper(JsonMapper.wrapperFactory_0, reader);
		}
		public static JsonData ToObject(TextReader reader)
		{
			JsonReader reader2 = new JsonReader(reader);
			if (JsonMapper.wrapperFactory_1 == null)
			{
				JsonMapper.wrapperFactory_1 = new WrapperFactory(JsonMapper.smethod_29);
			}
			return (JsonData)JsonMapper.ToWrapper(JsonMapper.wrapperFactory_1, reader2);
		}
		public static JsonData ToObject(string json)
		{
			if (JsonMapper.wrapperFactory_2 == null)
			{
				JsonMapper.wrapperFactory_2 = new WrapperFactory(JsonMapper.smethod_30);
			}
			return (JsonData)JsonMapper.ToWrapper(JsonMapper.wrapperFactory_2, json);
		}
		public static T ToObject<T>(JsonReader reader)
		{
			return (T)((object)JsonMapper.smethod_3(typeof(T), reader));
		}
		public static T ToObject<T>(TextReader reader)
		{
			JsonReader jsonReader_ = new JsonReader(reader);
			return (T)((object)JsonMapper.smethod_3(typeof(T), jsonReader_));
		}
		public static T ToObject<T>(string json)
		{
			JsonReader jsonReader_ = new JsonReader(json);
			return (T)((object)JsonMapper.smethod_3(typeof(T), jsonReader_));
		}
		public static IJsonWrapper ToWrapper(WrapperFactory factory, JsonReader reader)
		{
			return JsonMapper.Vhmpjjblo(factory, reader);
		}
		public static IJsonWrapper ToWrapper(WrapperFactory factory, string json)
		{
			JsonReader jsonReader_ = new JsonReader(json);
			return JsonMapper.Vhmpjjblo(factory, jsonReader_);
		}
		public static void RegisterExporter<T>(ExporterFunc<T> exporter)
		{
			Delegate0 value = delegate(object obj, JsonWriter writer)
			{
				exporter((T)((object)obj), writer);
			};
			JsonMapper.idictionary_1[typeof(T)] = value;
		}
		public static void RegisterImporter<TJson, TValue>(ImporterFunc<TJson, TValue> importer)
		{
			Delegate1 delegate1_ = (string input) => importer((TJson)((object)input));
			JsonMapper.smethod_6(JsonMapper.idictionary_3, typeof(TJson), typeof(TValue), delegate1_);
		}
		public static void UnregisterExporters()
		{
			JsonMapper.idictionary_1.Clear();
		}
		public static void UnregisterImporters()
		{
			JsonMapper.idictionary_3.Clear();
		}
		public JsonMapper()
		{
			Class16.cwDXy7Qz9AoPt();
			
		}
		[CompilerGenerated]
		private static void smethod_8(object object_5, JsonWriter jsonWriter_1)
		{
			jsonWriter_1.Write(Convert.ToInt32((byte)object_5));
		}
		[CompilerGenerated]
		private static void maFsHonKI(object object_5, JsonWriter jsonWriter_1)
		{
			jsonWriter_1.Write(Convert.ToString((char)object_5));
		}
		[CompilerGenerated]
		private static void smethod_9(object object_5, JsonWriter jsonWriter_1)
		{
			jsonWriter_1.Write(Convert.ToString((DateTime)object_5, JsonMapper.iformatProvider_0));
		}
		[CompilerGenerated]
		private static void smethod_10(object object_5, JsonWriter jsonWriter_1)
		{
			jsonWriter_1.Write((decimal)object_5);
		}
		[CompilerGenerated]
		private static void smethod_11(object object_5, JsonWriter jsonWriter_1)
		{
			jsonWriter_1.Write(Convert.ToInt32((sbyte)object_5));
		}
		[CompilerGenerated]
		private static void smethod_12(object object_5, JsonWriter jsonWriter_1)
		{
			jsonWriter_1.Write(Convert.ToInt32((short)object_5));
		}
		[CompilerGenerated]
		private static void smethod_13(object object_5, JsonWriter jsonWriter_1)
		{
			jsonWriter_1.Write(Convert.ToInt32((ushort)object_5));
		}
		[CompilerGenerated]
		private static void smethod_14(object object_5, JsonWriter jsonWriter_1)
		{
			jsonWriter_1.Write(Convert.ToUInt64((uint)object_5));
		}
		[CompilerGenerated]
		private static void smethod_15(object object_5, JsonWriter jsonWriter_1)
		{
			jsonWriter_1.Write((ulong)object_5);
		}
		[CompilerGenerated]
		private static object smethod_16(object object_5)
		{
			return Convert.ToByte((int)object_5);
		}
		[CompilerGenerated]
		private static object smethod_17(object object_5)
		{
			return Convert.ToUInt64((int)object_5);
		}
		[CompilerGenerated]
		private static object smethod_18(object object_5)
		{
			return Convert.ToSByte((int)object_5);
		}
		[CompilerGenerated]
		private static object smethod_19(object object_5)
		{
			return Convert.ToInt16((int)object_5);
		}
		[CompilerGenerated]
		private static object smethod_20(object object_5)
		{
			return Convert.ToUInt16((int)object_5);
		}
		[CompilerGenerated]
		private static object smethod_21(object object_5)
		{
			return Convert.ToUInt32((int)object_5);
		}
		[CompilerGenerated]
		private static object smethod_22(object object_5)
		{
			return Convert.ToSingle((int)object_5);
		}
		[CompilerGenerated]
		private static object smethod_23(object object_5)
		{
			return Convert.ToDouble((int)object_5);
		}
		[CompilerGenerated]
		private static object smethod_24(object object_5)
		{
			return Convert.ToDecimal((double)object_5);
		}
		[CompilerGenerated]
		private static object smethod_25(object object_5)
		{
			return Convert.ToUInt32((long)object_5);
		}
		[CompilerGenerated]
		private static object smethod_26(string string_0)
		{
			return Convert.ToChar((string)string_0);
		}
		[CompilerGenerated]
		private static object smethod_27(string string_0)
		{
			return Convert.ToDateTime((string)string_0, JsonMapper.iformatProvider_0);
		}
		[CompilerGenerated]
		private static IJsonWrapper smethod_28()
		{
			return new JsonData();
		}
		[CompilerGenerated]
		private static IJsonWrapper smethod_29()
		{
			return new JsonData();
		}
		[CompilerGenerated]
		private static IJsonWrapper smethod_30()
		{
			return new JsonData();
		}
	}
}
