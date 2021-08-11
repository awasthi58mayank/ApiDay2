
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectXDTO;

namespace ProjectXDAL
{
    public class CoursesDAL
    {
        ProjectDataEntities objContext;
        public CoursesDAL()
        {
            objContext = new ProjectDataEntities();
        }
        public List<CourseDTO> GetCourses()
        {
            try
            {
                List<CourseDTO> lstCourse = new List<CourseDTO>();
                
                var CourseDALListObj = objContext.Courses.ToList();
                foreach (var item in CourseDALListObj)
                {
                    lstCourse.Add(
                        new CourseDTO
                        {
                            CourseID = item.CourseId,
                            CourseTitle = item.CourseTitle,
                            Duration =(int)item.CourseDuration,
                           

                        });
                }
                return lstCourse;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oopss! Something went Wrong!");
                throw ex;
            }
        }
        public List<CourseFacultyMappingDTO> GetFacultyFromCId(string cid)
        {
            List<CourseFacultyMappingDTO> lstFilteredFac = new List<CourseFacultyMappingDTO>();
           
            try
            {
                var lstFilteredDb = objContext.Courses.Where(x => x.CourseId== cid);
                foreach (var item in lstFilteredDb)
                {
                    lstFilteredFac.Add(
                        new CourseFacultyMappingDTO
                        {
                            CourseID = item.CourseId,
                            
                        });
                }
                return lstFilteredFac;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public int AddNewCourse(CourseDTO newFacObj)
        {
            int ret = 0;
            try
            {
                using (var objContext = new ProjectDataEntities())
                {
                    
                    facDALObj.Cou = newFacObj.PSNo;
                    facDALObj.EmailId = newFacObj.EmailID;
                    facDALObj.FacultyName = newFacObj.FacultyName;
                    objContext.Faculties.Add(facDALObj);
                    ret = objContext.SaveChanges();
                    return ret;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ooopppss, Something went Wrong!");
                throw ex;
            }
        }
    }
}
