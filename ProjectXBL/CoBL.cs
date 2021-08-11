using ProjectXDAL;
using ProjectXDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXBL
{
  public   class CoBL
    {

        CoursesStoredDAL dObj;
        public int AddNewCourse(CourseDTO dalObj)
        {
            return dObj.AddNewCourse(dalObj);

        }
    }
}
