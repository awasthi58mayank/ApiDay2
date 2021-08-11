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
   public  class FacultyStoredDAl
    {
        SqlConnection sqlObj;
        SqlCommand sqlCmObj;
        public FacultyStoredDAl()
        {
            sqlObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectXEntities"].ToString());
        }
        public int AddNewFaculty(FacultyDTO facObj)
        {

            sqlCmObj = new SqlCommand("dbo.uspInsertFacultyDetails", sqlObj);
            sqlCmObj.CommandType = CommandType.StoredProcedure;
            sqlCmObj.Parameters.AddWithValue("@FacultyName", facObj.FacultyName);
            sqlCmObj.Parameters.AddWithValue("@EmailId", facObj.EmailID);
            sqlCmObj.Parameters.AddWithValue("@PSNo", facObj.PSNo);
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
