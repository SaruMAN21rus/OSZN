﻿using DatabaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSZN.Model
{
    class VocUnit
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

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

        public VocUnit() { }

        public VocUnit(Dictionary<string, object> dict)
        {
            if (dict != null && dict.Count > 0)
            {
                if (dict.ContainsKey("id"))
                    id = Convert.ToInt32(dict["id"]);
                if (dict.ContainsKey("name"))
                    name = dict["name"].ToString();
                if (dict.ContainsKey("active"))
                    active = Convert.ToBoolean(dict["active"]);
                if (dict.ContainsKey("description"))
                    description = dict["description"].ToString(); ;
            }
        }

        public ParametersCollection getParametersCollection()
        {
            ParametersCollection parameters = new ParametersCollection();
            if (id != null)
                parameters.Add("id", id, System.Data.DbType.Int32);
            parameters.Add("name", name, System.Data.DbType.String);
            parameters.Add("active", active, System.Data.DbType.Boolean);
            parameters.Add("description", description, System.Data.DbType.String);
            return parameters;
        }
    }
}
