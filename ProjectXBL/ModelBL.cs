using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectXDTO;
using ProjectXDAL;
using System.Threading.Tasks;

namespace ProjectXBL
{
    public class ModelBL
    {
        ModelDAL obj3;
        public ModelBL()
        {
            obj3 = new ModelDAL();
        }
        public List<ModelDTO> GetModelDetails()
        {
            try
            {
                var modelList = obj3.GetModelDetails();
                return modelList;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
