using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microwave.Stari
{
    public class STARE_USA_INCHISA : Stare
    {
        private static STARE_USA_INCHISA _instance = null;
        private STARE_USA_INCHISA() { }
        public static STARE_USA_INCHISA getInstance() => _instance == null ? new STARE_USA_INCHISA() : _instance;

        public override void DeschideUsa()
        {
            context.stareCurenta = STARE_USA_DESCHISA.getInstance();
            context.mainWindow.setUsaDeschisa();
        }

        public override void Gateste()
        {
            context.stareCurenta = STARE_GATESTE_ON.getInstance();  
            context.mainWindow.setGatesteOn();
            if (context.timpRamas == 0) context.timpRamas = 10;
            context.TickCeas();
        }

        public override void InchideUsa() { }

        public override void TickCeas()
        {
            throw new NotImplementedException();
        }
    }
}
