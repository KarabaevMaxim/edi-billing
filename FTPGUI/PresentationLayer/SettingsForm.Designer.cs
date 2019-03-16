namespace FTPGui.PresentationLayer
{
    partial class SettingsForm
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
			this.CloseBtn = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.WBFolderTxt = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.FtpUriTxt = new System.Windows.Forms.TextBox();
			this.CloseWithoutSaveBtn = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.IntervalTxt = new System.Windows.Forms.MaskedTextBox();
			this.PassiveChk = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.ServiceNameTxt = new System.Windows.Forms.TextBox();
			this.FtpTimeoutTxt = new System.Windows.Forms.MaskedTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.UpFileNameTxt = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.DownFileNameTxt = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.ExchFolderTxt = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.DayOfMonthToUnloadTxt = new System.Windows.Forms.MaskedTextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// CloseBtn
			// 
			this.CloseBtn.Location = new System.Drawing.Point(231, 297);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.Size = new System.Drawing.Size(127, 23);
			this.CloseBtn.TabIndex = 0;
			this.CloseBtn.Text = "Сохранить и закрыть";
			this.CloseBtn.UseVisualStyleBackColor = true;
			this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
			// 
			// WBFolderTxt
			// 
			this.WBFolderTxt.Location = new System.Drawing.Point(181, 38);
			this.WBFolderTxt.Name = "WBFolderTxt";
			this.WBFolderTxt.Size = new System.Drawing.Size(318, 20);
			this.WBFolderTxt.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(89, 41);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(86, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Папка на ФТП:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(117, 15);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(58, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "URI ФТП:";
			// 
			// FtpUriTxt
			// 
			this.FtpUriTxt.Location = new System.Drawing.Point(181, 12);
			this.FtpUriTxt.Name = "FtpUriTxt";
			this.FtpUriTxt.Size = new System.Drawing.Size(318, 20);
			this.FtpUriTxt.TabIndex = 11;
			// 
			// CloseWithoutSaveBtn
			// 
			this.CloseWithoutSaveBtn.Location = new System.Drawing.Point(364, 297);
			this.CloseWithoutSaveBtn.Name = "CloseWithoutSaveBtn";
			this.CloseWithoutSaveBtn.Size = new System.Drawing.Size(114, 23);
			this.CloseWithoutSaveBtn.TabIndex = 13;
			this.CloseWithoutSaveBtn.Text = "Закрыть";
			this.CloseWithoutSaveBtn.UseVisualStyleBackColor = true;
			this.CloseWithoutSaveBtn.Click += new System.EventHandler(this.CloseWithoutSaveBtn_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(38, 70);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(137, 13);
			this.label6.TabIndex = 15;
			this.label6.Text = "Интервал проверки, сек.:";
			// 
			// IntervalTxt
			// 
			this.IntervalTxt.Location = new System.Drawing.Point(181, 67);
			this.IntervalTxt.Mask = "0000000";
			this.IntervalTxt.Name = "IntervalTxt";
			this.IntervalTxt.Size = new System.Drawing.Size(57, 20);
			this.IntervalTxt.TabIndex = 16;
			// 
			// PassiveChk
			// 
			this.PassiveChk.AutoSize = true;
			this.PassiveChk.Location = new System.Drawing.Point(181, 119);
			this.PassiveChk.Name = "PassiveChk";
			this.PassiveChk.Size = new System.Drawing.Size(121, 17);
			this.PassiveChk.TabIndex = 17;
			this.PassiveChk.Text = "Пассивный режим";
			this.PassiveChk.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(101, 145);
			this.label1.Name = "label1";
			this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label1.Size = new System.Drawing.Size(74, 13);
			this.label1.TabIndex = 19;
			this.label1.Text = "Имя службы:";
			// 
			// ServiceNameTxt
			// 
			this.ServiceNameTxt.Location = new System.Drawing.Point(181, 142);
			this.ServiceNameTxt.Name = "ServiceNameTxt";
			this.ServiceNameTxt.Size = new System.Drawing.Size(318, 20);
			this.ServiceNameTxt.TabIndex = 18;
			// 
			// FtpTimeoutTxt
			// 
			this.FtpTimeoutTxt.Location = new System.Drawing.Point(181, 93);
			this.FtpTimeoutTxt.Mask = "00";
			this.FtpTimeoutTxt.Name = "FtpTimeoutTxt";
			this.FtpTimeoutTxt.Size = new System.Drawing.Size(24, 20);
			this.FtpTimeoutTxt.TabIndex = 21;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(58, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(117, 13);
			this.label2.TabIndex = 20;
			this.label2.Text = "Таймаут ответа, сек.:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.DayOfMonthToUnloadTxt);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.UpFileNameTxt);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.DownFileNameTxt);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.ExchFolderTxt);
			this.groupBox1.Location = new System.Drawing.Point(12, 168);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(539, 123);
			this.groupBox1.TabIndex = 22;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Настройки обмена";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(73, 71);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(90, 13);
			this.label8.TabIndex = 28;
			this.label8.Text = "Файл выгрузки:";
			// 
			// UpFileNameTxt
			// 
			this.UpFileNameTxt.Location = new System.Drawing.Point(169, 68);
			this.UpFileNameTxt.Name = "UpFileNameTxt";
			this.UpFileNameTxt.Size = new System.Drawing.Size(318, 20);
			this.UpFileNameTxt.TabIndex = 27;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(78, 45);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(88, 13);
			this.label7.TabIndex = 26;
			this.label7.Text = "Файл загрузки:";
			// 
			// DownFileNameTxt
			// 
			this.DownFileNameTxt.Location = new System.Drawing.Point(169, 42);
			this.DownFileNameTxt.Name = "DownFileNameTxt";
			this.DownFileNameTxt.Size = new System.Drawing.Size(318, 20);
			this.DownFileNameTxt.TabIndex = 25;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(83, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(83, 13);
			this.label3.TabIndex = 24;
			this.label3.Text = "Папка обмена:";
			// 
			// ExchFolderTxt
			// 
			this.ExchFolderTxt.Location = new System.Drawing.Point(169, 16);
			this.ExchFolderTxt.Name = "ExchFolderTxt";
			this.ExchFolderTxt.Size = new System.Drawing.Size(318, 20);
			this.ExchFolderTxt.TabIndex = 23;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(11, 97);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(152, 13);
			this.label9.TabIndex = 30;
			this.label9.Text = "День месяца автовыгрузки:";
			// 
			// DayOfMonthToUnloadTxt
			// 
			this.DayOfMonthToUnloadTxt.Location = new System.Drawing.Point(169, 94);
			this.DayOfMonthToUnloadTxt.Mask = "00";
			this.DayOfMonthToUnloadTxt.Name = "DayOfMonthToUnloadTxt";
			this.DayOfMonthToUnloadTxt.Size = new System.Drawing.Size(24, 20);
			this.DayOfMonthToUnloadTxt.TabIndex = 23;
			// 
			// SettingsForm
			// 
			this.AcceptButton = this.CloseBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(563, 340);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.FtpTimeoutTxt);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ServiceNameTxt);
			this.Controls.Add(this.PassiveChk);
			this.Controls.Add(this.IntervalTxt);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.CloseWithoutSaveBtn);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.FtpUriTxt);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.WBFolderTxt);
			this.Controls.Add(this.CloseBtn);
			this.Name = "SettingsForm";
			this.Text = "Настройки";
			this.Load += new System.EventHandler(this.SettingsForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox WBFolderTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox FtpUriTxt;
        private System.Windows.Forms.Button CloseWithoutSaveBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox IntervalTxt;
        private System.Windows.Forms.CheckBox PassiveChk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ServiceNameTxt;
        private System.Windows.Forms.MaskedTextBox FtpTimeoutTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox UpFileNameTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox DownFileNameTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ExchFolderTxt;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.MaskedTextBox DayOfMonthToUnloadTxt;
	}
}