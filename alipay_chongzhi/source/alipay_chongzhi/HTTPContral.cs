using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
namespace alipay_chongzhi
{
	public class HTTPContral
	{
		private static int int_0;
		private static string string_0;
		[CompilerGenerated]
		private static RemoteCertificateValidationCallback remoteCertificateValidationCallback_0;
		[CompilerGenerated]
		private static RemoteCertificateValidationCallback remoteCertificateValidationCallback_1;
		public int RunCount
		{
			get
			{
				return HTTPContral.int_0;
			}
		}
		public static string UserAgent
		{
			get
			{
				return HTTPContral.string_0;
			}
			set
			{
				HTTPContral.string_0 = value;
			}
		}
		public static string requestHtml(string Method, string URL, byte[] postBytes, string Referer, CookieContainer cookies, bool isAjax, string ForwardedIP, string string_1, bool Redirect)
		{
			HttpWebRequest httpWebRequest = null;
			HttpWebResponse httpWebResponse = null;
			Stream stream = null;
			Stream stream2 = null;
			string result;
			try
			{
				Interlocked.Increment(ref HTTPContral.int_0);
				if (URL.StartsWith("https", StringComparison.OrdinalIgnoreCase))
				{
					if (HTTPContral.remoteCertificateValidationCallback_0 == null)
					{
						HTTPContral.remoteCertificateValidationCallback_0 = new RemoteCertificateValidationCallback(HTTPContral.smethod_1);
					}
					ServicePointManager.ServerCertificateValidationCallback = HTTPContral.remoteCertificateValidationCallback_0;
				}
				httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
				Method = Method.ToUpper();
				httpWebRequest.Method = Method;
				if (Method == "POST")
				{
					httpWebRequest.ContentType = "application/x-www-form-urlencoded";
				}
				httpWebRequest.UserAgent = HTTPContral.string_0;
				if (isAjax)
				{
					httpWebRequest.Headers.Add("x-requested-with: XMLHttpRequest");
				}
				httpWebRequest.Accept = "application/json, text/javascript, */*";
				httpWebRequest.KeepAlive = false;
				httpWebRequest.Headers.Add("Accept-Encoding: gzip, deflate");
				httpWebRequest.AllowAutoRedirect = Redirect;
				if (string_1 != null)
				{
					httpWebRequest.Proxy = new WebProxy(string_1);
				}
				httpWebRequest.Proxy = null;
				if (cookies != null)
				{
					httpWebRequest.CookieContainer = cookies;
				}
				httpWebRequest.Timeout = 25000;
				if (Referer != null)
				{
					httpWebRequest.Referer = Referer;
				}
				if (ForwardedIP != null)
				{
					httpWebRequest.Headers.Add("X-Forwarded-For: " + ForwardedIP);
					httpWebRequest.Headers.Add("CLIENT_IP: " + ForwardedIP);
					httpWebRequest.Headers.Add("VIA: " + ForwardedIP);
					httpWebRequest.Headers.Add("REMOTE_ADDR: " + ForwardedIP);
				}
				if (Method == "POST" && postBytes != null && postBytes.Length > 0)
				{
					httpWebRequest.ContentLength = (long)postBytes.Length;
					stream = httpWebRequest.GetRequestStream();
					stream.Write(postBytes, 0, postBytes.Length);
					stream.Close();
					stream.Dispose();
					stream = null;
				}
				httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				if (!Redirect && httpWebResponse.Headers["Location"] != null)
				{
					result = httpWebResponse.Headers["Location"];
				}
				else
				{
					if (httpWebResponse.ContentEncoding == "deflate")
					{
						stream2 = new DeflateStream(httpWebResponse.GetResponseStream(), CompressionMode.Decompress);
					}
					if (httpWebResponse.ContentEncoding == "gzip")
					{
						stream2 = new GZipStream(httpWebResponse.GetResponseStream(), CompressionMode.Decompress);
					}
					else
					{
						stream2 = httpWebResponse.GetResponseStream();
					}
					MemoryStream memoryStream = new MemoryStream();
					int count = 256;
					byte[] buffer = new byte[256];
					for (int i = stream2.Read(buffer, 0, 256); i > 0; i = stream2.Read(buffer, 0, count))
					{
						memoryStream.Write(buffer, 0, i);
					}
					byte[] bytes = memoryStream.ToArray();
					memoryStream.Close();
					memoryStream.Dispose();
					Encoding encoding = Encoding.UTF8;
					Match match = Regex.Match(Encoding.Default.GetString(bytes), "<meta([^<]*)charset=([^<]*)[\"']", RegexOptions.IgnoreCase);
					string text = (match.Groups.Count > 1) ? match.Groups[2].Value.ToLower().Trim() : string.Empty;
					if (text.Length > 2)
					{
						try
						{
							if (text.IndexOf(" ") > 0)
							{
								text = text.Substring(0, text.IndexOf(" "));
							}
							encoding = Encoding.GetEncoding(text.Replace("\"", "").Replace("'", "").Replace(";", "").Replace("iso-8859-1", "gbk").Trim());
							goto IL_3E8;
						}
						catch
						{
							if (string.IsNullOrEmpty(httpWebResponse.CharacterSet))
							{
								encoding = Encoding.UTF8;
							}
							else
							{
								encoding = Encoding.GetEncoding(httpWebResponse.CharacterSet);
							}
							goto IL_3E8;
						}
					}
					if (string.IsNullOrEmpty(httpWebResponse.CharacterSet) || httpWebResponse.CharacterSet == "ISO-8859-1")
					{
						encoding = Encoding.UTF8;
					}
					else
					{
						encoding = Encoding.GetEncoding(httpWebResponse.CharacterSet);
					}
					IL_3E8:
					string @string = encoding.GetString(bytes);
					result = @string;
				}
			}
			catch (Exception ex)
			{
				HTTPContral.smethod_0(ex.ToString());
				throw ex;
			}
			finally
			{
				Interlocked.Decrement(ref HTTPContral.int_0);
				if (httpWebResponse != null)
				{
					httpWebResponse.Close();
				}
				if (httpWebRequest != null)
				{
					httpWebRequest.Abort();
					httpWebRequest = null;
				}
				if (stream != null)
				{
					stream.Close();
					stream.Dispose();
					stream = null;
				}
				if (stream2 != null)
				{
					stream2.Close();
					stream2.Dispose();
					stream2 = null;
				}
			}
			return result;
		}
		public static string getHtml(string URL, string Referer, CookieContainer Cookies, string string_1)
		{
			return HTTPContral.requestHtml("get", URL, null, Referer, Cookies, false, null, string_1, true);
		}
		public static string postHtml(string URL, string postStr, string Referer, CookieContainer Cookies, string string_1)
		{
			byte[] postBytes = null;
			if (!string.IsNullOrEmpty(postStr))
			{
				postBytes = Encoding.UTF8.GetBytes(postStr);
			}
			return HTTPContral.requestHtml("post", URL, postBytes, Referer, Cookies, false, null, string_1, true);
		}
		public static string postHtml(ref string URL, string postStr, string Referer, CookieContainer Cookies, string string_1)
		{
			byte[] postBytes = null;
			if (!string.IsNullOrEmpty(postStr))
			{
				postBytes = Encoding.UTF8.GetBytes(postStr);
			}
			string text = HTTPContral.requestHtml("post", URL, postBytes, Referer, Cookies, false, null, string_1, false);
			if (text.StartsWith("http"))
			{
				URL = text;
				text = HTTPContral.getHtml(URL, Referer, Cookies, string_1);
			}
			return text;
		}
		public static string postHtml(string URL, string postStr, string Referer, CookieContainer Cookies, string string_1, bool isAjax)
		{
			byte[] postBytes = null;
			if (!string.IsNullOrEmpty(postStr))
			{
				postBytes = Encoding.UTF8.GetBytes(postStr);
			}
			return HTTPContral.requestHtml("post", URL, postBytes, Referer, Cookies, isAjax, null, string_1, true);
		}
		public static string postHtml(string URL, string postStr, string Referer, CookieContainer Cookies, bool Redirect, string ForwardedIP)
		{
			byte[] postBytes = null;
			if (!string.IsNullOrEmpty(postStr))
			{
				postBytes = Encoding.UTF8.GetBytes(postStr);
			}
			return HTTPContral.requestHtml("post", URL, postBytes, Referer, Cookies, false, ForwardedIP, null, Redirect);
		}
		public static string postDate(string URL, byte[] postBytes, string Referer)
		{
			return HTTPContral.requestHtml("post", URL, postBytes, Referer, null, false, null, null, true);
		}
		public static string postFile(string URL, Dictionary<string, string> UpdataDic, string fileFormName, FileInfo fileinfo, string Referer, CookieContainer Cookies, string string_1)
		{
			if (fileinfo == null || !fileinfo.Exists)
			{
				throw new IOException("文件不存在");
			}
			byte[] array = null;
			using (FileStream fileStream = fileinfo.OpenRead())
			{
				array = new byte[fileinfo.Length];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
			}
			return HTTPContral.postFile(URL, UpdataDic, fileFormName, fileinfo.Name, "image/jpeg", array, Referer, Cookies, string_1);
		}
		public static string postFile(string URL, Dictionary<string, string> UpdataDic, string fileFormName, string FileName, string FileContentType, byte[] FileBytes, string Referer, CookieContainer Cookies, string string_1)
		{
			HttpWebRequest httpWebRequest = null;
			HttpWebResponse httpWebResponse = null;
			Stream stream = null;
			Stream stream2 = null;
			Encoding encoding = Encoding.GetEncoding("GBK");
			string result;
			try
			{
				Interlocked.Increment(ref HTTPContral.int_0);
				if (URL.StartsWith("https", StringComparison.OrdinalIgnoreCase))
				{
					if (HTTPContral.remoteCertificateValidationCallback_1 == null)
					{
						HTTPContral.remoteCertificateValidationCallback_1 = new RemoteCertificateValidationCallback(HTTPContral.smethod_2);
					}
					ServicePointManager.ServerCertificateValidationCallback = HTTPContral.remoteCertificateValidationCallback_1;
				}
				httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
				httpWebRequest.Method = "POST";
				string str = "----------" + DateTime.Now.Ticks.ToString("x");
				httpWebRequest.ContentType = "multipart/form-data; boundary=" + str;
				httpWebRequest.UserAgent = HTTPContral.string_0;
				httpWebRequest.Accept = "application/json, text/javascript, */*";
				httpWebRequest.KeepAlive = false;
				httpWebRequest.Headers.Add("Accept-Encoding: gzip, deflate");
				if (string_1 != null)
				{
					httpWebRequest.Proxy = new WebProxy(string_1);
				}
				if (Cookies != null)
				{
					httpWebRequest.CookieContainer = Cookies;
				}
				httpWebRequest.Timeout = 25000;
				if (Referer != null)
				{
					httpWebRequest.Referer = Referer;
				}
				stream = httpWebRequest.GetRequestStream();
				string str2 = "--" + str;
				string text = "";
				foreach (string current in UpdataDic.Keys)
				{
					text = text + str2 + "\r\n";
					text = text + "Content-Disposition: form-data; name=\"" + current + "\"\r\n\r\n";
					text = text + UpdataDic[current] + "\r\n";
				}
				text = text + str2 + "\r\n";
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					"Content-Disposition: form-data; name=\"",
					fileFormName,
					"\"; filename=\"",
					FileName,
					"\"\r\n"
				});
				if (string.IsNullOrEmpty(FileContentType))
				{
					FileContentType = "application/octet-stream";
				}
				text = text + "Content-Type: " + FileContentType + "\r\n\r\n";
				byte[] bytes = encoding.GetBytes(text);
				stream.Write(bytes, 0, bytes.Length);
				stream.Write(FileBytes, 0, FileBytes.Length);
				byte[] bytes2 = encoding.GetBytes("\r\n" + str2 + "--");
				stream.Write(bytes2, 0, bytes2.Length);
				stream.Close();
				stream.Dispose();
				stream = null;
				httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				if (httpWebResponse.ContentEncoding == "deflate")
				{
					stream2 = new DeflateStream(httpWebResponse.GetResponseStream(), CompressionMode.Decompress);
				}
				if (httpWebResponse.ContentEncoding == "gzip")
				{
					stream2 = new GZipStream(httpWebResponse.GetResponseStream(), CompressionMode.Decompress);
				}
				else
				{
					stream2 = httpWebResponse.GetResponseStream();
				}
				MemoryStream memoryStream = new MemoryStream();
				int count = 256;
				byte[] buffer = new byte[256];
				for (int i = stream2.Read(buffer, 0, 256); i > 0; i = stream2.Read(buffer, 0, count))
				{
					memoryStream.Write(buffer, 0, i);
				}
				byte[] bytes3 = memoryStream.ToArray();
				memoryStream.Close();
				memoryStream.Dispose();
				Encoding encoding2 = Encoding.UTF8;
				Match match = Regex.Match(Encoding.Default.GetString(bytes3), "<meta([^<]*)charset=([^<]*)[\"']", RegexOptions.IgnoreCase);
				string text3 = (match.Groups.Count > 1) ? match.Groups[2].Value.ToLower().Trim() : string.Empty;
				if (text3.Length > 2)
				{
					try
					{
						if (text3.IndexOf(" ") > 0)
						{
							text3 = text3.Substring(0, text3.IndexOf(" "));
						}
						encoding2 = Encoding.GetEncoding(text3.Replace("\"", "").Replace("'", "").Replace(";", "").Replace("iso-8859-1", "gbk").Trim());
						goto IL_46B;
					}
					catch
					{
						if (string.IsNullOrEmpty(httpWebResponse.CharacterSet))
						{
							encoding2 = Encoding.UTF8;
						}
						else
						{
							encoding2 = Encoding.GetEncoding(httpWebResponse.CharacterSet);
						}
						goto IL_46B;
					}
				}
				if (string.IsNullOrEmpty(httpWebResponse.CharacterSet) || httpWebResponse.CharacterSet == "ISO-8859-1")
				{
					encoding2 = Encoding.UTF8;
				}
				else
				{
					encoding2 = Encoding.GetEncoding(httpWebResponse.CharacterSet);
				}
				IL_46B:
				string @string = encoding2.GetString(bytes3);
				result = @string;
			}
			catch (Exception ex)
			{
				HTTPContral.smethod_0(ex.ToString());
				throw ex;
			}
			finally
			{
				Interlocked.Decrement(ref HTTPContral.int_0);
				if (httpWebResponse != null)
				{
					httpWebResponse.Close();
				}
				if (httpWebRequest != null)
				{
					httpWebRequest.Abort();
					httpWebRequest = null;
				}
				if (stream != null)
				{
					stream.Close();
					stream.Dispose();
					stream = null;
				}
				if (stream2 != null)
				{
					stream2.Close();
					stream2.Dispose();
					stream2 = null;
				}
			}
			return result;
		}
		public static long GetTimeLikeJS()
		{
			return ((DateTime.Now - new TimeSpan(8, 0, 0)).Ticks - 621355968000000000L) / 10000L;
		}
		private static void smethod_0(string string_1)
		{
			try
			{
				StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\http_error.log", true);
				streamWriter.WriteLine(DateTime.Now.ToString("yyyy:M:d HH:mm:ss") + string_1);
				streamWriter.WriteLine("------------------------------------分割线------------------------------------");
				streamWriter.Close();
				streamWriter.Dispose();
			}
			catch (Exception)
			{
			}
		}
		public HTTPContral()
		{
			Class16.cwDXy7Qz9AoPt();
			
		}
		[CompilerGenerated]
		private static bool smethod_1(object object_0, X509Certificate x509Certificate_0, X509Chain x509Chain_0, SslPolicyErrors sslPolicyErrors_0)
		{
			return true;
		}
		[CompilerGenerated]
		private static bool smethod_2(object object_0, X509Certificate x509Certificate_0, X509Chain x509Chain_0, SslPolicyErrors sslPolicyErrors_0)
		{
			return true;
		}
		static HTTPContral()
		{
			Class16.cwDXy7Qz9AoPt();
			HTTPContral.int_0 = 0;
			HTTPContral.string_0 = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; Trident/4.0)";
		}
	}
}
