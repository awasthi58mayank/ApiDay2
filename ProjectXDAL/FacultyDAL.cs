using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectXDTO;
using System.Threading.Tasks;

namespace ProjectXDAL
{
    public class FacultyStoredDAlL
    {
		ProjectDataEntities objContext = new ProjectDataEntities();
		public List<FacultyDTO> GetFaculties()
        {
            try
            {
                List<FacultyDTO> lstFaculty = new List<FacultyDTO>();
                
                var facDALListObj = objContext.Faculties.ToList();
                foreach (var item in facDALListObj)
                {
                    lstFaculty.Add(
                        new FacultyDTO
                        {
                            FacultyName = item.FacultyName,
                            EmailID = item.EmailId,
                            PSNo = item.PSNO

                        });
                }
                return lstFaculty;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ooops! Something went Wrong!");
                throw ex;
            }
        }
		public int GetFacultyPSNo(string fName)
		{
			try
			{
				object facPsno = objContext.Faculties.Where(x => x.FacultyName == fName).Select(x => new { x.PSNO});
				return (int)facPsno;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<CourseFacultyMappingDTO> GetCoursesByFacultyName(string fname)
		{
			List<CourseFacultyMappingDTO> lstCourses = new List<CourseFacultyMappingDTO>();
			try
			{
				var listFilteredCourse = objContext.FacultyCourseMappings.Join(objContext.Faculties,x => x.PSNO ,y=>y.PSNO,(x,y) =>new {fc=x,fac =y }).Where(x=>x.fac.FacultyName == fname).Select(x => new {x.fc.CourseId});
				foreach(var item in listFilteredCourse)
                {
					lstCourses.Add(
						new CourseFacultyMappingDTO()
						{
							CourseID = item.CourseId
						});
				}
				return lstCourses;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			
		}
        public int AddNewFaculty(FacultyDTO newFacObj)
        {
            int ret = 0;
            try
            {
                using (var objContext = new ProjectDataEntities())
                {
                    Faculty facDALObj = new Faculty();
                    facDALObj.PSNO = newFacObj.PSNo;
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


