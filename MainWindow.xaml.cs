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
            //MessageBox.Show("New command executed");
            Create w=new Create();
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
            MessageBox.Show("Open command executed");
        }

    }




}
