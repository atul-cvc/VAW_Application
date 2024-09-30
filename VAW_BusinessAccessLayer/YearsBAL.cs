using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAW_DataAccessLayer;
using VAW_Models;

namespace VAW_BusinessAccessLayer
{
    public class YearsBAL
    {
        YearsDAL YearsDAL = new YearsDAL();
        //GetAllYearsList

        public DataSet GetAllYearsList()
        {
            return YearsDAL.GetAllYearsList();
        }
    }
}
