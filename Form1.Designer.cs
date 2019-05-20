namespace ChatroomClient
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.rtMessage = new System.Windows.Forms.RichTextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnConnection = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listUser = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnSecret = new System.Windows.Forms.Button();
            this.lookConnection = new System.Windows.Forms.Timer(this.components);
            this.connectionLoop = new System.Windows.Forms.Timer(this.components);
            this.mainLoop = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // rtMessage
            // 
            this.rtMessage.Location = new System.Drawing.Point(12, 12);
            this.rtMessage.Name = "rtMessage";
            this.rtMessage.Size = new System.Drawing.Size(390, 334);
            this.rtMessage.TabIndex = 0;
            this.rtMessage.Text = "";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 378);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(390, 33);
            this.txtMessage.TabIndex = 1;
            // 
            // btnConnection
            // 
            this.btnConnection.Location = new System.Drawing.Point(436, 51);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(175, 44);
            this.btnConnection.TabIndex = 2;
            this.btnConnection.Text = "Connection to Server";
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(511, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 22);
            this.txtName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(434, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Your Name：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 363);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Type Message：";
            // 
            // listUser
            // 
            this.listUser.FormattingEnabled = true;
            this.listUser.ItemHeight = 12;
            this.listUser.Location = new System.Drawing.Point(436, 130);
            this.listUser.Name = "listUser";
            this.listUser.Size = new System.Drawing.Size(175, 160);
            this.listUser.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(434, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "User List：";
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(436, 378);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 33);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Send To All";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnSecret
            // 
            this.btnSecret.Enabled = false;
            this.btnSecret.Location = new System.Drawing.Point(436, 313);
            this.btnSecret.Name = "btnSecret";
            this.btnSecret.Size = new System.Drawing.Size(75, 33);
            this.btnSecret.TabIndex = 7;
            this.btnSecret.Text = "Send To Select User";
            this.btnSecret.UseVisualStyleBackColor = true;
            this.btnSecret.Click += new System.EventHandler(this.btnSecret_Click);
            // 
            // lookConnection
            // 
            this.lookConnection.Enabled = true;
            this.lookConnection.Interval = 500;
            this.lookConnection.Tick += new System.EventHandler(this.lookConnection_Tick);
            // 
            // connectionLoop
            // 
            this.connectionLoop.Interval = 50;
            this.connectionLoop.Tick += new System.EventHandler(this.connectionLoop_Tick);
            // 
            // mainLoop
            // 
            this.mainLoop.Enabled = true;
            this.mainLoop.Tick += new System.EventHandler(this.mainLoop_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 435);
            this.Controls.Add(this.btnSecret);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.listUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnConnection);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.rtMessage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnSecret;
        private System.Windows.Forms.Timer lookConnection;
        private System.Windows.Forms.Timer connectionLoop;
        private System.Windows.Forms.Timer mainLoop;
    }
}

