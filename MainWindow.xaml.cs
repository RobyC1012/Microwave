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
using static Microwave.Microunde;

namespace Microwave
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Microunde _microunde;

        public MainWindow()
        {
            _microunde = Microunde.getInstance(this);
            InitializeComponent();
        }

        private void ButonInchideUsa_Click(object sender, RoutedEventArgs e)
        {
            _microunde.InchideUsa();
        }

        private void ButonDeschideUsa_Click(object sender, RoutedEventArgs e)
        {
            _microunde.DeschideUsa();
        }

        private void ButonGatire_Click(object sender, RoutedEventArgs e)
        {
            _microunde.Gateste();
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
            setButonGatireOn();
        }
        public void setGatesteOff()
        {
            StareCuptor.Content = "Gatire OFF";
            setButonGatireOff();
        }

        public void setTimpRamas()
        {
            Ticker.Content = _microunde.GetTimpRamas();
        }

        public void setButonGatireOn()
        {
            ButonGatire.Content = "Pornit";
        }

        public void setButonGatireOff()
        {
            ButonGatire.Content = "Oprit";
        }
    }
}
