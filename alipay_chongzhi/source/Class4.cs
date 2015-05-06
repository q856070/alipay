using LitJson;
using System;
using System.IO;
using System.Text;
internal class Class4
{
	private delegate bool Delegate2(Class3 ctx);
	private static int[] int_0;
	private static Class4.Delegate2[] delegate2_0;
	private bool bool_0;
	private bool bool_1;
	private bool bool_2;
	private Class3 class3_0;
	private int int_1;
	private int int_2;
	private TextReader textReader_0;
	private int int_3;
	private StringBuilder stringBuilder_0;
	private string string_0;
	private int int_4;
	private int int_5;
	public bool method_0()
	{
		return this.bool_0;
	}
	public void method_1(bool bool_3)
	{
		this.bool_0 = bool_3;
	}
	public bool method_2()
	{
		return this.bool_1;
	}
	public void method_3(bool bool_3)
	{
		this.bool_1 = bool_3;
	}
	public bool method_4()
	{
		return this.bool_2;
	}
	public int method_5()
	{
		return this.int_4;
	}
	public string method_6()
	{
		return this.string_0;
	}
	static Class4()
	{
		Class16.cwDXy7Qz9AoPt();
		Class4.smethod_1();
	}
	public Class4(TextReader textReader_1)
	{
		Class16.cwDXy7Qz9AoPt();
		
		this.bool_0 = true;
		this.bool_1 = true;
		this.int_1 = 0;
		this.stringBuilder_0 = new StringBuilder(128);
		this.int_3 = 1;
		this.bool_2 = false;
		this.textReader_0 = textReader_1;
		this.class3_0 = new Class3();
		this.class3_0.class4_0 = this;
	}
	private static int smethod_0(int int_6)
	{
		int result;
		switch (int_6)
		{
		case 65:
			break;
		case 66:
			goto IL_50;
		case 67:
			goto IL_55;
		case 68:
			goto IL_5A;
		case 69:
			goto IL_5F;
		case 70:
			goto IL_64;
		default:
			switch (int_6)
			{
			case 97:
				break;
			case 98:
				goto IL_50;
			case 99:
				goto IL_55;
			case 100:
				goto IL_5A;
			case 101:
				goto IL_5F;
			case 102:
				goto IL_64;
			default:
				result = int_6 - 48;
				return result;
			}
			break;
		}
		result = 10;
		return result;
		IL_50:
		result = 11;
		return result;
		IL_55:
		result = 12;
		return result;
		IL_5A:
		result = 13;
		return result;
		IL_5F:
		result = 14;
		return result;
		IL_64:
		result = 15;
		return result;
	}
	private static void smethod_1()
	{
		Class4.delegate2_0 = new Class4.Delegate2[]
		{
			new Class4.Delegate2(Class4.smethod_3),
			new Class4.Delegate2(Class4.smethod_4),
			new Class4.Delegate2(Class4.smethod_5),
			new Class4.Delegate2(Class4.smethod_6),
			new Class4.Delegate2(Class4.smethod_7),
			new Class4.Delegate2(Class4.smethod_8),
			new Class4.Delegate2(Class4.smethod_9),
			new Class4.Delegate2(Class4.smethod_10),
			new Class4.Delegate2(Class4.smethod_11),
			new Class4.Delegate2(Class4.smethod_12),
			new Class4.Delegate2(Class4.smethod_13),
			new Class4.Delegate2(Class4.smethod_14),
			new Class4.Delegate2(Class4.smethod_15),
			new Class4.Delegate2(Class4.smethod_16),
			new Class4.Delegate2(Class4.smethod_17),
			new Class4.Delegate2(Class4.smethod_18),
			new Class4.Delegate2(Class4.smethod_19),
			new Class4.Delegate2(Class4.smethod_20),
			new Class4.Delegate2(Class4.smethod_21),
			new Class4.Delegate2(Class4.smethod_22),
			new Class4.Delegate2(Class4.smethod_23),
			new Class4.Delegate2(Class4.smethod_24),
			new Class4.Delegate2(Class4.smethod_25),
			new Class4.Delegate2(Class4.smethod_26),
			new Class4.Delegate2(Class4.smethod_27),
			new Class4.Delegate2(Class4.smethod_28),
			new Class4.Delegate2(Class4.smethod_29),
			new Class4.Delegate2(Class4.smethod_30)
		};
		Class4.int_0 = new int[]
		{
			65542,
			0,
			65537,
			65537,
			0,
			65537,
			0,
			65537,
			0,
			0,
			65538,
			0,
			0,
			0,
			65539,
			0,
			0,
			65540,
			65541,
			65542,
			0,
			0,
			65541,
			65542,
			0,
			0,
			0,
			0
		};
	}
	private static char smethod_2(int int_6)
	{
		char result;
		if (int_6 <= 92)
		{
			if (int_6 <= 39)
			{
				if (int_6 != 34 && int_6 != 39)
				{
					goto IL_68;
				}
			}
			else
			{
				if (int_6 != 47 && int_6 != 92)
				{
					goto IL_68;
				}
			}
			result = Convert.ToChar(int_6);
			return result;
		}
		if (int_6 <= 102)
		{
			if (int_6 == 98)
			{
				result = '\b';
				return result;
			}
			if (int_6 == 102)
			{
				result = '\f';
				return result;
			}
		}
		else
		{
			if (int_6 == 110)
			{
				result = '\n';
				return result;
			}
			switch (int_6)
			{
			case 114:
				result = '\r';
				return result;
			case 116:
				result = '\t';
				return result;
			}
		}
		IL_68:
		result = '?';
		return result;
	}
	private static bool smethod_3(Class3 class3_1)
	{
		bool result;
		while (class3_1.class4_0.method_7())
		{
			if (class3_1.class4_0.int_2 != 32 && (class3_1.class4_0.int_2 < 9 || class3_1.class4_0.int_2 > 13))
			{
				if (class3_1.class4_0.int_2 >= 49 && class3_1.class4_0.int_2 <= 57)
				{
					class3_1.class4_0.stringBuilder_0.Append((char)class3_1.class4_0.int_2);
					class3_1.int_0 = 3;
					result = true;
				}
				else
				{
					int num = class3_1.class4_0.int_2;
					if (num <= 58)
					{
						if (num <= 39)
						{
							if (num == 34)
							{
								class3_1.int_0 = 19;
								class3_1.bool_0 = true;
								result = true;
								return result;
							}
							if (num == 39)
							{
								if (!class3_1.class4_0.bool_1)
								{
									result = false;
									return result;
								}
								class3_1.class4_0.int_2 = 34;
								class3_1.int_0 = 23;
								class3_1.bool_0 = true;
								result = true;
								return result;
							}
						}
						else
						{
							switch (num)
							{
							case 44:
								goto IL_1FF;
							case 45:
								class3_1.class4_0.stringBuilder_0.Append((char)class3_1.class4_0.int_2);
								class3_1.int_0 = 2;
								result = true;
								return result;
							case 46:
								break;
							case 47:
								if (!class3_1.class4_0.bool_0)
								{
									result = false;
									return result;
								}
								class3_1.int_0 = 25;
								result = true;
								return result;
							case 48:
								class3_1.class4_0.stringBuilder_0.Append((char)class3_1.class4_0.int_2);
								class3_1.int_0 = 4;
								result = true;
								return result;
							default:
								if (num == 58)
								{
									goto IL_1FF;
								}
								break;
							}
						}
					}
					else
					{
						if (num <= 102)
						{
							switch (num)
							{
							case 91:
							case 93:
								goto IL_1FF;
							case 92:
								break;
							default:
								if (num == 102)
								{
									class3_1.int_0 = 12;
									result = true;
									return result;
								}
								break;
							}
						}
						else
						{
							if (num == 110)
							{
								class3_1.int_0 = 16;
								result = true;
								return result;
							}
							if (num == 116)
							{
								class3_1.int_0 = 9;
								result = true;
								return result;
							}
							switch (num)
							{
							case 123:
							case 125:
								goto IL_1FF;
							}
						}
					}
					result = false;
					return result;
					IL_1FF:
					class3_1.int_0 = 1;
					class3_1.bool_0 = true;
					result = true;
				}
				return result;
			}
		}
		result = true;
		return result;
	}
	private static bool smethod_4(Class3 class3_1)
	{
		class3_1.class4_0.method_7();
		bool result;
		if (class3_1.class4_0.int_2 >= 49 && class3_1.class4_0.int_2 <= 57)
		{
			class3_1.class4_0.stringBuilder_0.Append((char)class3_1.class4_0.int_2);
			class3_1.int_0 = 3;
			result = true;
		}
		else
		{
			int num = class3_1.class4_0.int_2;
			if (num != 48)
			{
				result = false;
			}
			else
			{
				class3_1.class4_0.stringBuilder_0.Append((char)class3_1.class4_0.int_2);
				class3_1.int_0 = 4;
				result = true;
			}
		}
		return result;
	}
	private static bool smethod_5(Class3 class3_1)
	{
		bool result;
		while (class3_1.class4_0.method_7())
		{
			if (class3_1.class4_0.int_2 < 48 || class3_1.class4_0.int_2 > 57)
			{
				if (class3_1.class4_0.int_2 == 32 || (class3_1.class4_0.int_2 >= 9 && class3_1.class4_0.int_2 <= 13))
				{
					class3_1.bool_0 = true;
					class3_1.int_0 = 1;
					result = true;
				}
				else
				{
					int num = class3_1.class4_0.int_2;
					if (num <= 69)
					{
						switch (num)
						{
						case 44:
							goto IL_131;
						case 45:
							break;
						case 46:
							class3_1.class4_0.stringBuilder_0.Append((char)class3_1.class4_0.int_2);
							class3_1.int_0 = 5;
							result = true;
							return result;
						default:
							if (num == 69)
							{
								goto IL_109;
							}
							break;
						}
					}
					else
					{
						if (num == 93)
						{
							goto IL_131;
						}
						if (num == 101)
						{
							goto IL_109;
						}
						if (num == 125)
						{
							goto IL_131;
						}
					}
					result = false;
					return result;
					IL_109:
					class3_1.class4_0.stringBuilder_0.Append((char)class3_1.class4_0.int_2);
					class3_1.int_0 = 7;
					result = true;
					return result;
					IL_131:
					class3_1.class4_0.method_10();
					class3_1.bool_0 = true;
					class3_1.int_0 = 1;
					result = true;
				}
				return result;
			}
			class3_1.class4_0.stringBuilder_0.Append((char)class3_1.class4_0.int_2);
		}
		result = true;
		return result;
	}
	private static bool smethod_6(Class3 class3_1)
	{
		class3_1.class4_0.method_7();
		bool result;
		if (class3_1.class4_0.int_2 == 32 || (class3_1.class4_0.int_2 >= 9 && class3_1.class4_0.int_2 <= 13))
		{
			class3_1.bool_0 = true;
			class3_1.int_0 = 1;
			result = true;
		}
		else
		{
			int num = class3_1.class4_0.int_2;
			if (num <= 69)
			{
				switch (num)
				{
				case 44:
					goto IL_E6;
				case 45:
					break;
				case 46:
					class3_1.class4_0.stringBuilder_0.Append((char)class3_1.class4_0.int_2);
					class3_1.int_0 = 5;
					result = true;
					return result;
				default:
					if (num == 69)
					{
						goto IL_BE;
					}
					break;
				}
			}
			else
			{
				if (num == 93)
				{
					goto IL_E6;
				}
				if (num == 101)
				{
					goto IL_BE;
				}
				if (num == 125)
				{
					goto IL_E6;
				}
			}
			result = false;
			return result;
			IL_BE:
			class3_1.class4_0.stringBuilder_0.Append((char)class3_1.class4_0.int_2);
			class3_1.int_0 = 7;
			result = true;
			return result;
			IL_E6:
			class3_1.class4_0.method_10();
			class3_1.bool_0 = true;
			class3_1.int_0 = 1;
			result = true;
		}
		return result;
	}
	private static bool smethod_7(Class3 class3_1)
	{
		class3_1.class4_0.method_7();
		bool result;
		if (class3_1.class4_0.int_2 >= 48 && class3_1.class4_0.int_2 <= 57)
		{
			class3_1.class4_0.stringBuilder_0.Append((char)class3_1.class4_0.int_2);
			class3_1.int_0 = 6;
			result = true;
		}
		else
		{
			result = false;
		}
		return result;
	}
	private static bool smethod_8(Class3 class3_1)
	{
		bool result;
		while (class3_1.class4_0.method_7())
		{
			if (class3_1.class4_0.int_2 < 48 || class3_1.class4_0.int_2 > 57)
			{
				if (class3_1.class4_0.int_2 == 32 || (class3_1.class4_0.int_2 >= 9 && class3_1.class4_0.int_2 <= 13))
				{
					class3_1.bool_0 = true;
					class3_1.int_0 = 1;
					result = true;
				}
				else
				{
					int num = class3_1.class4_0.int_2;
					if (num <= 69)
					{
						if (num == 44)
						{
							goto IL_F6;
						}
						if (num == 69)
						{
							goto IL_CE;
						}
					}
					else
					{
						if (num == 93)
						{
							goto IL_F6;
						}
						if (num == 101)
						{
							goto IL_CE;
						}
						if (num == 125)
						{
							goto IL_F6;
						}
					}
					result = false;
					return result;
					IL_CE:
					class3_1.class4_0.stringBuilder_0.Append((char)class3_1.class4_0.int_2);
					class3_1.int_0 = 7;
					result = true;
					return result;
					IL_F6:
					class3_1.class4_0.method_10();
					class3_1.bool_0 = true;
					class3_1.int_0 = 1;
					result = true;
				}
				return result;
			}
			class3_1.class4_0.stringBuilder_0.Append((char)class3_1.class4_0.int_2);
		}
		result = true;
		return result;
	}
	private static bool smethod_9(Class3 class3_1)
	{
		class3_1.class4_0.method_7();
		bool result;
		if (class3_1.class4_0.int_2 < 48 || class3_1.class4_0.int_2 > 57)
		{
			switch (class3_1.class4_0.int_2)
			{
			case 43:
			case 45:
				class3_1.class4_0.stringBuilder_0.Append((char)class3_1.class4_0.int_2);
				class3_1.int_0 = 8;
				result = true;
				return result;
			case 44:
				//IL_78:
				result = false;
				return result;
			}
			//goto IL_78;
		}
		class3_1.class4_0.stringBuilder_0.Append((char)class3_1.class4_0.int_2);
		class3_1.int_0 = 8;
		result = true;
		return result;
	}
	private static bool smethod_10(Class3 class3_1)
	{
		bool result;
		while (class3_1.class4_0.method_7())
		{
			if (class3_1.class4_0.int_2 < 48 || class3_1.class4_0.int_2 > 57)
			{
				if (class3_1.class4_0.int_2 == 32 || (class3_1.class4_0.int_2 >= 9 && class3_1.class4_0.int_2 <= 13))
				{
					class3_1.bool_0 = true;
					class3_1.int_0 = 1;
					result = true;
				}
				else
				{
					int num = class3_1.class4_0.int_2;
					if (num != 44 && num != 93 && num != 125)
					{
						result = false;
					}
					else
					{
						class3_1.class4_0.method_10();
						class3_1.bool_0 = true;
						class3_1.int_0 = 1;
						result = true;
					}
				}
				return result;
			}
			class3_1.class4_0.stringBuilder_0.Append((char)class3_1.class4_0.int_2);
		}
		result = true;
		return result;
	}
	private static bool smethod_11(Class3 class3_1)
	{
		class3_1.class4_0.method_7();
		int num = class3_1.class4_0.int_2;
		bool result;
		if (num != 114)
		{
			result = false;
		}
		else
		{
			class3_1.int_0 = 10;
			result = true;
		}
		return result;
	}
	private static bool smethod_12(Class3 class3_1)
	{
		class3_1.class4_0.method_7();
		int num = class3_1.class4_0.int_2;
		bool result;
		if (num != 117)
		{
			result = false;
		}
		else
		{
			class3_1.int_0 = 11;
			result = true;
		}
		return result;
	}
	private static bool smethod_13(Class3 class3_1)
	{
		class3_1.class4_0.method_7();
		int num = class3_1.class4_0.int_2;
		bool result;
		if (num != 101)
		{
			result = false;
		}
		else
		{
			class3_1.bool_0 = true;
			class3_1.int_0 = 1;
			result = true;
		}
		return result;
	}
	private static bool smethod_14(Class3 class3_1)
	{
		class3_1.class4_0.method_7();
		int num = class3_1.class4_0.int_2;
		bool result;
		if (num != 97)
		{
			result = false;
		}
		else
		{
			class3_1.int_0 = 13;
			result = true;
		}
		return result;
	}
	private static bool smethod_15(Class3 class3_1)
	{
		class3_1.class4_0.method_7();
		int num = class3_1.class4_0.int_2;
		bool result;
		if (num != 108)
		{
			result = false;
		}
		else
		{
			class3_1.int_0 = 14;
			result = true;
		}
		return result;
	}
	private static bool smethod_16(Class3 class3_1)
	{
		class3_1.class4_0.method_7();
		int num = class3_1.class4_0.int_2;
		bool result;
		if (num != 115)
		{
			result = false;
		}
		else
		{
			class3_1.int_0 = 15;
			result = true;
		}
		return result;
	}
	private static bool smethod_17(Class3 class3_1)
	{
		class3_1.class4_0.method_7();
		int num = class3_1.class4_0.int_2;
		bool result;
		if (num != 101)
		{
			result = false;
		}
		else
		{
			class3_1.bool_0 = true;
			class3_1.int_0 = 1;
			result = true;
		}
		return result;
	}
	private static bool smethod_18(Class3 class3_1)
	{
		class3_1.class4_0.method_7();
		int num = class3_1.class4_0.int_2;
		bool result;
		if (num != 117)
		{
			result = false;
		}
		else
		{
			class3_1.int_0 = 17;
			result = true;
		}
		return result;
	}
	private static bool smethod_19(Class3 class3_1)
	{
		class3_1.class4_0.method_7();
		int num = class3_1.class4_0.int_2;
		bool result;
		if (num != 108)
		{
			result = false;
		}
		else
		{
			class3_1.int_0 = 18;
			result = true;
		}
		return result;
	}
	private static bool smethod_20(Class3 class3_1)
	{
		class3_1.class4_0.method_7();
		int num = class3_1.class4_0.int_2;
		bool result;
		if (num != 108)
		{
			result = false;
		}
		else
		{
			class3_1.bool_0 = true;
			class3_1.int_0 = 1;
			result = true;
		}
		return result;
	}
	private static bool smethod_21(Class3 class3_1)
	{
		bool result;
		while (class3_1.class4_0.method_7())
		{
			int num = class3_1.class4_0.int_2;
			if (num != 34)
			{
				if (num != 92)
				{
					class3_1.class4_0.stringBuilder_0.Append((char)class3_1.class4_0.int_2);
					continue;
				}
				class3_1.int_1 = 19;
				class3_1.int_0 = 21;
				result = true;
			}
			else
			{
				class3_1.class4_0.method_10();
				class3_1.bool_0 = true;
				class3_1.int_0 = 20;
				result = true;
			}
			return result;
		}
		result = true;
		return result;
	}
	private static bool smethod_22(Class3 class3_1)
	{
		class3_1.class4_0.method_7();
		int num = class3_1.class4_0.int_2;
		bool result;
		if (num != 34)
		{
			result = false;
		}
		else
		{
			class3_1.bool_0 = true;
			class3_1.int_0 = 1;
			result = true;
		}
		return result;
	}
	private static bool smethod_23(Class3 class3_1)
	{
		class3_1.class4_0.method_7();
		int num = class3_1.class4_0.int_2;
		bool result;
		if (num <= 92)
		{
			if (num <= 39)
			{
				if (num == 34 || num == 39)
				{
					goto IL_79;
				}
			}
			else
			{
				if (num == 47 || num == 92)
				{
					goto IL_79;
				}
			}
		}
		else
		{
			if (num <= 102)
			{
				if (num == 98 || num == 102)
				{
					goto IL_79;
				}
			}
			else
			{
				if (num == 110)
				{
					goto IL_79;
				}
				switch (num)
				{
				case 114:
				case 116:
					goto IL_79;
				case 117:
					class3_1.int_0 = 22;
					result = true;
					return result;
				}
			}
		}
		result = false;
		return result;
		IL_79:
		class3_1.class4_0.stringBuilder_0.Append(Class4.smethod_2(class3_1.class4_0.int_2));
		class3_1.int_0 = class3_1.int_1;
		result = true;
		return result;
	}
	private static bool smethod_24(Class3 class3_1)
	{
		int num = 0;
		int num2 = 4096;
		class3_1.class4_0.int_5 = 0;
		bool result;
		while (class3_1.class4_0.method_7())
		{
			if ((class3_1.class4_0.int_2 >= 48 && class3_1.class4_0.int_2 <= 57) || (class3_1.class4_0.int_2 >= 65 && class3_1.class4_0.int_2 <= 70) || (class3_1.class4_0.int_2 >= 97 && class3_1.class4_0.int_2 <= 102))
			{
				class3_1.class4_0.int_5 += Class4.smethod_0(class3_1.class4_0.int_2) * num2;
				num++;
				num2 /= 16;
				if (num != 4)
				{
					continue;
				}
				class3_1.class4_0.stringBuilder_0.Append(Convert.ToChar(class3_1.class4_0.int_5));
				class3_1.int_0 = class3_1.int_1;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
		result = true;
		return result;
	}
	private static bool smethod_25(Class3 class3_1)
	{
		bool result;
		while (class3_1.class4_0.method_7())
		{
			int num = class3_1.class4_0.int_2;
			if (num != 39)
			{
				if (num != 92)
				{
					class3_1.class4_0.stringBuilder_0.Append((char)class3_1.class4_0.int_2);
					continue;
				}
				class3_1.int_1 = 23;
				class3_1.int_0 = 21;
				result = true;
			}
			else
			{
				class3_1.class4_0.method_10();
				class3_1.bool_0 = true;
				class3_1.int_0 = 24;
				result = true;
			}
			return result;
		}
		result = true;
		return result;
	}
	private static bool smethod_26(Class3 class3_1)
	{
		class3_1.class4_0.method_7();
		int num = class3_1.class4_0.int_2;
		bool result;
		if (num != 39)
		{
			result = false;
		}
		else
		{
			class3_1.class4_0.int_2 = 34;
			class3_1.bool_0 = true;
			class3_1.int_0 = 1;
			result = true;
		}
		return result;
	}
	private static bool smethod_27(Class3 class3_1)
	{
		class3_1.class4_0.method_7();
		int num = class3_1.class4_0.int_2;
		bool result;
		if (num != 42)
		{
			if (num != 47)
			{
				result = false;
			}
			else
			{
				class3_1.int_0 = 26;
				result = true;
			}
		}
		else
		{
			class3_1.int_0 = 27;
			result = true;
		}
		return result;
	}
	private static bool smethod_28(Class3 class3_1)
	{
		bool result;
		while (class3_1.class4_0.method_7())
		{
			if (class3_1.class4_0.int_2 == 10)
			{
				class3_1.int_0 = 1;
				result = true;
				return result;
			}
		}
		result = true;
		return result;
	}
	private static bool smethod_29(Class3 class3_1)
	{
		bool result;
		while (class3_1.class4_0.method_7())
		{
			if (class3_1.class4_0.int_2 == 42)
			{
				class3_1.int_0 = 28;
				result = true;
				return result;
			}
		}
		result = true;
		return result;
	}
	private static bool smethod_30(Class3 class3_1)
	{
		bool result;
		while (class3_1.class4_0.method_7())
		{
			if (class3_1.class4_0.int_2 != 42)
			{
				if (class3_1.class4_0.int_2 == 47)
				{
					class3_1.int_0 = 1;
					result = true;
				}
				else
				{
					class3_1.int_0 = 27;
					result = true;
				}
				return result;
			}
		}
		result = true;
		return result;
	}
	private bool method_7()
	{
		bool result;
		if ((this.int_2 = this.method_8()) != -1)
		{
			result = true;
		}
		else
		{
			this.bool_2 = true;
			result = false;
		}
		return result;
	}
	private int method_8()
	{
		int result;
		if (this.int_1 != 0)
		{
			int num = this.int_1;
			this.int_1 = 0;
			result = num;
		}
		else
		{
			result = this.textReader_0.Read();
		}
		return result;
	}
	public bool method_9()
	{
		this.class3_0.bool_0 = false;
		while (true)
		{
			Class4.Delegate2 @delegate = Class4.delegate2_0[this.int_3 - 1];
			if (!@delegate(this.class3_0))
			{
				break;
			}
			if (this.bool_2)
			{
				goto IL_63;
			}
			if (this.class3_0.bool_0)
			{
				goto IL_67;
			}
			this.int_3 = this.class3_0.int_0;
		}
		throw new JsonException(this.int_2);
		IL_63:
		bool result = false;
		return result;
		IL_67:
		this.string_0 = this.stringBuilder_0.ToString();
		this.stringBuilder_0.Remove(0, this.stringBuilder_0.Length);
		this.int_4 = Class4.int_0[this.int_3 - 1];
		if (this.int_4 == 65542)
		{
			this.int_4 = this.int_2;
		}
		this.int_3 = this.class3_0.int_0;
		result = true;
		return result;
	}
	private void method_10()
	{
		this.int_1 = this.int_2;
	}
}
