using DatabaseLib;
using OSZN.DAO;
using OSZN.Model;
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
        public bool isOwner { get; set; }
        public decimal? totalArea { get; set; }
        public decimal? livingArea { get; set; }
        public int? residentsCount { get; set; }
        public int? roomsCount { get; set; }
        public int? familyMembersCount { get; set; }
        public int? exemtId { get; set; }
        private Exempt exempt;
        public Exempt Exempt
        {
            get
            {
                if (exemtId != null)
                {
                    if (exempt == null || exempt.id != exemtId)
                    {
                        ExemptDAO eDAO = new ExemptDAO();
                        exempt = eDAO.getExemptById(exemtId.Value);
                    }
                }
                else
                {
                    exempt = null;
                }
                return exempt;
            }
            set
            {
                exempt = value;
            }
        }
        public decimal? landSize { get; set; }
        public int? vocHousingTypeId { get; set; }
        private VocHousingType vocHousingType;
        public VocHousingType VocHousingType
        {
            get
            {
                if (vocHousingTypeId != null)
                {
                    if (vocHousingType == null || vocHousingType.id != vocHousingTypeId)
                    {
                        VocHousingTypeDAO vhtDAO = new VocHousingTypeDAO();
                        vocHousingType = vhtDAO.getVocHousingTypeById(vocHousingTypeId.Value);
                    }
                }
                else
                {
                    vocHousingType = null;
                }
                return vocHousingType;
            }
            set
            {
                VocHousingType = value;
            }
        }

        public ExemptHouseroom() { }

        public ExemptHouseroom(Dictionary<string, object> dict)
        {
            if (dict != null && dict.Count > 0)
            {
                if (dict.ContainsKey("id"))
                    id = Convert.ToInt32(dict["id"]);
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
                if (dict.ContainsKey("land_size") && !DBNull.Value.Equals(dict["land_size"]))
                    landSize = Convert.ToDecimal(dict["land_size"]);
                if (dict.ContainsKey("voc_housing_type_id") && !DBNull.Value.Equals(dict["voc_housing_type_id"]))
                    vocHousingTypeId = Convert.ToInt32(dict["voc_housing_type_id"]);
            }
        }

        public ParametersCollection getParametersCollection()
        {
            ParametersCollection parameters = new ParametersCollection();
            if (id != null)
                parameters.Add("id", id, System.Data.DbType.Int32);
            parameters.Add("is_owner", isOwner, System.Data.DbType.Boolean);
            parameters.Add("total_area", totalArea, System.Data.DbType.Decimal);
            parameters.Add("living_area", livingArea, System.Data.DbType.Decimal);
            parameters.Add("residents_count", residentsCount, System.Data.DbType.Int32);
            parameters.Add("rooms_count", roomsCount, System.Data.DbType.Int32);
            parameters.Add("family_members_count", familyMembersCount, System.Data.DbType.Int32);
            parameters.Add("exempt_id", exemtId, System.Data.DbType.Int32);
            parameters.Add("land_size", landSize, System.Data.DbType.Decimal);
            parameters.Add("voc_housing_type_id", vocHousingTypeId, System.Data.DbType.Int32);
            return parameters;
        }
    }
}
