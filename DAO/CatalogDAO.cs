using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSZN.DAO
{
    class CatalogDAO : CommonDAO
    {
        public DataTable getLowLevels(string addressObjectGuid)
        {
            return db.Execute("select ID, NAME "
                + "from VOC_LEVEL "
                + "where ID > (select AOLEVEL from VOC_ADDRESS_OBJECT where CURRSTATUS = 0 and AOGUID = '" + addressObjectGuid + "') "
                + "order by ID ASC");
        }

        public DataTable getTypeBriefs(int level)
        {
            return db.Execute("select SOCRNAME "
                + "from VOC_ADDRESS_TYPE "
                + "where LEVEL = " + level + " "
                + "order by ID ASC");
        }

        public DataTable getCurrAndLowLevels(string addressObjectGuid)
        {
            return db.Execute("select ID, NAME "
                + "from VOC_LEVEL "
                + "where ID >= (select AOLEVEL from VOC_ADDRESS_OBJECT where CURRSTATUS = 0 and AOGUID = '" + addressObjectGuid + "') "
                + "order by ID ASC");
        }

    }
}
