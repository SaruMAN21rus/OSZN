using DatabaseLib;
using OSZN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSZN
{
    public class Exempt
    {
        public int? id { get; set; }
        public DateTime createDate { get; set; }
        public string personalAccount { get; set; }
        public string lastName { get; set; }
        public string name { get; set; }
        public string middleName { get; set; }
        public DateTime? birthDate { get; set; }
        public string sex { get; set; }
        public string SNILS { get; set; }
        public string documentName { get; set; }
        public string documentSeries { get; set; }
        public string documentNumber { get; set; }
        public DateTime? documentDate { get; set; }
        public string documentIssuer { get; set; }
        public int? houseId { get; set; }
        public House house { get; set; }
        public bool loaded { get; set; }
        private bool hasFamilyComposition = true;

        public bool HasFamilyComposition
        {
            get
            {
                return hasFamilyComposition;
            }
            set
            {
                hasFamilyComposition = value;
            }
        }

        public Exempt() { }

        public Exempt(Dictionary<string, object> dict)
        {
            if (dict != null && dict.Count > 0)
            {
                if (dict.ContainsKey("ID"))
                    id = Convert.ToInt32(dict["ID"]);
                if (dict.ContainsKey("create_date"))
                    createDate = Convert.ToDateTime(dict["create_date"]);
                if (dict.ContainsKey("personal_account"))
                    personalAccount = dict["personal_account"].ToString();
                if (dict.ContainsKey("last_name"))
                    lastName = dict["last_name"].ToString();
                if (dict.ContainsKey("name"))
                    name = dict["name"].ToString();
                if (dict.ContainsKey("middle_name"))
                    middleName = dict["middle_name"].ToString();
                if (dict.ContainsKey("birth_date") && !DBNull.Value.Equals(dict["birth_date"]))
                    birthDate = Convert.ToDateTime(dict["birth_date"]);
                if (dict.ContainsKey("sex"))
                    sex = dict["sex"].ToString();
                if (dict.ContainsKey("SNILS"))
                    SNILS = dict["SNILS"].ToString();
                if (dict.ContainsKey("document_name"))
                    documentName = dict["document_name"].ToString();
                if (dict.ContainsKey("document_series"))
                    documentSeries = dict["document_series"].ToString();
                if (dict.ContainsKey("document_number"))
                    documentNumber = dict["document_number"].ToString();
                if (dict.ContainsKey("document_date") && !DBNull.Value.Equals(dict["document_date"]))
                    documentDate = Convert.ToDateTime(dict["document_date"]);
                if (dict.ContainsKey("document_issuer"))
                    documentIssuer = dict["document_issuer"].ToString();
                if (dict.ContainsKey("house_id") && !DBNull.Value.Equals(dict["house_id"]))
                    houseId = Convert.ToInt32(dict["house_id"]);
                if (dict.ContainsKey("loaded"))
                    loaded = Convert.ToBoolean(dict["loaded"]);
                if (dict.ContainsKey("has_family_composition"))
                    hasFamilyComposition = Convert.ToBoolean(dict["has_family_composition"]);
            }
        }

        public ParametersCollection getParametersCollection()
        {
            ParametersCollection parameters = new ParametersCollection();
            if (id != null)
                parameters.Add("id", id, System.Data.DbType.Int32);
            parameters.Add("create_date", createDate, System.Data.DbType.Date);
            parameters.Add("personal_account", personalAccount, System.Data.DbType.String);
            parameters.Add("last_name", lastName, System.Data.DbType.String);
            parameters.Add("name", name, System.Data.DbType.String);
            parameters.Add("middle_name", middleName, System.Data.DbType.String);
            parameters.Add("birth_date", birthDate, System.Data.DbType.Date);
            parameters.Add("sex", sex, System.Data.DbType.String);
            parameters.Add("SNILS", SNILS, System.Data.DbType.String);
            parameters.Add("document_name", documentName, System.Data.DbType.String);
            parameters.Add("document_series", documentSeries, System.Data.DbType.String);
            parameters.Add("document_number", documentNumber, System.Data.DbType.String);
            parameters.Add("document_date", documentDate, System.Data.DbType.Date);
            parameters.Add("document_issuer", documentIssuer, System.Data.DbType.String);
            parameters.Add("house_id", houseId, System.Data.DbType.Int32);
            parameters.Add("loaded", loaded, System.Data.DbType.Boolean);
            parameters.Add("has_family_composition", hasFamilyComposition, System.Data.DbType.Boolean);
            return parameters;
        }
    }
}
