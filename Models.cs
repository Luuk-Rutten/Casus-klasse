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
        public SaveProject()   //controleren of alle data aanwezig is van het project
        {
            return;  //hoeft niet perse een return waarde te hebben, kan ook een mssgbox openen
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

            public OpenTaak()
            { 
            

            }

            public SaveTaak()
            {
                return;
            }
            public DeleteTaak()
            {
                return;
            }
        }

      

    }
}


