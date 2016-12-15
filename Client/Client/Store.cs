using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace РВИП2_консоль
{
    class Store
    {
        //public Store()
        //{

        //    List<Engine> engine_tasks = new List<Engine>();
        //    List<Transmission> transmission_tasks = new List<Transmission>();
        //    List<Carcase> carcase_tasks = new List<Carcase>();

        //    engine_tasks.Add(new Engine());


        //}

        public List<Engine> engine_tasks = new List<Engine>();
        public List<Transmission> transmission_tasks = new List<Transmission>();
        public List<Carcase> carcase_tasks = new List<Carcase>();

       public  void StoreVoid()
        {
            for (int i =0; i < 10; i++) 
            {
            engine_tasks.Add(new Engine());
            carcase_tasks.Add(new Carcase());
            transmission_tasks.Add(new Transmission());
            }
        }

        //public Engine getEngine()
        //{
        //   if (engine_tasks.Count != 0)
        //       return engine_tasks.Get(0);
        //   }

        //public Carcase getCarcase()
        //{
        //   if (carcase_tasks.Count != 0)

        //}

        //List<Transmission> getTransmission()
        //{
        //    if (transmission_tasks.Count !=0)
        //        return
        //}
    }



}

