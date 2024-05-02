using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    db.Database.EnsureCreated();
            //}
            StartServer();

            static void StartServer()
            {
                // Устанавливаем IP-адрес и порт для прослушивания
                string ipAddress = "127.0.0.1";
                int port = 12121;

                // Создаем TCPListener для прослушивания входящих подключений
                TcpListener listener = new TcpListener(IPAddress.Parse(ipAddress), port);

                try
                {
                    // Начинаем прослушивание
                    listener.Start();
                    Console.WriteLine("Сервер запущен...");

                    while (true)
                    {
                        // Принимаем входящее подключение
                        TcpClient client = listener.AcceptTcpClient();
                        Console.WriteLine("Установлено подключение!");

                        // Получаем поток сетевых данных для чтения и записи
                        NetworkStream stream = client.GetStream();

                        // Буфер для хранения полученных данных
                        byte[] data = new byte[256];

                        // Читаем данные из потока
                        int bytes = stream.Read(data, 0, data.Length);
                        string message = Encoding.UTF8.GetString(data, 0, bytes);
                        Console.WriteLine($"Получено сообщение: {message}");

                        // Отправляем ответ клиенту
                        string response = "Сообщение получено!";
                        byte[] responseData = Encoding.UTF8.GetBytes(response);
                        stream.Write(responseData, 0, responseData.Length);

                        // Закрываем подключение
                        client.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                finally
                {
                    // Останавливаем прослушивание
                    listener.Stop();
                }
            }
        }
    }
}
