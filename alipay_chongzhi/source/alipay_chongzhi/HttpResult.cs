using System;
using System.Net;
namespace alipay_chongzhi
{
	public class HttpResult
	{
		private string string_0;
		private CookieCollection cookieCollection_0;
		private string string_1;
		private byte[] byte_0;
		private WebHeaderCollection webHeaderCollection_0;
		private string string_2;
		private HttpStatusCode httpStatusCode_0;
		public string Cookie
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}
		public CookieCollection CookieCollection
		{
			get
			{
				return this.cookieCollection_0;
			}
			set
			{
				this.cookieCollection_0 = value;
			}
		}
		public string Html
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}
		public byte[] ResultByte
		{
			get
			{
				return this.byte_0;
			}
			set
			{
				this.byte_0 = value;
			}
		}
		public WebHeaderCollection Header
		{
			get
			{
				return this.webHeaderCollection_0;
			}
			set
			{
				this.webHeaderCollection_0 = value;
			}
		}
		public string StatusDescription
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}
		public HttpStatusCode StatusCode
		{
			get
			{
				return this.httpStatusCode_0;
			}
			set
			{
				this.httpStatusCode_0 = value;
			}
		}
		public HttpResult()
		{
			Class16.cwDXy7Qz9AoPt();
			
		}
	}
}
