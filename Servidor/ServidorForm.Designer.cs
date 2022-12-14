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
            this.labelMsgs = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.listBoxMsgs = new System.Windows.Forms.ListBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelMsgs
            // 
            this.labelMsgs.AutoSize = true;
            this.labelMsgs.Enabled = false;
            this.labelMsgs.Location = new System.Drawing.Point(23, 50);
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
            this.buttonStart.Location = new System.Drawing.Point(23, 10);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(352, 22);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Iniciar";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // listBoxMsgs
            // 
            this.listBoxMsgs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxMsgs.Enabled = false;
            this.listBoxMsgs.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxMsgs.FormattingEnabled = true;
            this.listBoxMsgs.ItemHeight = 20;
            this.listBoxMsgs.Location = new System.Drawing.Point(23, 77);
            this.listBoxMsgs.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.listBoxMsgs.Name = "listBoxMsgs";
            this.listBoxMsgs.Size = new System.Drawing.Size(352, 304);
            this.listBoxMsgs.TabIndex = 7;
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend.Enabled = false;
            this.buttonSend.Location = new System.Drawing.Point(300, 419);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 3;
            this.buttonSend.Text = "Enviar";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(23, 390);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(352, 23);
            this.textBoxInput.TabIndex = 8;
            // 
            // ServidorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 457);
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
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TextBox textBoxInput;
    }
}