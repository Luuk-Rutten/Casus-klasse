using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
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
        //Eventueel te vervangen met een global waarde dat de klant zelf een pad kan instellen
        public static string FilePath= "xml bestanden/";
        //Serializer nodig om weg te schrijven (object zelf moet je kiezen afhankalijk van wat je wil wegschrijven) voorbeeld bij opslaan
        public static XmlSerializer serializer;
        //Filestream om een file te kunnnen openen/schrijven/lezen
        public static FileStream fs;
        public static StreamWriter sw;
        public static StreamReader sr;


        //bestand opslaan en als bestand niet bestaat nieuw project aanmaken, geen extra klasse voor aanmaken nodig.
        public static void Opslaan(Project? cProject,Personeel? cPersoneel,Taak? cTaak)
        {
            //Kan denk ik beter
            if (cProject!=null)
            {
                serializer = new XmlSerializer(typeof(Project));
                using (fs = File.Create($"../../../{FilePath}{cProject.ProjectNaam}.xml"))
                {
                    serializer.Serialize(fs, cProject);
                }
            }
            else if (cPersoneel != null)
            {
                serializer = new XmlSerializer(typeof(Personeel));
                using (fs = File.Create($"../../../{FilePath}/Personeel/{cPersoneel.naam}.xml"))
                {
                    serializer.Serialize(fs, cPersoneel);
                }
                serializer = new XmlSerializer(typeof(Personeel));
            }
            else if (cTaak != null)
            {
                serializer = new XmlSerializer(typeof(Taak));
                using (fs = File.Create($"../../../{FilePath}/Taken/{cTaak.TaakNaam}.xml"))
                {
                    serializer.Serialize(fs, cTaak);
                }
            }
            else
            {
                //Puur voor debug melding zal nooit voorkomen
                MessageBox.Show("Passed object is not handled!");
            }
            

        }

        //Project uitlezen
        public static Project ProjectUitlezen(string cNaam)
        {
            using (sr = File.OpenText($"../../../{FilePath}{cNaam}.xml"))
            {
                serializer = new XmlSerializer(typeof(Project));
                return serializer.Deserialize(sr) as Project;
            }
        }

        //Alle personeel uitlezen
        public static List<Personeel> PersoneelUitlezen()
        {
            DirectoryInfo DIfiles = new DirectoryInfo($"../../../xml bestanden/Personeel/");
            List<Personeel> personeels = new List<Personeel>();
            serializer = new XmlSerializer(typeof(Personeel));
            FileInfo[] files = DIfiles.GetFiles();
            foreach (FileInfo file in files)
            {
                using (sr = File.OpenText($"../../../xml bestanden/Personeel/{file.Name}"))
                {
                    personeels.Add(serializer.Deserialize(sr) as Personeel);
                }
            }

            return personeels;
        }
        
        //Alle taken uitlezen
        public static List<Taak> TakenUitlezen()
        {
            DirectoryInfo DIfiles = new DirectoryInfo($"../../../xml bestanden/Taken/");
            List<Taak> Taken = new List<Taak>();
            serializer = new XmlSerializer(typeof(Taak));
            FileInfo[] files = DIfiles.GetFiles();
            foreach(FileInfo file in files)
            {
                using (sr = File.OpenText($"../../../xml bestanden/Taken/{file.Name}"))
                {
                    Taken.Add(serializer.Deserialize(sr) as Taak);
                }
            }
            return Taken;
        }

        //1 taak uitlezen (om aan te passen)
        public static Taak TaakUitlezen(string taakname)
        {
            Taak t=new Taak();
            serializer = new XmlSerializer(typeof(Taak));
            using (sr = File.OpenText($"../../../xml bestanden/Taken/{taakname}.xml"))
            {
                t = serializer.Deserialize(sr) as Taak;
            }
            return t;
        }

    }

}
