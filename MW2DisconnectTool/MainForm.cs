using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW2DisconnectTool
{
    public partial class MainForm : Form
    {
        public static readonly string MW2DisconnectToolVersion = "1.1";
        public static string LocalIP = string.Empty;
        public static string currentHostIp = string.Empty;
        public static List<wfpBan> bannedHosts = new List<wfpBan>();

        public struct wfpBan
        {
            public string targetIp;
            public DateTime time;
            public Guid inputRuleGuid;
            public Guid outputRuleGuid;
        };

        private static readonly string[] kicktoolUrls =
        {
            "http://localhost:6535/jisopo/",
            "http://127.0.0.1:6535/jisopo/"
        };

        public static void removeAllIPBans()
        {
            foreach (var ban in bannedHosts)
            {
                jisopoWFP.removeRule(ban.inputRuleGuid);
                jisopoWFP.removeRule(ban.outputRuleGuid);
            }
        }

        public static void removeIpBan(string ip)
        {
            wfpBan findedBan = new wfpBan();
            bool ban_found = false;

            foreach (var ban in bannedHosts)
            {
                if(ban.targetIp == ip)
                {
                    jisopoWFP.removeRule(ban.inputRuleGuid);
                    jisopoWFP.removeRule(ban.outputRuleGuid);
                    ban_found = true;
                    findedBan = bannedHosts.ElementAt(bannedHosts.IndexOf(ban));
                    break;
                }
            }

            if (ban_found)
            {
                bannedHosts.Remove(findedBan);
            }
        }

        public static void banIp()
        {
            if(currentHostIp != string.Empty && !bannedHosts.Where(e => e.targetIp == currentHostIp).Any())
            {
                Guid newGuid = new Guid();
                Guid newGuid2 = new Guid();
                uint result = jisopoWFP.banIp(currentHostIp, ref newGuid, ref newGuid2);
                if (result != 0)
                {
                    MessageBox.Show($"Не удалось выполнить banIp, ошибка {result}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bannedHosts.Add(new wfpBan
                {
                    inputRuleGuid = newGuid,
                    outputRuleGuid = newGuid2,
                    time = DateTime.Now,
                    targetIp = currentHostIp
                });
            }
        }

        public MainForm()
        {
            InitializeComponent();

            this.Text = $"MW2DiconnectTool v{MW2DisconnectToolVersion}";

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            notifyIcon.Visible = true;

            Task snifferThread = new Task(() => sniffer.Init());
            snifferThread.Start();

            textBox_kicktool_url.Clear();
            foreach (var kickToolUrl in kicktoolUrls)
            {
                textBox_kicktool_url.AppendText($"{kickToolUrl}\n");
            }

            Task.Factory.StartNew(() =>
            {
                new HttpServer(kicktoolUrls);
            });

            uint result = jisopoWFP.WFPInit();
            if (result != 0)
            {
                MessageBox.Show(string.Format("Не удалось выполнить WFPInit, ошибка {0}", result), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            removeAllIPBans();
            
            if (jisopoWFP.WFPClose() != 0)
            {
                MessageBox.Show($"Не удалось выполнить WFPClose", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_copy_kicktool_url_Click(object sender, EventArgs e)
        {
            if (textBox_kicktool_url.Text != string.Empty)
            {
                string firstUrl = textBox_kicktool_url.Text.Split(new[] { '\n' }, StringSplitOptions.None).First();
                Clipboard.SetText(firstUrl);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem_action_Click(object sender, EventArgs e)
        {
            removeAllIPBans();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon.Visible = false;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon.Visible = true;
                this.ShowInTaskbar = false;
            }
        }
    }
}
