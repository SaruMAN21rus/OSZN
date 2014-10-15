using DatabaseLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSZN.DAO
{
    class ExemptHouseroomDAO : CommonDAO
    {
        public int insertExemptHouseRoom(ExemptHouseroom exemptHouseroom)
        {
            return db.Insert("EXEMPT_HOUSEROOM", exemptHouseroom.getParametersCollection());
        }

        public ExemptHouseroom getExemptHouseroomByExemptId(int exemptId)
        {
            Select query = new Select()
                .From("EXEMPT_HOUSEROOM")
                .Where("exempt_id = " + exemptId);
            return new ExemptHouseroom(db.FetchOneRow(query));
        }

        public void updateExemptHouseroom(ExemptHouseroom exemptHouseroom)
        {
            db.Update("EXEMPT_HOUSEROOM", exemptHouseroom.getParametersCollection(), "id = " + exemptHouseroom.id);
        }
    }
}
