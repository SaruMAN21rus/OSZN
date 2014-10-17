using DatabaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSZN.Model
{
    class VocService
    {
        public int? id { get; set; }
        public int code { get; set; }
        public string name { get; set; }
        public string unit { get; set; }
        private string codeName;

        private bool active = true;

        public bool Active
        {
            get
            {
                return active;
            }
            set
            {
                active = value;
            }
        }

        public string CodeName
        {
            get
            {
                return codeName;
            }
            set
            {
                codeName = value;
            }
        }

        public VocService() { }

        public VocService(Dictionary<string, object> dict)
        {
            if (dict != null && dict.Count > 0)
            {
                if (dict.ContainsKey("id"))
                    id = Convert.ToInt32(dict["id"]);
                if (dict.ContainsKey("code"))
                    code = Convert.ToInt32(dict["code"]);
                if (dict.ContainsKey("name"))
                    name = dict["name"].ToString();
                if (dict.ContainsKey("unit"))
                    unit = dict["unit"].ToString();
                if (dict.ContainsKey("active"))
                    active = Convert.ToBoolean(dict["active"]);
                codeName = code + " - " + name;
            }
        }

        public ParametersCollection getParametersCollection()
        {
            ParametersCollection parameters = new ParametersCollection();
            if (id != null)
                parameters.Add("id", id, System.Data.DbType.Int32);
            parameters.Add("code", code, System.Data.DbType.Int32);
            parameters.Add("name", name, System.Data.DbType.String);
            parameters.Add("unit", unit, System.Data.DbType.String);
            parameters.Add("active", active, System.Data.DbType.Boolean);
            return parameters;
        }
    }
}
