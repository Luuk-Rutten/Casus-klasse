using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public static string FilePath= "\\net6.0-windows\\xml bestanden\\";
        //Serializer nodig om weg te schrijven (object zelf moet je kiezen afhankalijk van wat je wil wegschrijven) voorbeeld bij opslaan
        public static XmlSerializer serializer;
        //Filestream om een file te kunnnen openen/schrijven/lezen
        public static FileStream stream;
        //bestand opslaan en als bestand niet bestaat nieuw project aanmaken, geen extra klasse voor aanmaken nodig.
        public static void Opslaan(Project? cProject,Personeel? cPersoneel,Taak? cTaak)
        {
            CheckFileExists("personeel");
            //Kan denk ik beter. In ieder geval een goed begin!
            if (cProject!=null)
            {
                CheckFileExists(cProject.ProjectNaam);
                //moest van internal naar public in models?
                serializer = new XmlSerializer(typeof(Project));
                stream = File.OpenWrite($"..{FilePath}{cProject.ProjectNaam}.xml");
                serializer.Serialize(stream, cProject);
                stream.Dispose();
            }
            else if (cPersoneel != null)
            {

            }
            else if (cTaak != null)
            {

            }
            else
            {
                MessageBox.Show("Passed object is not handled!");
            }

        }

        public static void Verwijderen()
        {


        }

        public static object Uitlezen(string cNaam)
        {
            stream = File.OpenRead($"..{FilePath}{cNaam}.xml");
            var returnobject = serializer.Deserialize(stream) as Project;
            return 0;
        }

        public static void CheckFileExists(string name)
        {
            //momenteel komt alles in de debug folder
            if (!File.Exists($"..{FilePath}{name}.xml"))
            {
                File.Create($"..{FilePath}{name}.xml").Close();
            }
        }

/*        public static List<String> GetProjecten ()
        {
            List<String> FileNames = new List<String>();
            DirectoryInfo d = new DirectoryInfo($"..{FilePath}");
            FileInfo[] Files = d.GetFiles("*.xml");
            foreach (FileInfo file in Files)
            {
                FileNames.Add(file.Name);
            }
            return FileNames;
        }*/
    
    }

}
