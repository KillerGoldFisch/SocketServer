namespace SocketServer
{
    partial class Connection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Connection));
            this.btnClear = new System.Windows.Forms.Button();
            this.cbAutoscroll = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClientConnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbClientPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbClientIP = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbLocal = new System.Windows.Forms.TextBox();
            this.btnServerListen = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbServerPort = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.btnCloseConn = new System.Windows.Forms.Button();
            this.lvConnections = new System.Windows.Forms.ListView();
            this.ironTextBoxControl1 = new UIIronTextBox.IronTextBoxControl();
            this.cbNotification = new System.Windows.Forms.CheckBox();
            this.cbSpeech = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.Location = new System.Drawing.Point(11, 606);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cbAutoscroll
            // 
            this.cbAutoscroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAutoscroll.AutoSize = true;
            this.cbAutoscroll.Checked = true;
            this.cbAutoscroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoscroll.Location = new System.Drawing.Point(92, 610);
            this.cbAutoscroll.Name = "cbAutoscroll";
            this.cbAutoscroll.Size = new System.Drawing.Size(72, 17);
            this.cbAutoscroll.TabIndex = 2;
            this.cbAutoscroll.Text = "Autoscroll";
            this.cbAutoscroll.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(653, 588);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnClientConnect);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbClientPort);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbClientIP);
            this.groupBox1.Location = new System.Drawing.Point(11, 636);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 115);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Client";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnClientConnect
            // 
            this.btnClientConnect.Location = new System.Drawing.Point(9, 77);
            this.btnClientConnect.Name = "btnClientConnect";
            this.btnClientConnect.Size = new System.Drawing.Size(175, 23);
            this.btnClientConnect.TabIndex = 5;
            this.btnClientConnect.Text = "Connect";
            this.btnClientConnect.UseVisualStyleBackColor = true;
            this.btnClientConnect.Click += new System.EventHandler(this.btnClientConnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // tbClientPort
            // 
            this.tbClientPort.Location = new System.Drawing.Point(64, 51);
            this.tbClientPort.Name = "tbClientPort";
            this.tbClientPort.Size = new System.Drawing.Size(120, 20);
            this.tbClientPort.TabIndex = 2;
            this.tbClientPort.TextChanged += new System.EventHandler(this.TbClientPortTextChanged);
            this.tbClientPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbClientPortKeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP Address";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbClientIP
            // 
            this.tbClientIP.Location = new System.Drawing.Point(64, 25);
            this.tbClientIP.Name = "tbClientIP";
            this.tbClientIP.Size = new System.Drawing.Size(120, 20);
            this.tbClientIP.TabIndex = 0;
            this.tbClientIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbClientIPKeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbLocal);
            this.groupBox2.Controls.Add(this.btnServerListen);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbServerPort);
            this.groupBox2.Location = new System.Drawing.Point(214, 636);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(201, 115);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Local";
            // 
            // tbLocal
            // 
            this.tbLocal.Location = new System.Drawing.Point(64, 25);
            this.tbLocal.Name = "tbLocal";
            this.tbLocal.Size = new System.Drawing.Size(120, 20);
            this.tbLocal.TabIndex = 7;
            this.tbLocal.TextChanged += new System.EventHandler(this.TbLocalTextChanged);
            // 
            // btnServerListen
            // 
            this.btnServerListen.Location = new System.Drawing.Point(9, 77);
            this.btnServerListen.Name = "btnServerListen";
            this.btnServerListen.Size = new System.Drawing.Size(175, 23);
            this.btnServerListen.TabIndex = 6;
            this.btnServerListen.Text = "Listen";
            this.btnServerListen.UseVisualStyleBackColor = true;
            this.btnServerListen.Click += new System.EventHandler(this.btnServerListen_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Port";
            // 
            // tbServerPort
            // 
            this.tbServerPort.Location = new System.Drawing.Point(64, 51);
            this.tbServerPort.Name = "tbServerPort";
            this.tbServerPort.Size = new System.Drawing.Size(120, 20);
            this.tbServerPort.TabIndex = 4;
            this.tbServerPort.TextChanged += new System.EventHandler(this.TbServerPortTextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.btnSend);
            this.groupBox3.Controls.Add(this.tbSend);
            this.groupBox3.Controls.Add(this.btnCloseConn);
            this.groupBox3.Controls.Add(this.lvConnections);
            this.groupBox3.Location = new System.Drawing.Point(421, 606);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(244, 145);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Connections";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(192, 86);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(44, 23);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BtnSendClick);
            // 
            // tbSend
            // 
            this.tbSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSend.Location = new System.Drawing.Point(6, 88);
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(180, 20);
            this.tbSend.TabIndex = 3;
            this.tbSend.TextChanged += new System.EventHandler(this.TbSendTextChanged);
            this.tbSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbSendKeyPress);
            // 
            // btnCloseConn
            // 
            this.btnCloseConn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseConn.Location = new System.Drawing.Point(6, 114);
            this.btnCloseConn.Name = "btnCloseConn";
            this.btnCloseConn.Size = new System.Drawing.Size(229, 23);
            this.btnCloseConn.TabIndex = 1;
            this.btnCloseConn.Text = "Close selected Connections";
            this.btnCloseConn.UseVisualStyleBackColor = true;
            this.btnCloseConn.Click += new System.EventHandler(this.btnCloseConn_Click);
            // 
            // lvConnections
            // 
            this.lvConnections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvConnections.Location = new System.Drawing.Point(7, 20);
            this.lvConnections.Name = "lvConnections";
            this.lvConnections.Size = new System.Drawing.Size(229, 65);
            this.lvConnections.TabIndex = 0;
            this.lvConnections.UseCompatibleStateImageBehavior = false;
            this.lvConnections.View = System.Windows.Forms.View.List;
            // 
            // ironTextBoxControl1
            // 
            this.ironTextBoxControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ironTextBoxControl1.AutoScroll = true;
            this.ironTextBoxControl1.ConsoleTextBackColor = System.Drawing.Color.White;
            this.ironTextBoxControl1.ConsoleTextFont = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ironTextBoxControl1.ConsoleTextForeColor = System.Drawing.SystemColors.WindowText;
            this.ironTextBoxControl1.defBuilder = ((System.Text.StringBuilder)(resources.GetObject("ironTextBoxControl1.defBuilder")));
            this.ironTextBoxControl1.Location = new System.Drawing.Point(671, 12);
            this.ironTextBoxControl1.Name = "ironTextBoxControl1";
            this.ironTextBoxControl1.Prompt = ">>>";
            this.ironTextBoxControl1.Size = new System.Drawing.Size(642, 739);
            this.ironTextBoxControl1.TabIndex = 7;
            this.ironTextBoxControl1.Load += new System.EventHandler(this.ironTextBoxControl1_Load);
            // 
            // cbNotification
            // 
            this.cbNotification.AutoSize = true;
            this.cbNotification.Location = new System.Drawing.Point(170, 610);
            this.cbNotification.Name = "cbNotification";
            this.cbNotification.Size = new System.Drawing.Size(108, 17);
            this.cbNotification.TabIndex = 8;
            this.cbNotification.Text = "Notification tones";
            this.cbNotification.UseVisualStyleBackColor = true;
            // 
            // cbSpeech
            // 
            this.cbSpeech.AutoSize = true;
            this.cbSpeech.Location = new System.Drawing.Point(284, 610);
            this.cbSpeech.Name = "cbSpeech";
            this.cbSpeech.Size = new System.Drawing.Size(63, 17);
            this.cbSpeech.TabIndex = 9;
            this.cbSpeech.Text = "Speech";
            this.cbSpeech.UseVisualStyleBackColor = true;
            // 
            // Connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 763);
            this.Controls.Add(this.cbSpeech);
            this.Controls.Add(this.cbNotification);
            this.Controls.Add(this.ironTextBoxControl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.cbAutoscroll);
            this.Controls.Add(this.btnClear);
            this.Name = "Connection";
            this.Text = "Connection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConnectionFormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Button btnSend;

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox cbAutoscroll;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClientConnect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnServerListen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCloseConn;
        public System.Windows.Forms.TextBox tbSend;
        public System.Windows.Forms.TextBox tbClientIP;
        public System.Windows.Forms.TextBox tbClientPort;
        public System.Windows.Forms.TextBox tbServerPort;
        public System.Windows.Forms.TextBox tbLocal;
        public System.Windows.Forms.ListView lvConnections;
        public UIIronTextBox.IronTextBoxControl ironTextBoxControl1;
        private System.Windows.Forms.CheckBox cbNotification;
        private System.Windows.Forms.CheckBox cbSpeech;

    }
}