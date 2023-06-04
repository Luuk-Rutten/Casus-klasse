using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Xml;

namespace Casus_klasse
{
    public partial class MenuWithCommands : Window
    {
        public MenuWithCommands()
        {
            // InitializeComponent();
        }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;


        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("New command executed");



            }
        }
    }

//methodes werden automatisch aangemaakt in de mainwindow, kreeg ze hier in deze window niet werkend dus heb t zo gelaten.