using DatabaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSZN.Model
{
    class ExemptService
    {
        public int? id { get; set; }
        public DateTime period { get; set; }
        public decimal? paymentAmount { get; set; }
        public decimal? penaltiesAmount { get; set; }
        public decimal? debtAmount { get; set; }
        public int? debtMonthCount { get; set; }
        public decimal? paymentDebtAmount { get; set; }
        public int? exemptId { get; set; }
        public Exempt exempt { get; set; }

        public ExemptService() { }

        public ExemptService(Dictionary<string, object> dict)
        {
            if (dict != null && dict.Count > 0)
            {
                if (dict.ContainsKey("id"))
                    id = Convert.ToInt32(dict["id"]);
                if (dict.ContainsKey("period") && !DBNull.Value.Equals(dict["period"]))
                    period = Convert.ToDateTime(dict["period"]);
                if (dict.ContainsKey("payment_amount") && !DBNull.Value.Equals(dict["payment_amount"]))
                    paymentAmount = Convert.ToDecimal(dict["payment_amount"]);
                if (dict.ContainsKey("penalties_amount") && !DBNull.Value.Equals(dict["penalties_amount"]))
                    penaltiesAmount = Convert.ToDecimal(dict["penalties_amount"]);
                if (dict.ContainsKey("debt_amount") && !DBNull.Value.Equals(dict["debt_amount"]))
                    debtAmount = Convert.ToDecimal(dict["debt_amount"]);
                if (dict.ContainsKey("debt_month_count") && !DBNull.Value.Equals(dict["debt_month_count"]))
                    debtMonthCount = Convert.ToInt32(dict["debt_month_count"]);
                if (dict.ContainsKey("payment_debt_amount") && !DBNull.Value.Equals(dict["payment_debt_amount"]))
                    paymentDebtAmount = Convert.ToDecimal(dict["payment_debt_amount"]);
                if (dict.ContainsKey("exempt_id"))
                    exemptId = Convert.ToInt32(dict["exempt_id"]);
            }
        }

        public ParametersCollection getParametersCollection()
        {
            ParametersCollection parameters = new ParametersCollection();
            if (id != null)
                parameters.Add("id", id, System.Data.DbType.Int32);
            parameters.Add("period", period, System.Data.DbType.Date);
            parameters.Add("payment_amount", paymentAmount, System.Data.DbType.Decimal);
            parameters.Add("penalties_amount", penaltiesAmount, System.Data.DbType.Decimal);
            parameters.Add("debt_amount", debtAmount, System.Data.DbType.Decimal);
            parameters.Add("debt_month_count", debtMonthCount, System.Data.DbType.Int32);
            parameters.Add("payment_debt_amount", paymentDebtAmount, System.Data.DbType.Decimal);
            parameters.Add("exempt_id", exemptId, System.Data.DbType.Int32);
            return parameters;
        }
    }
}
