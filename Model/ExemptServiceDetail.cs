using DatabaseLib;
using OSZN.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSZN.Model
{
    class ExemptServiceDetail
    {
        public int? id { get; set; }
        public int? vocServiceId { get; set; }
        private VocService vocService;
        public VocService VocService {
            get
            {
                if (vocServiceId != null)
                {
                    if (vocService == null || vocService.id != vocServiceId)
                    {
                        VocServiceDAO vsDAO = new VocServiceDAO();
                        vocService = vsDAO.getVocServiceById(vocServiceId.Value);
                    }
                }
                else
                {
                    vocService = null;
                }
                return vocService;
            }
            set
            {
                vocService = value;
            }
        }
        public decimal? rate { get; set; }
        public decimal? norm { get; set; }
        public decimal? volume { get; set; }
        public string parameter { get; set; }
        public decimal? accruedAmount { get; set; }
        public decimal? penaltiesAmount { get; set; }
        public decimal? paidAmount { get; set; }
        public decimal? recalculatedAmount { get; set; }
        public DateTime? recalculateStartDate { get; set; }
        public DateTime? recalculateEndDate { get; set; }
        public int? exemptServiceId { get; set; }
        public ExemptService exemptService { get; set; }

        public ExemptServiceDetail() { }

        public ExemptServiceDetail(Dictionary<string, object> dict)
        {
            if (dict != null && dict.Count > 0)
            {
                if (dict.ContainsKey("id"))
                    id = Convert.ToInt32(dict["id"]);
                if (dict.ContainsKey("voc_service_id"))
                    vocServiceId = Convert.ToInt32(dict["voc_service_id"]);
                if (dict.ContainsKey("rate") && !DBNull.Value.Equals(dict["rate"]))
                    rate = Convert.ToDecimal(dict["rate"]);
                if (dict.ContainsKey("norm") && !DBNull.Value.Equals(dict["norm"]))
                    norm = Convert.ToDecimal(dict["norm"]);
                if (dict.ContainsKey("service_volume") && !DBNull.Value.Equals(dict["service_volume"]))
                    volume = Convert.ToDecimal(dict["service_volume"]);
                if (dict.ContainsKey("parameter"))
                    parameter = dict["parameter"].ToString();
                if (dict.ContainsKey("accrued_amount") && !DBNull.Value.Equals(dict["accrued_amount"]))
                    accruedAmount = Convert.ToDecimal(dict["accrued_amount"]);
                if (dict.ContainsKey("penalties_amount") && !DBNull.Value.Equals(dict["penalties_amount"]))
                    penaltiesAmount = Convert.ToDecimal(dict["penalties_amount"]);
                if (dict.ContainsKey("paid_amount") && !DBNull.Value.Equals(dict["paid_amount"]))
                    paidAmount = Convert.ToDecimal(dict["paid_amount"]);
                if (dict.ContainsKey("recalculated_amount") && !DBNull.Value.Equals(dict["recalculated_amount"]))
                    recalculatedAmount = Convert.ToDecimal(dict["recalculated_amount"]);
                if (dict.ContainsKey("recalculate_start_date") && !DBNull.Value.Equals(dict["recalculate_start_date"]))
                    recalculateStartDate = Convert.ToDateTime(dict["recalculate_start_date"]);
                if (dict.ContainsKey("recalculate_end_date") && !DBNull.Value.Equals(dict["recalculate_end_date"]))
                    recalculateEndDate = Convert.ToDateTime(dict["recalculate_end_date"]);
                if (dict.ContainsKey("exempt_service_id"))
                    exemptServiceId = Convert.ToInt32(dict["exempt_service_id"]);
            }
        }

        public ParametersCollection getParametersCollection()
        {
            ParametersCollection parameters = new ParametersCollection();
            if (id != null)
                parameters.Add("id", id, System.Data.DbType.Int32);
            parameters.Add("voc_service_id", vocServiceId, System.Data.DbType.Int32);
            parameters.Add("rate", rate, System.Data.DbType.Decimal);
            parameters.Add("norm", norm, System.Data.DbType.Decimal);
            parameters.Add("service_volume", volume, System.Data.DbType.Decimal);
            parameters.Add("parameter", parameter, System.Data.DbType.String);
            parameters.Add("accrued_amount", accruedAmount, System.Data.DbType.Decimal);
            parameters.Add("penalties_amount", penaltiesAmount, System.Data.DbType.Decimal);
            parameters.Add("paid_amount", paidAmount, System.Data.DbType.Decimal);
            parameters.Add("recalculated_amount", recalculatedAmount, System.Data.DbType.Decimal);
            parameters.Add("recalculate_start_date", recalculateStartDate, System.Data.DbType.Date);
            parameters.Add("recalculate_end_date", recalculateEndDate, System.Data.DbType.Date);
            parameters.Add("exempt_service_id", exemptServiceId, System.Data.DbType.Int32);
            return parameters;
        }
    }
}
