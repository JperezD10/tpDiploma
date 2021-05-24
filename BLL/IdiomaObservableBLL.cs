using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class IdiomaObservableBLL
    {
        private List<IObserver<string>> listaObservers = new List<IObserver<string>>();

        public void Notify(string idioma)
        {
            foreach (IObserver<string> observer in listaObservers)
            {
                observer.OnNext(idioma);
                observer.OnCompleted();
            }
        }

        public void AddObserver(IObserver<string> observer)
        {
            if (listaObservers.Contains(observer)) return;
            listaObservers.Add(observer);
        }

        public void RemoveObserver(IObserver<string> observer)
        {
            listaObservers.Remove(observer);
        }
    }
}
