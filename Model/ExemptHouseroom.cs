using DatabaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSZN
{
    class ExemptHouseroom
    {
        public int? id { get; set; }
        public string propertyType { get; set; }
        public bool isOwner { get; set; }
        public decimal? totalArea { get; set; }
        public decimal? livingArea { get; set; }
        public int? residentsCount { get; set; }
        public int? roomsCount { get; set; }
        public int? familyMembersCount { get; set; }
        public int? exemtId { get; set; }
        public Exempt exempt { get; set; }

        public ExemptHouseroom() { }

        public ExemptHouseroom(Dictionary<string, object> dict)
        {
            if (dict != null && dict.Count > 0)
            {
                if (dict.ContainsKey("ID"))
                    id = Convert.ToInt32(dict["ID"]);
                if (dict.ContainsKey("property_type"))
                    propertyType = dict["property_type"].ToString();
                if (dict.ContainsKey("is_owner"))
                    isOwner = Convert.ToBoolean(dict["is_owner"]);
                if (dict.ContainsKey("total_area") && !DBNull.Value.Equals(dict["total_area"]))
                    totalArea = Convert.ToDecimal(dict["total_area"]);
                if (dict.ContainsKey("living_area") && !DBNull.Value.Equals(dict["living_area"]))
                    livingArea = Convert.ToDecimal(dict["living_area"]);
                if (dict.ContainsKey("residents_count") && !DBNull.Value.Equals(dict["residents_count"]))
                    residentsCount = Convert.ToInt32(dict["residents_count"]);
                if (dict.ContainsKey("rooms_count") && !DBNull.Value.Equals(dict["rooms_count"]))
                    roomsCount = Convert.ToInt32(dict["rooms_count"]);
                if (dict.ContainsKey("family_members_count") && !DBNull.Value.Equals(dict["family_members_count"]))
                    familyMembersCount = Convert.ToInt32(dict["family_members_count"]);
                if (dict.ContainsKey("exempt_id"))
                    exemtId = Convert.ToInt32(dict["exempt_id"]);
            }
        }

        public ParametersCollection getParametersCollection()
        {
            ParametersCollection parameters = new ParametersCollection();
            if (id != null)
                parameters.Add("id", id, System.Data.DbType.Int32);
            parameters.Add("property_type", propertyType, System.Data.DbType.String);
            parameters.Add("is_owner", isOwner, System.Data.DbType.Boolean);
            parameters.Add("total_area", totalArea, System.Data.DbType.Decimal);
            parameters.Add("living_area", livingArea, System.Data.DbType.Decimal);
            parameters.Add("residents_count", residentsCount, System.Data.DbType.Int32);
            parameters.Add("rooms_count", roomsCount, System.Data.DbType.Int32);
            parameters.Add("family_members_count", familyMembersCount, System.Data.DbType.Int32);
            parameters.Add("exempt_id", exemtId, System.Data.DbType.Int32);
            return parameters;
        }
    }
}
