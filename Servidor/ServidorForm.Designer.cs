namespace Servidor
{
    partial class ServidorForm
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
            this.components = new System.ComponentModel.Container();
            this.labelMsgs = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.listBoxMsgs = new System.Windows.Forms.ListBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.timerCheckMsgs = new System.Windows.Forms.Timer(this.components);
            this.labelServidorStatus = new System.Windows.Forms.Label();
            this.timerCheckConnection = new System.Windows.Forms.Timer(this.components);
            this.labelConnStatus = new System.Windows.Forms.Label();
            this.labelEscribeMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelMsgs
            // 
            this.labelMsgs.AutoSize = true;
            this.labelMsgs.Enabled = false;
            this.labelMsgs.Location = new System.Drawing.Point(23, 21);
            this.labelMsgs.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMsgs.Name = "labelMsgs";
            this.labelMsgs.Size = new System.Drawing.Size(56, 15);
            this.labelMsgs.TabIndex = 1;
            this.labelMsgs.Text = "Mensajes";
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Location = new System.Drawing.Point(459, 41);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(163, 22);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Iniciar servidor";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // listBoxMsgs
            // 
            this.listBoxMsgs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxMsgs.Enabled = false;
            this.listBoxMsgs.FormattingEnabled = true;
            this.listBoxMsgs.ItemHeight = 15;
            this.listBoxMsgs.Location = new System.Drawing.Point(23, 41);
            this.listBoxMsgs.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.listBoxMsgs.Name = "listBoxMsgs";
            this.listBoxMsgs.Size = new System.Drawing.Size(397, 274);
            this.listBoxMsgs.TabIndex = 7;
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend.Enabled = false;
            this.buttonSend.Location = new System.Drawing.Point(314, 407);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(106, 23);
            this.buttonSend.TabIndex = 3;
            this.buttonSend.Text = "Enviar";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxInput
            // 
            this.textBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxInput.Location = new System.Drawing.Point(23, 375);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(397, 23);
            this.textBoxInput.TabIndex = 8;
            // 
            // timerCheckMsgs
            // 
            this.timerCheckMsgs.Interval = 500;
            this.timerCheckMsgs.Tick += new System.EventHandler(this.timerCheckMsgs_Tick);
            // 
            // labelServidorStatus
            // 
            this.labelServidorStatus.AutoSize = true;
            this.labelServidorStatus.Location = new System.Drawing.Point(459, 76);
            this.labelServidorStatus.Name = "labelServidorStatus";
            this.labelServidorStatus.Size = new System.Drawing.Size(154, 15);
            this.labelServidorStatus.TabIndex = 9;
            this.labelServidorStatus.Text = "El servidor está desactivado.";
            // 
            // timerCheckConnection
            // 
            this.timerCheckConnection.Interval = 2000;
            this.timerCheckConnection.Tick += new System.EventHandler(this.timerCheckConnection_Tick);
            // 
            // labelConnStatus
            // 
            this.labelConnStatus.AutoSize = true;
            this.labelConnStatus.Location = new System.Drawing.Point(338, 21);
            this.labelConnStatus.Name = "labelConnStatus";
            this.labelConnStatus.Size = new System.Drawing.Size(82, 15);
            this.labelConnStatus.TabIndex = 10;
            this.labelConnStatus.Text = "Desconectado";
            // 
            // labelEscribeMsg
            // 
            this.labelEscribeMsg.AutoSize = true;
            this.labelEscribeMsg.Location = new System.Drawing.Point(23, 357);
            this.labelEscribeMsg.Name = "labelEscribeMsg";
            this.labelEscribeMsg.Size = new System.Drawing.Size(108, 15);
            this.labelEscribeMsg.TabIndex = 11;
            this.labelEscribeMsg.Text = "Escribe un mensaje";
            // 
            // ServidorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 442);
            this.Controls.Add(this.labelEscribeMsg);
            this.Controls.Add(this.labelConnStatus);
            this.Controls.Add(this.labelServidorStatus);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.listBoxMsgs);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelMsgs);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "ServidorForm";
            this.Text = "ChatRoom - Servidor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label labelMsgs;
        private Button buttonStart;
        private ListBox listBoxMsgs;
        private Button buttonSend;
        private TextBox textBoxInput;
        private System.Windows.Forms.Timer timerCheckMsgs;
        private Label labelServidorStatus;
        private System.Windows.Forms.Timer timerCheckConnection;
        private Label labelConnStatus;
        private Label labelEscribeMsg;
    }
}