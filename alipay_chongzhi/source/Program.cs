using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using alipay_chongzhi;
internal partial class alipay
{
	[STAThread]
	private static void Main() {
        bool flag;
        new Mutex(true, "vspTcpServerOnlyRunOneInstance", out flag);
        if (!flag) {
            MessageBox.Show("程序已启动!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Application.Exit();
        } else {
            if (!Class10.smethod_9()) {
                throw new IOException("IO Error");
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Class16.cwDXy7Qz9AoPt();

            //var testDate = DateTime.Parse("2015-05-17");
            //if ((DateTime.Now - testDate).Days > 1) {
            //    System.Windows.Forms.MessageBox.Show("测试已过期");
            //    Application.Exit();
            //    return;
            //}
            Application.Run(new MainForm());
        }
	}
}
