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
    class ExemptServiceDetailDAO : CommonDAO
    {
        public DataTable getExemptServiceDetailsByExemptServiceId(int exemptServiceId)
        {
            Select query = new Select()
                .From("exempt_service_detail as esd")
                .Join("voc_service as vs", "esd.voc_service_id = vs.id", SQLJoinTypes.LEFT_JOIN)
                .Join("voc_unit as vu1", "vs.unit_id = vu1.id", SQLJoinTypes.LEFT_JOIN)
                .Join("voc_unit as vu2", "vs.norm_base_unit_id = vu2.id", SQLJoinTypes.LEFT_JOIN)
                .Where("exempt_service_id = " + exemptServiceId);
            DataTable dt = db.Execute(query);
            if (dt != null)
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = "serviceName";
                dc.Expression = "name + ', ' + ISNULL(name1, '')";
                dt.Columns.Add(dc);
            }
            return dt;
        }

        public int insertExemptServiceDetail(ExemptServiceDetail exemptServiceDetail)
        {
            return db.Insert("exempt_service_detail", exemptServiceDetail.getParametersCollection());
        }

        public void updateExemptServiceDetail(ExemptServiceDetail exemptServiceDetail)
        {
            db.Update("exempt_service_detail", exemptServiceDetail.getParametersCollection(), "id = " + exemptServiceDetail.id);
        }

        public ExemptServiceDetail getExemptServiceById(int exemptServiceDetailId)
        {
            Select query = new Select()
                .From("exempt_service_detail")
                .Where("id = " + exemptServiceDetailId);
            return new ExemptServiceDetail(db.FetchOneRow(query));
        }

        public void deleteExemptServiceDetail(int id)
        {
            db.Delete("exempt_service_detail", "id = " + id);
        }
    }
}
