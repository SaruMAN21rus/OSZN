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
                .Where("exempt_service_id = " + exemptServiceId);
            DataTable dt = db.Execute(query);
            if (dt != null)
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = "serviceName";
                dc.Expression = "code + ' - ' + ISNULL(name, '')";
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
            ExemptServiceDetail esd =  new ExemptServiceDetail(db.FetchOneRow(query));
            if (esd.vocServiceId != null)
                esd.vocService = new VocServiceDAO(db).getVocServiceById(esd.vocServiceId.Value);
            return esd;
        }

        public void deleteExemptServiceDetail(int id)
        {
            db.Delete("exempt_service_detail", "id = " + id);
        }
    }
}
