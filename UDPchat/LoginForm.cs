using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UDPChat;
using UDPchat.Server;



namespace UDPchat
{
    public partial class LoginForm : Form
    {
        private Server.ApplicationContext db = new Server.ApplicationContext();

        public LoginForm()
        {
            InitializeComponent();
        }

        public void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Проверка существования пользователя в базе данных
            var user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                MessageBox.Show("Авторизация успешна!");
                // Открыть основную форму приложения или другую необходимую форму
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.");
            }
        }




        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Создаем новый экземпляр RegisterForm и отображаем его
            RegisterForm registrationForm = new RegisterForm();
            registrationForm.Show();
        }





    }
}
    




