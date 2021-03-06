using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
//using Newtonsoft.Json;
using System.Text.Json;
using System.Threading;
using System.Windows;
using static EasySave_GRP4.Model.Model_Factory;


namespace EasySave_GRP4.Model
{
    class Sauvegarde_Unique
    {
       
        private static Object _locker = new Object();
        private static Mutex mutex = new Mutex();
        States CES = new States();
        private EventWaitHandle Event = new ManualResetEvent(false);


        public void CopyRepertoire(string name, string src, string dest, string etat,int index) //Function to copy the files completly
        {

                string path = @"..\..\..\Config\Travaux_Sauvegarde\";
                int nbFichiersSD = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).Length;

                StreamReader r = new StreamReader(@"..\..\..\Config\Parametres.json");
                string jsonString = r.ReadToEnd();
                JFile_parametres JP = JsonConvert.DeserializeObject<JFile_parametres>(jsonString);
                // Get the subdirectories for the specified directory.
                DirectoryInfo dir = new DirectoryInfo(src);

                if (!dir.Exists)
                {
                    throw new DirectoryNotFoundException(
                        "Source directory does not exist or could not be found: "
                        + src);
                }

                DirectoryInfo[] dirs = dir.GetDirectories();

                // If the destination directory doesn't exist, create it.       
                Directory.CreateDirectory(dest);

                // Get the files in the directory and copy them to the new location.
                FileInfo[] files = dir.GetFiles();
                files = OrderFiles(files.ToList()).ToArray();
            var i = 0;
            foreach (FileInfo file in files)
                {
                     if (etat == "END") return;
                     if (etat == "Actif") Event.Set();
                    Event.WaitOne();
                if (Process.GetProcessesByName(JP.Metier).Length == 0)
                    {
                    Stopwatch stopWatch = new Stopwatch();
                        Stopwatch CryptWatch = new Stopwatch();

                        string tempPath = Path.Combine(dest, file.Name);
                        if (file.Extension == "." + JP.Cryptage)
                        {
                            Stopwatch.StartNew();
                            var p = new Process();
                            p.StartInfo.FileName = @"..\..\..\..\CryptoSoft\bin\Debug\netcoreapp3.0\Cryptage_Soft.exe";
                            p.StartInfo.Arguments = $"{file.FullName} {tempPath}";
                            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            if (file.Length < Convert.ToInt32(JP.Taille)) // Prohibition to simultaneously transfer files larger than n KB
                        {
                                CryptWatch.Start(); 
                                mutex.WaitOne();
                                p.StartInfo.UseShellExecute = false;
                                p.StartInfo.CreateNoWindow = true;
                                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                p.Start(); 
                                mutex.ReleaseMutex();
                                CryptWatch.Stop(); 
                            }
                            else
                            {
                                lock (_locker) ; // verrou 
                                CryptWatch.Start();
                                mutex.WaitOne();
                                p.StartInfo.UseShellExecute = false;
                                p.StartInfo.CreateNoWindow = true;
                                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                p.Start();
                                mutex.ReleaseMutex();
                                CryptWatch.Stop();
                            }
                        }
                        TimeSpan cts = CryptWatch.Elapsed;
                        if (file.Length < Convert.ToInt32(JP.Taille))
                        {
                            Stopwatch.StartNew();
                            stopWatch.Start();
                            mutex.WaitOne();
                            file.CopyTo(tempPath, true);
                            mutex.ReleaseMutex();
                            stopWatch.Stop();
                        }
                        else
                        {
                            lock (_locker) ;
                            Stopwatch.StartNew();
                            stopWatch.Start();
                            mutex.WaitOne();
                            file.CopyTo(tempPath, true);
                            mutex.ReleaseMutex();
                            stopWatch.Stop();
                        }

                        long tf = Convert.ToInt64(file.Length);
                        long Taille = tf;

                        TimeSpan ts = stopWatch.Elapsed;
                        Butter.LG.Create_Log(file, name, src, dest, ts, cts, Taille); //Function to create a log in log file
                        Butter.LG.Create_Logxml(file, name, src, dest, ts, cts, Taille); //Function to create a log in log file
                }
                    else
                    {
                        while (Process.GetProcessesByName(JP.Metier).Length != 0)
                        {
                        StreamReader rlang = new StreamReader(@"..\..\..\Config\Parametres.json");
                        string jsonlang = rlang.ReadToEnd();
                        JFile_parametres Jlang = JsonConvert.DeserializeObject<JFile_parametres>(jsonlang);
                        if (Jlang.Langue == "French")
                        {
                            MessageBox.Show("Votre logiciel métier est en cours d'execution, veuillez le fermer !");
                        }
                        else if (Jlang.Langue == "English")
                        {
                            MessageBox.Show("Job application is running, Please close it !");
                        }
                    }
                    }
                i++;
                int nbfichiers = Directory.GetFiles(src, "*", SearchOption.TopDirectoryOnly).Length;
                int filesLeftToDo = nbfichiers - i;
                string progress = Convert.ToString((100 - (filesLeftToDo * 100) / nbfichiers)) + "%";

                List<State_File> stateList = CES.readOnlyState();
                List<State_File> stateListx = CES.readOnlyStatex();


                stateList[index].NbFilesLeftToDo = filesLeftToDo.ToString();
                stateList[index].Progression = progress;
                stateList[index].State = etat;


                stateListx[index].NbFilesLeftToDo = filesLeftToDo.ToString();
                stateListx[index].Progression = progress;
                stateListx[index].State = etat;

                CES.writeOnlyState(stateList);
                CES.writeOnlyStatex(stateListx);

            }
            List<State_File> modifyStateList = CES.readOnlyState();
            List<State_File> modifyStateListx = CES.readOnlyStatex();

            modifyStateList[index].Time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            modifyStateList[index].State = "END";

            modifyStateListx[index].Time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            modifyStateListx[index].State = "END";

            CES.writeOnlyState(modifyStateList);
            CES.writeOnlyStatex(modifyStateListx);

            //In development ---

            /**
            DirectoryInfo diSource = new DirectoryInfo(src);
            DirectoryInfo diTarget = new DirectoryInfo(dest);

            foreach (DirectoryInfo diSourceSubDir in diSource.GetDirectories()) //Check the subdirectories
            {
                if (Process.GetProcessesByName(JP.Metier).Length == 0)
                {
                    DirectoryInfo nextTargetSubDir =
                    diTarget.CreateSubdirectory(diSourceSubDir.Name);
                    CopyRepertoire(name, Convert.ToString(diSourceSubDir), Convert.ToString(nextTargetSubDir), etat);
                }
                else
                {
                    while (Process.GetProcessesByName(JP.Metier).Length != 0)
                    {
                        MessageBox.Show("Votre logiciel métier est en cours d'éxecution, veuillez le fermer !");
                    }
                }
            }
            **/

            //In development
        }
        private List<FileInfo> OrderFiles(List<FileInfo> l) // Gestion des fichiers prioritaires
        {
            StreamReader r = new StreamReader(@"..\..\..\Config\Parametres.json");
            string jsonString = r.ReadToEnd();
            JFile_parametres JP = JsonConvert.DeserializeObject<JFile_parametres>(jsonString);

            List<FileInfo> lp = l.Where(el => el.Extension == "." + JP.Taille).ToList();
            foreach (var t in lp) l.Remove(t);
            lp.AddRange(l);
            return new List<FileInfo>(lp);
        }
    }
}
