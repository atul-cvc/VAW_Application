using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using VAW_DataAccessLayer;
using VAW_Models;
namespace VAW_BusinessAccessLayer
{
    public class IntegrityPledgeManager
    {
        IntegrityPledgeDAL IntegrityPledgeDAL = new IntegrityPledgeDAL();
        public DataSet GetIntegrityPledgeByCVOID(string cvoid)
        {
            return IntegrityPledgeDAL.GetIntegrityPledgeBYCVOID(cvoid);
        }

        public int SaveIntegrityPledge(Tran_1a_integritypledge_Model obj)
        {
            return IntegrityPledgeDAL.SaveIntegrityPledge(obj);
        }
    }
}
