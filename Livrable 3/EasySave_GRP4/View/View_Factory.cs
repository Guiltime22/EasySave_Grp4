using System;
using System.Collections.Generic;
using System.Text;
using EasySave_Grp4.ModelView;

namespace EasySave_GRP4.View
{
    class View_Factory
    {
        static public CL_Execute_Travail CET = new CL_Execute_Travail();
        static public CL_Create_Travail CCT = new CL_Create_Travail();
        static public CL_Parametres PR = new CL_Parametres();
    }
}
