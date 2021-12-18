using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;



namespace test
{
    class Log
    {
        public void Create_Logxml(FileInfo name, string nom_fichier, string src, string dest, TimeSpan ts, int Taille) //Function to create a log into the log file for the work
        {
            var Temps = ("Timestamp", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));


            string xml = File.ReadAllText(LogFile.filepath);
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "LogFile";
            xRoot.IsNullable = true;

            // List<LogFile> worklist =  new List<LogFile>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<LogFile>), xRoot);

            TextReader textReader = new StringReader(xml);

            List<LogFile> worklist = (List<LogFile>)serializer.Deserialize(textReader);



            worklist.Add(new LogFile()
            {
                Name = nom_fichier,
                SourceFilePath = src + "\\" + name.Name,
                TargetFilePath = dest + "\\" + name.Name,
                TransitionTime = Convert.ToString(ts),
                Size = Convert.ToString(Taille),
                Time = Convert.ToString(Temps)
            });




            var writer1 = new StringWriter();
            serializer.Serialize(writer1, worklist);
            var xml1 = writer1.ToString();
            File.WriteAllText(LogFile.filepath, xml1);




        }

        public void Create_LogJson(FileInfo name, string nom_fichier, string src, string dest, TimeSpan ts, int Taille) //Function to create a log into the log file for the work
        {
            var Temps = new JProperty("Timestamp", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
            var jsonDataWork = File.ReadAllText(LogFile.filepathj);
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
            string jsonString = JsonConvert.SerializeObject(workList, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(LogFile.filepathj, jsonString);





        }

    }
}
