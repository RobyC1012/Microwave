using Microwave.Stari;
using System;
using System.Windows;

namespace Microwave
{
    public partial class MainWindow : Window, IAfisaj_Microunde, IObserver<Stare>
    {
        public static Context _context;
        static MainWindow instance;
        private IDisposable unsubscriber;

        public MainWindow()
        {
            InitializeComponent();
            _context = Context.getInstance(this);
            Subscribe(_context);
            instance = this;
        }

        #region Actiuni utilizator
        private void ButonInchideUsa_Click(object sender, RoutedEventArgs e)
        {
            _context.InchideUsa();
        }

        private void ButonDeschideUsa_Click(object sender, RoutedEventArgs e)
        {
            _context.DeschideUsa();
        }

        private void ButonGatire_Click(object sender, RoutedEventArgs e)
        {
            _context.Gateste();
        }
        #endregion

        #region Interfata Grafica Utilizator
        public void setUsaDeschisa()
        {
            StareUsa.Content = "Usa deschisa";
            setGatesteOff();
        }

        public void setUsaInchisa()
        {
            StareUsa.Content = "Usa inchisa";
            setGatesteOff();
        }

        public void setGatesteOn()
        {
            StareCuptor.Content = "Gatire ON";
            ButonGatire.Content = "Pornit";
        }
        public void setGatesteOff()
        {
            StareCuptor.Content = "Gatire OFF";
            ButonGatire.Content = "Oprit";
        }

        public void setTimpRamas(int time)
        {
            Ticker.Content = time;
        }

        #endregion

        #region Sablonul Observer

        public void Subscribe(IObservable<Stare> context)
        {
            unsubscriber = context.Subscribe(this);
        }
        
        public void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        public void OnNext(Stare value)
        {
            if (value is STARE_GATESTE_ON)
            {
                setGatesteOn();
                setTimpRamas(_context.GetTimpRamas());
                if(_context.GetTimpRamas() == 0)
                {
                    setGatesteOff();
                }

            } else if (value is STARE_USA_DESCHISA)
            {
                setUsaDeschisa();
                setGatesteOff();
                setTimpRamas(_context.GetTimpRamas());

            } else if (value is STARE_USA_INCHISA)
            {
                setUsaInchisa();
            }
        }

        public void OnCompleted()
        {
            ((IObserver<Stare>)instance).OnCompleted();
        }

        public void OnError(Exception error)
        {
            ((IObserver<Stare>)instance).OnError(error);
        }

        #endregion
    }
}
