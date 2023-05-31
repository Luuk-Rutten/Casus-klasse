using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Casus_klasse
{
    internal class Models
    {
    }

    public class Personeel
    {
        public string naam;
        public string? functie;
        public int ID;

    }

    public class Project
    {
        public string ProjectNaam { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }

        public TaakToevoegen()
        {
            return;
        }

        public NieuwProject()
        {
            return;
        }
        public SaveProject()
        {
            return;
        }
        public OpenProject()
        {
            return;
        }
        public DeleteProject()
        {
            return;
        }

        public class Taak
       {
            public int TaakNummer;

            public void VoegPersoneelToe()
            {
                 
            }


            public AddTaak()
            {
                return;
            }
            public DeleteTaak()
            {
                return;
            }
        }

        public class Bestand
        {
            public OpenBestand()
            {

                return;
            }
            public SluitBestand()
            {

                return;
            }
            public SaveBestand()
            {

                return;
            }
            public DeleteBestand()
            {

                return;
            }

        }
        public class Data
        {
            public ReadData()
            {
                return;
            }
            public SaveData()
            {
                return;
            }


        }

    }
}


