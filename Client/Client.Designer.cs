namespace Client
{
    partial class Client
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
            this.logger = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.bSendMsg = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // logger
            // 
            this.logger.Dock = System.Windows.Forms.DockStyle.Top;
            this.logger.Location = new System.Drawing.Point(0, 0);
            this.logger.Name = "logger";
            this.logger.Size = new System.Drawing.Size(382, 311);
            this.logger.TabIndex = 0;
            this.logger.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 348);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "User";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 383);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Message";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(196, 343);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(150, 22);
            this.tbUser.TabIndex = 3;
            this.tbUser.TextChanged += new System.EventHandler(this.tbUser_TextChanged);
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(196, 378);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(150, 46);
            this.tbMessage.TabIndex = 4;
            this.tbMessage.TextChanged += new System.EventHandler(this.tbMessage_TextChanged);
            // 
            // bSendMsg
            // 
            this.bSendMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bSendMsg.Location = new System.Drawing.Point(0, 430);
            this.bSendMsg.Name = "bSendMsg";
            this.bSendMsg.Size = new System.Drawing.Size(382, 23);
            this.bSendMsg.TabIndex = 5;
            this.bSendMsg.Text = "Send";
            this.bSendMsg.UseVisualStyleBackColor = true;
            this.bSendMsg.Click += new System.EventHandler(this.bSendMsg_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 453);
            this.Controls.Add(this.bSendMsg);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logger);
            this.Name = "Client";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox logger;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Button bSendMsg;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

