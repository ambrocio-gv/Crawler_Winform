namespace WinFormsAppLOA
{
    partial class FormLOA
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_Username = new System.Windows.Forms.TextBox();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label_Username = new System.Windows.Forms.Label();
            this.label_Password = new System.Windows.Forms.Label();
            this.label_InquiryIDPath = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_DownloadedPath = new System.Windows.Forms.Label();
            this.label_LogFilepath = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox_DownloadPath = new System.Windows.Forms.TextBox();
            this.textBox_InquiryIDPath = new System.Windows.Forms.TextBox();
            this.textBox_LogFilePath = new System.Windows.Forms.TextBox();
            this.button_DownloadedPath = new System.Windows.Forms.Button();
            this.button_InquiryPath = new System.Windows.Forms.Button();
            this.button_LogPath = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(452, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 70);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_Username
            // 
            this.textBox_Username.Location = new System.Drawing.Point(121, 35);
            this.textBox_Username.Name = "textBox_Username";
            this.textBox_Username.Size = new System.Drawing.Size(163, 23);
            this.textBox_Username.TabIndex = 1;
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(121, 73);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(163, 23);
            this.textBox_Password.TabIndex = 2;
            // 
            // label_Username
            // 
            this.label_Username.AutoSize = true;
            this.label_Username.Location = new System.Drawing.Point(35, 38);
            this.label_Username.Name = "label_Username";
            this.label_Username.Size = new System.Drawing.Size(60, 15);
            this.label_Username.TabIndex = 3;
            this.label_Username.Text = "Username";
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(35, 81);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(57, 15);
            this.label_Password.TabIndex = 4;
            this.label_Password.Text = "Password";
            // 
            // label_InquiryIDPath
            // 
            this.label_InquiryIDPath.AutoSize = true;
            this.label_InquiryIDPath.Location = new System.Drawing.Point(35, 164);
            this.label_InquiryIDPath.Name = "label_InquiryIDPath";
            this.label_InquiryIDPath.Size = new System.Drawing.Size(105, 15);
            this.label_InquiryIDPath.TabIndex = 5;
            this.label_InquiryIDPath.Text = "Inquiry Id File Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 6;
            // 
            // label_DownloadedPath
            // 
            this.label_DownloadedPath.AutoSize = true;
            this.label_DownloadedPath.Location = new System.Drawing.Point(35, 121);
            this.label_DownloadedPath.Name = "label_DownloadedPath";
            this.label_DownloadedPath.Size = new System.Drawing.Size(176, 15);
            this.label_DownloadedPath.TabIndex = 7;
            this.label_DownloadedPath.Text = "Downloaded Files Location Path";
            // 
            // label_LogFilepath
            // 
            this.label_LogFilepath.AutoSize = true;
            this.label_LogFilepath.Location = new System.Drawing.Point(35, 205);
            this.label_LogFilepath.Name = "label_LogFilepath";
            this.label_LogFilepath.Size = new System.Drawing.Size(75, 15);
            this.label_LogFilepath.TabIndex = 11;
            this.label_LogFilepath.Text = "Log File Path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 15);
            this.label3.TabIndex = 10;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(318, 38);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 19);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "Remember me";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox_DownloadPath
            // 
            this.textBox_DownloadPath.Location = new System.Drawing.Point(244, 118);
            this.textBox_DownloadPath.Name = "textBox_DownloadPath";
            this.textBox_DownloadPath.Size = new System.Drawing.Size(344, 23);
            this.textBox_DownloadPath.TabIndex = 19;
            // 
            // textBox_InquiryIDPath
            // 
            this.textBox_InquiryIDPath.Location = new System.Drawing.Point(244, 156);
            this.textBox_InquiryIDPath.Name = "textBox_InquiryIDPath";
            this.textBox_InquiryIDPath.Size = new System.Drawing.Size(344, 23);
            this.textBox_InquiryIDPath.TabIndex = 20;
            // 
            // textBox_LogFilePath
            // 
            this.textBox_LogFilePath.Location = new System.Drawing.Point(244, 197);
            this.textBox_LogFilePath.Name = "textBox_LogFilePath";
            this.textBox_LogFilePath.Size = new System.Drawing.Size(344, 23);
            this.textBox_LogFilePath.TabIndex = 21;
            // 
            // button_DownloadedPath
            // 
            this.button_DownloadedPath.Location = new System.Drawing.Point(629, 117);
            this.button_DownloadedPath.Name = "button_DownloadedPath";
            this.button_DownloadedPath.Size = new System.Drawing.Size(24, 23);
            this.button_DownloadedPath.TabIndex = 22;
            this.button_DownloadedPath.Text = "...";
            this.button_DownloadedPath.UseVisualStyleBackColor = true;
            this.button_DownloadedPath.Click += new System.EventHandler(this.button_DownloadedPath_Click);
            // 
            // button_InquiryPath
            // 
            this.button_InquiryPath.Location = new System.Drawing.Point(629, 155);
            this.button_InquiryPath.Name = "button_InquiryPath";
            this.button_InquiryPath.Size = new System.Drawing.Size(24, 23);
            this.button_InquiryPath.TabIndex = 23;
            this.button_InquiryPath.Text = "...";
            this.button_InquiryPath.UseVisualStyleBackColor = true;
            this.button_InquiryPath.Click += new System.EventHandler(this.button_InquiryPath_Click);
            // 
            // button_LogPath
            // 
            this.button_LogPath.Location = new System.Drawing.Point(629, 196);
            this.button_LogPath.Name = "button_LogPath";
            this.button_LogPath.Size = new System.Drawing.Size(24, 23);
            this.button_LogPath.TabIndex = 24;
            this.button_LogPath.Text = "...";
            this.button_LogPath.UseVisualStyleBackColor = true;
            this.button_LogPath.Click += new System.EventHandler(this.button_LogPath_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(35, 258);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(618, 23);
            this.progressBar1.TabIndex = 26;
            // 
            // FormLOA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 309);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button_LogPath);
            this.Controls.Add(this.button_InquiryPath);
            this.Controls.Add(this.button_DownloadedPath);
            this.Controls.Add(this.textBox_LogFilePath);
            this.Controls.Add(this.textBox_InquiryIDPath);
            this.Controls.Add(this.textBox_DownloadPath);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label_LogFilepath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_DownloadedPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_InquiryIDPath);
            this.Controls.Add(this.label_Password);
            this.Controls.Add(this.label_Username);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.textBox_Username);
            this.Controls.Add(this.button1);
            this.Name = "FormLOA";
            this.Text = "FormLOA";
            this.Load += new System.EventHandler(this.FormLOA_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private TextBox textBox_Username;
        private TextBox textBox_Password;
        private Label label_Username;
        private Label label_Password;
        private Label label_InquiryIDPath;
        private Label label2;
        private Label label_DownloadedPath;
        private Label label_LogFilepath;
        private Label label3;
        private CheckBox checkBox1;
        private TextBox textBox_DownloadPath;
        private TextBox textBox_InquiryIDPath;
        private TextBox textBox_LogFilePath;
        private Button button_DownloadedPath;
        private Button button_InquiryPath;
        private Button button_LogPath;
        private ProgressBar progressBar1;
    }
}