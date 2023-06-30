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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
