using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using static Casus_klasse.Models;
using static Casus_klasse.DataVerwerking;
using static Casus_klasse.Create;
using System.Xml;

namespace Casus_klasse
{
    /// <summary>
    /// Interaction logic for TakenWindow.xaml
    /// </summary>
    public partial class TakenWindow : Window
    {


        public TakenWindow()
        {
            InitializeComponent();
        }

        private void COpslaanTaak(object sender, RoutedEventArgs e)
        {
            Taak T = new Taak();
            T.TaakNaam = TaakNaam.Text;
            T.TaakBeschrijving = TaakBeschrijving.Text;
            Opslaan(null, null, T);
            this.Close();
        }

        private void CancelBttn(object sender, RoutedEventArgs e)
        {
            TaakNaam.Text = null;
            TaakBeschrijving.Text = null;
            this.Close();

        }

        private void Personeel()
        {
            //using (XmlReader reader = XmlReader.Create(stream)) ;



        }



        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
