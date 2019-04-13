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
            this.textBox_stdout = new System.Windows.Forms.TextBox();
            this.panel_Rcv.SuspendLayout();
            this.panel_Snd.SuspendLayout();
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
            this.textBox_stdin.Size = new System.Drawing.Size(256, 97);
            this.textBox_stdin.TabIndex = 0;
            // 
            // button_Send
            // 
            this.button_Send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Send.Location = new System.Drawing.Point(197, 6);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(75, 23);
            this.button_Send.TabIndex = 1;
            this.button_Send.Text = "send";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button1_Click);
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
            this.panel_Rcv.Size = new System.Drawing.Size(284, 127);
            this.panel_Rcv.TabIndex = 3;
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 127);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(284, 6);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // panel_Snd
            // 
            this.panel_Snd.Controls.Add(this.textBox_stdout);
            this.panel_Snd.Controls.Add(this.label2);
            this.panel_Snd.Controls.Add(this.button_Send);
            this.panel_Snd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Snd.Location = new System.Drawing.Point(0, 133);
            this.panel_Snd.Name = "panel_Snd";
            this.panel_Snd.Size = new System.Drawing.Size(284, 128);
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
            // textBox_stdout
            // 
            this.textBox_stdout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_stdout.Location = new System.Drawing.Point(14, 32);
            this.textBox_stdout.Multiline = true;
            this.textBox_stdout.Name = "textBox_stdout";
            this.textBox_stdout.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_stdout.Size = new System.Drawing.Size(256, 84);
            this.textBox_stdout.TabIndex = 3;
            this.textBox_stdout.Text = "HTTP/1.1 200 OK\r\nServer: xxx\r\nContent-length: 7\r\n\r\nabcdefg";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.panel_Snd);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel_Rcv);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel_Rcv.ResumeLayout(false);
            this.panel_Rcv.PerformLayout();
            this.panel_Snd.ResumeLayout(false);
            this.panel_Snd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_stdin;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_Rcv;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel_Snd;
        private System.Windows.Forms.TextBox textBox_stdout;
        private System.Windows.Forms.Label label2;
    }
}

