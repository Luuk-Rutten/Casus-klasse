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

        private void COpslaan(object sender, RoutedEventArgs e)
        {
            Project P=new Project();
            P.ProjectNaam = ProjectNaam.Text;
            Opslaan(P,null,null);
            MessageBox.Show("Project created");
            this.Close();
        }
    }
}
