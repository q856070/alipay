using alipay_chongzhi;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
internal static class Class8
{
	internal static void smethod_0()
	{
		bool flag;
		new Mutex(true, "vspTcpServerOnlyRunOneInstance", out flag);
		if (!flag)
		{
			MessageBox.Show("程序已启动!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			Application.Exit();
		}
		else
		{
			if (!Class10.smethod_9())
			{
				throw new IOException("IO Error");
			}
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Class16.cwDXy7Qz9AoPt();
			Application.Run(new MainForm());
		}
	}
}
