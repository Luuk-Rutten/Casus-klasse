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
using System.Collections;
using Accessibility;
using System.IO;
using System.Runtime.CompilerServices;

namespace Casus_klasse
{
    /// <summary>
    /// Interaction logic for TakenWindow.xaml
    /// </summary>
    
    public partial class TakenWindow : Window
    {

        public Taak cTaak=new Taak();
        public TakenWindow(Taak? t)
        {
            cTaak = t;
            InitializeComponent();
            Project cProject = ProjectUitlezen(Globals.SelectedProject);
            //Wij gebruiken hetzelfde scherm om te bewerken/nieuw aan te maken dus wij moeten tijdens het bewerken een aantal functionaliteiten aanpassen
            if (t!=null)
            {
                TaakNaam.Text = t.TaakNaam;
                TaakNaam.IsEnabled = false;
                TaakBeschrijving.Text = t.TaakBeschrijving;
                StartTime.Text = t.StartDatum.ToString();
                FinishTime.Text = t.EindDatum.ToString();
                CBTaakstarted.IsChecked = t.TaakStarted;

                foreach (string w in t.TaakMedewerkers)
                {
                    AddedWN.Items.Add(w);
                }

                //Ik weet zeker dat ik hier iets over het hoofd zie daarom is het hier zo slecht
                List<Personeel> AllPers = PersoneelUitlezen();
                foreach (Personeel P in AllPers)
                {
                    if (AddedWN.Items.Count==0)
                    {
                        AvailableWN.Items.Add(P.naam);
                    }
                    else
                    {
                        foreach (string item in AddedWN.Items)
                        {
                            if (item != P.naam)
                            {
                                AvailableWN.Items.Add(P.naam);
                            }
                        }
                    }
                }

                foreach (string s in t.Dependency)
                {
                    TakenAL.Items.Add(s);
                }

                if (t.TaakStarted)
                {
                    CBTaakDone.Visibility = Visibility.Visible;
                }

                if (t.TaakDone)
                {
                    CBTaakDone.IsChecked = true;
                }
                foreach (Taak T in cProject.Taken)
                {
                    if (TakenAL.Items.Count==0 && T.TaakNaam != cTaak.TaakNaam)
                    {
                        TakenLB.Items.Add(T.TaakNaam);
                    }
                    else
                    {
                        foreach (string item in TakenAL.Items)
                        {
                            if (item != T.TaakNaam && T.TaakNaam!=cTaak.TaakNaam)
                            {
                                TakenLB.Items.Add(T.TaakNaam);
                            }
                        }
                    }
                }
            }
            else
            {
                CBTaakstarted.Visibility = Visibility.Hidden;
                BTNDel.Visibility = Visibility.Hidden;
                LBTakenAL.Visibility = Visibility.Hidden;
                TakenAL.Visibility = Visibility.Hidden;
                List<Taak> Taken = TakenUitlezen();
                foreach (Taak T in cProject.Taken)
                {
                    TakenLB.Items.Add(T.TaakNaam);
                }
                List<Personeel> AllPers = PersoneelUitlezen();
                foreach (Personeel P in AllPers)
                {
                    AvailableWN.Items.Add(P.naam);
                }
            }


        }

        private void COpslaanTaak(object sender, RoutedEventArgs e)
        {
            bool save = true;
            Taak T = new Taak();

            List<string> DependentList = new List<string>();
            //Dit is een beetje onhading maar so be it
            foreach(string s in TakenLB.SelectedItems)
            {
                DependentList.Add(s);
            }

            foreach (string s in TakenAL.Items)
            {
                DependentList.Add(s);
            }

            List<string> TaakMWList = new List<string>();
            foreach (string medewerker in AddedWN.Items)
            {
                TaakMWList.Add(medewerker);
            }

            List<Taak> Taken = TakenUitlezen();
            List<String> Overeenkomst = new List<string>();


            //Check om te kijken of alle andere taken al gedaan zijn
            if (CBTaakstarted.IsChecked??true && cTaak.Dependency.Count>0)
            {
                Project P = ProjectUitlezen(Globals.SelectedProject);
                foreach (string s in cTaak.Dependency)
                {
                    Taak taak = TaakUitlezen(s);
                    if (!taak.TaakDone)
                    {
                        MessageBox.Show($"Dependent task is not yet completed {taak.TaakNaam}");
                        save = false;
                    }
                }
            }

            if (TaakNaam.Text.Trim() == "" || TaakBeschrijving.Text.Trim() == "" || StartTime.Text == "" || FinishTime.Text == "")
            {
                MessageBox.Show("Fill in all forms");
                save=false;
            }

            T.TaakNaam = TaakNaam.Text;
            T.TaakNaam = T.TaakNaam.Replace(" ", "_");
            //Extra check die wij van te voren niet wisten.
            if (save)
            {
                if (Char.IsDigit(T.TaakNaam[0]))
                {
                    MessageBox.Show("First character can not be a digit.");
                    save = false;
                }

                if (CBTaakDone.IsChecked ?? true)
                {
                    T.TaakDone = true;
                }
                else if (cTaak == null)
                {
                    T.TaakDone = false;
                    //Check of de taak niet eerder begint dan een andere taak met dezelfde medewerker.
                    foreach (Taak taak in Taken)
                    {
                        int StartDateDiff = (DateTime.Parse(StartTime.Text) - taak.StartDatum).Days;
                        int FinishDateDiff = (DateTime.Parse(StartTime.Text) - taak.StartDatum).Days;
                        if (StartDateDiff >= 0 && StartDateDiff < taak.Dagen)
                        {
                            Overeenkomst = TaakMWList.Intersect(taak.TaakMedewerkers).ToList();
                            if (Overeenkomst.Count > 0)
                            {
                                MessageBox.Show("One or more people can not be planned for this task!");
                                save = false;
                                break;
                            }
                        }
                    }
                }
            }


            if (!save)
            {
                //Uitzonderingen toevoegen
            }
            else
            {

                //Taak opslaan samen met het project nog een keer
                if (DateTime.Parse(StartTime.Text)<DateTime.Parse(FinishTime.Text))
                {

                    T.TaakBeschrijving = TaakBeschrijving.Text;
                    T.StartDatum = DateTime.Parse(StartTime.Text);
                    T.EindDatum = DateTime.Parse(FinishTime.Text);



                    //Check checkboxes
                    if (CBTaakstarted.IsChecked?? true)
                    {
                        T.TaakStarted = true;
                    }
                    else
                    {
                        T.TaakStarted = false;
                    }



                    T.Dependency = DependentList;
                    T.Dagen = (T.EindDatum - T.StartDatum).Days;
                    T.TaakMedewerkers = TaakMWList;
                    T.ProjectName = Globals.SelectedProject;
                    Opslaan(null, null, T);

                    Project cProject = ProjectUitlezen(Globals.SelectedProject);
                    cProject.ProjectBeschrijving = cProject.ProjectBeschrijving;
                    cProject.ProjectNaam = cProject.ProjectNaam;
                    List<Taak> taken = new List<Taak>();
                    if (cProject.Taken.Count != 0)
                    {
                        taken = cProject.Taken;
                    }

                    foreach (Taak PT in cProject.Taken)
                    {
                        if (PT.TaakNaam==T.TaakNaam)
                        {
                            cProject.Taken.Remove(PT);
                            break;
                        }
                    }

                    taken.Add(T);

                    cProject.Taken = taken;
                    Opslaan(cProject, null, null);

                    MainWindow P = new MainWindow();
                    P.Left = Width / 2;
                    P.Top = Height / 2;
                    P.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("End date earlier than start date!");
                }
              

            }

        }

        private void CancelBttn(object sender, RoutedEventArgs e) 
        {
            TaakNaam.Text = null; //???
            TaakBeschrijving.Text = null; //???
            MainWindow P = new MainWindow();
            P.Left = Width / 2;
            P.Top = Height / 2;
            P.Show();
            this.Close();

        }

        private void Move_Werknemer(object sender, RoutedEventArgs e)
        {
            string btnstring = (sender as Button).Content.ToString();
            if (btnstring=="Add")
            {
                if (AvailableWN.SelectedIndex != -1)
                {
                    int index = AvailableWN.SelectedIndex;
                    AddedWN.Items.Add(AvailableWN.Items[index].ToString());
                    AvailableWN.Items.Remove(AvailableWN.Items[index]);
                }
            }
            else if (btnstring=="Remove")
            {
                if (AddedWN.SelectedIndex != -1)
                {
                    int index = AddedWN.SelectedIndex;
                    AvailableWN.Items.Add(AddedWN.Items[index].ToString());
                    AddedWN.Items.Remove(AddedWN.Items[index]);
                }
            }

        }

        //Taak verwijderen
        private void Verwijder_taak(object sender, RoutedEventArgs e)
        {
            Project cProject = ProjectUitlezen(Globals.SelectedProject);
            cProject.ProjectBeschrijving = cProject.ProjectBeschrijving;
            cProject.ProjectNaam = cProject.ProjectNaam;
            foreach (Taak PT in cProject.Taken)
            {
                if (PT.TaakNaam == cTaak.TaakNaam)
                {
                    cProject.Taken.Remove(PT);
                    break;
                }
            }
            File.Delete($"../../../{FilePath}/Taken/{cTaak.TaakNaam}.xml");
            Opslaan(cProject, null, null);
            MainWindow P = new MainWindow();
            P.Left = Width / 2;
            P.Top = Height / 2;
            P.Show();
            this.Close();
        }
    }
}
