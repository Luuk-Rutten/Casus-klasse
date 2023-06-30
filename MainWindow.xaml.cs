using Casus_klasse;
using Microsoft.Win32;
using static Casus_klasse.Models;
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
         


        }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Project_Click(object sender, RoutedEventArgs e)
        {

            Create w = new Create();
            w.Left = Width / 2;
            w.Top = Height / 2;
            w.Show();

        }

        private void Taak_Click(object sender, RoutedEventArgs e)
        {
            TakenWindow T = new TakenWindow();
            T.Left = Width / 2;
            T.Top = Height / 2;
            T.Show();

        }

        private void Personeel_Click(object sender, RoutedEventArgs e)
        {
            PersoneelWindow P = new PersoneelWindow(); 
            P.Left = Width / 2;
            P.Top = Height / 2;
            P.Show();
        }

        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;



        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //opent window waarin je een file kunt selecteren om te openen
     
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\Users\Luuk\OneDrive\Documenten\Ad- ICT 2022\Blok 4\Software Modeling\Casus\Casus klasse\bin\Debug\net6.0-windows\xml bestanden";
            openFileDialog.Filter = "Xml files (*.Xml)|*.xml|All files (*.*)|*.*";



            if (openFileDialog.ShowDialog() == true)
            {
                var fileStream = openFileDialog.OpenFile();

                //schrijft inhoud file naar Textbox in de Mainwindow

                using (StreamReader reader = new StreamReader(fileStream))
                {

                    var fileContent = reader.ReadToEnd();


               

                }

            }

        }


        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            {
                e.CanExecute = true;

            }


        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
          

        }

        private void SaveAsCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

            {
                e.CanExecute = true;

            }

        }

        private void SaveAsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {


            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Xml files (*.Xml)|*.xml|All files (*.*)|*.*";

            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
               FileStream fs = (FileStream)saveFileDialog1.OpenFile();
                // fs.Write(UnicodeEncoding.GetBytes(ProjectBox.Text));

/*                foreach (char line in ProjectBox.Text)
                {
                    ProjectBox.Text += fs;
                   
                }*/
                // TODO  kutzooi lukt me niet, geen idee hoe ik uit de tekstbox iets kan opslaan in een xml

                //fs.CopyTo(fileStream);

                fs.Close();
                MessageBox.Show("Opgeslagen!");
            }

        }


    }
}


