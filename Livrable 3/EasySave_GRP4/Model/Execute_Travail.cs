﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Windows;
using static EasySave_GRP4.Model.Model_Factory;
using System.Diagnostics;
using System.Threading;

namespace EasySave_GRP4.Model
{
    /*
    public class JFile
    {
        public string name { get; set; }
        public string source_name { get; set; }
        public string dest_name { get; set; }
        public string type_save { get; set; }
    }
    */
    //
    class Execute_Travail
    {
        Thread Exe_Unique;
        Thread Exe_Diff;
        
        string ETAT = "Actif";
        public void Execute_Unique(string nom_fichier) //function to execute a work of saving
        {
            try
            {

                string fileName = @"..\..\..\Config\Travaux_Sauvegarde\" + nom_fichier + ".json";
                string jsonString = File.ReadAllText(fileName); //Open the file to read the work
                JFile jFile = System.Text.Json.JsonSerializer.Deserialize<JFile>(jsonString); //Convert the content of the file into Objects

                Model.States state = new Model.States();
                var stateList = state.readOnlyState();

                int indexState = 0;
                for (int i = 0; i < stateList.Count; i++)
                {
                    if (stateList[i].Name == jFile.name)
                    {
                        indexState = i;
                        break;
                    }
                }
                if (jFile.type_save == "Complet" || jFile.type_save == "Full")
                {
                    Butter.SVU.CopyRepertoire(jFile.name, jFile.source_name, jFile.dest_name, ETAT,indexState); //Function to copy the files completly
                    //File.Delete(fileName); //Delete the work after the execution
                }
                else if (jFile.type_save == "Differentiel" || jFile.type_save == " Differential")
                {

                    Butter.SVS.CopyRepertoire_Modifier(jFile.name, jFile.source_name, jFile.dest_name, ETAT); //Function to copy the files differential
                    //File.Delete(fileName);
                }
                MessageBox.Show("Execution du travail réussi");
            }
            catch
            {
                MessageBox.Show("Travail introuvable");
            }
        }
        public void Execute_Seq()
        { 

            string[] files = Directory.GetFiles(@"..\..\..\Config\Travaux_Sauvegarde", "*.json"); //Table to put the different works
            foreach (var file in files) //For each work
            {
              
                string jsonString = File.ReadAllText(file); //Open the file to read the work
                JFile jFile = System.Text.Json.JsonSerializer.Deserialize<JFile>(jsonString);//Convert the content of the file into Objects
                Model.States state = new Model.States();
                var stateList = state.readOnlyState();

                int indexState = 0;
                for (int i = 0; i < stateList.Count; i++)
                {
                    if (stateList[i].Name == jFile.name)
                    {
                        indexState = i;
                        break;
                    }
                }
                Exe_Unique = new Thread(() => Butter.SVU.CopyRepertoire(jFile.name, jFile.source_name, jFile.dest_name, ETAT, indexState)); // Sauvegarde en parallèle
                Exe_Diff = new Thread(() => Butter.SVS.CopyRepertoire_Modifier(jFile.name, jFile.source_name, jFile.dest_name, ETAT));

                if (jFile.type_save == "Complet" || jFile.type_save == "Full") 
                {
                    //Butter.SVU.CopyRepertoire(jFile.name, jFile.source_name, jFile.dest_name, ETAT); //Function to copy the files completly

                    Exe_Unique.Start(); //Tebda la sauvegarde
                    File.Delete(file);
                }
                else if (jFile.type_save == "Differentiel" || jFile.type_save == " Differential")
                {
                    //Butter.SVS.CopyRepertoire_Modifier(jFile.name, jFile.source_name, jFile.dest_name, ETAT); //Function to copy the files Differential
                    Exe_Diff.Start(); //Tebda la sauvegarde
                    File.Delete(file);
                }

            }
            //MessageBox.Show("Execution du travail réussi");
        }

        public void Pause()
        {

        }


        public void Play()
        {

        }
        public void Stop()
        {
            /*
            // Signal the shutdown event
            Butter._shutdownEvent.Set();

            // Make sure to resume any paused threads
            Butter._pauseEvent.Set();

            // Wait for the thread to exit
            Exe_Unique.Join();
            */
        }

    }
}
