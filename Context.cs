using Microwave.Stari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microwave
{
    public class Context : IObservable<Stare>
    {
        public Stare stareCurenta;
        public int timpRamas { get; set;}
        public MainWindow mainWindow;
        public List<IObserver<Stare>> observatori = new List<IObserver<Stare>>();

        #region Singleton

        private static Context _instance = null;
        private Context(MainWindow window) {
            mainWindow = window;
            stareCurenta = STARE_USA_INCHISA.getInstance();
            timpRamas = 0;
        }
        public static Context getInstance(MainWindow window) => _instance == null ? new Context(window) : _instance;

        #endregion

        #region Logica functiilor de stare
        public void InchideUsa()
        {
            stareCurenta.InchideUsa();
        }

        public void DeschideUsa()
        {
            stareCurenta.DeschideUsa();
        }

        public void Gateste()
        {
            stareCurenta.Gateste();
        }

        public int GetTimpRamas()
        {
            return timpRamas;
        }

        #endregion

        #region Sablon Observer

        public void Display()
        {
            foreach (IObserver<Stare> observator in observatori)
            {
                observator.OnNext(stareCurenta);
            }
        }

        public IDisposable Subscribe(IObserver<Stare> observator)
        {
            if (!observatori.Contains(observator))
                observatori.Add(observator);
            return new Unsubscribe(observatori, observator);
        }

        #endregion

        #region Timer pentru gatire

        public async void TickCeas()
        {
            while (timpRamas > 0 && stareCurenta is STARE_GATESTE_ON)
            {
                await Task.Delay(1000);
                stareCurenta.TickCeas();
            }

            if (timpRamas == 0)
            {
                stareCurenta = STARE_USA_INCHISA.getInstance();
                Display();
            }
        }

        #endregion
    }
}
