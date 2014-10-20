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
    class ExemptServiceDAO : CommonDAO
    {
        public DataTable getExemptServicesByExemptIdAndYear(int exemptId, int year)
        {
            Select query = new Select()
                .From("exempt_service")
                .Where("exempt_id = " + exemptId + " and strftime('%Y', period) = '" + year + "'");
            return db.Execute(query);
        }

        public void insertExemptServicesByYear(int exemptId, int year)
        {
            db.BeginTransaction();
            for (int i = 1; i <= 12; i++)
            {
                ExemptService es = new ExemptService();
                es.period = new DateTime(year, i, 1);
                es.exemptId = exemptId;
                db.Insert("exempt_service", es.getParametersCollection());
            }
            db.CommitTransaction();
        }

        public void updateExemptServices(ExemptService exemptServices)
        {
            db.Update("exempt_service", exemptServices.getParametersCollection(), "id = " + exemptServices.id);
        }

        public ExemptService getExemptServiceById(int serviceId)
        {
            Select query = new Select()
                .From("exempt_service")
                .Where("id = " + serviceId);
            return new ExemptService(db.FetchOneRow(query));
        }

        public ExemptService getExemptServiceByPeriodAndExemptId(DateTime period, int exemptId)
        {
            Select query = new Select()
                .From("exempt_service")
                .Where("exempt_id = " + exemptId + " and period = '" + period.ToString("yyyy-MM-dd HH:mm:ss") + "'");
            return new ExemptService(db.FetchOneRow(query));
        }
    }
}
