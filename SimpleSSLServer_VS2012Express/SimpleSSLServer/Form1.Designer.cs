namespace SimpleSSLServer
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
            this.button_Listen = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_Listen
            // 
            this.button_Listen.Location = new System.Drawing.Point(14, 39);
            this.button_Listen.Name = "button_Listen";
            this.button_Listen.Size = new System.Drawing.Size(100, 23);
            this.button_Listen.TabIndex = 0;
            this.button_Listen.Text = "Listen";
            this.button_Listen.UseVisualStyleBackColor = true;
            this.button_Listen.Click += new System.EventHandler(this.button_Listen_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(14, 111);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLog.Size = new System.Drawing.Size(220, 115);
            this.textBoxLog.TabIndex = 1;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(147, 39);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(100, 19);
            this.textBoxPort.TabIndex = 2;
            this.textBoxPort.Text = "8883";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.button_Listen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Listen;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.TextBox textBoxPort;
    }
}

