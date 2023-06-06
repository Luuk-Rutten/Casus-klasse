using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using static Casus_klasse.Models;

namespace Casus_klasse
{
    internal class DataVerwerking
    {
        //Serializer nodig om weg te schrijven (object zelf moet je kiezen afhankalijk van wat je wil wegschrijven) voorbeeld bij opslaan
        public static XmlSerializer serializer;
        //Filestream om een file te kunnnen openen/schrijven/lezen
        public static FileStream stream;
        //bestand opslaan en als bestand niet bestaat nieuw project aanmaken, geen extra klasse voor aanmaken nodig.
        public static void Opslaan(object cobject)
        {
            CheckFileExists("personeel");
            string filename="";
            //Kan denk ik beter. In ieder geval een goed begin!
            if (cobject is Project)
            {
                var PRobject = cobject as Project ;
                filename = PRobject.ProjectNaam;
                CheckFileExists(filename);
                //moest van internal naar public in models?
                serializer = new XmlSerializer(typeof(Project));
                stream = File.OpenWrite($"..\\net6.0-windows\\xml bestanden\\{filename}.xml");
                serializer.Serialize(stream, PRobject);
                stream.Dispose();
            }
            else if (cobject is Personeel)
            {
                var PEobject = cobject as Personeel;
            }
            else if (cobject is Taak)
            {
                var Tobject = cobject as Taak;
            }
            else
            {
                MessageBox.Show("Passed object is not handled!");
            }

        }

        public static void Verwijderen()
        {


        }

        public static object Uitlezen()
        {
            stream = File.OpenRead("..\\net6.0-windows\\xml bestanden\\");
            var returnobject= serializer.Deserialize(stream) as Project;
            return 0; 
        }

        public static void CheckFileExists(string name)
        {
            //momenteel komt alles in de debug folder
            if (!File.Exists($"..\\net6.0-windows\\xml bestanden\\{name}.xml"))
            {
                File.Create($"..\\net6.0-windows\\xml bestanden\\{name}.xml").Close();
            }
        }
    
    }

}
