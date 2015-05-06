using System;
namespace LitJson
{
	public class JsonException : ApplicationException
	{
		public JsonException()
		{
			Class16.cwDXy7Qz9AoPt();
			
		}
		internal JsonException(Enum1 token)
            :this(string.Format("Invalid token '{0}' in input string", token))
		{
			Class16.cwDXy7Qz9AoPt();
		}
		internal JsonException(Enum1 token, Exception inner_exception)
            :this(string.Format("Invalid token '{0}' in input string", token), inner_exception)
		{
			Class16.cwDXy7Qz9AoPt();
		}
		internal JsonException(int c):this(string.Format("Invalid character '{0}' in input string", (char)c))
		{
			Class16.cwDXy7Qz9AoPt();
		}
		internal JsonException(int c, Exception inner_exception):this(string.Format("Invalid character '{0}' in input string", (char)c), inner_exception)
		{
			Class16.cwDXy7Qz9AoPt();
		}
        public JsonException(string message)
            : base(message)
		{
			Class16.cwDXy7Qz9AoPt();
		}
		public JsonException(string message, Exception inner_exception)
            :base(message, inner_exception)
		{
			Class16.cwDXy7Qz9AoPt();
		}
	}
}
