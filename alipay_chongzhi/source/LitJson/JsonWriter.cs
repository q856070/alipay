using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
namespace LitJson
{
	public class JsonWriter
	{
		private static NumberFormatInfo numberFormatInfo_0;
		private Class2 class2_0;
		private Stack<Class2> stack_0;
		private bool bool_0;
		private char[] char_0;
		private int int_0;
		private int int_1;
		private StringBuilder stringBuilder_0;
		private bool bool_1;
		private bool bool_2;
		private TextWriter textWriter_0;
		public int IndentValue
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_0 = this.int_0 / this.int_1 * value;
				this.int_1 = value;
			}
		}
		public bool PrettyPrint
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
			}
		}
		public TextWriter TextWriter
		{
			get
			{
				return this.textWriter_0;
			}
		}
		public bool Validate
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
			}
		}
		static JsonWriter()
		{
			Class16.cwDXy7Qz9AoPt();
			JsonWriter.numberFormatInfo_0 = NumberFormatInfo.InvariantInfo;
		}
		public JsonWriter()
		{
			Class16.cwDXy7Qz9AoPt();
			
			this.stringBuilder_0 = new StringBuilder();
			this.textWriter_0 = new StringWriter(this.stringBuilder_0);
			this.method_1();
		}
		public JsonWriter(StringBuilder sb)
            :this(new StringWriter(sb))
		{
			Class16.cwDXy7Qz9AoPt();
		}
		public JsonWriter(TextWriter writer)
		{
			Class16.cwDXy7Qz9AoPt();
			
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			this.textWriter_0 = writer;
			this.method_1();
		}
		private void method_0(Enum0 enum0_0)
		{
			if (!this.class2_0.bool_2)
			{
				this.class2_0.int_0++;
			}
			if (this.bool_2)
			{
				if (this.bool_0)
				{
					throw new JsonException("A complete JSON symbol has already been written");
				}
				switch (enum0_0)
				{
				case (Enum0)0:
					if (!this.class2_0.bool_0)
					{
						throw new JsonException("Can't close an array here");
					}
					break;
				case (Enum0)1:
					if (!this.class2_0.bool_1 || this.class2_0.bool_2)
					{
						throw new JsonException("Can't close an object here");
					}
					break;
				case (Enum0)2:
					if (this.class2_0.bool_1 && !this.class2_0.bool_2)
					{
						throw new JsonException("Expected a property");
					}
					break;
				case (Enum0)3:
					if (!this.class2_0.bool_1 || this.class2_0.bool_2)
					{
						throw new JsonException("Can't add a property here");
					}
					break;
				case (Enum0)4:
					if (!this.class2_0.bool_0 && (!this.class2_0.bool_1 || !this.class2_0.bool_2))
					{
						throw new JsonException("Can't add a value here");
					}
					break;
				}
			}
		}
		private void method_1()
		{
			this.bool_0 = false;
			this.char_0 = new char[4];
			this.int_0 = 0;
			this.int_1 = 4;
			this.bool_1 = false;
			this.bool_2 = true;
			this.stack_0 = new Stack<Class2>();
			this.class2_0 = new Class2();
			this.stack_0.Push(this.class2_0);
		}
		private static void smethod_0(int int_2, char[] char_1)
		{
			for (int i = 0; i < 4; i++)
			{
				int num = int_2 % 16;
				if (num < 10)
				{
					char_1[3 - i] = (char)(48 + num);
				}
				else
				{
					char_1[3 - i] = (char)(65 + (num - 10));
				}
				int_2 >>= 4;
			}
		}
		private void method_2()
		{
			if (this.bool_1)
			{
				this.int_0 += this.int_1;
			}
		}
		private void method_3(string string_0)
		{
			if (this.bool_1 && !this.class2_0.bool_2)
			{
				for (int i = 0; i < this.int_0; i++)
				{
					this.textWriter_0.Write(' ');
				}
			}
			this.textWriter_0.Write(string_0);
		}
		private void method_4()
		{
			this.method_5(true);
		}
		private void method_5(bool bool_3)
		{
			if (bool_3 && !this.class2_0.bool_2 && this.class2_0.int_0 > 1)
			{
				this.textWriter_0.Write(',');
			}
			if (this.bool_1 && !this.class2_0.bool_2)
			{
				this.textWriter_0.Write('\n');
			}
		}
		private void method_6(string string_0)
		{
			this.method_3(string.Empty);
			this.textWriter_0.Write('"');
			int length = string_0.Length;
			int i = 0;
			while (i < length)
			{
				char c = string_0[i];
				switch (c)
				{
				case '\b':
					this.textWriter_0.Write("\\b");
					break;
				case '\t':
					this.textWriter_0.Write("\\t");
					break;
				case '\n':
					this.textWriter_0.Write("\\n");
					break;
				case '\v':
					goto IL_B7;
				case '\f':
					this.textWriter_0.Write("\\f");
					break;
				case '\r':
					this.textWriter_0.Write("\\r");
					break;
				default:
					if (c != '"' && c != '\\')
					{
						goto IL_B7;
					}
					this.textWriter_0.Write('\\');
					this.textWriter_0.Write(string_0[i]);
					break;
				}
				IL_11C:
				i++;
				continue;
				IL_B7:
				if (string_0[i] >= ' ' && string_0[i] <= '~')
				{
					this.textWriter_0.Write(string_0[i]);
					goto IL_11C;
				}
				this.textWriter_0.Write(string_0[i]);
				goto IL_11C;
			}
			this.textWriter_0.Write('"');
		}
		private void method_7()
		{
			if (this.bool_1)
			{
				this.int_0 -= this.int_1;
			}
		}
		public override string ToString()
		{
			string result;
			if (this.stringBuilder_0 == null)
			{
				result = string.Empty;
			}
			else
			{
				result = this.stringBuilder_0.ToString();
			}
			return result;
		}
		public void Reset()
		{
			this.bool_0 = false;
			this.stack_0.Clear();
			this.class2_0 = new Class2();
			this.stack_0.Push(this.class2_0);
			if (this.stringBuilder_0 != null)
			{
				this.stringBuilder_0.Remove(0, this.stringBuilder_0.Length);
			}
		}
		public void Write(bool boolean)
		{
			this.method_0((Enum0)4);
			this.method_4();
			this.method_3(boolean ? "true" : "false");
			this.class2_0.bool_2 = false;
		}
		public void Write(decimal number)
		{
			this.method_0((Enum0)4);
			this.method_4();
			this.method_3(Convert.ToString(number, JsonWriter.numberFormatInfo_0));
			this.class2_0.bool_2 = false;
		}
		public void Write(double number)
		{
			this.method_0((Enum0)4);
			this.method_4();
			string text = Convert.ToString(number, JsonWriter.numberFormatInfo_0);
			this.method_3(text);
			if (text.IndexOf('.') == -1 && text.IndexOf('E') == -1)
			{
				this.textWriter_0.Write(".0");
			}
			this.class2_0.bool_2 = false;
		}
		public void Write(int number)
		{
			this.method_0((Enum0)4);
			this.method_4();
			this.method_3(Convert.ToString(number, JsonWriter.numberFormatInfo_0));
			this.class2_0.bool_2 = false;
		}
		public void Write(long number)
		{
			this.method_0((Enum0)4);
			this.method_4();
			this.method_3(Convert.ToString(number, JsonWriter.numberFormatInfo_0));
			this.class2_0.bool_2 = false;
		}
		public void Write(string str)
		{
			this.method_0((Enum0)4);
			this.method_4();
			if (str == null)
			{
				this.method_3("null");
			}
			else
			{
				this.method_6(str);
			}
			this.class2_0.bool_2 = false;
		}
		[CLSCompliant(false)]
		public void Write(ulong number)
		{
			this.method_0((Enum0)4);
			this.method_4();
			this.method_3(Convert.ToString(number, JsonWriter.numberFormatInfo_0));
			this.class2_0.bool_2 = false;
		}
		public void WriteArrayEnd()
		{
			this.method_0((Enum0)0);
			this.method_5(false);
			this.stack_0.Pop();
			if (this.stack_0.Count == 1)
			{
				this.bool_0 = true;
			}
			else
			{
				this.class2_0 = this.stack_0.Peek();
				this.class2_0.bool_2 = false;
			}
			this.method_7();
			this.method_3("]");
		}
		public void WriteArrayStart()
		{
			this.method_0((Enum0)2);
			this.method_4();
			this.method_3("[");
			this.class2_0 = new Class2();
			this.class2_0.bool_0 = true;
			this.stack_0.Push(this.class2_0);
			this.method_2();
		}
		public void WriteObjectEnd()
		{
			this.method_0((Enum0)1);
			this.method_5(false);
			this.stack_0.Pop();
			if (this.stack_0.Count == 1)
			{
				this.bool_0 = true;
			}
			else
			{
				this.class2_0 = this.stack_0.Peek();
				this.class2_0.bool_2 = false;
			}
			this.method_7();
			this.method_3("}");
		}
		public void WriteObjectStart()
		{
			this.method_0((Enum0)2);
			this.method_4();
			this.method_3("{");
			this.class2_0 = new Class2();
			this.class2_0.bool_1 = true;
			this.stack_0.Push(this.class2_0);
			this.method_2();
		}
		public void WritePropertyName(string property_name)
		{
			this.method_0((Enum0)3);
			this.method_4();
			this.method_6(property_name);
			if (this.bool_1)
			{
				if (property_name.Length > this.class2_0.int_1)
				{
					this.class2_0.int_1 = property_name.Length;
				}
				for (int i = this.class2_0.int_1 - property_name.Length; i >= 0; i--)
				{
					this.textWriter_0.Write(' ');
				}
				this.textWriter_0.Write(": ");
			}
			else
			{
				this.textWriter_0.Write(':');
			}
			this.class2_0.bool_2 = true;
		}
	}
}
