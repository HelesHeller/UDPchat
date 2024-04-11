using System;
using System.Windows.Forms;


namespace UDPChat
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        public void btnRegister_Click(object sender, EventArgs e)
        {

            string nickname = txtUsername.Text;
            string password = txtPassword.Text;

            // Проверка наличия имени пользователя и пароля
            if (!string.IsNullOrEmpty(nickname) && !string.IsNullOrEmpty(password))
            {
                // Здесь можно добавить логику для проверки и сохранения данных регистрации

                // Пример: скрываем форму регистрации и отображаем главную форму
                this.Hide();
                MainForm mainForm = new MainForm(nickname);
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Введите имя пользователя и пароль!");
            }
            //

            // Пример: просто выводим информацию о зарегистрированном пользователе
            MessageBox.Show($"Пользователь {nickname} успешно зарегистрирован!");
        }
    }
}
