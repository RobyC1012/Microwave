﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microwave.Stari
{
    public class STARE_USA_DESCHISA : Stare
    {
        private static STARE_USA_DESCHISA _instance = null;

        private STARE_USA_DESCHISA() { }
        public static STARE_USA_DESCHISA getInstance() => _instance == null ? new STARE_USA_DESCHISA() : _instance;

        public override void DeschideUsa() { }

        public override void Gateste() { }

        public override void InchideUsa()
        {
            context.stareCurenta = STARE_USA_INCHISA.getInstance();
            context.mainWindow.setUsaInchisa();
        }

        public override void TickCeas() { }
    }
}
