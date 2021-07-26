using System;
using System.Threading;
using System.Threading.Tasks;

namespace Demo_Observer_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var interfacesManager = new BDIInterfacesManager();

            //ESCENARIO 2: Cuando se quiere agregar una interfaz del tipo X cuando ya se esta ejeuctanod 1
            var interfaceToExecute1 = new InterfaceToExecute(1,"A",interfacesManager);

            interfacesManager.Attach(interfaceToExecute1);

            //SE ESTA EJEUCTANDO LA INTERFAZ 0 Y LUEGO DE 2 SEGUNDOS TERMINA Y LLAMA EL NOTIFY PARA AVISAR QUE YA ACABÓ
            Task t = Task.Run(() =>
            {
                Thread.Sleep(2000);
                interfacesManager.Notify("A");
            });

            var interfaceToExecute2 = new InterfaceToExecute(2, "A", interfacesManager);

            interfacesManager.Attach(interfaceToExecute2);

            var interfaceToExecute3 = new InterfaceToExecute(3, "A", interfacesManager);

            interfacesManager.Attach(interfaceToExecute3);

            Task t1 = Task.Run(() =>
            {
                Thread.Sleep(3000);
                interfacesManager.Notify("B");
            });

            var interfaceToExecute1B = new InterfaceToExecute(3, "B", interfacesManager);

            interfacesManager.Attach(interfaceToExecute1B);

            Console.ReadKey(); //BDIIM tendra el registro de todas las interfaces pendientes
            //por ejecuctar, y cuando una interfaz del tipo X se termine, se llama
            //Su metodo notify pasandole el parametro para que llame a la siguiente
            //interfaz de ese tipo a ejecutarse


            //DOS CAMINOS
            //If no hay interfaz pendiente, cuando se termine de ejecutar esa interfaz, al manager se le mandara la notificacion para que le avise a la siguiente interfaz que debe ejecutarse
            //If hay una interfaz pendiente, esta interfaz se agrega al manager para que cuando llegue su momento, la agregue
        }
    }
}
