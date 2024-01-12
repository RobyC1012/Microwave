namespace Microwave.Stari
{
    public class STARE_USA_INCHISA : Stare
    {
        #region Singleton

        private static STARE_USA_INCHISA _instance = null;
        private STARE_USA_INCHISA() { }
        public static STARE_USA_INCHISA getInstance() => _instance == null ? new STARE_USA_INCHISA() : _instance;

        #endregion

        public override void DeschideUsa()
        {
            context.stareCurenta = STARE_USA_DESCHISA.getInstance();
            context.Display();
        }

        public override void Gateste()
        {
            context.stareCurenta = STARE_GATESTE_ON.getInstance();
            if (context.GetTimpRamas() == 0) context.timpRamas = 10; context.TickCeas();
            context.Display();
        }

        public override void InchideUsa() { }

        public override void TickCeas() { }
    }
}
