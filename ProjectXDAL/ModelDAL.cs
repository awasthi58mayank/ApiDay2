
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectXDTO;
using System.Threading.Tasks;

namespace ProjectXDAL
{
    public class ModelDAL
    {
        ProjectDataEntities objContext;
        public ModelDAL()
        {
            objContext = new ProjectDataEntities();
        }
        public List<ModelDTO> GetModelDetails()
        {
            try
            {
                List < ModelDTO> lstModel = new List<ModelDTO>();

                var modelDALListObj = objContext.DeliveryModels.ToList();
                foreach (var item in modelDALListObj)
                {
                    lstModel.Add(
                        new ModelDTO
                        {
                         ModelID = item.ModelId,
                         ModelName = item.ModelName,
                         
                        });
                }
                return lstModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oopss! Something went Wrong!");
                throw ex;
            }
        }
    }
}
