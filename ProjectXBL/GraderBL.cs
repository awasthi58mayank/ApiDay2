using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectXDAL;
using ProjectXDTO;

namespace ProjectXBL
{
    public class GraderBL
    {
        GraderDAL obj2;
        public GraderBL()
        {
            obj2 = new GraderDAL();
        }
        public List<GraderDTO> GetGradesFromPSNo(int psno)
        {
            try
            {
                var graderList = obj2.GetGradesFromPSNo(psno);
                return graderList;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<GraderDTO> GetGradesFitered()
        {
            try
            {
                var graderFilteredList = obj2.GetGradesFitered();
                return graderFilteredList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
