using DatabaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSZN.DAO
{
    class OrganizationDAO : CommonDAO
    {
        public Dictionary<string, object> getOrganization()
        {
            Select select = new Select()
                .From("ORGANIZATION as o")
                .Join("HOUSE h", "o.house_id = h.id", SQLJoinTypes.INNER_JOIN)
                .Columns("*");

            return db.FetchOneRow(select);
        }

        public void saveOrganization(ParametersCollection parameters, House house, bool add)
        {
            db.BeginTransaction();
            HouseDAO hDAO = new HouseDAO(db);
            house.id = hDAO.saveHouse(house);
            parameters.Add("HOUSE_ID", house.id, System.Data.DbType.Int32);
            if (add)
            {
                db.Insert("ORGANIZATION", parameters);
            }
            else
            {
                db.Update("ORGANIZATION", parameters, "name is not null");
            }
            db.CommitTransaction();
        }
    }
}
