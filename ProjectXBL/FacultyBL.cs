using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectXDTO;
using ProjectXDAL;

namespace ProjectXBL
{
   public class FacultyBL
    {
        FacultyStoredDAlL obj;
            public FacultyBL()
            {
                obj = new FacultyStoredDAlL();

            }
            public List<FacultyDTO> GetFaculties()
            {
                var facList = obj.GetFaculties();
                return facList;
            }
        public List<CourseFacultyMappingDTO> GetCoursesByFacultyName(string facName)
        {
            try
            {
                var courseList = obj.GetCoursesByFacultyName(facName);
                return courseList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
