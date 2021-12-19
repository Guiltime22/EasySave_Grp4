using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace EasySave_GRP4.Model
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
        private static Mutex mutex = new Mutex();
        public void Creer_Fichier_Etat(string nom_fichier, string source, string destination, string ETAT) //Function to create a state into the state file for the work
        {
            long Taille = 0;
            int TotalFichiersACopier = Directory.GetFiles(source, "*.*", SearchOption.AllDirectories).Length;
            int TotalFichiersDestination = Directory.GetFiles(destination, "*.*", SearchOption.AllDirectories).Length;
            int TotalFichiersRestants = TotalFichiersACopier - TotalFichiersDestination; //To calculate the remaining files
            float Progressioune=0;
            DirectoryInfo dir = new DirectoryInfo(source);
            DirectoryInfo[] dirs = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                long tf = Convert.ToInt64(file.Length);
                Taille = Taille + tf; //The size of the file

            }
            Progressioune = (TotalFichiersDestination / TotalFichiersACopier) * 100; //To calculate the progress of the copy
            var Temps = new JProperty("Timestamp", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")); //To set the time of the copy
            mutex.WaitOne();
            var jsonDataWork = File.ReadAllText(State_File.fileName);
            mutex.ReleaseMutex();
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
                Progression = Convert.ToString(Progressioune) + "%",
                Time = Convert.ToString(Temps)
            });
            
            string jsonString = JsonConvert.SerializeObject(workList, Formatting.Indented);
            mutex.WaitOne();
            File.WriteAllText(State_File.fileName, jsonString);
            mutex.ReleaseMutex();
            

        }
        public void writeOnlyState(List<State_File> stateList) { 
            mutex.WaitOne(); 
            string strResultJsonState = JsonConvert.SerializeObject(stateList, Formatting.Indented);
            File.WriteAllText(State_File.fileName, strResultJsonState);
            mutex.ReleaseMutex();
        }
        public List<State_File> readOnlyState()
        {
            mutex.WaitOne();
            var jsonDataWork = File.ReadAllText(State_File.fileName); //Read the JSON file
            var workList = JsonConvert.DeserializeObject<List<State_File>>(jsonDataWork) ?? new List<State_File>(); //convert a string into an object for JSON
            mutex.ReleaseMutex();

            return workList;

        }
    }
}