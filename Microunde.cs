using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microwave.MainWindow;

namespace Microwave
{
    class Microunde
    { 
        /*private Context context;

        private static Microunde _instance = null;
        private Microunde(MainWindow mainWindow)
        {
            context = Context.getInstance(mainWindow);
           *//* stare = Stari.STARE_USA_INCHISA;
            timp_ramas = 0;
            _mainWindow = mainWindow;*//*
        }
        public static Microunde getInstance(MainWindow mainWindow) => _instance == null ? new Microunde(mainWindow) : _instance;

        public void DeschideUsa()
        {
            switch (stare)
            {
                case Stari.STARE_GATESTE_ON:
                {
                    stare = Stari.STARE_USA_DESCHISA;
                    _mainWindow.setUsaDeschisa();
                    break;
                }
                case Stari.STARE_USA_INCHISA:
                {
                    stare = Stari.STARE_USA_DESCHISA;
                    _mainWindow.setUsaDeschisa();
                    break;
                }
                case Stari.STARE_USA_DESCHISA:
                {
                    break;
                }
            }
        }

        public void InchideUsa()
        {
            switch(stare)
            {
                case Stari.STARE_GATESTE_ON:
                {
                    break;
                }
                case Stari.STARE_USA_INCHISA:
                {
                    break;
                }
                case Stari.STARE_USA_DESCHISA:
                {
                    stare = Stari.STARE_USA_INCHISA;
                    _mainWindow.setUsaInchisa();
                    break;
                }
            }
        }

        public void Gateste()
        {
            switch (stare)
            {
                case Stari.STARE_GATESTE_ON:
                {
                    stare = Stari.STARE_USA_INCHISA;
                    _mainWindow.setUsaInchisa();
                    break;
                }
                case Stari.STARE_USA_INCHISA:
                {
                    stare = Stari.STARE_GATESTE_ON;
                    _mainWindow.setGatesteOn();
                    _mainWindow.setTimpRamas();
                    if(timp_ramas == 0)
                        timp_ramas = 10;
                    TickCeas();
                    break;
                }
                case Stari.STARE_USA_DESCHISA:
                {
                    break;
                }
            }
        }

        async void TickCeas()
        {
            while (timp_ramas >= 0 && stare == Stari.STARE_GATESTE_ON)
            {
                _mainWindow.setTimpRamas();
                await Task.Delay(1000);
                timp_ramas--;
            }

            if (GetStare() == Stari.STARE_GATESTE_ON)
            {
                stare = Stari.STARE_USA_INCHISA;
                timp_ramas = 0;
                _mainWindow.setUsaInchisa();
            }
        }

        public Stari GetStare() { return stare; }
        public int GetTimpRamas() {  return timp_ramas; }*/
    }
}
