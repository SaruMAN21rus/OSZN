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
    class VocHousingTypeDAO : CommonDAO
    {
        public VocHousingTypeDAO(DbFacadeSQLite db)
            : base(db)
        {
            this.db = db;
        }

        public VocHousingTypeDAO()
            : base()
        {
            this.db = db;
        }

        public int insertVocHousingType(VocHousingType housingType)
        {
            return db.Insert("voc_housing_type", housingType.getParametersCollection());
        }

        public DataTable getVocHousingTypes(string searchText)
        {
            Select select = new Select()
                .From("voc_housing_type");
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

        public VocHousingType getVocHousingTypeById(int id)
        {
            Select query = new Select()
                .From("voc_housing_type")
                .Where("id = " + id);
            return new VocHousingType(db.FetchOneRow(query));
        }

        public void updateVocHousingType(VocHousingType housingType)
        {
            db.Update("voc_housing_type", housingType.getParametersCollection(), "id = " + housingType.id);
        }
    }
}
