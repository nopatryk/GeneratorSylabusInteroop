using GeneratorSylabus.Properties;
using System.Windows.Forms;

namespace GeneratorSylabus
{
    partial class Main
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
                conn.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.unsucesfullPanel = new System.Windows.Forms.Panel();
            this.connectionIcon = new System.Windows.Forms.PictureBox();
            this.succesPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.listViewSylabus = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.currmoduleeText = new System.Windows.Forms.Label();
            this.listOfmodulees = new System.Windows.Forms.ComboBox();
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.saveSettings = new System.Windows.Forms.Button();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.loginBox = new System.Windows.Forms.TextBox();
            this.databaseName = new System.Windows.Forms.TextBox();
            this.ipBox = new System.Windows.Forms.MaskedTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.sylabusPanel = new System.Windows.Forms.Panel();
            this.filesList = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.deleteFile = new System.Windows.Forms.Button();
            this.searchSylabus = new System.Windows.Forms.TextBox();
            this.settingsBtn = new System.Windows.Forms.Button();
            this.sylabusBtn = new System.Windows.Forms.Button();
            this.mainBtn = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.unsucesfullPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectionIcon)).BeginInit();
            this.succesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.settingsPanel.SuspendLayout();
            this.sylabusPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.InfoText;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(200, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 70);
            this.button1.TabIndex = 0;
            this.button1.Text = "GENERUJ SYLABUS";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.button1.MouseHover += new System.EventHandler(this.button1_MouseHover);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(1, 460);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(848, 21);
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Brak połączenia";
            // 
            // unsucesfullPanel
            // 
            this.unsucesfullPanel.BackColor = System.Drawing.Color.Transparent;
            this.unsucesfullPanel.Controls.Add(this.label2);
            this.unsucesfullPanel.Controls.Add(this.connectionIcon);
            this.unsucesfullPanel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.unsucesfullPanel.Location = new System.Drawing.Point(678, 2);
            this.unsucesfullPanel.Name = "unsucesfullPanel";
            this.unsucesfullPanel.Size = new System.Drawing.Size(129, 23);
            this.unsucesfullPanel.TabIndex = 10;
            this.unsucesfullPanel.Visible = false;
            // 
            // connectionIcon
            // 
            this.connectionIcon.Image = global::GeneratorSylabus.Properties.Resources.red1;
            this.connectionIcon.Location = new System.Drawing.Point(113, 4);
            this.connectionIcon.Name = "connectionIcon";
            this.connectionIcon.Size = new System.Drawing.Size(13, 13);
            this.connectionIcon.TabIndex = 9;
            this.connectionIcon.TabStop = false;
            this.connectionIcon.Click += new System.EventHandler(this.connectionIcon_Click);
            // 
            // succesPanel
            // 
            this.succesPanel.BackColor = System.Drawing.Color.Transparent;
            this.succesPanel.Controls.Add(this.label3);
            this.succesPanel.Controls.Add(this.pictureBox1);
            this.succesPanel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.succesPanel.Location = new System.Drawing.Point(698, 2);
            this.succesPanel.Name = "succesPanel";
            this.succesPanel.Size = new System.Drawing.Size(109, 23);
            this.succesPanel.TabIndex = 11;
            this.succesPanel.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point(18, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Połączono";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox1.Image = global::GeneratorSylabus.Properties.Resources.green;
            this.pictureBox1.Location = new System.Drawing.Point(96, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(13, 16);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.listViewSylabus);
            this.mainPanel.Controls.Add(this.currmoduleeText);
            this.mainPanel.Controls.Add(this.listOfmodulees);
            this.mainPanel.Controls.Add(this.button1);
            this.mainPanel.Location = new System.Drawing.Point(216, 25);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(615, 430);
            this.mainPanel.TabIndex = 14;
            // 
            // listViewSylabus
            // 
            this.listViewSylabus.AllowColumnReorder = true;
            this.listViewSylabus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewSylabus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewSylabus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listViewSylabus.FullRowSelect = true;
            this.listViewSylabus.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewSylabus.Location = new System.Drawing.Point(34, 92);
            this.listViewSylabus.MultiSelect = false;
            this.listViewSylabus.Name = "listViewSylabus";
            this.listViewSylabus.Size = new System.Drawing.Size(560, 200);
            this.listViewSylabus.TabIndex = 17;
            this.listViewSylabus.UseCompatibleStateImageBehavior = false;
            this.listViewSylabus.View = System.Windows.Forms.View.Details;
            this.listViewSylabus.SelectedIndexChanged += new System.EventHandler(this.listViewSylabus_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Moduł";
            this.columnHeader1.Width = 292;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Semestr";
            this.columnHeader2.Width = 72;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tryb studiów";
            this.columnHeader3.Width = 192;
            // 
            // currmoduleeText
            // 
            this.currmoduleeText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.currmoduleeText.Location = new System.Drawing.Point(0, 307);
            this.currmoduleeText.Name = "currmoduleeText";
            this.currmoduleeText.Size = new System.Drawing.Size(615, 23);
            this.currmoduleeText.TabIndex = 14;
            this.currmoduleeText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listOfmodulees
            // 
            this.listOfmodulees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.listOfmodulees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listOfmodulees.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.listOfmodulees.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listOfmodulees.FormattingEnabled = true;
            this.listOfmodulees.Location = new System.Drawing.Point(34, 49);
            this.listOfmodulees.Name = "listOfmodulees";
            this.listOfmodulees.Size = new System.Drawing.Size(554, 29);
            this.listOfmodulees.TabIndex = 13;
            this.listOfmodulees.SelectedIndexChanged += new System.EventHandler(this.listOfmodulees_SelectedIndexChanged);
            // 
            // settingsPanel
            // 
            this.settingsPanel.Controls.Add(this.portTextBox);
            this.settingsPanel.Controls.Add(this.saveSettings);
            this.settingsPanel.Controls.Add(this.passwordBox);
            this.settingsPanel.Controls.Add(this.loginBox);
            this.settingsPanel.Controls.Add(this.databaseName);
            this.settingsPanel.Controls.Add(this.ipBox);
            this.settingsPanel.Controls.Add(this.checkBox1);
            this.settingsPanel.Controls.Add(this.label4);
            this.settingsPanel.Controls.Add(this.label6);
            this.settingsPanel.Controls.Add(this.label7);
            this.settingsPanel.Controls.Add(this.label8);
            this.settingsPanel.Location = new System.Drawing.Point(216, 30);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(507, 385);
            this.settingsPanel.TabIndex = 3;
            this.settingsPanel.Visible = false;
            // 
            // portTextBox
            // 
            this.portTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.portTextBox.Location = new System.Drawing.Point(158, 87);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(65, 23);
            this.portTextBox.TabIndex = 23;
            this.portTextBox.Text = global::GeneratorSylabus.Properties.Settings.Default.port;
            // 
            // saveSettings
            // 
            this.saveSettings.BackColor = System.Drawing.Color.Black;
            this.saveSettings.FlatAppearance.BorderSize = 0;
            this.saveSettings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saveSettings.ForeColor = System.Drawing.Color.White;
            this.saveSettings.Location = new System.Drawing.Point(330, 304);
            this.saveSettings.Name = "saveSettings";
            this.saveSettings.Size = new System.Drawing.Size(98, 49);
            this.saveSettings.TabIndex = 22;
            this.saveSettings.Text = "Zapisz";
            this.saveSettings.UseVisualStyleBackColor = false;
            this.saveSettings.Click += new System.EventHandler(this.saveSettings_Click);
            // 
            // passwordBox
            // 
            this.passwordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.passwordBox.Location = new System.Drawing.Point(251, 250);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(177, 23);
            this.passwordBox.TabIndex = 21;
            this.passwordBox.Text = global::GeneratorSylabus.Properties.Settings.Default.password;
            this.passwordBox.UseSystemPasswordChar = true;
            // 
            // loginBox
            // 
            this.loginBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.loginBox.Location = new System.Drawing.Point(251, 202);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(177, 23);
            this.loginBox.TabIndex = 20;
            this.loginBox.Text = global::GeneratorSylabus.Properties.Settings.Default.login;
            // 
            // databaseName
            // 
            this.databaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.databaseName.Location = new System.Drawing.Point(251, 87);
            this.databaseName.Name = "databaseName";
            this.databaseName.Size = new System.Drawing.Size(177, 23);
            this.databaseName.TabIndex = 19;
            this.databaseName.Text = global::GeneratorSylabus.Properties.Settings.Default.dbName;
            // 
            // ipBox
            // 
            this.ipBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ipBox.Location = new System.Drawing.Point(46, 87);
            this.ipBox.Mask = "###\\.###\\.###\\.###";
            this.ipBox.Name = "ipBox";
            this.ipBox.Size = new System.Drawing.Size(106, 23);
            this.ipBox.TabIndex = 18;
            this.ipBox.Text = global::GeneratorSylabus.Properties.Settings.Default.ip;
            this.ipBox.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.ipBox_MaskInputRejected);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = global::GeneratorSylabus.Properties.Settings.Default.auth;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox1.Location = new System.Drawing.Point(251, 141);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(161, 21);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "Autoryzacja Windows";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(324, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Hasło:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(325, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Login:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(279, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 30);
            this.label7.TabIndex = 14;
            this.label7.Text = "Nazwa bazy:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(112, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 30);
            this.label8.TabIndex = 13;
            this.label8.Text = "IP: / PORT";
            // 
            // sylabusPanel
            // 
            this.sylabusPanel.Controls.Add(this.filesList);
            this.sylabusPanel.Controls.Add(this.deleteFile);
            this.sylabusPanel.Controls.Add(this.searchSylabus);
            this.sylabusPanel.Location = new System.Drawing.Point(196, 30);
            this.sylabusPanel.Name = "sylabusPanel";
            this.sylabusPanel.Size = new System.Drawing.Size(641, 425);
            this.sylabusPanel.TabIndex = 15;
            this.sylabusPanel.Visible = false;
            // 
            // filesList
            // 
            this.filesList.AllowColumnReorder = true;
            this.filesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader6});
            this.filesList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.filesList.FullRowSelect = true;
            this.filesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.filesList.LargeImageList = this.imageList1;
            this.filesList.Location = new System.Drawing.Point(25, 54);
            this.filesList.MultiSelect = false;
            this.filesList.Name = "filesList";
            this.filesList.Size = new System.Drawing.Size(589, 299);
            this.filesList.SmallImageList = this.imageList1;
            this.filesList.TabIndex = 26;
            this.filesList.UseCompatibleStateImageBehavior = false;
            this.filesList.View = System.Windows.Forms.View.Details;
            this.filesList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.filesList_MouseDoubleClick);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Moduł";
            this.columnHeader4.Width = 292;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Data modyfikacji";
            this.columnHeader6.Width = 192;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "word.png");
            // 
            // deleteFile
            // 
            this.deleteFile.BackColor = System.Drawing.Color.Black;
            this.deleteFile.FlatAppearance.BorderSize = 0;
            this.deleteFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteFile.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.deleteFile.ForeColor = System.Drawing.Color.White;
            this.deleteFile.Location = new System.Drawing.Point(524, 376);
            this.deleteFile.Name = "deleteFile";
            this.deleteFile.Size = new System.Drawing.Size(98, 49);
            this.deleteFile.TabIndex = 23;
            this.deleteFile.Text = "Usuń";
            this.deleteFile.UseVisualStyleBackColor = false;
            this.deleteFile.Click += new System.EventHandler(this.deleteFile_Click_1);
            // 
            // searchSylabus
            // 
            this.searchSylabus.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.searchSylabus.Location = new System.Drawing.Point(178, 11);
            this.searchSylabus.Name = "searchSylabus";
            this.searchSylabus.Size = new System.Drawing.Size(311, 27);
            this.searchSylabus.TabIndex = 2;
            this.searchSylabus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.searchSylabus.TextChanged += new System.EventHandler(this.searchSylabus_TextChanged);
            // 
            // settingsBtn
            // 
            this.settingsBtn.BackColor = System.Drawing.Color.DarkOrange;
            this.settingsBtn.FlatAppearance.BorderSize = 0;
            this.settingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.settingsBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.settingsBtn.Location = new System.Drawing.Point(12, 323);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(186, 132);
            this.settingsBtn.TabIndex = 17;
            this.settingsBtn.Text = "USTAWIENIA";
            this.settingsBtn.UseVisualStyleBackColor = false;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // sylabusBtn
            // 
            this.sylabusBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(130)))), ((int)(((byte)(5)))));
            this.sylabusBtn.FlatAppearance.BorderSize = 0;
            this.sylabusBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sylabusBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sylabusBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.sylabusBtn.Location = new System.Drawing.Point(12, 171);
            this.sylabusBtn.Name = "sylabusBtn";
            this.sylabusBtn.Size = new System.Drawing.Size(186, 132);
            this.sylabusBtn.TabIndex = 18;
            this.sylabusBtn.Text = "SYLABUSY";
            this.sylabusBtn.UseVisualStyleBackColor = false;
            this.sylabusBtn.Click += new System.EventHandler(this.sylabusBtn_Click);
            // 
            // mainBtn
            // 
            this.mainBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.mainBtn.FlatAppearance.BorderSize = 0;
            this.mainBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mainBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.mainBtn.Location = new System.Drawing.Point(12, 18);
            this.mainBtn.Name = "mainBtn";
            this.mainBtn.Size = new System.Drawing.Size(186, 132);
            this.mainBtn.TabIndex = 16;
            this.mainBtn.Text = "GENERUJ";
            this.mainBtn.UseVisualStyleBackColor = false;
            this.mainBtn.Click += new System.EventHandler(this.mainBtn_Click);
            // 
            // exit_button
            // 
            this.exit_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exit_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(68)))), ((int)(((byte)(71)))));
            this.exit_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exit_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.exit_button.Location = new System.Drawing.Point(831, 0);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(18, 19);
            this.exit_button.TabIndex = 19;
            this.exit_button.Text = "X";
            this.exit_button.UseVisualStyleBackColor = false;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::GeneratorSylabus.Properties.Resources.formBackground;
            this.ClientSize = new System.Drawing.Size(849, 482);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.settingsBtn);
            this.Controls.Add(this.sylabusBtn);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.mainBtn);
            this.Controls.Add(this.succesPanel);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.settingsPanel);
            this.Controls.Add(this.sylabusPanel);
            this.Controls.Add(this.unsucesfullPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generator WSEI";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Main_MouseUp);
            this.unsucesfullPanel.ResumeLayout(false);
            this.unsucesfullPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectionIcon)).EndInit();
            this.succesPanel.ResumeLayout(false);
            this.succesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.settingsPanel.ResumeLayout(false);
            this.settingsPanel.PerformLayout();
            this.sylabusPanel.ResumeLayout(false);
            this.sylabusPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox connectionIcon;
        private System.Windows.Forms.Panel unsucesfullPanel;
        private System.Windows.Forms.Panel succesPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.Button saveSettings;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox loginBox;
        private System.Windows.Forms.TextBox databaseName;
        private System.Windows.Forms.MaskedTextBox ipBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel sylabusPanel;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox searchSylabus;
        private System.Windows.Forms.Button settingsBtn;
        private System.Windows.Forms.Button sylabusBtn;
        private System.Windows.Forms.Button mainBtn;
        private System.Windows.Forms.Button exit_button;
        private ComboBox listOfmodulees;
        private Label currmoduleeText;
        private Button deleteFile;
        private TextBox portTextBox;
        private ListView listViewSylabus;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ListView filesList;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader6;
    }

}
