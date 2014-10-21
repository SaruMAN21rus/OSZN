using DatabaseLib;
using OSZN.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSZN.DAO
{
    class VocUnitDAO : CommonDAO
    {
        public VocUnitDAO(DbFacadeSQLite db)
            : base(db)
        {
            this.db = db;
        }

        public VocUnitDAO()
            : base()
        {
            this.db = db;
        }

        public int insertVocUnit(VocUnit vocUnit)
        {
            return db.Insert("voc_unit", vocUnit.getParametersCollection());
        }

        public DataTable getVocUnits(string searchText)
        {
            Select select = new Select()
                .From("voc_unit");
            if (!String.IsNullOrEmpty(searchText) && searchText != "Все")
            {
                if (searchText == "Активные")
                    select.Where("active = 1");
                else
                    select.Where("active = 0");
            }
            select.Order("name ASC");
            return db.Execute(select);
        }

        public VocUnit getVocUnitById(int id)
        {
            Select query = new Select()
                .From("voc_unit")
                .Where("id = " + id);
            return new VocUnit(db.FetchOneRow(query));
        }

        public void updateVocUnit(VocUnit vocUnit)
        {
            db.Update("voc_unit", vocUnit.getParametersCollection(), "id = " + vocUnit.id);
        }
    }
}
