namespace LauncherHash
{
    partial class Form1
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
            this.BtnHash = new System.Windows.Forms.Button();
            this.LblBackgroundTop = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnHash
            // 
            this.BtnHash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(7)))), ((int)(((byte)(28)))));
            this.BtnHash.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BtnHash.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnHash.Font = new System.Drawing.Font("Roboto Black", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.BtnHash.ForeColor = System.Drawing.Color.White;
            this.BtnHash.Location = new System.Drawing.Point(88, 137);
            this.BtnHash.Name = "BtnHash";
            this.BtnHash.Size = new System.Drawing.Size(413, 142);
            this.BtnHash.TabIndex = 0;
            this.BtnHash.Text = "Hashen";
            this.BtnHash.UseVisualStyleBackColor = false;
            this.BtnHash.Click += new System.EventHandler(this.BtnHash_Click);
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
            this.LblBackgroundTop.Size = new System.Drawing.Size(581, 48);
            this.LblBackgroundTop.TabIndex = 15;
            this.LblBackgroundTop.Text = "Hasher";
            this.LblBackgroundTop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblBackgroundTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblBackgroundTop_MouseDown);
            this.LblBackgroundTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblBackgroundTop_MouseMove);
            this.LblBackgroundTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LblBackgroundTop_MouseUp);
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
            this.BtnClose.Location = new System.Drawing.Point(528, 6);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnClose.Size = new System.Drawing.Size(50, 37);
            this.BtnClose.TabIndex = 16;
            this.BtnClose.TabStop = false;
            this.BtnClose.Text = "X";
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::LauncherHash.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(581, 375);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.LblBackgroundTop);
            this.Controls.Add(this.BtnHash);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnHash;
        private System.Windows.Forms.Label LblBackgroundTop;
        private System.Windows.Forms.Button BtnClose;
    }
}

