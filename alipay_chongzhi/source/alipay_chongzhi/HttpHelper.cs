using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
namespace alipay_chongzhi
{
	public class HttpHelper
	{
		private static HttpHelper httpHelper_0;
		private Encoding encoding_0;
		private Encoding encoding_1;
		private HttpWebRequest httpWebRequest_0;
		private HttpWebResponse httpWebResponse_0;
		public static HttpHelper Helper
		{
			get
			{
				return HttpHelper.httpHelper_0;
			}
		}
		public HttpResult GetHtml(HttpItem item)
		{
			HttpResult httpResult = new HttpResult();
			HttpResult result;
			try
			{
				this.method_1(item);
			}
			catch (Exception ex)
			{
				httpResult = new HttpResult();
				httpResult.Cookie = string.Empty;
				httpResult.Header = null;
				httpResult.Html = ex.Message;
				httpResult.StatusDescription = "配置参数时出错：" + ex.Message;
				result = httpResult;
				return result;
			}
			try
			{
				using (this.httpWebResponse_0 = (HttpWebResponse)this.httpWebRequest_0.GetResponse())
				{
					httpResult.StatusCode = this.httpWebResponse_0.StatusCode;
					httpResult.StatusDescription = this.httpWebResponse_0.StatusDescription;
					httpResult.Header = this.httpWebResponse_0.Headers;
					if (this.httpWebResponse_0.Cookies != null)
					{
						httpResult.CookieCollection = this.httpWebResponse_0.Cookies;
					}
					if (this.httpWebResponse_0.Headers["set-cookie"] != null)
					{
						httpResult.Cookie = this.httpWebResponse_0.Headers["set-cookie"];
					}
					MemoryStream memoryStream = new MemoryStream();
					if (this.httpWebResponse_0.ContentEncoding != null && this.httpWebResponse_0.ContentEncoding.Equals("gzip", StringComparison.InvariantCultureIgnoreCase))
					{
						memoryStream = this.method_0(new GZipStream(this.httpWebResponse_0.GetResponseStream(), CompressionMode.Decompress));
					}
					else
					{
						memoryStream = this.method_0(this.httpWebResponse_0.GetResponseStream());
					}
					byte[] array = memoryStream.ToArray();
					memoryStream.Close();
					if (array != null & array.Length > 0)
					{
						if (item.ResultType == ResultType.Byte)
						{
							httpResult.ResultByte = array;
						}
						if (this.encoding_0 == null)
						{
							Match match = Regex.Match(Encoding.Default.GetString(array), "<meta([^<]*)charset=([^<]*)[\"']", RegexOptions.IgnoreCase);
							string text = (match.Groups.Count > 1) ? match.Groups[2].Value.ToLower().Trim() : string.Empty;
							if (text.Length > 2)
							{
								try
								{
									if (text.IndexOf(" ") > 0)
									{
										text = text.Substring(0, text.IndexOf(" "));
									}
									this.encoding_0 = Encoding.GetEncoding(text.Replace("\"", "").Replace("'", "").Replace(";", "").Replace("iso-8859-1", "gbk").Trim());
									goto IL_2F2;
								}
								catch
								{
									if (string.IsNullOrEmpty(this.httpWebResponse_0.CharacterSet))
									{
										this.encoding_0 = Encoding.UTF8;
									}
									else
									{
										this.encoding_0 = Encoding.GetEncoding(this.httpWebResponse_0.CharacterSet);
									}
									goto IL_2F2;
								}
							}
							if (string.IsNullOrEmpty(this.httpWebResponse_0.CharacterSet))
							{
								this.encoding_0 = Encoding.UTF8;
							}
							else
							{
								this.encoding_0 = Encoding.GetEncoding(this.httpWebResponse_0.CharacterSet);
							}
						}
						IL_2F2:
						httpResult.Html = this.encoding_0.GetString(array);
					}
					else
					{
						httpResult.Html = "本次请求并未返回任何数据";
					}
				}
			}
			catch (WebException ex2)
			{
				this.httpWebResponse_0 = (HttpWebResponse)ex2.Response;
				httpResult.Html = ex2.Message;
				if (this.httpWebResponse_0 != null)
				{
					using (Stream responseStream = this.httpWebResponse_0.GetResponseStream())
					{
						httpResult.Html = new StreamReader(responseStream).ReadToEnd();
					}
					httpResult.StatusCode = this.httpWebResponse_0.StatusCode;
					httpResult.StatusDescription = this.httpWebResponse_0.StatusDescription;
				}
			}
			catch (Exception ex)
			{
				httpResult.Html = ex.Message;
			}
			if (item.IsToLower)
			{
				httpResult.Html = httpResult.Html.ToLower();
			}
			result = httpResult;
			return result;
		}
		private MemoryStream method_0(Stream stream_0)
		{
			MemoryStream memoryStream = new MemoryStream();
			int count = 256;
			byte[] buffer = new byte[256];
			for (int i = stream_0.Read(buffer, 0, 256); i > 0; i = stream_0.Read(buffer, 0, count))
			{
				memoryStream.Write(buffer, 0, i);
			}
			return memoryStream;
		}
		private void method_1(HttpItem httpItem_0)
		{
			this.method_2(httpItem_0);
			if (httpItem_0.Header != null && httpItem_0.Header.Count > 0)
			{
				string[] allKeys = httpItem_0.Header.AllKeys;
				for (int i = 0; i < allKeys.Length; i++)
				{
					string name = allKeys[i];
					this.httpWebRequest_0.Headers.Add(name, httpItem_0.Header[name]);
				}
			}
			this.method_6(httpItem_0);
			if (httpItem_0.ProtocolVersion != null)
			{
				this.httpWebRequest_0.ProtocolVersion = httpItem_0.ProtocolVersion;
			}
			this.httpWebRequest_0.ServicePoint.Expect100Continue = httpItem_0.Expect100Continue;
			this.httpWebRequest_0.Method = httpItem_0.Method;
			this.httpWebRequest_0.Timeout = httpItem_0.Timeout;
			this.httpWebRequest_0.KeepAlive = httpItem_0.KeepAlive;
			this.httpWebRequest_0.ReadWriteTimeout = httpItem_0.ReadWriteTimeout;
			this.httpWebRequest_0.Accept = httpItem_0.Accept;
			this.httpWebRequest_0.ContentType = httpItem_0.ContentType;
			this.httpWebRequest_0.UserAgent = httpItem_0.UserAgent;
			this.encoding_0 = httpItem_0.Encoding;
			this.httpWebRequest_0.Credentials = httpItem_0.ICredentials;
			this.method_4(httpItem_0);
			this.httpWebRequest_0.Referer = httpItem_0.Referer;
			this.httpWebRequest_0.AllowAutoRedirect = httpItem_0.Allowautoredirect;
			this.method_5(httpItem_0);
			if (httpItem_0.Connectionlimit > 0)
			{
				this.httpWebRequest_0.ServicePoint.ConnectionLimit = httpItem_0.Connectionlimit;
			}
		}
		private void method_2(HttpItem httpItem_0)
		{
			if (!string.IsNullOrEmpty(httpItem_0.CerPath))
			{
				ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(this.CheckValidationResult);
				this.httpWebRequest_0 = (HttpWebRequest)WebRequest.Create(httpItem_0.URL);
				this.method_3(httpItem_0);
				this.httpWebRequest_0.ClientCertificates.Add(new X509Certificate(httpItem_0.CerPath));
			}
			else
			{
				this.httpWebRequest_0 = (HttpWebRequest)WebRequest.Create(httpItem_0.URL);
				this.method_3(httpItem_0);
			}
		}
		private void method_3(HttpItem httpItem_0)
		{
			if (httpItem_0.ClentCertificates != null && httpItem_0.ClentCertificates.Count > 0)
			{
				foreach (X509Certificate current in httpItem_0.ClentCertificates)
				{
					this.httpWebRequest_0.ClientCertificates.Add(current);
				}
			}
		}
		private void method_4(HttpItem httpItem_0)
		{
			if (!string.IsNullOrEmpty(httpItem_0.Cookie))
			{
				this.httpWebRequest_0.Headers[HttpRequestHeader.Cookie] = httpItem_0.Cookie;
			}
			if (httpItem_0.ResultCookieType == ResultCookieType.CookieCollection)
			{
				this.httpWebRequest_0.CookieContainer = new CookieContainer();
				if (httpItem_0.CookieCollection != null && httpItem_0.CookieCollection.Count > 0)
				{
					this.httpWebRequest_0.CookieContainer.Add(httpItem_0.CookieCollection);
				}
			}
			else
			{
				if (httpItem_0.ResultCookieType == ResultCookieType.CookieContainer && httpItem_0.CookieContainer != null)
				{
					this.httpWebRequest_0.CookieContainer = httpItem_0.CookieContainer;
				}
			}
		}
		private void method_5(HttpItem httpItem_0)
		{
			if (this.httpWebRequest_0.Method.Trim().ToLower().Contains("post"))
			{
				if (httpItem_0.PostEncoding != null)
				{
					this.encoding_1 = httpItem_0.PostEncoding;
				}
				byte[] array = null;
				if (httpItem_0.PostDataType == PostDataType.Byte && httpItem_0.PostdataByte != null && httpItem_0.PostdataByte.Length > 0)
				{
					array = httpItem_0.PostdataByte;
				}
				else
				{
					if (httpItem_0.PostDataType == PostDataType.FilePath && !string.IsNullOrEmpty(httpItem_0.Postdata))
					{
						StreamReader streamReader = new StreamReader(httpItem_0.Postdata, this.encoding_1);
						array = this.encoding_1.GetBytes(streamReader.ReadToEnd());
						streamReader.Close();
					}
					else
					{
						if (!string.IsNullOrEmpty(httpItem_0.Postdata))
						{
							array = this.encoding_1.GetBytes(httpItem_0.Postdata);
						}
					}
				}
				if (array != null)
				{
					this.httpWebRequest_0.ContentLength = (long)array.Length;
					this.httpWebRequest_0.GetRequestStream().Write(array, 0, array.Length);
				}
			}
		}
		private void method_6(HttpItem httpItem_0)
		{
			bool flag = false;
			if (!string.IsNullOrEmpty(httpItem_0.ProxyIp))
			{
				flag = httpItem_0.ProxyIp.ToLower().Contains("ieproxy");
			}
			if (!string.IsNullOrEmpty(httpItem_0.ProxyIp) && !flag)
			{
				if (httpItem_0.ProxyIp.Contains(":"))
				{
					string[] array = httpItem_0.ProxyIp.Split(new char[]
					{
						':'
					});
					WebProxy webProxy = new WebProxy(array[0].Trim(), Convert.ToInt32(array[1].Trim()));
					webProxy.Credentials = new NetworkCredential(httpItem_0.ProxyUserName, httpItem_0.ProxyPwd);
					this.httpWebRequest_0.Proxy = webProxy;
				}
				else
				{
					if (httpItem_0.ProxyIp != null)
					{
						WebProxy webProxy = new WebProxy(httpItem_0.ProxyIp, false);
						webProxy.Credentials = new NetworkCredential(httpItem_0.ProxyUserName, httpItem_0.ProxyPwd);
						this.httpWebRequest_0.Proxy = webProxy;
					}
				}
			}
			else
			{
				if (!flag && httpItem_0.WebProxy != null)
				{
					this.httpWebRequest_0.Proxy = httpItem_0.WebProxy;
				}
			}
		}
		public bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
		{
			return true;
		}
		public HttpHelper()
		{
			Class16.cwDXy7Qz9AoPt();
			this.encoding_0 = Encoding.Default;
			this.encoding_1 = Encoding.Default;
			this.httpWebRequest_0 = null;
			this.httpWebResponse_0 = null;
			
		}
		static HttpHelper()
		{
			Class16.cwDXy7Qz9AoPt();
			HttpHelper.httpHelper_0 = new HttpHelper();
		}
	}
}
