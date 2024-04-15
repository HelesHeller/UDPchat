using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Windows.Forms;
using UDPChat;

namespace UDPchat
{
    public partial class LoginForm : Form
    {
        private readonly string constring = "Data Source=HELES;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                // Проверка существования пользователя в базе данных
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Авторизация успешна!");

                    // Скрыть текущую форму
                    this.Hide();

                    // Показать главную форму приложения
                    MainForm mainForm = new MainForm(username);
                    mainForm.ShowDialog();

                    // Показать или закрыть форму в зависимости от вашей логики
                    // mainForm.Show();
                    // this.Close();
                }
                else
                {
                    MessageBox.Show("Неверное имя пользователя или пароль.");
                }
            }
        }
    }
}
