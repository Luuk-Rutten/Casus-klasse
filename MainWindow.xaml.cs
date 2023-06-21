using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Enumeration;
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
using System.Xml;


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

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //MessageBox.Show("New command executed");
            Create w = new Create();
            w.Left = Width / 2;
            w.Top = Height / 2;
            w.Show();
            //Wordt in dataverwerking gedaan?

            // XmlTextWriter textWriter = new XmlTextWriter("..\\net6.0-windows\\xml bestanden\\test1.xml", null);

            //XmlTextReader textReader = new XmlTextReader("..\\net6.0-windows\\xml bestanden\\test1.xml");


            //textReader.Read();
            //while (textReader.Read())
            //{

            //    textReader.MoveToElement();
            //    textReader.Close(); 
            //}
        }
        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;   //logica toevoegen zodat je geen project kunt openen dat al geopend is //MARK Beter denk ik om dat niet te laten zien
        }





        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //opent window waarin je een file kunt selecteren om te openen

            OpenFileDialog openFileDialog = new OpenFileDialog();
            var fileName = openFileDialog.InitialDirectory = @"C:\Users\Luuk\OneDrive\Documenten\Ad- ICT 2022\Blok 4\Software Modeling\Casus\Casus klasse\bin\Debug\net6.0-windows\xml bestanden";
            openFileDialog.Filter = "Xml files (*.Xml)|*.xml|All files (*.*)|*.*";


            if (openFileDialog.ShowDialog() == true)
            {
                var fileStream = openFileDialog.OpenFile();

                //schrijft inhoud file naar Textbox in de Mainwindow

                  //using (StreamReader reader = new StreamReader(fileStream))
                using (XmlReader xr = XmlReader.Create(fileStream)) 
                                
              {
                    XmlNodeType type = XmlNodeType.Element;
                    //var fileContent = reader.ReadToEnd();


                    ProjectBox.Text = fileContent;
                }



            }

        }

    }
}



