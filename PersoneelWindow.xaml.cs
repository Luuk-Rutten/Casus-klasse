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
using System.Windows.Shapes;
using static Casus_klasse.Models;
using static Casus_klasse.DataVerwerking;
using static Casus_klasse.Create;
using System.Xml;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using System.Text.Json;

namespace Casus_klasse
{
    /// <summary>
    /// Interaction logic for PersoneelWindow.xaml
    /// </summary>
    public partial class PersoneelWindow : Window
    {

        private List<Personeel> personeel;
        public PersoneelWindow()
        {
            InitializeComponent();
            List<Personeel> AllPers=PersoneelUitlezen();
            foreach (Personeel P in AllPers)
            {
                CbPersoneel.Items.Add(P.naam);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Left = Width / 2;
            w.Top = Height / 2;
            w.Show();
            this.Close();
        }

        private void Personeel_aanmaken(object sender, RoutedEventArgs e)
        {
            if (PersoneelNaam.Text.Trim()=="" || PersoneelFunctie.Text.Trim()=="")
            {
                MessageBox.Show("Fill in all forms");
            }
            else
            {
                Personeel pers = new Personeel();
                pers.naam = PersoneelNaam.Text;
                pers.functie = PersoneelFunctie.Text;
                pers.ID = Guid.NewGuid();
                Opslaan(null, pers, null);
                PersoneelWindow w = new PersoneelWindow();
                w.Left = Width / 2;
                w.Top = Height / 2;
                w.Show();
                this.Close();
            }

        }

    }
}
