namespace MonBazou_ModManager_V2
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.mainMenu = new System.Windows.Forms.TabPage();
            this.versionlabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bepinexConfigButton = new System.Windows.Forms.Button();
            this.bepinexButton = new System.Windows.Forms.Button();
            this.bepinexLabel = new System.Windows.Forms.Label();
            this.installLocLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.changelogLabel = new System.Windows.Forms.Label();
            this.modsMenu = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.forceUpdateButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.reasonLabel = new System.Windows.Forms.Label();
            this.disabledLabel = new System.Windows.Forms.Label();
            this.deinstallButton = new System.Windows.Forms.Button();
            this.installButton = new System.Windows.Forms.Button();
            this.descTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.authorTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.releaseDateTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gameVersionTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.versionTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.helpMenu = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.steamLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.modsMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.helpMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.mainMenu);
            this.tabControl1.Controls.Add(this.modsMenu);
            this.tabControl1.Controls.Add(this.helpMenu);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(901, 482);
            this.tabControl1.TabIndex = 0;
            // 
            // mainMenu
            // 
            this.mainMenu.Controls.Add(this.steamLabel);
            this.mainMenu.Controls.Add(this.versionlabel);
            this.mainMenu.Controls.Add(this.label7);
            this.mainMenu.Controls.Add(this.button2);
            this.mainMenu.Controls.Add(this.button1);
            this.mainMenu.Controls.Add(this.bepinexConfigButton);
            this.mainMenu.Controls.Add(this.bepinexButton);
            this.mainMenu.Controls.Add(this.bepinexLabel);
            this.mainMenu.Controls.Add(this.installLocLabel);
            this.mainMenu.Controls.Add(this.textBox1);
            this.mainMenu.Controls.Add(this.changelogLabel);
            this.mainMenu.Location = new System.Drawing.Point(4, 22);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(3);
            this.mainMenu.Size = new System.Drawing.Size(893, 456);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "Main Menu";
            this.mainMenu.UseVisualStyleBackColor = true;
            // 
            // versionlabel
            // 
            this.versionlabel.AutoSize = true;
            this.versionlabel.Location = new System.Drawing.Point(195, 379);
            this.versionlabel.Name = "versionlabel";
            this.versionlabel.Size = new System.Drawing.Size(45, 13);
            this.versionlabel.TabIndex = 9;
            this.versionlabel.Text = "Version:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 395);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(300, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Mon Bazou Mod Manager --- Developed by Amenofisch#5368";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(149, 414);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(338, 33);
            this.button2.TabIndex = 7;
            this.button2.Text = "Official Mon Bazou Discord";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 414);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 33);
            this.button1.TabIndex = 6;
            this.button1.Text = "Check for Updates";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bepinexConfigButton
            // 
            this.bepinexConfigButton.Location = new System.Drawing.Point(186, 111);
            this.bepinexConfigButton.Name = "bepinexConfigButton";
            this.bepinexConfigButton.Size = new System.Drawing.Size(217, 27);
            this.bepinexConfigButton.TabIndex = 5;
            this.bepinexConfigButton.Text = "Open BepInEx Config Folder";
            this.bepinexConfigButton.UseVisualStyleBackColor = true;
            this.bepinexConfigButton.Click += new System.EventHandler(this.bepinexConfigButton_Click);
            // 
            // bepinexButton
            // 
            this.bepinexButton.Location = new System.Drawing.Point(7, 111);
            this.bepinexButton.Name = "bepinexButton";
            this.bepinexButton.Size = new System.Drawing.Size(173, 27);
            this.bepinexButton.TabIndex = 4;
            this.bepinexButton.Text = "Open BepInEx Folder";
            this.bepinexButton.UseVisualStyleBackColor = true;
            this.bepinexButton.Click += new System.EventHandler(this.bepinexButton_Click);
            // 
            // bepinexLabel
            // 
            this.bepinexLabel.AutoSize = true;
            this.bepinexLabel.Location = new System.Drawing.Point(7, 60);
            this.bepinexLabel.Name = "bepinexLabel";
            this.bepinexLabel.Size = new System.Drawing.Size(35, 13);
            this.bepinexLabel.TabIndex = 3;
            this.bepinexLabel.Text = "label2";
            // 
            // installLocLabel
            // 
            this.installLocLabel.AutoSize = true;
            this.installLocLabel.Location = new System.Drawing.Point(7, 15);
            this.installLocLabel.Name = "installLocLabel";
            this.installLocLabel.Size = new System.Drawing.Size(35, 13);
            this.installLocLabel.TabIndex = 2;
            this.installLocLabel.Text = "label2";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(493, 35);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(394, 412);
            this.textBox1.TabIndex = 1;
            // 
            // changelogLabel
            // 
            this.changelogLabel.AutoSize = true;
            this.changelogLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changelogLabel.Location = new System.Drawing.Point(641, 11);
            this.changelogLabel.Name = "changelogLabel";
            this.changelogLabel.Size = new System.Drawing.Size(95, 20);
            this.changelogLabel.TabIndex = 0;
            this.changelogLabel.Text = "Changelog";
            this.changelogLabel.Click += new System.EventHandler(this.changelogLabel_Click);
            // 
            // modsMenu
            // 
            this.modsMenu.Controls.Add(this.label10);
            this.modsMenu.Controls.Add(this.label9);
            this.modsMenu.Controls.Add(this.label8);
            this.modsMenu.Controls.Add(this.refreshButton);
            this.modsMenu.Controls.Add(this.forceUpdateButton);
            this.modsMenu.Controls.Add(this.listView1);
            this.modsMenu.Controls.Add(this.groupBox1);
            this.modsMenu.Location = new System.Drawing.Point(4, 22);
            this.modsMenu.Name = "modsMenu";
            this.modsMenu.Padding = new System.Windows.Forms.Padding(3);
            this.modsMenu.Size = new System.Drawing.Size(893, 456);
            this.modsMenu.TabIndex = 1;
            this.modsMenu.Text = "Mods";
            this.modsMenu.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Lime;
            this.label10.Location = new System.Drawing.Point(254, 381);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Installed";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Yellow;
            this.label9.Location = new System.Drawing.Point(149, 381);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Ready to Install";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Red;
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(81, 381);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Disabled";
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(229, 408);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(176, 39);
            this.refreshButton.TabIndex = 3;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // forceUpdateButton
            // 
            this.forceUpdateButton.Location = new System.Drawing.Point(7, 408);
            this.forceUpdateButton.Name = "forceUpdateButton";
            this.forceUpdateButton.Size = new System.Drawing.Size(170, 39);
            this.forceUpdateButton.TabIndex = 2;
            this.forceUpdateButton.Text = "Force Update";
            this.forceUpdateButton.UseVisualStyleBackColor = true;
            this.forceUpdateButton.Click += new System.EventHandler(this.forceUpdateButton_Click);
            // 
            // listView1
            // 
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(7, 7);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(398, 363);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.reasonLabel);
            this.groupBox1.Controls.Add(this.disabledLabel);
            this.groupBox1.Controls.Add(this.deinstallButton);
            this.groupBox1.Controls.Add(this.installButton);
            this.groupBox1.Controls.Add(this.descTextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.authorTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.releaseDateTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.gameVersionTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.versionTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Location = new System.Drawing.Point(423, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 440);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // reasonLabel
            // 
            this.reasonLabel.AutoSize = true;
            this.reasonLabel.Location = new System.Drawing.Point(10, 347);
            this.reasonLabel.Name = "reasonLabel";
            this.reasonLabel.Size = new System.Drawing.Size(47, 13);
            this.reasonLabel.TabIndex = 14;
            this.reasonLabel.Text = "Reason:";
            // 
            // disabledLabel
            // 
            this.disabledLabel.AutoSize = true;
            this.disabledLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disabledLabel.ForeColor = System.Drawing.Color.Red;
            this.disabledLabel.Location = new System.Drawing.Point(26, 297);
            this.disabledLabel.Name = "disabledLabel";
            this.disabledLabel.Size = new System.Drawing.Size(411, 31);
            this.disabledLabel.TabIndex = 13;
            this.disabledLabel.Text = "This Mod is currently disabled!";
            this.disabledLabel.Visible = false;
            // 
            // deinstallButton
            // 
            this.deinstallButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deinstallButton.Location = new System.Drawing.Point(237, 387);
            this.deinstallButton.Name = "deinstallButton";
            this.deinstallButton.Size = new System.Drawing.Size(221, 47);
            this.deinstallButton.TabIndex = 12;
            this.deinstallButton.Text = "Deinstall";
            this.deinstallButton.UseVisualStyleBackColor = true;
            this.deinstallButton.Click += new System.EventHandler(this.deinstallButton_Click);
            // 
            // installButton
            // 
            this.installButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installButton.Location = new System.Drawing.Point(10, 387);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(221, 47);
            this.installButton.TabIndex = 11;
            this.installButton.Text = "Install";
            this.installButton.UseVisualStyleBackColor = true;
            this.installButton.Click += new System.EventHandler(this.installButton_Click);
            // 
            // descTextBox
            // 
            this.descTextBox.Enabled = false;
            this.descTextBox.Location = new System.Drawing.Point(6, 139);
            this.descTextBox.Multiline = true;
            this.descTextBox.Name = "descTextBox";
            this.descTextBox.ReadOnly = true;
            this.descTextBox.Size = new System.Drawing.Size(452, 155);
            this.descTextBox.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(234, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Author:";
            // 
            // authorTextBox
            // 
            this.authorTextBox.Enabled = false;
            this.authorTextBox.Location = new System.Drawing.Point(237, 88);
            this.authorTextBox.Name = "authorTextBox";
            this.authorTextBox.ReadOnly = true;
            this.authorTextBox.Size = new System.Drawing.Size(221, 20);
            this.authorTextBox.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Release Date:";
            // 
            // releaseDateTextBox
            // 
            this.releaseDateTextBox.Enabled = false;
            this.releaseDateTextBox.Location = new System.Drawing.Point(6, 89);
            this.releaseDateTextBox.Name = "releaseDateTextBox";
            this.releaseDateTextBox.ReadOnly = true;
            this.releaseDateTextBox.Size = new System.Drawing.Size(225, 20);
            this.releaseDateTextBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(341, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Game Version:";
            // 
            // gameVersionTextBox
            // 
            this.gameVersionTextBox.Enabled = false;
            this.gameVersionTextBox.Location = new System.Drawing.Point(344, 41);
            this.gameVersionTextBox.Name = "gameVersionTextBox";
            this.gameVersionTextBox.ReadOnly = true;
            this.gameVersionTextBox.Size = new System.Drawing.Size(114, 20);
            this.gameVersionTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Version:";
            // 
            // versionTextBox
            // 
            this.versionTextBox.Enabled = false;
            this.versionTextBox.Location = new System.Drawing.Point(237, 41);
            this.versionTextBox.Name = "versionTextBox";
            this.versionTextBox.ReadOnly = true;
            this.versionTextBox.Size = new System.Drawing.Size(100, 20);
            this.versionTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Enabled = false;
            this.nameTextBox.Location = new System.Drawing.Point(6, 41);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(225, 20);
            this.nameTextBox.TabIndex = 0;
            // 
            // helpMenu
            // 
            this.helpMenu.Controls.Add(this.label1);
            this.helpMenu.Location = new System.Drawing.Point(4, 22);
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Padding = new System.Windows.Forms.Padding(3);
            this.helpMenu.Size = new System.Drawing.Size(893, 456);
            this.helpMenu.TabIndex = 2;
            this.helpMenu.Text = "Help";
            this.helpMenu.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(40, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(603, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "1. JOIN THE OFFICIAL DISCORD!\r\n2. FOLLOW THE FLOWCHART IN #MODS-FAQ";
            // 
            // steamLabel
            // 
            this.steamLabel.AutoSize = true;
            this.steamLabel.Location = new System.Drawing.Point(7, 95);
            this.steamLabel.Name = "steamLabel";
            this.steamLabel.Size = new System.Drawing.Size(35, 13);
            this.steamLabel.TabIndex = 10;
            this.steamLabel.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(925, 506);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mon Bazou - Mod Manager V2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.modsMenu.ResumeLayout(false);
            this.modsMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.helpMenu.ResumeLayout(false);
            this.helpMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage mainMenu;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label changelogLabel;
        private System.Windows.Forms.TabPage modsMenu;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage helpMenu;
        private System.Windows.Forms.Label bepinexLabel;
        private System.Windows.Forms.Label installLocLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bepinexConfigButton;
        private System.Windows.Forms.Button bepinexButton;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox versionTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox descTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox authorTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox releaseDateTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox gameVersionTextBox;
        private System.Windows.Forms.Label reasonLabel;
        private System.Windows.Forms.Label disabledLabel;
        private System.Windows.Forms.Button deinstallButton;
        private System.Windows.Forms.Button installButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button forceUpdateButton;
        private System.Windows.Forms.Label versionlabel;
        private System.Windows.Forms.Label steamLabel;
    }
}

