
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectXDTO;

namespace ProjectXDAL
{
    public class GraderDAL
    {
        ProjectDataEntities objContext;
        public GraderDAL()
        {
            objContext = new ProjectDataEntities();
        }
        public List<GraderDTO> GetGradesFromPSNo(int psno)
        {
            List<GraderDTO> lstGrader = new List<GraderDTO>();
            try
            {
                var lstGraderDb = objContext.Graders.Where(x => x.PSNO == psno).Select(x => new { x.Score });
                foreach (var item in lstGraderDb)
                {
                    lstGrader.Add(
                        new GraderDTO
                        {
                            Marks = item.Score
                        });
                }
                return lstGrader;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<GraderDTO> GetGradesFitered()
        {
            List<GraderDTO> lstFilteredGrader = new List<GraderDTO>();
            try
            {
                var lstFilteredGraderDb = objContext.Graders.Where(x => x.Score > 70).Select(x => new { x.PSNO});
                foreach (var item in lstFilteredGraderDb)
                {
                    lstFilteredGrader.Add(
                        new GraderDTO
                        {
                            PSNo =(int) item.PSNO
                        });
                }
                return lstFilteredGrader;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


