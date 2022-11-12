namespace Cliente
{
    partial class ClienteForm
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
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxIPAddress = new System.Windows.Forms.TextBox();
            this.labelConnectTo = new System.Windows.Forms.Label();
            this.labelConnStatus = new System.Windows.Forms.Label();
            this.listBoxMsgs = new System.Windows.Forms.ListBox();
            this.labelMsgs = new System.Windows.Forms.Label();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.labelEscribeMsgs = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(21, 90);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(156, 23);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Conectar";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textBoxIPAddress
            // 
            this.textBoxIPAddress.Location = new System.Drawing.Point(21, 39);
            this.textBoxIPAddress.Name = "textBoxIPAddress";
            this.textBoxIPAddress.PlaceholderText = "Dirección IP";
            this.textBoxIPAddress.Size = new System.Drawing.Size(156, 23);
            this.textBoxIPAddress.TabIndex = 1;
            // 
            // labelConnectTo
            // 
            this.labelConnectTo.AutoSize = true;
            this.labelConnectTo.Location = new System.Drawing.Point(21, 21);
            this.labelConnectTo.Name = "labelConnectTo";
            this.labelConnectTo.Size = new System.Drawing.Size(134, 15);
            this.labelConnectTo.TabIndex = 2;
            this.labelConnectTo.Text = "Dirección IP del servidor";
            // 
            // labelConnStatus
            // 
            this.labelConnStatus.AutoSize = true;
            this.labelConnStatus.Location = new System.Drawing.Point(458, 21);
            this.labelConnStatus.Name = "labelConnStatus";
            this.labelConnStatus.Size = new System.Drawing.Size(82, 15);
            this.labelConnStatus.TabIndex = 3;
            this.labelConnStatus.Text = "Desconectado";
            // 
            // listBoxMsgs
            // 
            this.listBoxMsgs.Enabled = false;
            this.listBoxMsgs.FormattingEnabled = true;
            this.listBoxMsgs.ItemHeight = 15;
            this.listBoxMsgs.Location = new System.Drawing.Point(206, 39);
            this.listBoxMsgs.Name = "listBoxMsgs";
            this.listBoxMsgs.Size = new System.Drawing.Size(334, 289);
            this.listBoxMsgs.TabIndex = 4;
            // 
            // labelMsgs
            // 
            this.labelMsgs.AutoSize = true;
            this.labelMsgs.Location = new System.Drawing.Point(206, 21);
            this.labelMsgs.Name = "labelMsgs";
            this.labelMsgs.Size = new System.Drawing.Size(56, 15);
            this.labelMsgs.TabIndex = 5;
            this.labelMsgs.Text = "Mensajes";
            // 
            // textBoxInput
            // 
            this.textBoxInput.Enabled = false;
            this.textBoxInput.Location = new System.Drawing.Point(206, 368);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(334, 23);
            this.textBoxInput.TabIndex = 6;
            // 
            // labelEscribeMsgs
            // 
            this.labelEscribeMsgs.AutoSize = true;
            this.labelEscribeMsgs.Location = new System.Drawing.Point(206, 350);
            this.labelEscribeMsgs.Name = "labelEscribeMsgs";
            this.labelEscribeMsgs.Size = new System.Drawing.Size(108, 15);
            this.labelEscribeMsgs.TabIndex = 7;
            this.labelEscribeMsgs.Text = "Escribe un mensaje";
            // 
            // buttonSend
            // 
            this.buttonSend.Enabled = false;
            this.buttonSend.Location = new System.Drawing.Point(427, 402);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(113, 23);
            this.buttonSend.TabIndex = 8;
            this.buttonSend.Text = "Enviar";
            this.buttonSend.UseVisualStyleBackColor = true;
            // 
            // ClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 437);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.labelEscribeMsgs);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.labelMsgs);
            this.Controls.Add(this.listBoxMsgs);
            this.Controls.Add(this.labelConnStatus);
            this.Controls.Add(this.labelConnectTo);
            this.Controls.Add(this.textBoxIPAddress);
            this.Controls.Add(this.buttonConnect);
            this.Name = "ClienteForm";
            this.Text = "ChatRoom - Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonConnect;
        private TextBox textBoxIPAddress;
        private Label labelConnectTo;
        private Label labelConnStatus;
        private ListBox listBoxMsgs;
        private Label labelMsgs;
        private TextBox textBoxInput;
        private Label labelEscribeMsgs;
        private Button buttonSend;
    }
}