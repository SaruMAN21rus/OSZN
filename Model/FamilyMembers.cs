using DatabaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSZN.Model
{
    class FamilyMember
    {
        public int? id { get; set; }
        public string lastName { get; set; }
        public string name { get; set; }
        public string middleName { get; set; }
        public DateTime birthDate { get; set; }
        public string sex { get; set; }
        public bool isOwner { get; set; }
        public int? exemptId { get; set; }
        public Exempt exempt { get; set; }
        public int? relationshipDegreeId { get; set; }
        public RelationshipDegree relationshipDegree { get; set; }

        public FamilyMember() { }

        public FamilyMember(Dictionary<string, object> dict)
        {
            if (dict != null && dict.Count > 0)
            {
                if (dict.ContainsKey("id"))
                    id = Convert.ToInt32(dict["id"]);
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
                if (dict.ContainsKey("is_owner"))
                    isOwner = Convert.ToBoolean(dict["is_owner"]);
                if (dict.ContainsKey("exempt_id"))
                    exemptId = Convert.ToInt32(dict["exempt_id"]);
                if (dict.ContainsKey("relationship_degree_id") && !DBNull.Value.Equals(dict["relationship_degree_id"]))
                    relationshipDegreeId = Convert.ToInt32(dict["relationship_degree_id"]);
            }
        }

        public ParametersCollection getParametersCollection()
        {
            ParametersCollection parameters = new ParametersCollection();
            if (id != null)
                parameters.Add("id", id, System.Data.DbType.Int32);
            parameters.Add("last_name", lastName, System.Data.DbType.String);
            parameters.Add("name", name, System.Data.DbType.String);
            parameters.Add("middle_name", middleName, System.Data.DbType.String);
            parameters.Add("birth_date", birthDate, System.Data.DbType.Date);
            parameters.Add("sex", sex, System.Data.DbType.String);
            parameters.Add("is_owner", isOwner, System.Data.DbType.Boolean);
            parameters.Add("exempt_id", exemptId, System.Data.DbType.Int32);
            parameters.Add("relationship_degree_id", relationshipDegreeId, System.Data.DbType.Int32);
            return parameters;
        }
    }
}
