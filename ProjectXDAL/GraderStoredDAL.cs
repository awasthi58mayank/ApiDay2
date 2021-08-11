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
  public   class GraderStoredDAL
    {
        SqlConnection sqlObj;
        SqlCommand sqlCmObj;
        public GraderStoredDAL()
        {
            sqlObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectDataEntities"].ToString());
        }
        public int AddNewGrader(GraderDTO facObj)
        {

            sqlCmObj = new SqlCommand("dbo.uspGraderInput", sqlObj);
            sqlCmObj.CommandType = CommandType.StoredProcedure;
            sqlCmObj.Parameters.AddWithValue("@Marks", facObj.Marks);
            sqlCmObj.Parameters.AddWithValue("@PsNo", facObj.PSNo);
           

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


