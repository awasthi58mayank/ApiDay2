using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectXDAL;
using ProjectXDTO;

namespace ProjectXBL
{
    public class CoursesBL
    {
        CoursesDAL obj1;
        public CoursesBL()
        {
            obj1 = new CoursesDAL();

        }
        public List<CourseDTO> GetCourses()
        {
            var CourseList = obj1.GetCourses();
            return CourseList;
        }
        public List<CourseFacultyMappingDTO> GetFacultyFromCId(string cid)
        {
            try
            {
                var listt = obj1.GetFacultyFromCId(cid);
                return listt;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
