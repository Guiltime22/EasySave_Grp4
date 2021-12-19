using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
//using Newtonsoft.Json;
using System.Text.Json;
using System.Threading;
using System.Windows;
using static EasySave_GRP4.Model.Model_Factory;

namespace EasySave_GRP4.Model
{
    class Sauvegarde_Differentiel
    {
        private static Object _locker = new Object();
        private static Mutex mutex = new Mutex();
        States CED = new States();
        public void CopyRepertoire_Modifier(string name, string sourcePath, string destinationPath, string etat,int index)  //Function to copy the files differential
        {
            var i = 0;
            StreamReader r = new StreamReader(@"..\..\..\Config\Parametres.json");
            string jsonString = r.ReadToEnd();
            JFile_parametres JP = JsonConvert.DeserializeObject<JFile_parametres>(jsonString);
            DirectoryInfo sourceDir = new DirectoryInfo(sourcePath); //Get the informations of the directory source
            FileInfo[] sourceFiles = sourceDir.GetFiles(); //Get files from the directory source
            for (int source = 0; source < sourceFiles.Length; source++)
            {
                if (Process.GetProcessesByName(JP.Metier).Length == 0)
                {
                    DirectoryInfo destinationDir = new DirectoryInfo(destinationPath); //Get the informations of the directory destination
                    FileInfo[] destFiles = destinationDir.GetFiles(); //Get files from the directory destination
                    for (int destination = 0; destination < destFiles.Length; destination++)
                    {
                        if (File.Exists(Path.Combine(destinationPath, sourceFiles[source].Name)))
                        {
                            if (sourceFiles[source].Name == destFiles[destination].Name) //Check if the exist in both the directories
                            {
                                if (sourceFiles[source].LastWriteTime > destFiles[destination].LastWriteTime) //Check the WriteTime of the both files 
                                {
                                    Stopwatch CryptWatch = new Stopwatch();
                                    string tempPath = Path.Combine(destinationPath, sourceFiles[source].Name);
                                    if (sourceFiles[source].Extension == "." + JP.Cryptage)
                                    {
                                        Stopwatch.StartNew();
                                        var p = new Process();
                                        p.StartInfo.FileName = @"..\..\..\..\CryptoSoft\bin\Debug\netcoreapp3.0\Cryptage_Soft.exe";
                                        p.StartInfo.Arguments = $"{sourceFiles[source].FullName} {tempPath}";
                                        CryptWatch.Start();
                                        mutex.WaitOne();
                                        p.Start();
                                        mutex.ReleaseMutex(); 
                                        CryptWatch.Stop();
                                    }
                                    TimeSpan cts = CryptWatch.Elapsed;
                                    mutex.WaitOne();//pour éviter les conflits 
                                    sourceFiles[source].CopyTo(Path.Combine(destinationDir.FullName, sourceFiles[source].Name), true); //Execute the copy
                                    mutex.ReleaseMutex(); //release the mutex my son
                                    Butter.ST.Creer_Fichier_Etat(name, sourcePath, destinationPath, etat);
                                    Stopwatch stopWatch = new Stopwatch(); //Instance the Timer
                                    Stopwatch.StartNew(); //Reset the Timer
                                    stopWatch.Start(); //Begin the Timer
                                    int tf = Convert.ToInt32(sourceFiles[source].Length);
                                    int Taille = tf;
                                    stopWatch.Stop(); //Stop the Timer
                                    TimeSpan ts = stopWatch.Elapsed;
                                    Butter.LG.Create_Log(sourceFiles[source], name, sourcePath, destinationPath, ts, cts, Taille); //Function to create a log in log file

                                }
                            }
                        }
                        else
                        {
                            mutex.WaitOne();
                            sourceFiles[source].CopyTo(Path.Combine(destinationDir.FullName, sourceFiles[source].Name), true);
                            mutex.ReleaseMutex();
                        }
                        i++;
                        int nbfichiers = Directory.GetFiles(sourcePath, "*", SearchOption.TopDirectoryOnly).Length;
                        int filesLeftToDo = nbfichiers - i;
                        string progress = Convert.ToString((100 - (filesLeftToDo * 100) / nbfichiers)) + "%";

                        List<State_File> stateList = CED.readOnlyState();

                        stateList[index].NbFilesLeftToDo = filesLeftToDo.ToString();
                        stateList[index].Progression = progress;
                        stateList[index].State = etat;
                        CED.writeOnlyState(stateList);
                    }
                }
                else
                {
                    while (Process.GetProcessesByName(JP.Metier).Length != 0)
                    {
                        MessageBox.Show("Votre logiciel métier est en cours d'execution, veuillez le fermer !");
                    }
                }
                

            }
            List<State_File> modifyStateList = CED.readOnlyState();

            modifyStateList[index].Time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            modifyStateList[index].State = "END";

            CED.writeOnlyState(modifyStateList);
        }

    }
}