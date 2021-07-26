using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Observer_Pattern
{
    public interface IObservable
    {
        public void Attach(IObserver o);
        //TODO: Remove
        public void Notify(string interfaceType);
    }
}
