using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace РВИП2_консоль
{
    class Program
    {
        static int port = 8005; // порт сервера
        static string address = "127.0.0.1"; // адрес сервера
        
        const int Maxcount_car = 10;
        //public int count_car = 0;

        static void Main(string[] args)
        {

            Thread th_car1 = new Thread(ThreadFunction);
            th_car1.Start(true);
            Thread th_car2 = new Thread(ThreadFunction);
            th_car2.Start(false);
            Console.Read();
        }

        static void ThreadFunction(Object input)
        {
            try
            {
                int count_car = 0;
                bool flag = (bool)input;
                Transporter transp = new Transporter();

                for (int i = 0; i < Maxcount_car; i++)
                {
                    IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    // подключаемся к удаленному хосту
                    socket.Connect(ipPoint);

                    //Если входящий флаг true - значит "я первый поток"
                    if (flag)
                    {
                        transp.Constructor();
                        count_car++;
                        Console.WriteLine(("Собрал машину в первом потоке. Это" + count_car.ToString() + "машина"));
                        
                    }
                    //Если входящий флаг false - значит "я второй поток"
                    else
                    {
                        transp.Constructor();
                        count_car++;
                        Console.WriteLine("Собрал машину во втором потоке. Это" + count_car.ToString() + "машина");
                        
                    }
                    
                    string message = count_car.ToString();
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    socket.Send(data);

                    // получаем ответ
                    data = new byte[256]; // буфер для ответа
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0; // количество полученных байт
                    do
                    {
                        bytes = socket.Receive(data, data.Length, 0);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (socket.Available > 0);
                    Console.WriteLine("ответ сервера: " + builder.ToString());

                    // закрываем сокет
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }

    }
}
