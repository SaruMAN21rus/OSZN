using DatabaseLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSZN.DAO
{
    class ExemptDAO : CommonDAO
    {       
        public int insertExempt(Exempt exempt)
        {
            return db.Insert("EXEMPT", exempt.getParametersCollection());
        }

        public DataTable getExempts(string searchText)
        {
            Select select = new Select()
                .From("EXEMPT as e");
                if (!String.IsNullOrEmpty(searchText)) {
                    searchText = searchText.ToLower();
                    select.Where("id = " + searchText
                        + " or lower(last_name) LIKE ('%" + searchText + "%')"
                        + " or lower(name) LIKE ('%" + searchText + "%')"
                        + " or lower(middle_name) LIKE ('%" + searchText + "%')"
                        + " or personal_account  LIKE ('%" + searchText + "%')"
                        + " or SNILS LIKE ('%" + searchText + "%')");
                }
                select.Order("e.id ASC");
            DataTable dt = db.Execute(select);
            if (dt != null)
            {
                DataColumn fio = new DataColumn();
                fio.ColumnName = "fio";
                fio.Expression = "TRIM(ISNULL(last_name, '') + ' ' + ISNULL(name, '') + ' ' + ISNULL(middle_name, ''))";
                dt.Columns.Add(fio);
                DataColumn document = new DataColumn();
                document.ColumnName = "document";
                document.Expression = "TRIM(ISNULL(document_name, '') + ' ' + ISNULL(document_series, '') + ' ' + ISNULL(document_number, '') + "
                                    + "IIF (document_date is not null or document_issuer is not null,' Выдан ' + ISNULL(document_issuer, '') + ' ' + "
                                    + "IIF (document_date is not null, SUBSTRING(Convert(document_date, 'System.String'), 1, 10), ''),''))";
                dt.Columns.Add(document);
                DataColumn address = new DataColumn();
                address.ColumnName = "address";
                dt.Columns.Add("address");
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["house_id"] != null && !DBNull.Value.Equals(dr["house_id"]))
                        dr["address"] = new HouseDAO(db).getAddressById(Convert.ToInt32(dr["house_id"])).fullAddress;
                }
            }
            return dt;
        }

        public Exempt getExemptById(int id)
        {
            Select query = new Select()
                .From("EXEMPT")
                .Where("id = " + id);
            Exempt e = new Exempt(db.FetchOneRow(query));
            if (e.houseId != null)
                e.house = new HouseDAO(db).getAddressById(e.houseId.Value);
            return e;
        }

        public void updateExempt(Exempt exempt)
        {
            db.Update("EXEMPT", exempt.getParametersCollection(), "id = " + exempt.id);
        }
    }
}
