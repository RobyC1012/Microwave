namespace Microwave.Stari
{
    public class STARE_USA_DESCHISA : Stare
    {
        #region Singleton

        private static STARE_USA_DESCHISA _instance = null;

        private STARE_USA_DESCHISA() { }
        public static STARE_USA_DESCHISA getInstance() => _instance == null ? new STARE_USA_DESCHISA() : _instance;

        #endregion

        public override void DeschideUsa() { }
        public override void Gateste() { }

        public override void InchideUsa()
        {
            context.stareCurenta = STARE_USA_INCHISA.getInstance();
            context.Display();
        }

        public override void TickCeas() { }
    }
}
