Contexte :
Après notre intégration à l'éditeur de logiciels ProSoft, sous la responsabilité du DSI, nous avons été responsabilisés à gérer le projet "EasySave" qui demande le développement d'un logiciel de sauvegarde.

Le logiciel s'intégrera à la politique tarifaire.
•	Prix unitaire : 200 €HT
•	Contrat de maintenance annuel 5/7 8-17h (mises à jour incluses): 12% prix d'achat (Contrat annuel à tacite reconduction avec revalorisation basée sur l'indice SYNTEC)
Nous avons eu comme mission d'assurer le développement ainsi que la gestion des versions majeures, mais également les documentations pour les utilisateurs (manuel d'utilisation) et le support client (le rapport technique).

Installation : 

•	Visual Studio 2019 (entreprise version)

•	Visual Paradigm (Pour les diagrammes UML) 

•	Github

Langage, FrameWork :

•	Langage C#

•	Bibliothèque Net.Core 3.X

EasySave Version 1.0 : 

Dans cette première version notre logiciel est réalisé en ligne de console sans interface graphique.

•	Le logiciel est utilisé par des utilisateurs anglophones et francophones.
•	Le logiciel permet de créer jusqu’à 5 travaux de sauvegarde.
•	Un travail est défini par : 
    -Son nom.
    -Son répertoire source
    -Son répertoire cible
  	-Le type de sauvegarde (Complet ou Différentiel)			
•	Les répertoires cibles et sources pourront être sur des disques locaux, externes ou des lecteurs réseaux.
•	L’historique des actions de sauvegardes seront écrit dans fichier log journalier, où sera transcrit l’horodatage, l’appellation du travail de sauvegarde, l’adresse complète du fichier Source (format UNC), l’adresse complète du fichier de destination (format UNC), la taille du fichier et le Temps de transfert du fichier en ms.
•	L’état d’avancement des travaux de sauvegarde sera aussi enregistré dans un fichier unique où sera transcrit pour chaque sauvegarde l’appellation du travail de sauvegarde, l’horodatage ainsi que l’état du travail de Sauvegarde (ex : Actif, Non Actif...)
  o	Si le travail est actif, les informations enregistrées en plus seront : 
    	•Le nombre total de fichiers éligibles
    	•La taille des fichiers à transférer
     	•La progression
          -Nombre de fichiers restants
          -Taille des fichiers restants
          -Adresse complète du fichier Source en cours de sauvegarde
          -Adresse complète du fichier de destination
•	Les fichiers (log journalier et état) et tous les fichiers de configuration seront au format JSON. Afin de permettre une lecture rapide via Notepad, il est nécessaire de mettre des sauts de ligne entre les éléments JSON. Une pagination serait un plus.

Démarrer l’application :
[Guide d'utilisation Groupe04.docx](https://github.com/Guiltime22/EasySave_Grp4/files/7598919/Guide.d.utilisation.Groupe04.docx)



Auteurs : Groupe 04
TIGAMOUNINE Nadjib
OUCHAOUA Ghiles
KADOUCHE Lydia
MAZOUNI Chiraz
MESBAH Wail

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Context :
After our integration with the ProSoft software editor, under the responsibility of the DSI, we were responsible for managing the "EasySave" project which requires the development of backup software.

The software will be integrated into the pricing policy.
• Unit price: 200 €HT
• Annual maintenance contract 5/7 8-17h (including updates): 12% purchase price (Annual contract with tacit renewal with revaluation based on the SYNTEC index)

Our mission was to ensure the development and management of major versions, but also the documentation for users (user manual) and customer support (the technical report).

Installation:
• Visual Studio 2019 (enterprise version)
• Visual Paradigm (for diagrams)
•	Github

Language, FrameWork:
• Language C#
• Net.Core library 3.X

EasySave Version 1.0:
In this first version, the code will be on the console line without a graphic interface.
• The software is used by English and French users.
• The software can create up to 5 backup works.
• A work is defined by:
    -	His name.
	  -Its source directory
	  -Its target directory
  	-Backup type (Full or Differential)
• Target and source directories may be on local, external, or network drives.
• The history of the backup actions will be written in the log daily file, where will be transcribed the time stamp, the name of the backup work, the complete address of the Source file (UNC format), the complete address of the destination file (UNC format), file size and file transfer time in ms.
• The progress of the backup work will also be recorded in a single file where the name of the backup work, the timestamp and the state of the Backup work will be transcribed for each backup (e.g.: Active, Not Active...)
      	     o If the work is active, the additional recorded information will be:
                  	•Total number of eligible files
                  	•The size of the files to be transferred
	                  •Progress
                           -Number of files remaining
                           -Size of remaining files
                           -Complete address of the Source file being saved
                           -Complete address of the destination file
• The files (daily log and status) and any configuration files will be in JSON format. In order to allow fast reading via Notepad, it is necessary to put line feeds between the JSON elements. A pagination would be a plus.

Start the application : [Guide d'utilisation Groupe04.docx](https://github.com/Guiltime22/EasySave_Grp4/files/7598921/Guide.d.utilisation.Groupe04.docx)

Authors : Group 04
TIGAMOUNINE Nadjib
OUCHAOUA Ghiles
KADOUCHE Lydia
MAZOUNI Chiraz
MESBAH Wail

