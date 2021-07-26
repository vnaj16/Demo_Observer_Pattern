using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo_Observer_Pattern
{
    public class BDIInterfacesManager : IObservable
    {
        private List<InterfaceToExecute> interfacesToExecute = new List<InterfaceToExecute>();

        public void Attach(IObserver o)
        {
            var newInterface = (InterfaceToExecute)o;
            newInterface.Order = interfacesToExecute.Where(x => x.Type == newInterface.Type).Count() + 1;
            this.interfacesToExecute.Add(newInterface);
        }

        public void Notify(string interfaceType) //ESTE NOTIFY LE DICE A LA INTERFAZ SIGUIENTE QUE DEBE PASAR A EJEUCTARSE, Y LUEGO SE QUITA DE LA LISTA
        {
            if (interfacesToExecute.Where(x => x.Type == interfaceType).Count() > 0)
            {
                var interface2Exec = interfacesToExecute.Where(x => x.Type == interfaceType).OrderBy(x => x.Order).ToList()[0];
                interfacesToExecute.Remove(interface2Exec);
                interface2Exec.Update();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"Se terminaron de ejecutar las interfaces del tipo {interfaceType}");
                Console.WriteLine("La lista quedo asi:");
                Console.WriteLine();
                foreach (var item in interfacesToExecute)
                {
                    Console.WriteLine($"Interface {item.ID} - {item.Type}");
                }
            }
        }
    }
}
