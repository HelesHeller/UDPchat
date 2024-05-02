namespace TCPChat
{
    partial class AddChatForm
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
            this.txtChatName = new System.Windows.Forms.TextBox();
            this.btnCreateChat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtChatName
            // 
            this.txtChatName.Location = new System.Drawing.Point(12, 12);
            this.txtChatName.Name = "txtChatName";
            this.txtChatName.Size = new System.Drawing.Size(260, 20);
            this.txtChatName.TabIndex = 0;
            // 
            // btnCreateChat
            // 
            this.btnCreateChat.Location = new System.Drawing.Point(197, 38);
            this.btnCreateChat.Name = "btnCreateChat";
            this.btnCreateChat.Size = new System.Drawing.Size(75, 23);
            this.btnCreateChat.TabIndex = 1;
            this.btnCreateChat.Text = "Create Chat";
            this.btnCreateChat.UseVisualStyleBackColor = true;
            this.btnCreateChat.Click += new System.EventHandler(this.btnCreateChat_Click);
            // 
            // AddChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 73);
            this.Controls.Add(this.btnCreateChat);
            this.Controls.Add(this.txtChatName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddChatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Chat";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtChatName;
        private System.Windows.Forms.Button btnCreateChat;
    }
}
