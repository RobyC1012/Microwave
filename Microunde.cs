using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microwave.MainWindow;

namespace Microwave
{
    class Microunde : IAfisaj_Microunde
    {
        public enum Stari
        {
            STARE_USA_INCHISA,
            STARE_USA_DESCHISA,
            STARE_GATESTE_ON
        }


        private Stari stare {  get; set; }
        private int timp_ramas;
        private static MainWindow _mainWindow;
        
        
        private static Microunde _instance = null;
        private Microunde(MainWindow mainWindow)
        {
            stare = Stari.STARE_USA_INCHISA;
            timp_ramas = 0;
            _mainWindow = mainWindow;
        }
        public static Microunde getInstance(MainWindow mainWindow) => _instance == null ? new Microunde(mainWindow) : _instance;

        public void DeschideUsa()
        {
            switch (stare)
            {
                case Stari.STARE_GATESTE_ON:
                {
                    setGatesteOff();
                    setUsaDeschisa();
                    break;
                }
                case Stari.STARE_USA_INCHISA:
                {
                    setUsaDeschisa();
                    break;
                }
            }
        }

        public void InchideUsa()
        {
            switch(stare)
            {
                case Stari.STARE_USA_DESCHISA:
                {
                    setUsaInchisa();   
                    break;
                }
            }
        }

        public void Gateste()
        {
            switch (stare)
            {
                case Stari.STARE_USA_INCHISA:
                {
                    setGatesteOn();
                    if(timp_ramas == 0)
                        timp_ramas = 10;
                    setTimpRamas();
                    TickCeas();
                    break;
                }
            }
        }

        async void TickCeas()
        {
            while (timp_ramas >= 0 && stare == Stari.STARE_GATESTE_ON)
            {
                await Task.Delay(1000);
                timp_ramas--;
                setTimpRamas();
            }

            if (GetStare() == Stari.STARE_GATESTE_ON)
            {
                for(int i = 0; i < 3; i++)
                    Console.Beep(1200, 800);
                setUsaInchisa();
                setGatesteOff();
            }
        }

        public Stari GetStare() { return stare; }
        
        public void setGatesteOn()
        {
            stare = Stari.STARE_GATESTE_ON;
            _mainWindow.ButonGatire.Content = "Pornit";
            _mainWindow.StareCuptor.Content = "Gatire ON";
        }

        public void setGatesteOff()
        {
            stare = Stari.STARE_USA_INCHISA;
            _mainWindow.ButonGatire.Content = "Oprit";
            _mainWindow.StareCuptor.Content = "Gatire OFF";
        }

        public void setUsaDeschisa()
        {
            stare = Stari.STARE_USA_DESCHISA;
            _mainWindow.StareUsa.Content = "Usa deschisa";
        }

        public void setUsaInchisa()
        {
            stare = Stari.STARE_USA_INCHISA;
            _mainWindow.StareUsa.Content = "Usa inchisa";
        }

        public void setTimpRamas()
        {
            _mainWindow.Ticker.Content = timp_ramas;
        }
    }
}
