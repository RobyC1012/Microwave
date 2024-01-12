using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Microwave
{
    public partial class MainWindow : Window
    {
        public static Context _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = Context.getInstance(this);
        }

        private void ButonInchideUsa_Click(object sender, RoutedEventArgs e)
        {
            _context.InchideUsa();
        }

        private void ButonDeschideUsa_Click(object sender, RoutedEventArgs e)
        {
            _context.DeschideUsa();
        }

        private void ButonGatire_Click(object sender, RoutedEventArgs e)
        {
            _context.Gateste();
        }

        public void setUsaDeschisa()
        {
            StareUsa.Content = "Usa deschisa";
            setGatesteOff();
        }

        public void setUsaInchisa()
        {
            StareUsa.Content = "Usa inchisa";
            setGatesteOff();
        }

        public void setGatesteOn()
        {
            StareCuptor.Content = "Gatire ON";
            ButonGatire.Content = "Pornit";
        }
        public void setGatesteOff()
        {
            StareCuptor.Content = "Gatire OFF";
            ButonGatire.Content = "Oprit";
        }

        public void setTimpRamas()
        {
            Ticker.Content = _context.GetTimpRamas();
        }
    }
}
