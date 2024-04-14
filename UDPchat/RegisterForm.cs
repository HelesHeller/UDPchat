using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UDPchat
{
    public partial class RegisterForm : Form
    {
        private readonly UDPServer.ApplicationContext dbContext;


        public RegisterForm()
        {
            InitializeComponent();
            dbContext = new UDPServer.ApplicationContext();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Проверка наличия пользователя с таким именем в базе данных
            var existingUser = dbContext.Users.FirstOrDefault(u => u.Username == username);
            if (existingUser != null)
            {
                MessageBox.Show("Пользователь с таким именем уже существует.");
                return;
            }

            // Создание нового пользователя и сохранение его в базе данных
            var newUser = new UDPServer.User { Username = username, Password = password };
            dbContext.Users.Add(newUser);
            dbContext.SaveChanges();

            MessageBox.Show("Регистрация успешна!");
        }


    }
}
