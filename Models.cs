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
            public string naam { get; set; }
            public string? functie { get; set; }
            public int ID { get; set; }

        }

        public class Project
        {
            public string ProjectNaam { get; set; }
            public string ProjectBeschrijving { get; set; }

            //public DateTime StartDatum { get; set; }
            //public DateTime EindDatum { get; set; }
            //public List<Personeel>? LinkedPersoneel { get; set; } 
            //public List<Taak>? Taken { get; set; }

        }
        /*     public SaveProject()
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
     /**/
        public class Taak
        {


        }


        public void OpenTaak()
        {


        }


        /*        public AddTaak()
                {
                    return 0;
                }
                public DeleteTaak()
                {
                    return;
                }
            }*/

        /*    public class Bestand
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
                    return 0;
                }
        */

    }

}

