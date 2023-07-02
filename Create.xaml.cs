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
using static Casus_klasse.TakenWindow;
using System.IO;
using System.Xml.Serialization;

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
            DirectoryInfo DIfiles = new DirectoryInfo($"../../../xml bestanden/");
            FileInfo[] files = DIfiles.GetFiles();
            foreach (FileInfo file in files)
            {
                ProjectenBOX.Items.Add(file.Name.Substring(0,file.Name.Length-4));
            }

            List<Taak> Taken = TakenUitlezen();
            foreach (Taak taak in Taken)
            {
                BeschTaken.Items.Add(taak.TaakNaam);
            }
        }

        //Opslaan knop binnen project menu
        private void COpslaan(object sender, RoutedEventArgs e)
        {
            if (ProjectNaam.Text.Trim()==""||ProjectBeschrijving.Text.Trim()=="")
            {
                MessageBox.Show("Fill in all forms");
            }
            else
            {
                Project P = new Project();
                P.ProjectNaam = ProjectNaam.Text;
                P.ProjectBeschrijving = ProjectBeschrijving.Text;
                Opslaan(P, null, null);
                MainWindow w = new MainWindow();
                w.Left = Width / 2;
                w.Top = Height / 2;
                w.Show();
                this.Close();
            }
        }

        //Cancel knop binnen project menu
        private void CancelBttn(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Left = Width / 2;
            w.Top = Height / 2;
            w.Show();
            this.Close();

        }

        private void ProjectOpen(object sender, RoutedEventArgs e)
        {
            if (ProjectenBOX.SelectedItem != null)
            {
                Globals.SelectedProject = ProjectenBOX.SelectedItem.ToString();
                MainWindow w = new MainWindow();
                w.Left = Width / 2;
                w.Top = Height / 2;
                w.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Select a project!");
            }

        }
    }
}