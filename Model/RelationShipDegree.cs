﻿using DatabaseLib;
using System;
using System.Collections.Generic;

namespace OSZN.Model
{
    class RelationshipDegree
    {
        public int? id { get; set; }
        public string name { get; set; }

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

        public RelationshipDegree() { }

        public RelationshipDegree(Dictionary<string, object> dict)
        {
            if (dict != null && dict.Count > 0)
            {
                if (dict.ContainsKey("id"))
                    id = Convert.ToInt32(dict["id"]);
                if (dict.ContainsKey("name"))
                    name = dict["name"].ToString();
                if (dict.ContainsKey("active"))
                    active = Convert.ToBoolean(dict["active"]);
            }
        }

        public ParametersCollection getParametersCollection()
        {
            ParametersCollection parameters = new ParametersCollection();
            if (id != null)
                parameters.Add("id", id, System.Data.DbType.Int32);
            parameters.Add("name", name, System.Data.DbType.String);
            parameters.Add("active", active, System.Data.DbType.Boolean);
            return parameters;
        }
    }
}
