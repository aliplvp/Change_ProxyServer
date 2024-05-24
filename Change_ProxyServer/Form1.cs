using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace Change_ProxyServer
{
    public partial class Form1 : Form
    {
        RegistryKey Internet_Settings = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_set_Click(object sender, EventArgs e)
        {
            string proxy = txt_IP.Text + ":" + txt_Port.Text;
            Internet_Settings.SetValue("ProxyEnable", 1);
            Internet_Settings.SetValue("ProxyServer", proxy);
            this.Text = "Change To " + proxy;
            System.Threading.Thread.Sleep(1000);
            Application.Exit();
        }

        private void btn_off_Click(object sender, EventArgs e)
        {
            Internet_Settings.SetValue("ProxyEnable", 0);
            this.Text = "Proxy Off...";
            System.Threading.Thread.Sleep(1000);
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ip = Internet_Settings.GetValue("ProxyServer").ToString();
            var new_ip = ip.Replace("http://", "");
            var parts = new_ip.Split(':');

            string ipAddress = parts[0];
            string port = parts[1];

            txt_IP.Text = ipAddress;
            txt_Port.Text = port;

            if ((int)Internet_Settings.GetValue("ProxyEnable", 1) == 1)
            {
                btn_off.Enabled = true;
                btn_set.Enabled = false;
            }
            else
            {
                btn_off.Enabled = false;
                btn_set.Enabled = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.aliplvp.ir/");
        }
    }
}
