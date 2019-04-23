namespace UserAppHttpServer
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_stdin = new System.Windows.Forms.TextBox();
            this.button_Send = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Rcv = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel_Snd = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_Send_Header_Auto = new System.Windows.Forms.RadioButton();
            this.radioButton_Send_Header_Manual = new System.Windows.Forms.RadioButton();
            this.comboBox_Send_StatusCode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Send_Manual_StatusLine = new System.Windows.Forms.TextBox();
            this.textBox_Send_Manual_ContentLen = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_stdout = new System.Windows.Forms.TextBox();
            this.radioButton_Send_Body_Text = new System.Windows.Forms.RadioButton();
            this.radioButton_Send_Body_Hex = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_Send_Body = new System.Windows.Forms.TextBox();
            this.button_Send_HeadrBody_Raw = new System.Windows.Forms.Button();
            this.panel_Rcv.SuspendLayout();
            this.panel_Snd.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_stdin
            // 
            this.textBox_stdin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_stdin.Location = new System.Drawing.Point(14, 24);
            this.textBox_stdin.Multiline = true;
            this.textBox_stdin.Name = "textBox_stdin";
            this.textBox_stdin.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_stdin.Size = new System.Drawing.Size(545, 97);
            this.textBox_stdin.TabIndex = 0;
            // 
            // button_Send
            // 
            this.button_Send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Send.Location = new System.Drawing.Point(317, 6);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(75, 23);
            this.button_Send.TabIndex = 1;
            this.button_Send.Text = "send";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Received data: ";
            // 
            // panel_Rcv
            // 
            this.panel_Rcv.Controls.Add(this.label1);
            this.panel_Rcv.Controls.Add(this.textBox_stdin);
            this.panel_Rcv.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Rcv.Location = new System.Drawing.Point(0, 0);
            this.panel_Rcv.Name = "panel_Rcv";
            this.panel_Rcv.Size = new System.Drawing.Size(573, 127);
            this.panel_Rcv.TabIndex = 3;
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 127);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(573, 6);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // panel_Snd
            // 
            this.panel_Snd.Controls.Add(this.groupBox3);
            this.panel_Snd.Controls.Add(this.groupBox2);
            this.panel_Snd.Controls.Add(this.groupBox1);
            this.panel_Snd.Controls.Add(this.label2);
            this.panel_Snd.Controls.Add(this.button_Send);
            this.panel_Snd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Snd.Location = new System.Drawing.Point(0, 133);
            this.panel_Snd.Name = "panel_Snd";
            this.panel_Snd.Size = new System.Drawing.Size(573, 316);
            this.panel_Snd.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Response data";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.textBox_Send_Manual_ContentLen);
            this.groupBox1.Controls.Add(this.textBox_Send_Manual_StatusLine);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox_Send_StatusCode);
            this.groupBox1.Controls.Add(this.radioButton_Send_Header_Manual);
            this.groupBox1.Controls.Add(this.radioButton_Send_Header_Auto);
            this.groupBox1.Location = new System.Drawing.Point(14, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 116);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Header";
            // 
            // radioButton_Send_Header_Auto
            // 
            this.radioButton_Send_Header_Auto.AutoSize = true;
            this.radioButton_Send_Header_Auto.Checked = true;
            this.radioButton_Send_Header_Auto.Location = new System.Drawing.Point(109, 18);
            this.radioButton_Send_Header_Auto.Name = "radioButton_Send_Header_Auto";
            this.radioButton_Send_Header_Auto.Size = new System.Drawing.Size(45, 16);
            this.radioButton_Send_Header_Auto.TabIndex = 0;
            this.radioButton_Send_Header_Auto.TabStop = true;
            this.radioButton_Send_Header_Auto.Text = "auto";
            this.radioButton_Send_Header_Auto.UseVisualStyleBackColor = true;
            // 
            // radioButton_Send_Header_Manual
            // 
            this.radioButton_Send_Header_Manual.AutoSize = true;
            this.radioButton_Send_Header_Manual.Location = new System.Drawing.Point(217, 18);
            this.radioButton_Send_Header_Manual.Name = "radioButton_Send_Header_Manual";
            this.radioButton_Send_Header_Manual.Size = new System.Drawing.Size(59, 16);
            this.radioButton_Send_Header_Manual.TabIndex = 1;
            this.radioButton_Send_Header_Manual.Text = "manual";
            this.radioButton_Send_Header_Manual.UseVisualStyleBackColor = true;
            // 
            // comboBox_Send_StatusCode
            // 
            this.comboBox_Send_StatusCode.FormattingEnabled = true;
            this.comboBox_Send_StatusCode.Location = new System.Drawing.Point(109, 40);
            this.comboBox_Send_StatusCode.Name = "comboBox_Send_StatusCode";
            this.comboBox_Send_StatusCode.Size = new System.Drawing.Size(102, 20);
            this.comboBox_Send_StatusCode.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Status line:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "Content-Length:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "Content-Type:";
            // 
            // textBox_Send_Manual_StatusLine
            // 
            this.textBox_Send_Manual_StatusLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Send_Manual_StatusLine.Location = new System.Drawing.Point(217, 40);
            this.textBox_Send_Manual_StatusLine.Name = "textBox_Send_Manual_StatusLine";
            this.textBox_Send_Manual_StatusLine.Size = new System.Drawing.Size(155, 19);
            this.textBox_Send_Manual_StatusLine.TabIndex = 6;
            this.textBox_Send_Manual_StatusLine.Text = "200 OKOK";
            // 
            // textBox_Send_Manual_ContentLen
            // 
            this.textBox_Send_Manual_ContentLen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Send_Manual_ContentLen.Location = new System.Drawing.Point(217, 66);
            this.textBox_Send_Manual_ContentLen.Name = "textBox_Send_Manual_ContentLen";
            this.textBox_Send_Manual_ContentLen.Size = new System.Drawing.Size(155, 19);
            this.textBox_Send_Manual_ContentLen.TabIndex = 7;
            this.textBox_Send_Manual_ContentLen.Text = "12";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(217, 91);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(155, 19);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "----";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textBox_Send_Body);
            this.groupBox2.Controls.Add(this.radioButton_Send_Body_Hex);
            this.groupBox2.Controls.Add(this.radioButton_Send_Body_Text);
            this.groupBox2.Location = new System.Drawing.Point(14, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(378, 150);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Body";
            // 
            // textBox_stdout
            // 
            this.textBox_stdout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_stdout.Location = new System.Drawing.Point(6, 47);
            this.textBox_stdout.Multiline = true;
            this.textBox_stdout.Name = "textBox_stdout";
            this.textBox_stdout.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_stdout.Size = new System.Drawing.Size(149, 245);
            this.textBox_stdout.TabIndex = 4;
            this.textBox_stdout.Text = "HTTP/1.1 200 OK\r\nServer: xxx\r\nContent-length: 7\r\n\r\nabcdefg";
            // 
            // radioButton_Send_Body_Text
            // 
            this.radioButton_Send_Body_Text.AutoSize = true;
            this.radioButton_Send_Body_Text.Checked = true;
            this.radioButton_Send_Body_Text.Location = new System.Drawing.Point(6, 18);
            this.radioButton_Send_Body_Text.Name = "radioButton_Send_Body_Text";
            this.radioButton_Send_Body_Text.Size = new System.Drawing.Size(43, 16);
            this.radioButton_Send_Body_Text.TabIndex = 5;
            this.radioButton_Send_Body_Text.TabStop = true;
            this.radioButton_Send_Body_Text.Text = "text";
            this.radioButton_Send_Body_Text.UseVisualStyleBackColor = true;
            // 
            // radioButton_Send_Body_Hex
            // 
            this.radioButton_Send_Body_Hex.AutoSize = true;
            this.radioButton_Send_Body_Hex.Location = new System.Drawing.Point(55, 18);
            this.radioButton_Send_Body_Hex.Name = "radioButton_Send_Body_Hex";
            this.radioButton_Send_Body_Hex.Size = new System.Drawing.Size(41, 16);
            this.radioButton_Send_Body_Hex.TabIndex = 5;
            this.radioButton_Send_Body_Hex.Text = "hex";
            this.radioButton_Send_Body_Hex.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.button_Send_HeadrBody_Raw);
            this.groupBox3.Controls.Add(this.textBox_stdout);
            this.groupBox3.Location = new System.Drawing.Point(398, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(161, 292);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Header + Body";
            // 
            // textBox_Send_Body
            // 
            this.textBox_Send_Body.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Send_Body.Location = new System.Drawing.Point(6, 40);
            this.textBox_Send_Body.Multiline = true;
            this.textBox_Send_Body.Name = "textBox_Send_Body";
            this.textBox_Send_Body.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Send_Body.Size = new System.Drawing.Size(366, 104);
            this.textBox_Send_Body.TabIndex = 6;
            this.textBox_Send_Body.Text = "abcdefg";
            // 
            // button_Send_HeadrBody_Raw
            // 
            this.button_Send_HeadrBody_Raw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Send_HeadrBody_Raw.Location = new System.Drawing.Point(80, 18);
            this.button_Send_HeadrBody_Raw.Name = "button_Send_HeadrBody_Raw";
            this.button_Send_HeadrBody_Raw.Size = new System.Drawing.Size(75, 23);
            this.button_Send_HeadrBody_Raw.TabIndex = 5;
            this.button_Send_HeadrBody_Raw.Text = "send";
            this.button_Send_HeadrBody_Raw.UseVisualStyleBackColor = true;
            this.button_Send_HeadrBody_Raw.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 449);
            this.Controls.Add(this.panel_Snd);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel_Rcv);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel_Rcv.ResumeLayout(false);
            this.panel_Rcv.PerformLayout();
            this.panel_Snd.ResumeLayout(false);
            this.panel_Snd.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_stdin;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_Rcv;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel_Snd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_Send_Header_Auto;
        private System.Windows.Forms.RadioButton radioButton_Send_Header_Manual;
        private System.Windows.Forms.ComboBox comboBox_Send_StatusCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Send_Manual_StatusLine;
        private System.Windows.Forms.TextBox textBox_Send_Manual_ContentLen;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_stdout;
        private System.Windows.Forms.RadioButton radioButton_Send_Body_Text;
        private System.Windows.Forms.RadioButton radioButton_Send_Body_Hex;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_Send_Body;
        private System.Windows.Forms.Button button_Send_HeadrBody_Raw;
    }
}

