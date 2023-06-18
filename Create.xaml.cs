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

namespace Casus_klasse
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Window
    {
        public Create()
        {
            InitializeComponent();
        }

        //Opslaan knop binnen project menu
        private void COpslaan(object sender, RoutedEventArgs e)
        {
            Project P=new Project();
            P.ProjectNaam = ProjectNaam.Text;
            P.ProjectBeschrijving = ProjectBeschrijving.Text;
            Opslaan(P);
            this.Close();
        }


        //Cancel knop binnen project menu

        private void CancelBttn(object sender, RoutedEventArgs e)
        {
            ProjectNaam.Text = null;
            ProjectBeschrijving.Text = null;
            this.Close();

        }

        private void ProjectNaam_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ProjectBeschrijving_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
