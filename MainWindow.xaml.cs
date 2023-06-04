using System;
using System.Collections.Generic;
using System.IO;
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
            MessageBox.Show("New command executed");

             XmlTextWriter textWriter = new XmlTextWriter("C:\\Users\\Luuk\\OneDrive\\Documenten\\Ad- ICT 2022\\Blok 4\\Software Modeling\\Casus\\Casus klasse\\xml bestanden\\test1.xml", null);

            XmlTextReader textReader = new XmlTextReader("C:\\Users\\Luuk\\OneDrive\\Documenten\\Ad- ICT 2022\\Blok 4\\Software Modeling\\Casus\\Casus klasse\\xml bestanden\\test1.xml");


            textReader.Read();
            while (textReader.Read())
            {
                
                textReader.MoveToElement();
                textReader.Close(); 
            }
        }
        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;   //logica toevoegen zodat je geen project kunt openen dat al geopend is
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Open command executed");
        }

    }




}
