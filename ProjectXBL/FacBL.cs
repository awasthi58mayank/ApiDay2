using ProjectXDAL;
using ProjectXDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXBL
{
   public  class FacBL
    {
        FacultyStoredDAlL dalObj;
        public int AddNewFaculty(FacultyDTO facObj)
        {
            return dalObj.AddNewFaculty(facObj);

        }
    }
}
