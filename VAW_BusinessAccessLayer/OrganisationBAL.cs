using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAW_DataAccessLayer;

namespace VAW_BusinessAccessLayer
{
    public class OrganisationBAL
    {
        OrganisationDAL OrganisationDAL = new OrganisationDAL();
        public DataSet GetAllOrgsList()
        {
            return OrganisationDAL.GetAllOrgsList();
        }
    }
}
