using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Casus_klasse
{
    public class Models
    {

        public class Personeel
        {
            public string naam { get; set;  }
            public string? functie { get; set; }
            public int ID { get; set; }

        }

        public class Project
        {
            public string ProjectNaam { get; set; }
            //public DateTime StartDatum { get; set; }
            //public DateTime EindDatum { get; set; }
            //public List<Personeel>? LinkedPersoneel { get; set; } 
            //public List<Taak>? Taken { get; set; }

        }
        public class Taak
        {
            public int TaakNummer;

            public void VoegPersoneelToe()
            {

            }

            public void OpenTaak()
            {


            }

            public void SaveTaak()
            {
                
            }
            public void DeleteTaak()
            {
               
            }
        }
    }

    /*        public TaakToevoegen()
            {
                return;
            }*/

    /*      public NieuwProject()
          {



              return;
          }*/
    /*        public SaveProject()   //controleren of alle data aanwezig is van het project
            {
                return;  //hoeft niet perse een return waarde te hebben, kan ook een mssgbox openen
            }
            public OpenProject()
            {
                return;
            }
            public DeleteProject()
            {
                return;*/
}
 


      

    




