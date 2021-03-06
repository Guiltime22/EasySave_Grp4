using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace test
{
    public class State_File
    {
        public static string fileName = @"..\..\..\Config\Etats.json";
        public string Name { get; set; }
        public string SourceFilePath { get; set; }
        public string TargetFilePath { get; set; }
        public string State { get; set; }
        public string TotalFilesToCopy { get; set; }
        public string TotalFilesSize { get; set; }
        public string NbFilesLeftToDo { get; set; }
        public string Progression { get; set; }
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
            
            string jsonString = JsonConvert.SerializeObject(workList, Formatting.Indented);
            File.WriteAllText(State_File.fileName, jsonString);

        }
    }
}