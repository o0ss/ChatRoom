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
            this.labelUsrs = new System.Windows.Forms.Label();
            this.labelMsgs = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.listBoxUsrs = new System.Windows.Forms.ListBox();
            this.listBoxMsgs = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // labelUsrs
            // 
            this.labelUsrs.AutoSize = true;
            this.labelUsrs.Location = new System.Drawing.Point(29, 50);
            this.labelUsrs.Name = "labelUsrs";
            this.labelUsrs.Size = new System.Drawing.Size(232, 32);
            this.labelUsrs.TabIndex = 0;
            this.labelUsrs.Text = "Usuarios conectados";
            // 
            // labelMsgs
            // 
            this.labelMsgs.AutoSize = true;
            this.labelMsgs.Location = new System.Drawing.Point(381, 50);
            this.labelMsgs.Name = "labelMsgs";
            this.labelMsgs.Size = new System.Drawing.Size(114, 32);
            this.labelMsgs.TabIndex = 1;
            this.labelMsgs.Text = "Mensajes";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(858, 36);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(150, 46);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Iniciar";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // listBoxUsrs
            // 
            this.listBoxUsrs.FormattingEnabled = true;
            this.listBoxUsrs.ItemHeight = 32;
            this.listBoxUsrs.Location = new System.Drawing.Point(29, 107);
            this.listBoxUsrs.Name = "listBoxUsrs";
            this.listBoxUsrs.Size = new System.Drawing.Size(288, 516);
            this.listBoxUsrs.TabIndex = 5;
            // 
            // listBoxMsgs
            // 
            this.listBoxMsgs.FormattingEnabled = true;
            this.listBoxMsgs.ItemHeight = 32;
            this.listBoxMsgs.Location = new System.Drawing.Point(372, 107);
            this.listBoxMsgs.Name = "listBoxMsgs";
            this.listBoxMsgs.Size = new System.Drawing.Size(650, 516);
            this.listBoxMsgs.TabIndex = 7;
            // 
            // ServidorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 657);
            this.Controls.Add(this.listBoxMsgs);
            this.Controls.Add(this.listBoxUsrs);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelMsgs);
            this.Controls.Add(this.labelUsrs);
            this.Name = "ServidorForm";
            this.Text = "ChatRoom - Servidor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelUsrs;
        private Label labelMsgs;
        private Button buttonStart;
        private ListBox listBoxUsrs;
        private ListBox listBoxMsgs;
    }
}