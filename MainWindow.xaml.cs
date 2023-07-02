using Casus_klasse;
using Microsoft.Win32;
using static Casus_klasse.Models;
using static Casus_klasse.DataVerwerking;
using System.Diagnostics.Metrics;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Xml;
using System.Xml.Serialization;
using System.IO.Pipes;

namespace Casus_klasse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (Globals.SelectedProject!="")
            {
                ProjectName.Content = Globals.SelectedProject;
                ProjectName.Visibility = Visibility.Visible;
                Project cProject = ProjectUitlezen(Globals.SelectedProject);
                //Aantal parameters aanmaken voor later
                int y = -300;
                int x = 0;
                int MarginX = 0;
                int maxDays = 0;
                List<Taak> projectTaken= new List<Taak>();
                if (cProject.Taken.Count!=0)
                {
                    //Hier soorteren wij de taken by date
                    foreach (Taak t in cProject.Taken)
                    {
                        projectTaken.Add(t);
                        projectTaken = projectTaken.OrderBy(t => t.StartDatum).ToList();

                    }
                    //Wij hebben nu een project ingeladen dus wij zetten alle data weer op zichtbaar
                    StartDate.Content = projectTaken[0].StartDatum.Date;
                    StartDate.Visibility = Visibility.Visible;
                    EndDate.Content = projectTaken[projectTaken.Count-1].EindDatum.Date;
                    EndDate.Visibility = Visibility.Visible;
                    //Bereken aantal dagen die het project nodig heeft
                    maxDays += (projectTaken[projectTaken.Count - 1].EindDatum-projectTaken[0].StartDatum).Days;
                    ProjectDuur.Content = maxDays;
                    ProjectDuur.Visibility = Visibility.Visible;
                    //Voor de styling
                    MarginX = 1200 / maxDays/2;
                    DateTime lastenddate=DateTime.MinValue;
                    int diffbetweentasks = 0;
                    //Hier maken wij de knoppen aan voor de taken
                    foreach (Taak t in projectTaken)
                    {
                        if (lastenddate != DateTime.MinValue)
                        {
                            diffbetweentasks = (t.StartDatum-lastenddate).Days;

                        }
                        Button btn = new Button();
                        btn.Content = "";
                        x += MarginX*t.Dagen;
                        btn.Width = MarginX*t.Dagen;
                        btn.Content =t.TaakNaam;
                        btn.Click +=new RoutedEventHandler(Taak_aanpassen);
                        btn.Height = 20;
                        btn.Margin = new Thickness(x-300+(MarginX*diffbetweentasks), y, 0, 0);
                        if (t.TaakStarted && !t.TaakDone)
                        {
                            btn.Background = Brushes.Yellow;
                        }
                        else if (t.TaakDone)
                        {
                            btn.Background = Brushes.Green;
                        }
                        else
                        {
                            btn.Background = Brushes.Red;
                        }
                        Button btn2 = new Button();
                        btn2.Content = $"{t.TaakNaam}";
                        btn2.Width = 100;
                        btn2.Height = 20;
                        btn2.IsEnabled = false;
                        btn2.Margin = new Thickness(-650, y, 0, 0);
                        y += 50;
                        x += (1200 / maxDays/2)*t.Dagen;
                        ProjectGrid.Children.Add(btn2);
                        ProjectGrid.Children.Add(btn);
                        lastenddate = t.EindDatum;
                    }
                }

            }
        }
        //Scherm naar taak aanpassen
        private void Taak_aanpassen(object sender, EventArgs e)
        {
            string btnname = (sender as Button).Content.ToString();
            Taak t = TaakUitlezen(btnname);
            TakenWindow T = new TakenWindow(t);
            T.Left = Width / 2;
            T.Top = Height / 2;
            T.Show();
            this.Close();
        }

        //Project aanmaken
        private void Project_Click(object sender, RoutedEventArgs e)
        {

            Create w = new Create();
            w.Left = Width / 2;
            w.Top = Height / 2;
            w.Show();
            this.Close();
        }

        //Takenwindow openen
        private void Taak_Click(object sender, RoutedEventArgs e)
        {
            if (Globals.SelectedProject!="")
            {
                TakenWindow T = new TakenWindow(null);
                T.Left = Width / 2;
                T.Top = Height / 2;
                T.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Select a project first");
            }
        }

        //Personeel window openen
        private void Personeel_Click(object sender, RoutedEventArgs e)
        {
            PersoneelWindow P = new PersoneelWindow(); 
            P.Left = Width / 2;
            P.Top = Height / 2;
            P.Show();
            this.Close();
        }
    }
}


