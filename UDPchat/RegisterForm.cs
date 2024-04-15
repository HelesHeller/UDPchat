using System;
using System.Linq;
using System.Windows.Forms;

namespace UDPchat
{
    public partial class RegisterForm : Form
    {
        private readonly TCPServer.ApplicationContext dbContext;
        

        public RegisterForm()
        {
            InitializeComponent();
            dbContext = new TCPServer.ApplicationContext();
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
            var newUser = new TCPServer.User { Username = username, Password = password };
            dbContext.Users.Add(newUser);
            dbContext.SaveChanges();

            MessageBox.Show("Регистрация успешна!");
        }

    }
}
