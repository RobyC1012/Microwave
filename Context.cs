using Microwave.Stari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microwave
{
    public class Context
    {
        public Stare stareCurenta;
        public int timpRamas;
        public MainWindow mainWindow;

        private static Context _instance = null;
        private Context(MainWindow window) {
            mainWindow = window;
            stareCurenta = STARE_USA_INCHISA.getInstance();
            timpRamas = 0;
        }
        public static Context getInstance(MainWindow window) => _instance == null ? new Context(window) : _instance;


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

        public async void TickCeas()
        {
            while (timpRamas >= 0 && stareCurenta is STARE_GATESTE_ON)
            {
                mainWindow.setTimpRamas();
                await Task.Delay(1000);
                timpRamas--;
            }

            if (stareCurenta is STARE_GATESTE_ON)
            {
                stareCurenta.InchideUsa();
                timpRamas = 0;
                mainWindow.setTimpRamas();
            }
        }


    }
}
