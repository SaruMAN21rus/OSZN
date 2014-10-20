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
    class LoadLogDAO : CommonDAO
    {
        public int insertLog(LoadLog loadLog)
        {
            return db.Insert("load_log", loadLog.getParametersCollection());
        }

        public DataTable getLogs()
        {
            Select select = new Select()
                .From("load_log");
            DataTable dt = db.Execute(select);
            if (dt != null)
            {
                DataColumn requestPeriod = new DataColumn();
                requestPeriod.ColumnName = "request_period";
                requestPeriod.Expression = "ISNULL(request_period_start_date, '') + ' - ' + ISNULL(request_period_end_date, '')";
                dt.Columns.Add(requestPeriod);
            }
            return dt;
        }
    }
}
