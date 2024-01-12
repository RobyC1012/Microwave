using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microwave.Stari
{
    public class STARE_GATESTE_ON : Stare
    {
        private static STARE_GATESTE_ON _instance = null;
        private STARE_GATESTE_ON() { }
        public static STARE_GATESTE_ON getInstance() => _instance == null ? new STARE_GATESTE_ON() : _instance;

        public override void DeschideUsa()
        {
            context.stareCurenta = STARE_USA_DESCHISA.getInstance();
            context.mainWindow.setUsaDeschisa();
        }

        public override void Gateste() { }

        public override void InchideUsa() { }

        public override void TickCeas()
        {
        }
    }
}
