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
                requestPeriod.Expression = "IIF(request_period_start_date is null, '', SubString(Convert(request_period_start_date,'System.String'),1,10)) + ' - ' + IIF(request_period_end_date is null, '', SubString(Convert(request_period_end_date,'System.String'),1,10))";
                dt.Columns.Add(requestPeriod);
            }
            return dt;
        }
    }
}
