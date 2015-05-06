using System;
using System.Collections.Generic;
using System.IO;
namespace LitJson
{
	public class JsonReader
	{
		private static IDictionary<int, IDictionary<int, int[]>> idictionary_0;
		private Stack<int> stack_0;
		private int int_0;
		private int int_1;
		private bool bool_0;
		private bool bool_1;
		private Class4 class4_0;
		private bool bool_2;
		private bool bool_3;
		private bool bool_4;
		private TextReader textReader_0;
		private bool bool_5;
		private string string_0;
		private JsonToken jsonToken_0;
		public bool AllowComments
		{
			get
			{
				return this.class4_0.method_0();
			}
			set
			{
				this.class4_0.method_1(value);
			}
		}
		public bool AllowSingleQuotedStrings
		{
			get
			{
				return this.class4_0.method_2();
			}
			set
			{
				this.class4_0.method_3(value);
			}
		}
		public bool EndOfInput
		{
			get
			{
				return this.bool_1;
			}
		}
		public bool EndOfJson
		{
			get
			{
				return this.bool_0;
			}
		}
		public JsonToken Token
		{
			get
			{
				return this.jsonToken_0;
			}
		}
		public object Value
		{
			get
			{
				return this.string_0;
			}
		}
		static JsonReader()
		{
			Class16.cwDXy7Qz9AoPt();
			JsonReader.smethod_0();
		}
		public JsonReader(string json_text)
            :this(new StringReader(json_text), true)
		{
			Class16.cwDXy7Qz9AoPt();
		}
		public JsonReader(TextReader reader)
            : this(reader, false)
		{
			Class16.cwDXy7Qz9AoPt();
		}
		private JsonReader(TextReader reader, bool owned)
		{
			Class16.cwDXy7Qz9AoPt();
			
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			this.bool_2 = false;
			this.bool_3 = false;
			this.bool_4 = false;
			this.stack_0 = new Stack<int>();
			this.stack_0.Push(65553);
			this.stack_0.Push(65543);
			this.class4_0 = new Class4(reader);
			this.bool_1 = false;
			this.bool_0 = false;
			this.textReader_0 = reader;
			this.bool_5 = owned;
		}
		private static void smethod_0()
		{
			JsonReader.idictionary_0 = new Dictionary<int, IDictionary<int, int[]>>();
			JsonReader.BndqOejAmh((Enum1)65548);
			JsonReader.smethod_1((Enum1)65548, 91, new int[]
			{
				91,
				65549
			});
			JsonReader.BndqOejAmh((Enum1)65549);
			JsonReader.smethod_1((Enum1)65549, 34, new int[]
			{
				65550,
				65551,
				93
			});
			JsonReader.smethod_1((Enum1)65549, 91, new int[]
			{
				65550,
				65551,
				93
			});
			JsonReader.smethod_1((Enum1)65549, 93, new int[]
			{
				93
			});
			JsonReader.smethod_1((Enum1)65549, 123, new int[]
			{
				65550,
				65551,
				93
			});
			JsonReader.smethod_1((Enum1)65549, 65537, new int[]
			{
				65550,
				65551,
				93
			});
			JsonReader.smethod_1((Enum1)65549, 65538, new int[]
			{
				65550,
				65551,
				93
			});
			JsonReader.smethod_1((Enum1)65549, 65539, new int[]
			{
				65550,
				65551,
				93
			});
			JsonReader.smethod_1((Enum1)65549, 65540, new int[]
			{
				65550,
				65551,
				93
			});
			JsonReader.BndqOejAmh((Enum1)65544);
			JsonReader.smethod_1((Enum1)65544, 123, new int[]
			{
				123,
				65545
			});
			JsonReader.BndqOejAmh((Enum1)65545);
			JsonReader.smethod_1((Enum1)65545, 34, new int[]
			{
				65546,
				65547,
				125
			});
			JsonReader.smethod_1((Enum1)65545, 125, new int[]
			{
				125
			});
			JsonReader.BndqOejAmh((Enum1)65546);
			JsonReader.smethod_1((Enum1)65546, 34, new int[]
			{
				65552,
				58,
				65550
			});
			JsonReader.BndqOejAmh((Enum1)65547);
			JsonReader.smethod_1((Enum1)65547, 44, new int[]
			{
				44,
				65546,
				65547
			});
			JsonReader.smethod_1((Enum1)65547, 125, new int[]
			{
				65554
			});
			JsonReader.BndqOejAmh((Enum1)65552);
			JsonReader.smethod_1((Enum1)65552, 34, new int[]
			{
				34,
				65541,
				34
			});
			JsonReader.BndqOejAmh((Enum1)65543);
			JsonReader.smethod_1((Enum1)65543, 91, new int[]
			{
				65548
			});
			JsonReader.smethod_1((Enum1)65543, 123, new int[]
			{
				65544
			});
			JsonReader.BndqOejAmh((Enum1)65550);
			JsonReader.smethod_1((Enum1)65550, 34, new int[]
			{
				65552
			});
			JsonReader.smethod_1((Enum1)65550, 91, new int[]
			{
				65548
			});
			JsonReader.smethod_1((Enum1)65550, 123, new int[]
			{
				65544
			});
			JsonReader.smethod_1((Enum1)65550, 65537, new int[]
			{
				65537
			});
			JsonReader.smethod_1((Enum1)65550, 65538, new int[]
			{
				65538
			});
			JsonReader.smethod_1((Enum1)65550, 65539, new int[]
			{
				65539
			});
			JsonReader.smethod_1((Enum1)65550, 65540, new int[]
			{
				65540
			});
			JsonReader.BndqOejAmh((Enum1)65551);
			JsonReader.smethod_1((Enum1)65551, 44, new int[]
			{
				44,
				65550,
				65551
			});
			JsonReader.smethod_1((Enum1)65551, 93, new int[]
			{
				65554
			});
		}
		private static void smethod_1(Enum1 enum1_0, int int_2, params int[] symbols)
		{
			JsonReader.idictionary_0[(int)enum1_0].Add(int_2, symbols);
		}
		private static void BndqOejAmh(Enum1 enum1_0)
		{
			JsonReader.idictionary_0.Add((int)enum1_0, new Dictionary<int, int[]>());
		}
		private void method_0(string string_1)
		{
			double num;
			if ((string_1.IndexOf('.') != -1 || string_1.IndexOf('e') != -1 || string_1.IndexOf('E') != -1) && double.TryParse(string_1, out num))
			{
				this.jsonToken_0 = JsonToken.Double;
                this.string_0 = num.ToString();
			}
			else
			{
				int num2;
				if (int.TryParse(string_1, out num2))
				{
					this.jsonToken_0 = JsonToken.Int;
					this.string_0 = num2.ToString();
				}
				else
				{
					long num3;
					if (long.TryParse(string_1, out num3))
					{
						this.jsonToken_0 = JsonToken.Long;
						this.string_0 = num3.ToString();
					}
					else
					{
						this.jsonToken_0 = JsonToken.Int;
						this.string_0 ="0";
					}
				}
			}
		}
		private void method_1()
		{
			if (this.int_1 == 91)
			{
				this.jsonToken_0 = JsonToken.ArrayStart;
				this.bool_3 = true;
			}
			else
			{
				if (this.int_1 == 93)
				{
					this.jsonToken_0 = JsonToken.ArrayEnd;
					this.bool_3 = true;
				}
				else
				{
					if (this.int_1 == 123)
					{
						this.jsonToken_0 = JsonToken.ObjectStart;
						this.bool_3 = true;
					}
					else
					{
						if (this.int_1 == 125)
						{
							this.jsonToken_0 = JsonToken.ObjectEnd;
							this.bool_3 = true;
						}
						else
						{
							if (this.int_1 == 34)
							{
								if (this.bool_2)
								{
									this.bool_2 = false;
									this.bool_3 = true;
								}
								else
								{
									if (this.jsonToken_0 == JsonToken.None)
									{
										this.jsonToken_0 = JsonToken.String;
									}
									this.bool_2 = true;
								}
							}
							else
							{
								if (this.int_1 == 65541)
								{
									this.string_0 = this.class4_0.method_6();
								}
								else
								{
									if (this.int_1 == 65539)
									{
										this.jsonToken_0 = JsonToken.Boolean;
										this.string_0 = false.ToString();
										this.bool_3 = true;
									}
									else
									{
										if (this.int_1 == 65540)
										{
											this.jsonToken_0 = JsonToken.Null;
											this.bool_3 = true;
										}
										else
										{
											if (this.int_1 == 65537)
											{
												this.method_0(this.class4_0.method_6());
												this.bool_3 = true;
											}
											else
											{
												if (this.int_1 == 65546)
												{
													this.jsonToken_0 = JsonToken.PropertyName;
												}
												else
												{
													if (this.int_1 == 65538)
													{
														this.jsonToken_0 = JsonToken.Boolean;
														this.string_0 = true.ToString();
														this.bool_3 = true;
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
		private bool method_2()
		{
			bool result;
			if (this.bool_1)
			{
				result = false;
			}
			else
			{
				this.class4_0.method_9();
				if (this.class4_0.method_4())
				{
					this.Close();
					result = false;
				}
				else
				{
					this.int_0 = this.class4_0.method_5();
					result = true;
				}
			}
			return result;
		}
		public void Close()
		{
			if (!this.bool_1)
			{
				this.bool_1 = true;
				this.bool_0 = true;
				if (this.bool_5)
				{
					this.textReader_0.Close();
				}
				this.textReader_0 = null;
			}
		}
		public bool Read()
		{
			bool result;
			if (this.bool_1)
			{
				result = false;
			}
			else
			{
				if (this.bool_0)
				{
					this.bool_0 = false;
					this.stack_0.Clear();
					this.stack_0.Push(65553);
					this.stack_0.Push(65543);
				}
				this.bool_2 = false;
				this.bool_3 = false;
				this.jsonToken_0 = JsonToken.None;
				this.string_0 = null;
				if (!this.bool_4)
				{
					this.bool_4 = true;
					if (!this.method_2())
					{
						result = false;
						return result;
					}
				}
				while (!this.bool_3)
				{
					this.int_1 = this.stack_0.Pop();
					this.method_1();
					if (this.int_1 == this.int_0)
					{
						if (!this.method_2())
						{
							if (this.stack_0.Peek() != 65553)
							{
								throw new JsonException("Input doesn't evaluate to proper JSON text");
							}
							result = this.bool_3;
							return result;
						}
					}
					else
					{
						int[] array;
						try
						{
							array = JsonReader.idictionary_0[this.int_1][this.int_0];
						}
						catch (KeyNotFoundException inner_exception)
						{
							throw new JsonException((Enum1)this.int_0, inner_exception);
						}
						if (array[0] != 65554)
						{
							for (int i = array.Length - 1; i >= 0; i--)
							{
								this.stack_0.Push(array[i]);
							}
						}
					}
				}
				if (this.stack_0.Peek() == 65553)
				{
					this.bool_0 = true;
				}
				result = true;
			}
			return result;
		}
	}
}
