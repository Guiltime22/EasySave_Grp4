using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EasySave_GRP4.Model
{
    public class LogFile
        
    {
        public static string filepath = @"..\..\..\Config\Log.json";
         public static string filepathx = @"..\..\..\Config\Log.xml";

        [XmlElement(ElementName = "Cryptime")]
        public string CryptTime { get; set; }

        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "SourceFilePath")]
        public string SourceFilePath { get; set; }
        [XmlElement(ElementName = "TargetFilePath")]
        public string TargetFilePath { get; set; }
        [XmlElement(ElementName = "Size")]
        public string Size { get; set; }
        [XmlElement(ElementName = "Time")]
        public string Time { get; set; }
        [XmlElement(ElementName = "TransitionTime")]
        public string TransitionTime { get; set; }

    }
    class Log
    {
        private static Mutex mutex = new Mutex();
        public void Create_Logxml(FileInfo name, string nom_fichier, string src, string dest, TimeSpan ts, TimeSpan cts, long Taille) //Function to create a log into the log file for the work
        {
            while (true)
            {
                try
                {
                    var Temps = ("Timestamp", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));

            mutex.WaitOne();
            string xml = File.ReadAllText(LogFile.filepathx);
            mutex.ReleaseMutex();
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "LogFile";
            xRoot.IsNullable = true;

          
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
                Time = Convert.ToString(Temps),
                 CryptTime = Convert.ToString(cts)
            });




            var writer1 = new StringWriter();
            serializer.Serialize(writer1, worklist);
            var xml1 = writer1.ToString();
            mutex.WaitOne();
            File.WriteAllText(LogFile.filepathx, xml1);
            mutex.ReleaseMutex();
            break;
                }
                catch (Exception e)
                {

                }
                Thread.Sleep(100);
            }



        }

        public void Create_Log(FileInfo name, string nom_fichier, string src, string dest, TimeSpan ts, TimeSpan cts, long Taille) //Function to create a log into the log file for the work
        {
            while (true)
            {
                try
                {
                    var Temps = new JProperty("Timestamp", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
                    mutex.WaitOne();
                    var jsonDataWork = File.ReadAllText(LogFile.filepath);
                    mutex.ReleaseMutex();
                    var File_Var = new LogFile()
                    {
                        Name = nom_fichier,
                        SourceFilePath = src + "\\" + name.Name,
                        TargetFilePath = dest + "\\" + name.Name,
                        TransitionTime = Convert.ToString(ts),
                        Size = Convert.ToString(Taille),
                        Time = Convert.ToString(Temps),
                        CryptTime = Convert.ToString(cts)
                    };
                    var workList = JsonConvert.DeserializeObject<List<LogFile>>(jsonDataWork) ?? new List<LogFile>();
                    workList.Add(new LogFile()
                    {
                        Name = nom_fichier,
                        SourceFilePath = src + "\\" + name.Name,
                        TargetFilePath = dest + "\\" + name.Name,
                        TransitionTime = Convert.ToString(ts),
                        Size = Convert.ToString(Taille),
                        Time = Convert.ToString(Temps),
                        CryptTime = Convert.ToString(cts)
                    });
                    string jsonString = JsonConvert.SerializeObject(workList, Newtonsoft.Json.Formatting.Indented);
                    mutex.WaitOne();
                    File.WriteAllText(LogFile.filepath, jsonString);
                    mutex.ReleaseMutex();
                    break;
                }
                catch(Exception e)
                {

                }
                Thread.Sleep(100);
            }
        }

    }
}
