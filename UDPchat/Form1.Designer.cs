namespace TCPChat
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            listBoxChat = new ListBox();
            textBoxMessage = new TextBox();
            buttonSend = new Button();
            panelChats = new Panel();
            panelParticipants = new Panel();
            buttonAddChat = new Button();
            SuspendLayout();
            // 
            // listBoxChat
            // 
            listBoxChat.BackColor = Color.Snow;
            listBoxChat.BorderStyle = BorderStyle.None;
            listBoxChat.ForeColor = Color.Maroon;
            listBoxChat.FormattingEnabled = true;
            listBoxChat.ItemHeight = 15;
            listBoxChat.Location = new Point(133, 7);
            listBoxChat.Margin = new Padding(4, 3, 4, 3);
            listBoxChat.MaximumSize = new Size(705, 390);
            listBoxChat.MinimumSize = new Size(705, 390);
            listBoxChat.Name = "listBoxChat";
            listBoxChat.Size = new Size(705, 390);
            listBoxChat.TabIndex = 0;
            // 
            // textBoxMessage
            // 
            textBoxMessage.BackColor = Color.MistyRose;
            textBoxMessage.BorderStyle = BorderStyle.FixedSingle;
            textBoxMessage.ForeColor = Color.Maroon;
            textBoxMessage.Location = new Point(133, 403);
            textBoxMessage.Margin = new Padding(4, 3, 4, 3);
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.Size = new Size(609, 23);
            textBoxMessage.TabIndex = 1;
            // 
            // buttonSend
            // 
            buttonSend.BackColor = Color.MistyRose;
            buttonSend.FlatStyle = FlatStyle.Flat;
            buttonSend.ForeColor = Color.Maroon;
            buttonSend.Location = new Point(750, 403);
            buttonSend.Margin = new Padding(4, 3, 4, 3);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(88, 23);
            buttonSend.TabIndex = 2;
            buttonSend.Text = "Send";
            buttonSend.UseVisualStyleBackColor = false;
            buttonSend.Click += buttonSend_Click;
            // 
            // panelChats
            // 
            panelChats.BackColor = Color.Snow;
            panelChats.ForeColor = Color.Tomato;
            panelChats.Location = new Point(10, 7);
            panelChats.Name = "panelChats";
            panelChats.Size = new Size(116, 390);
            panelChats.TabIndex = 3;
            // 
            // panelParticipants
            // 
            panelParticipants.BackColor = Color.Snow;
            panelParticipants.Location = new Point(845, 7);
            panelParticipants.Name = "panelParticipants";
            panelParticipants.Size = new Size(150, 419);
            panelParticipants.TabIndex = 4;
            // 
            // buttonAddChat
            // 
            buttonAddChat.BackColor = Color.MistyRose;
            buttonAddChat.FlatStyle = FlatStyle.Flat;
            buttonAddChat.ForeColor = Color.Maroon;
            buttonAddChat.Location = new Point(10, 403);
            buttonAddChat.Name = "buttonAddChat";
            buttonAddChat.Size = new Size(116, 23);
            buttonAddChat.TabIndex = 5;
            buttonAddChat.Text = "Add Chat";
            buttonAddChat.UseVisualStyleBackColor = false;
            buttonAddChat.Click += buttonAddChat_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1005, 438);
            Controls.Add(panelParticipants);
            Controls.Add(panelChats);
            Controls.Add(buttonSend);
            Controls.Add(listBoxChat);
            Controls.Add(textBoxMessage);
            Controls.Add(buttonAddChat);
            ForeColor = Color.DarkRed;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "Cherry Blossom Chat";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.ListBox listBoxChat;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Panel panelChats;
        private System.Windows.Forms.Panel panelParticipants;
        private System.Windows.Forms.Button buttonAddChat;
    }
}
