using System;
using System.Collections.Generic;
using System.Text;
using EasySave_GRP4.Model;

namespace EasySave_Grp4.ModelView
{
    class VM_Factory
    {
            static public Create_Travail TR = new Create_Travail();
            static public Execute_Travail ET = new Execute_Travail();
            static public Parametres P = new Parametres();
            static public Gestion_Travail GT = new Gestion_Travail(); 
    }
}
