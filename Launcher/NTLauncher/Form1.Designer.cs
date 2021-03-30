namespace NTLauncher
{
    partial class LauncherWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherWindow));
            this.BtnDownload = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.TxtPath = new System.Windows.Forms.TextBox();
            this.BtnPath = new System.Windows.Forms.Button();
            this.LblSavePath = new System.Windows.Forms.Label();
            this.BackDownloader = new System.ComponentModel.BackgroundWorker();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.ProgressDownload = new System.Windows.Forms.ProgressBar();
            this.resultLabel = new System.Windows.Forms.Label();
            this.LblVersion = new System.Windows.Forms.Label();
            this.RichTest = new System.Windows.Forms.RichTextBox();
            this.BtnClose = new System.Windows.Forms.Button();
            this.PicStatus = new System.Windows.Forms.PictureBox();
            this.BtnStartGame = new System.Windows.Forms.Button();
            this.LblFilename = new System.Windows.Forms.Label();
            this.BackUpdater = new System.ComponentModel.BackgroundWorker();
            this.BackHashing = new System.ComponentModel.BackgroundWorker();
            this.check64bit = new System.Windows.Forms.CheckBox();
            this.checkConnectServer = new System.Windows.Forms.CheckBox();
            this.checkDebug = new System.Windows.Forms.CheckBox();
            this.LblBackgroundTop = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PicStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnDownload
            // 
            this.BtnDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(33)))));
            this.BtnDownload.FlatAppearance.BorderSize = 0;
            this.BtnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDownload.Font = new System.Drawing.Font("Roboto Black", 11F, System.Drawing.FontStyle.Bold);
            this.BtnDownload.ForeColor = System.Drawing.Color.White;
            this.BtnDownload.Location = new System.Drawing.Point(226, 381);
            this.BtnDownload.Name = "BtnDownload";
            this.BtnDownload.Size = new System.Drawing.Size(146, 60);
            this.BtnDownload.TabIndex = 0;
            this.BtnDownload.Text = "Update/Download";
            this.BtnDownload.UseVisualStyleBackColor = false;
            this.BtnDownload.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtPath
            // 
            this.TxtPath.BackColor = System.Drawing.SystemColors.Control;
            this.TxtPath.Location = new System.Drawing.Point(32, 60);
            this.TxtPath.Name = "TxtPath";
            this.TxtPath.Size = new System.Drawing.Size(459, 20);
            this.TxtPath.TabIndex = 1;
            // 
            // BtnPath
            // 
            this.BtnPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(33)))));
            this.BtnPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnPath.ForeColor = System.Drawing.Color.White;
            this.BtnPath.Location = new System.Drawing.Point(498, 42);
            this.BtnPath.Name = "BtnPath";
            this.BtnPath.Size = new System.Drawing.Size(94, 35);
            this.BtnPath.TabIndex = 2;
            this.BtnPath.Text = "Durchsuchen";
            this.BtnPath.UseVisualStyleBackColor = false;
            this.BtnPath.Click += new System.EventHandler(this.BtnPath_Click);
            // 
            // LblSavePath
            // 
            this.LblSavePath.AutoSize = true;
            this.LblSavePath.BackColor = System.Drawing.Color.Transparent;
            this.LblSavePath.ForeColor = System.Drawing.Color.White;
            this.LblSavePath.Location = new System.Drawing.Point(32, 44);
            this.LblSavePath.Name = "LblSavePath";
            this.LblSavePath.Size = new System.Drawing.Size(131, 13);
            this.LblSavePath.TabIndex = 5;
            this.LblSavePath.Text = "Speicherpfad für die Mods";
            // 
            // BackDownloader
            // 
            this.BackDownloader.WorkerReportsProgress = true;
            this.BackDownloader.WorkerSupportsCancellation = true;
            this.BackDownloader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.BackDownloader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.BackDownloader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(16)))), ((int)(((byte)(26)))));
            this.BtnCancel.FlatAppearance.BorderSize = 0;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.ForeColor = System.Drawing.SystemColors.Control;
            this.BtnCancel.Location = new System.Drawing.Point(766, 404);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(36, 36);
            this.BtnCancel.TabIndex = 8;
            this.BtnCancel.Text = "X";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // ProgressDownload
            // 
            this.ProgressDownload.Location = new System.Drawing.Point(405, 404);
            this.ProgressDownload.Name = "ProgressDownload";
            this.ProgressDownload.Size = new System.Drawing.Size(355, 36);
            this.ProgressDownload.TabIndex = 9;
            // 
            // resultLabel
            // 
            this.resultLabel.BackColor = System.Drawing.Color.Transparent;
            this.resultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.resultLabel.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.resultLabel.Location = new System.Drawing.Point(404, 366);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(356, 35);
            this.resultLabel.TabIndex = 10;
            this.resultLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // LblVersion
            // 
            this.LblVersion.AutoSize = true;
            this.LblVersion.BackColor = System.Drawing.Color.Transparent;
            this.LblVersion.Enabled = false;
            this.LblVersion.ForeColor = System.Drawing.Color.White;
            this.LblVersion.Location = new System.Drawing.Point(12, 450);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(84, 13);
            this.LblVersion.TabIndex = 11;
            this.LblVersion.Text = "Versionsnummer";
            this.LblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RichTest
            // 
            this.RichTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(10)))), ((int)(((byte)(74)))));
            this.RichTest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTest.Font = new System.Drawing.Font("Sitka Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTest.ForeColor = System.Drawing.Color.White;
            this.RichTest.Location = new System.Drawing.Point(32, 120);
            this.RichTest.Name = "RichTest";
            this.RichTest.Size = new System.Drawing.Size(406, 148);
            this.RichTest.TabIndex = 12;
            this.RichTest.Text = "";
            // 
            // BtnClose
            // 
            this.BtnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.BtnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(16)))), ((int)(((byte)(26)))));
            this.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClose.FlatAppearance.BorderSize = 0;
            this.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.BtnClose.Location = new System.Drawing.Point(775, 3);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnClose.Size = new System.Drawing.Size(40, 27);
            this.BtnClose.TabIndex = 13;
            this.BtnClose.TabStop = false;
            this.BtnClose.Text = "X";
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // PicStatus
            // 
            this.PicStatus.BackColor = System.Drawing.Color.Transparent;
            this.PicStatus.InitialImage = null;
            this.PicStatus.Location = new System.Drawing.Point(679, 202);
            this.PicStatus.Name = "PicStatus";
            this.PicStatus.Size = new System.Drawing.Size(128, 128);
            this.PicStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicStatus.TabIndex = 7;
            this.PicStatus.TabStop = false;

            // 
            // BtnStartGame
            // 
            this.BtnStartGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(33)))));
            this.BtnStartGame.FlatAppearance.BorderSize = 0;
            this.BtnStartGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStartGame.Font = new System.Drawing.Font("Roboto Black", 15F, System.Drawing.FontStyle.Bold);
            this.BtnStartGame.ForeColor = System.Drawing.Color.White;
            this.BtnStartGame.Location = new System.Drawing.Point(12, 380);
            this.BtnStartGame.Name = "BtnStartGame";
            this.BtnStartGame.Size = new System.Drawing.Size(208, 60);
            this.BtnStartGame.TabIndex = 18;
            this.BtnStartGame.Text = "Spiel starten";
            this.BtnStartGame.UseVisualStyleBackColor = false;
            this.BtnStartGame.Click += new System.EventHandler(this.BtnStartGame_Click);
            // 
            // LblFilename
            // 
            this.LblFilename.BackColor = System.Drawing.Color.Transparent;
            this.LblFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.LblFilename.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.LblFilename.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.LblFilename.Location = new System.Drawing.Point(405, 443);
            this.LblFilename.Name = "LblFilename";
            this.LblFilename.Size = new System.Drawing.Size(397, 20);
            this.LblFilename.TabIndex = 19;
            // 
            // BackUpdater
            // 
            this.BackUpdater.DoWork += new System.ComponentModel.DoWorkEventHandler(this.InitializeUpdate);
            // 
            // BackHashing
            // 
            this.BackHashing.WorkerReportsProgress = true;
            this.BackHashing.WorkerSupportsCancellation = true;
            this.BackHashing.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackHashing_DoWork);
            this.BackHashing.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackHashing_ProgressChanged);
            this.BackHashing.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackHashing_RunWorkerCompleted);
            // 
            // check64bit
            // 
            this.check64bit.AutoSize = true;
            this.check64bit.BackColor = System.Drawing.Color.Transparent;
            this.check64bit.Checked = true;
            this.check64bit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check64bit.ForeColor = System.Drawing.Color.White;
            this.check64bit.Location = new System.Drawing.Point(470, 152);
            this.check64bit.Name = "check64bit";
            this.check64bit.Size = new System.Drawing.Size(141, 17);
            this.check64bit.TabIndex = 21;
            this.check64bit.Text = "nutze 64-bit Anwendung";
            this.check64bit.UseVisualStyleBackColor = false;
            // 
            // checkConnectServer
            // 
            this.checkConnectServer.AutoSize = true;
            this.checkConnectServer.BackColor = System.Drawing.Color.Transparent;
            this.checkConnectServer.Checked = true;
            this.checkConnectServer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkConnectServer.ForeColor = System.Drawing.Color.White;
            this.checkConnectServer.Location = new System.Drawing.Point(470, 129);
            this.checkConnectServer.Name = "checkConnectServer";
            this.checkConnectServer.Size = new System.Drawing.Size(158, 17);
            this.checkConnectServer.TabIndex = 22;
            this.checkConnectServer.Text = "direkt zum Server verbinden";
            this.checkConnectServer.UseVisualStyleBackColor = false;
            // 
            // checkDebug
            // 
            this.checkDebug.AutoSize = true;
            this.checkDebug.BackColor = System.Drawing.Color.Transparent;
            this.checkDebug.Checked = true;
            this.checkDebug.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkDebug.ForeColor = System.Drawing.Color.White;
            this.checkDebug.Location = new System.Drawing.Point(470, 106);
            this.checkDebug.Name = "checkDebug";
            this.checkDebug.Size = new System.Drawing.Size(226, 17);
            this.checkDebug.TabIndex = 23;
            this.checkDebug.Text = "im Debug-Modus starten (nur zum Testen!)";
            this.checkDebug.UseVisualStyleBackColor = false;
            // 
            // LblBackgroundTop
            // 
            this.LblBackgroundTop.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.LblBackgroundTop.BackColor = System.Drawing.Color.Transparent;
            this.LblBackgroundTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblBackgroundTop.Font = new System.Drawing.Font("Yu Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBackgroundTop.ForeColor = System.Drawing.Color.White;
            this.LblBackgroundTop.Location = new System.Drawing.Point(0, 0);
            this.LblBackgroundTop.Name = "LblBackgroundTop";
            this.LblBackgroundTop.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.LblBackgroundTop.Size = new System.Drawing.Size(819, 35);
            this.LblBackgroundTop.TabIndex = 14;
            this.LblBackgroundTop.Text = "NT Launcher";
            this.LblBackgroundTop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblBackgroundTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblBackgroundTop_MouseDown);
            this.LblBackgroundTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblBackgroundTop_MouseMove);
            this.LblBackgroundTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LblBackgroundTop_MouseUp);
            // 
            // LauncherWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NTLauncher.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(819, 477);
            this.Controls.Add(this.checkDebug);
            this.Controls.Add(this.checkConnectServer);
            this.Controls.Add(this.check64bit);
            this.Controls.Add(this.LblFilename);
            this.Controls.Add(this.BtnStartGame);
            this.Controls.Add(this.TxtPath);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.BtnDownload);
            this.Controls.Add(this.BtnPath);
            this.Controls.Add(this.RichTest);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.LblSavePath);
            this.Controls.Add(this.LblBackgroundTop);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.PicStatus);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.ProgressDownload);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LauncherWindow";
            this.Text = "NightTech Launcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnDownload;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox TxtPath;
        private System.Windows.Forms.Button BtnPath;
        private System.Windows.Forms.Label LblSavePath;
        private System.Windows.Forms.PictureBox PicStatus;
        private System.ComponentModel.BackgroundWorker BackDownloader;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.ProgressBar ProgressDownload;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label LblVersion;
        private System.Windows.Forms.RichTextBox RichTest;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnStartGame;
        private System.Windows.Forms.Label LblFilename;
        private System.ComponentModel.BackgroundWorker BackUpdater;
        private System.ComponentModel.BackgroundWorker BackHashing;
        private System.Windows.Forms.CheckBox check64bit;
        private System.Windows.Forms.CheckBox checkConnectServer;
        private System.Windows.Forms.CheckBox checkDebug;
        private System.Windows.Forms.Label LblBackgroundTop;
    }
}

