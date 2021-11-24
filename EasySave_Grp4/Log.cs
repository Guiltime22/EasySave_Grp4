/* using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Text.Json;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace test
{
    class Log
    {
        //Declaration of the properties that are used for the program log file
        public static string filepath = @"..\..\..\..\..\Config\Log.json";
        public string Name { get; set; }
        public string SourceFilePath { get; set; }
        public string TargetFilePath { get; set; }
        public string Size { get; set; }
        public string Time { get; set; }



        public void Create_Log(string file, string src, string dest, string nom_fichier)
        {
            int tf = Convert.ToInt32(file.Length);
            int Taille = tf;
            var Temps = new JProperty("Timestamp", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
            var jsonDataWork = File.ReadAllText(Log.filepath);
            var File_Var = new Log
            {
                Name = file,
                SourceFilePath = src + "\\" + nom_fichier,
                TargetFilePath = dest + "\\" + nom_fichier,
                Size = Convert.ToString(Taille),
                Time = Convert.ToString(Temps)
            };
            var workList = JsonConvert.DeserializeObject<List<Log>>(jsonDataWork) ?? new List<Log>();
            workList.Add(new Log()
            {
                Name = file,
                SourceFilePath = src + "\\" + nom_fichier,
                TargetFilePath = dest + "\\" + nom_fichier,
                Size = Convert.ToString(Taille),
                Time = Convert.ToString(Temps)
            });
            string jsonString = JsonConvert.SerializeObject(workList, Formatting.Indented);
            File.WriteAllText(Log.filepath, jsonString);
        }

    }

}
*/