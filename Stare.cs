using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microwave
{
    public abstract class Stare
    {   //add context
        public static Context context = MainWindow._context;

        public abstract void DeschideUsa();
        public abstract void InchideUsa();
        public abstract void Gateste();
        public abstract void TickCeas();
    }
}
