namespace UDPchat
{
    partial class RegisterForm
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
            labelUsername = new Label();
            txtUsername = new TextBox();
            labelPassword = new Label();
            txtPassword = new TextBox();
            buttonRegister = new Button();
            SuspendLayout();
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(35, 35);
            labelUsername.Margin = new Padding(4, 0, 4, 0);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(78, 15);
            labelUsername.TabIndex = 0;
            labelUsername.Text = "Введите имя:";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.Snow;
            txtUsername.Location = new Point(38, 54);
            txtUsername.Margin = new Padding(4, 3, 4, 3);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(233, 23);
            txtUsername.TabIndex = 1;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(35, 104);
            labelPassword.Margin = new Padding(4, 0, 4, 0);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(96, 15);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Введите пароль:";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.Snow;
            txtPassword.Location = new Point(38, 123);
            txtPassword.Margin = new Padding(4, 3, 4, 3);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(233, 23);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // buttonRegister
            // 
            buttonRegister.BackColor = Color.Snow;
            buttonRegister.Location = new Point(91, 152);
            buttonRegister.Margin = new Padding(4, 3, 4, 3);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(142, 27);
            buttonRegister.TabIndex = 4;
            buttonRegister.Text = "Зарегистрироваться";
            buttonRegister.UseVisualStyleBackColor = false;
            buttonRegister.Click += btnRegister_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(331, 220);
            Controls.Add(buttonRegister);
            Controls.Add(txtPassword);
            Controls.Add(labelPassword);
            Controls.Add(txtUsername);
            Controls.Add(labelUsername);
            Margin = new Padding(4, 3, 4, 3);
            Name = "RegisterForm";
            Text = "Регистрация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button buttonRegister;
    }
}
