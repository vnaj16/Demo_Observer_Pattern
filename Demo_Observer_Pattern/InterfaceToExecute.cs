using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo_Observer_Pattern
{
    public class InterfaceToExecute : IObserver
    {
        private IObservable BDIInterfacesManager;
        public int ID { get; set; }
        public int Order { get; set; }
        public string Type { get; set; }
        private int ExecutionTime { get; set; }
        public InterfaceToExecute(int ID, string Type, IObservable bDIInterfacesManager)
        {
            this.ID = ID;
            this.Type = Type;
            BDIInterfacesManager = bDIInterfacesManager;
            this.ExecutionTime = new Random().Next(2500, 5000);
        }

        public void Update()
        {//ACA CREO QUE SE HARIA EL LLAMADO A LA DB PARAO BTENER EL OBJETO INTERFAZ Y MANDAR A BDI, ACA TAMBIEN SE CREARIA EL NUEVO HILO
            Task t = Task.Run(() =>
            {
                Console.WriteLine($"INTERFAZ TIPO {Type}: se procede a ejecutar la interfaz con codigo {ID}");
                Thread.Sleep(this.ExecutionTime);
                Console.WriteLine($"Interfaz con codigo {ID} ejecutada con exito");
                this.BDIInterfacesManager.Notify(Type);
            });
        }
    }
}
