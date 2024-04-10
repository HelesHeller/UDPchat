partial class LoginForm : Form
{
    private System.ComponentModel.IContainer components = null;
    private Button btnLogin;
    private TextBox txtUsername;
    private TextBox txtPassword;
    private Label lblUsername;
    private Label lblPassword;
    private LinkLabel linkRegister;

    public LoginForm()
    {
        InitializeComponent();
    }

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
        btnLogin = new Button();
        txtUsername = new TextBox();
        txtPassword = new TextBox();
        lblUsername = new Label();
        lblPassword = new Label();
        linkRegister = new LinkLabel();
        SuspendLayout();
        // 
        // btnLogin
        // 
        btnLogin.Location = new Point(120, 120);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(75, 23);
        btnLogin.TabIndex = 5;
        btnLogin.Text = "Login";
        btnLogin.Click += btnLogin_Click;
        // 
        // txtUsername
        // 
        txtUsername.Location = new Point(120, 30);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(150, 23);
        txtUsername.TabIndex = 4;
        // 
        // txtPassword
        // 
        txtPassword.Location = new Point(120, 60);
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '*';
        txtPassword.Size = new Size(150, 23);
        txtPassword.TabIndex = 3;
        // 
        // lblUsername
        // 
        lblUsername.Location = new Point(20, 30);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(100, 20);
        lblUsername.TabIndex = 2;
        lblUsername.Text = "Username:";
        // 
        // lblPassword
        // 
        lblPassword.Location = new Point(20, 60);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(100, 20);
        lblPassword.TabIndex = 1;
        lblPassword.Text = "Password:";
        // 
        // linkRegister
        // 
        linkRegister.AutoSize = true;
        linkRegister.Location = new Point(65, 86);
        linkRegister.Name = "linkRegister";
        linkRegister.Size = new Size(205, 15);
        linkRegister.TabIndex = 0;
        linkRegister.TabStop = true;
        linkRegister.Text = "Don't have an account? Register here.";
        linkRegister.LinkClicked += linkRegister_LinkClicked;
        // 
        // LoginForm
        // 
        ClientSize = new Size(298, 170);
        Controls.Add(linkRegister);
        Controls.Add(lblPassword);
        Controls.Add(lblUsername);
        Controls.Add(txtPassword);
        Controls.Add(txtUsername);
        Controls.Add(btnLogin);
        Name = "LoginForm";
        Text = "Login";
        ResumeLayout(false);
        PerformLayout();
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        // Логика для авторизации
    }

    private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        // Открытие формы регистрации
    }
}
