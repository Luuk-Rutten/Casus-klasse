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
        public List<Personeel>? LinkedPersoneel { get; set; }

        public class Personeel
        {
            public string? naam { get; set; }
            public string? functie { get; set; }
            public int ID { get; set; }

        }

        public class Project
        {
            public string ProjectNaam { get; set; }
            public string? ProjectBeschrijving { get; set; }
            public List<Taak>? Taken { get; set; }

        }
  
        public class Taak
        {
            public string TaakNaam { get; set; }

            public string? TaakBeschrijving { get; set; }

            public DateTime StartDatum { get; set; }
            public DateTime EindDatum { get; set; }

        }


        public void OpenTaak()
        {


        }


      

    }

}

