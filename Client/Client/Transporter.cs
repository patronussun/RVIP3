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
    class Transporter
    {

        List<Car> car_tasks = new List<Car>();

        Store st = new Store();
        public void Constructor()
        {
            Console.WriteLine("Собираю машину...");
            st.StoreVoid();
            //  st.transmission_tasks.Add(new Transmission());

            car_tasks.Add(new Car()); // создаем новую машину
            //удаляем из очереди детали для машины
            st.engine_tasks.RemoveAt(0);
            st.transmission_tasks.RemoveAt(0);
            st.carcase_tasks.RemoveAt(0);

            Thread.Sleep(2000);
        }

    }


}
