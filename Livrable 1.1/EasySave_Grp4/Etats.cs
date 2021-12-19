using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace test
{
    [XmlRoot("State_File"), XmlType("State_File")]

    public class State_File
    {

        public static string fileName = @"..\..\..\Config\Etats.json";
        public static string fileNamex = @"..\..\..\Config\Etats.xml";
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "SourceFilePath")]
        public string SourceFilePath { get; set; }
        [XmlElement(ElementName = "TargetFilePath")]
        public string TargetFilePath { get; set; }
        [XmlElement(ElementName = "State")]
        public string State { get; set; }
        [XmlElement(ElementName = "TotalFilesToCopy")]
        public string TotalFilesToCopy { get; set; }
        [XmlElement(ElementName = "TotalFilesSize ")]
        public string TotalFilesSize { get; set; }
        [XmlElement(ElementName = "NbFilesLeftToDo")]
        public string NbFilesLeftToDo { get; set; }
        [XmlElement(ElementName = "Progression ")]
        public string Progression { get; set; }
        [XmlElement(ElementName = "Time ")]
        public string Time { get; set; }
    }
    class States
    {
        public void Creer_Fichier_Etat(string nom_fichier, string source, string destination, string ETAT) //Function to create a state into the state file for the work
        {
            int Taille = 0;
            int TotalFichiersACopier = Directory.GetFiles(source, "*.*", SearchOption.TopDirectoryOnly).Length;
            int TotalFichiersDestination = Directory.GetFiles(destination, "*.*", SearchOption.TopDirectoryOnly).Length;
            int TotalFichiersRestants = TotalFichiersACopier - TotalFichiersDestination; //To calculate the remaining files

            DirectoryInfo dir = new DirectoryInfo(source);
            DirectoryInfo[] dirs = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                int tf = Convert.ToInt32(file.Length);
                Taille = Taille + tf; //The size of the file
            }
            float Progress = (TotalFichiersDestination / TotalFichiersACopier) * 100; //To calculate the progress of the copy
            var Temps = new JProperty("Timestamp", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")); //To set the time of the copy
            var jsonDataWork = File.ReadAllText(State_File.fileName);
            var workList = JsonConvert.DeserializeObject<List<State_File>>(jsonDataWork) ?? new List<State_File>();
            workList.Add(new State_File()
            {
                Name = nom_fichier,
                SourceFilePath = source,
                TargetFilePath = destination,
                State = ETAT,
                TotalFilesToCopy = Convert.ToString(TotalFichiersACopier),
                TotalFilesSize = Convert.ToString(Taille),
                NbFilesLeftToDo = Convert.ToString(TotalFichiersRestants),
                Progression = Convert.ToString(Progress) + "%",
                Time = Convert.ToString(Temps)
            });

            string jsonString = JsonConvert.SerializeObject(workList, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(State_File.fileName, jsonString);

        }
        public void Creer_Fichier_Etatx(string nom_fichier, string source, string destination, string ETAT) //Function to create a state into the state file for the work
        {
            int Taille = 0;
            int TotalFichiersACopier = Directory.GetFiles(source, "*.*", SearchOption.TopDirectoryOnly).Length;
            int TotalFichiersDestination = Directory.GetFiles(destination, "*.*", SearchOption.TopDirectoryOnly).Length;
            int TotalFichiersRestants = TotalFichiersACopier - TotalFichiersDestination; //To calculate the remaining files

            DirectoryInfo dir = new DirectoryInfo(source);
            DirectoryInfo[] dirs = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                int tf = Convert.ToInt32(file.Length);
                Taille = Taille + tf; //The size of the file
            }
            float Progress = (TotalFichiersDestination / TotalFichiersACopier) * 100; //To calculate the progress of the copy
            var Temps = ("Timestamp", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")); //To set the time of the copy


            string xml = File.ReadAllText(State_File.fileNamex);
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "State_File";
            xRoot.IsNullable = true;

            XmlSerializer serializer = new XmlSerializer(typeof(List<State_File>), xRoot);

            TextReader textReader = new StringReader(xml);

            List<State_File> worklist = (List<State_File>)serializer.Deserialize(textReader);



            worklist.Add(new State_File()
            {
                Name = nom_fichier,
                SourceFilePath = source,
                TargetFilePath = destination,
                State = ETAT,
                TotalFilesToCopy = Convert.ToString(TotalFichiersACopier),
                TotalFilesSize = Convert.ToString(Taille),
                NbFilesLeftToDo = Convert.ToString(TotalFichiersRestants),
                Progression = Convert.ToString(Progress) + "%",
                Time = Convert.ToString(Temps)
            });


            var writer1 = new StringWriter();
            serializer.Serialize(writer1, worklist);
            var xml1 = writer1.ToString();
            File.WriteAllText(State_File.fileNamex, xml1);


        }
    }

}
