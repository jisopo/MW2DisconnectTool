using System.Drawing;

namespace MW2DisconnectTool
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textBoxProgramGithubRepo = new System.Windows.Forms.TextBox();
            this.pictureBoxGithub = new System.Windows.Forms.PictureBox();
            this.textBoxAuthorSteam = new System.Windows.Forms.TextBox();
            this.pictureBoxSteam = new System.Windows.Forms.PictureBox();
            this.textBoxAutorEmail = new System.Windows.Forms.TextBox();
            this.pictureBoxEmail = new System.Windows.Forms.PictureBox();
            this.label_autor = new System.Windows.Forms.Label();
            this.textBox_kicktool_url = new System.Windows.Forms.RichTextBox();
            this.button_copy_kicktool_url = new System.Windows.Forms.Button();
            this.label_webbrowser_links = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.textBoxWeb = new System.Windows.Forms.TextBox();
            this.pictureBoxWeb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGithub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSteam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmail)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWeb)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxProgramGithubRepo
            // 
            this.textBoxProgramGithubRepo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxProgramGithubRepo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxProgramGithubRepo.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textBoxProgramGithubRepo.Location = new System.Drawing.Point(53, 168);
            this.textBoxProgramGithubRepo.Name = "textBoxProgramGithubRepo";
            this.textBoxProgramGithubRepo.ReadOnly = true;
            this.textBoxProgramGithubRepo.Size = new System.Drawing.Size(289, 13);
            this.textBoxProgramGithubRepo.TabIndex = 14;
            this.textBoxProgramGithubRepo.Text = "https://github.com/jisopo/MW2DisconnectTool";
            // 
            // pictureBoxGithub
            // 
            this.pictureBoxGithub.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxGithub.Image")));
            this.pictureBoxGithub.Location = new System.Drawing.Point(15, 159);
            this.pictureBoxGithub.Name = "pictureBoxGithub";
            this.pictureBoxGithub.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxGithub.TabIndex = 13;
            this.pictureBoxGithub.TabStop = false;
            // 
            // textBoxAuthorSteam
            // 
            this.textBoxAuthorSteam.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxAuthorSteam.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAuthorSteam.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textBoxAuthorSteam.Location = new System.Drawing.Point(53, 83);
            this.textBoxAuthorSteam.Name = "textBoxAuthorSteam";
            this.textBoxAuthorSteam.ReadOnly = true;
            this.textBoxAuthorSteam.Size = new System.Drawing.Size(289, 13);
            this.textBoxAuthorSteam.TabIndex = 12;
            this.textBoxAuthorSteam.Text = "https://steamcommunity.com/profiles/76561198028442050";
            // 
            // pictureBoxSteam
            // 
            this.pictureBoxSteam.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSteam.Image")));
            this.pictureBoxSteam.Location = new System.Drawing.Point(15, 73);
            this.pictureBoxSteam.Name = "pictureBoxSteam";
            this.pictureBoxSteam.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxSteam.TabIndex = 11;
            this.pictureBoxSteam.TabStop = false;
            // 
            // textBoxAutorEmail
            // 
            this.textBoxAutorEmail.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxAutorEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAutorEmail.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxAutorEmail.Location = new System.Drawing.Point(53, 46);
            this.textBoxAutorEmail.Name = "textBoxAutorEmail";
            this.textBoxAutorEmail.ReadOnly = true;
            this.textBoxAutorEmail.Size = new System.Drawing.Size(100, 13);
            this.textBoxAutorEmail.TabIndex = 10;
            this.textBoxAutorEmail.Text = "jisopo@mail.ru";
            // 
            // pictureBoxEmail
            // 
            this.pictureBoxEmail.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxEmail.Image")));
            this.pictureBoxEmail.Location = new System.Drawing.Point(15, 35);
            this.pictureBoxEmail.Name = "pictureBoxEmail";
            this.pictureBoxEmail.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxEmail.TabIndex = 9;
            this.pictureBoxEmail.TabStop = false;
            // 
            // label_autor
            // 
            this.label_autor.AutoSize = true;
            this.label_autor.Location = new System.Drawing.Point(12, 9);
            this.label_autor.Name = "label_autor";
            this.label_autor.Size = new System.Drawing.Size(68, 13);
            this.label_autor.TabIndex = 8;
            this.label_autor.Text = "Author jisopo";
            // 
            // textBox_kicktool_url
            // 
            this.textBox_kicktool_url.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_kicktool_url.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_kicktool_url.Location = new System.Drawing.Point(12, 237);
            this.textBox_kicktool_url.Name = "textBox_kicktool_url";
            this.textBox_kicktool_url.ReadOnly = true;
            this.textBox_kicktool_url.Size = new System.Drawing.Size(206, 77);
            this.textBox_kicktool_url.TabIndex = 27;
            this.textBox_kicktool_url.Text = "";
            // 
            // button_copy_kicktool_url
            // 
            this.button_copy_kicktool_url.Location = new System.Drawing.Point(158, 208);
            this.button_copy_kicktool_url.Name = "button_copy_kicktool_url";
            this.button_copy_kicktool_url.Size = new System.Drawing.Size(47, 23);
            this.button_copy_kicktool_url.TabIndex = 26;
            this.button_copy_kicktool_url.Text = "Copy";
            this.button_copy_kicktool_url.UseVisualStyleBackColor = true;
            this.button_copy_kicktool_url.Click += new System.EventHandler(this.button_copy_kicktool_url_Click);
            // 
            // label_webbrowser_links
            // 
            this.label_webbrowser_links.AutoSize = true;
            this.label_webbrowser_links.Location = new System.Drawing.Point(12, 211);
            this.label_webbrowser_links.Name = "label_webbrowser_links";
            this.label_webbrowser_links.Size = new System.Drawing.Size(140, 13);
            this.label_webbrowser_links.TabIndex = 28;
            this.label_webbrowser_links.Text = "Web browser links(use any):";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(93, 26);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "MW2 Disconnect Tool";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // textBoxWeb
            // 
            this.textBoxWeb.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxWeb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxWeb.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textBoxWeb.Location = new System.Drawing.Point(53, 124);
            this.textBoxWeb.Name = "textBoxWeb";
            this.textBoxWeb.ReadOnly = true;
            this.textBoxWeb.Size = new System.Drawing.Size(289, 13);
            this.textBoxWeb.TabIndex = 30;
            this.textBoxWeb.Text = "https://jisopo.github.io/MW2DisconnectTool.html";
            // 
            // pictureBoxWeb
            // 
            this.pictureBoxWeb.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxWeb.Image")));
            this.pictureBoxWeb.Location = new System.Drawing.Point(15, 115);
            this.pictureBoxWeb.Name = "pictureBoxWeb";
            this.pictureBoxWeb.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxWeb.TabIndex = 29;
            this.pictureBoxWeb.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 322);
            this.Controls.Add(this.textBoxWeb);
            this.Controls.Add(this.pictureBoxWeb);
            this.Controls.Add(this.label_webbrowser_links);
            this.Controls.Add(this.textBox_kicktool_url);
            this.Controls.Add(this.button_copy_kicktool_url);
            this.Controls.Add(this.textBoxProgramGithubRepo);
            this.Controls.Add(this.pictureBoxGithub);
            this.Controls.Add(this.textBoxAuthorSteam);
            this.Controls.Add(this.pictureBoxSteam);
            this.Controls.Add(this.textBoxAutorEmail);
            this.Controls.Add(this.pictureBoxEmail);
            this.Controls.Add(this.label_autor);
            this.MinimumSize = new System.Drawing.Size(395, 323);
            this.Name = "MainForm";
            this.Text = "MW2DiconnectTool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGithub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSteam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmail)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWeb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxProgramGithubRepo;
        private System.Windows.Forms.PictureBox pictureBoxGithub;
        private System.Windows.Forms.TextBox textBoxAuthorSteam;
        private System.Windows.Forms.PictureBox pictureBoxSteam;
        private System.Windows.Forms.TextBox textBoxAutorEmail;
        private System.Windows.Forms.PictureBox pictureBoxEmail;
        private System.Windows.Forms.Label label_autor;
        private System.Windows.Forms.RichTextBox textBox_kicktool_url;
        private System.Windows.Forms.Button button_copy_kicktool_url;
        private System.Windows.Forms.Label label_webbrowser_links;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.TextBox textBoxWeb;
        private System.Windows.Forms.PictureBox pictureBoxWeb;
    }
}

