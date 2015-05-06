using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
namespace alipay_chongzhi
{
	public class HttpItem
	{
		private string string_0;
		private string string_1;
		private int int_0;
		private int int_1;
		private bool bool_0;
		private string string_2;
		private string string_3;
		private string string_4;
		private Encoding encoding_0;
		private PostDataType postDataType_0;
		private string string_5;
		private byte[] eLuVyMymc2;
		private WebProxy webProxy_0;
		private CookieCollection cookieCollection_0;
		private CookieContainer cookieContainer_0;
		private string string_6;
		private string string_7;
		private string string_8;
		private bool bool_1;
		private bool bool_2;
		private int int_2;
		private string string_9;
		private string string_10;
		private string string_11;
		private ResultType resultType_0;
		private WebHeaderCollection webHeaderCollection_0;
		private Version version_0;
		private bool bool_3;
		private X509CertificateCollection x509CertificateCollection_0;
		private Encoding encoding_1;
		private ResultCookieType resultCookieType_0;
		private ICredentials icredentials_0;
		public string URL
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
		public string Method
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
		public int Timeout
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}
		public int ReadWriteTimeout
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_1 = value;
			}
		}
		public bool KeepAlive
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}
		public string Accept
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
		public string ContentType
		{
			get
			{
				return this.string_3;
			}
			set
			{
				this.string_3 = value;
			}
		}
		public string UserAgent
		{
			get
			{
				return this.string_4;
			}
			set
			{
				this.string_4 = value;
			}
		}
		public Encoding Encoding
		{
			get
			{
				return this.encoding_0;
			}
			set
			{
				this.encoding_0 = value;
			}
		}
		public PostDataType PostDataType
		{
			get
			{
				return this.postDataType_0;
			}
			set
			{
				this.postDataType_0 = value;
			}
		}
		public string Postdata
		{
			get
			{
				return this.string_5;
			}
			set
			{
				this.string_5 = value;
			}
		}
		public byte[] PostdataByte
		{
			get
			{
				return this.eLuVyMymc2;
			}
			set
			{
				this.eLuVyMymc2 = value;
			}
		}
		public WebProxy WebProxy
		{
			get
			{
				return this.webProxy_0;
			}
			set
			{
				this.webProxy_0 = value;
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
		public CookieContainer CookieContainer
		{
			get
			{
				return this.cookieContainer_0;
			}
			set
			{
				this.cookieContainer_0 = value;
			}
		}
		public string Cookie
		{
			get
			{
				return this.string_6;
			}
			set
			{
				this.string_6 = value;
			}
		}
		public string Referer
		{
			get
			{
				return this.string_7;
			}
			set
			{
				this.string_7 = value;
			}
		}
		public string CerPath
		{
			get
			{
				return this.string_8;
			}
			set
			{
				this.string_8 = value;
			}
		}
		public bool IsToLower
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
		public bool Allowautoredirect
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
		public int Connectionlimit
		{
			get
			{
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
			}
		}
		public string ProxyUserName
		{
			get
			{
				return this.string_9;
			}
			set
			{
				this.string_9 = value;
			}
		}
		public string ProxyPwd
		{
			get
			{
				return this.string_10;
			}
			set
			{
				this.string_10 = value;
			}
		}
		public string ProxyIp
		{
			get
			{
				return this.string_11;
			}
			set
			{
				this.string_11 = value;
			}
		}
		public ResultType ResultType
		{
			get
			{
				return this.resultType_0;
			}
			set
			{
				this.resultType_0 = value;
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
		public Version ProtocolVersion
		{
			get
			{
				return this.version_0;
			}
			set
			{
				this.version_0 = value;
			}
		}
		public bool Expect100Continue
		{
			get
			{
				return this.bool_3;
			}
			set
			{
				this.bool_3 = value;
			}
		}
		public X509CertificateCollection ClentCertificates
		{
			get
			{
				return this.x509CertificateCollection_0;
			}
			set
			{
				this.x509CertificateCollection_0 = value;
			}
		}
		public Encoding PostEncoding
		{
			get
			{
				return this.encoding_1;
			}
			set
			{
				this.encoding_1 = value;
			}
		}
		public ResultCookieType ResultCookieType
		{
			get
			{
				return this.resultCookieType_0;
			}
			set
			{
				this.resultCookieType_0 = value;
			}
		}
		public ICredentials ICredentials
		{
			get
			{
				return this.icredentials_0;
			}
			set
			{
				this.icredentials_0 = value;
			}
		}
		public HttpItem()
		{
			Class16.cwDXy7Qz9AoPt();
			this.string_0 = string.Empty;
			this.string_1 = "GET";
			this.int_0 = 100000;
			this.int_1 = 30000;
			this.bool_0 = true;
			this.string_2 = "text/html, application/xhtml+xml, */*";
			this.string_3 = "text/html";
			this.string_4 = "Mozilla/5.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/5.0)";
			this.encoding_0 = null;
			this.postDataType_0 = PostDataType.String;
			this.string_5 = string.Empty;
			this.eLuVyMymc2 = null;
			this.cookieCollection_0 = null;
			this.cookieContainer_0 = null;
			this.string_6 = string.Empty;
			this.string_7 = string.Empty;
			this.string_8 = string.Empty;
			this.bool_1 = false;
			this.bool_2 = false;
			this.int_2 = 1024;
			this.string_9 = string.Empty;
			this.string_10 = string.Empty;
			this.string_11 = string.Empty;
			this.resultType_0 = ResultType.String;
			this.webHeaderCollection_0 = new WebHeaderCollection();
			this.bool_3 = true;
			this.resultCookieType_0 = ResultCookieType.String;
			this.icredentials_0 = CredentialCache.DefaultCredentials;
			
		}
	}
}
