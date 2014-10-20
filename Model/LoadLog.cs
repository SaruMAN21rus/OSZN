using DatabaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSZN.Model
{
    class LoadLog
    {
        public int? id { get; set; }
        public string fileName { get; set; }
        public DateTime requestPeriodStartDate { get; set; }
        public DateTime requestPeriodEndDate { get; set; }
        public DateTime loadDate { get; set; }
        public string status { get; set; }
        public string errorText { get; set; }
        public string errorFullTrace { get; set; }
        public string loadFolder { get; set; }

        public ParametersCollection getParametersCollection()
        {
            ParametersCollection parameters = new ParametersCollection();
            if (id != null)
                parameters.Add("id", id, System.Data.DbType.Int32);
            parameters.Add("file_name", fileName, System.Data.DbType.String);
            parameters.Add("request_period_start_date", requestPeriodStartDate, System.Data.DbType.Date);
            parameters.Add("request_period_end_date", requestPeriodEndDate, System.Data.DbType.Date);
            parameters.Add("load_date", loadDate, System.Data.DbType.Date);
            parameters.Add("status", status, System.Data.DbType.String);
            parameters.Add("error_text", errorText, System.Data.DbType.String);
            parameters.Add("error_full_trace", errorFullTrace, System.Data.DbType.String);
            parameters.Add("load_folder", loadFolder, System.Data.DbType.String);
            return parameters;
        }
    }
}
