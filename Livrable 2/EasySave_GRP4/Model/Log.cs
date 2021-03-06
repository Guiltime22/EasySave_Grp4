using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EasySave_GRP4.Model
{
    public class LogFile
    {
        public static string filepath = @"..\..\..\Config\Log.json";
        public string Name { get; set; }
        public string SourceFilePath { get; set; }
        public string TargetFilePath { get; set; }
        public string Size { get; set; }
        public string Time { get; set; }
        public string TransitionTime { get; set; }

    }
    class Log
    {
        public void Create_Log(FileInfo name, string nom_fichier, string src, string dest, TimeSpan ts, int Taille) //Function to create a log into the log file for the work
        {
            var Temps = new JProperty("Timestamp", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
            var jsonDataWork = File.ReadAllText(LogFile.filepath);
            var File_Var = new LogFile()
            {
                Name = nom_fichier,
                SourceFilePath = src + "\\" + name.Name,
                TargetFilePath = dest + "\\" + name.Name,
                TransitionTime = Convert.ToString(ts),
                Size = Convert.ToString(Taille),
                Time = Convert.ToString(Temps)
            };
            var workList = JsonConvert.DeserializeObject<List<LogFile>>(jsonDataWork) ?? new List<LogFile>();
            workList.Add(new LogFile()
            {
                Name = nom_fichier,
                SourceFilePath = src + "\\" + name.Name,
                TargetFilePath = dest + "\\" + name.Name,
                TransitionTime = Convert.ToString(ts),
                Size = Convert.ToString(Taille),
                Time = Convert.ToString(Temps)
            });
            string jsonString = JsonConvert.SerializeObject(workList, Formatting.Indented);
            File.WriteAllText(LogFile.filepath, jsonString);

        }

    }
}
