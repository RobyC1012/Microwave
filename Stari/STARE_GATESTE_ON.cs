using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microwave.Stari
{
    public class STARE_GATESTE_ON : Stare
    {
        #region Singleton

        private static STARE_GATESTE_ON _instance = null;
        private STARE_GATESTE_ON() { }
        public static STARE_GATESTE_ON getInstance() => _instance == null ? new STARE_GATESTE_ON() : _instance;

        #endregion

        public override void DeschideUsa()
        {
            context.stareCurenta = STARE_USA_DESCHISA.getInstance();
            context.Display();
        }

        public override void Gateste() { }
        public override void InchideUsa() { }
        public override void TickCeas() 
        {
            if (context.timpRamas > 0) 
            {
                context.timpRamas -= 1;
                context.Display();
            }
            else
            {
                context.stareCurenta = STARE_USA_INCHISA.getInstance();
                context.Display();
            }
        }
    }
}
