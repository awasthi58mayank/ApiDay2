using ProjectXDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXDAL
{
  public  class CoursesStoredDAL
    {
        SqlConnection sqlObj;
        SqlCommand sqlCmObj;
        public CoursesStoredDAL()
        {
            sqlObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectDataEntities"].ToString());
        }
        public int AddNewCourse(CourseDTO facObj)
        {

            sqlCmObj = new SqlCommand("dbo.usp.AddCourses", sqlObj);
            sqlCmObj.CommandType = CommandType.StoredProcedure;
            sqlCmObj.Parameters.AddWithValue("@CourseId", facObj.CourseID);
            sqlCmObj.Parameters.AddWithValue("@CourseTitle", facObj.CourseTitle);
            sqlCmObj.Parameters.AddWithValue("@CourseDuration", facObj.CourseDuration);
            sqlCmObj.Parameters.AddWithValue("@CourseMode", facObj.CourseMode);

            try
            {
                sqlObj.Open();
                SqlParameter rm = sqlCmObj.Parameters.Add("RetVal", SqlDbType.Int);
                rm.Direction = ParameterDirection.ReturnValue;
                int returnValue = (int)rm.Value;
                return returnValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Something went Wrong !");
                return 0;

            }
            finally
            {
                sqlObj.Close();
            }
        }
    }
}


    