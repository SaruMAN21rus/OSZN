using DatabaseLib;
using OSZN.DAO;
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
        public string direction { get; set; }
        public int? unitId { get; set; }
        private VocUnit unit;
        public VocUnit Unit
        {
            get
            {
                if (unitId != null)
                {
                    if (unit == null || unit.id != unitId)
                    {
                        VocUnitDAO vuDAO = new VocUnitDAO();
                        unit = vuDAO.getVocUnitById(unitId.Value);
                    }
                }
                else
                {
                    unit = null;
                }
                return unit;
            }
            set
            {
                unit = value;
            }
        }
        public int? normBaseUnitId { get; set; }
        private VocUnit normBaseUnit;
        public VocUnit NormBaseUnit
        {
            get
            {
                if (normBaseUnitId != null)
                {
                    if (normBaseUnit == null || normBaseUnit.id != normBaseUnitId)
                    {
                        VocUnitDAO vuDAO = new VocUnitDAO();
                        normBaseUnit = vuDAO.getVocUnitById(normBaseUnitId.Value);
                    }
                }
                else
                {
                    normBaseUnit = null;
                }
                return normBaseUnit;
            }
            set
            {
                normBaseUnit = value;
            }
        }
        private string nameWithUnit;

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

        public string NameWithUnit
        {
            get
            {
                return nameWithUnit;
            }
            set
            {
                nameWithUnit = value;
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
                if (dict.ContainsKey("direction"))
                    direction = dict["direction"].ToString();
                if (dict.ContainsKey("unit_id") && !DBNull.Value.Equals(dict["unit_id"]))
                    unitId =  Convert.ToInt32(dict["unit_id"]);
                if (dict.ContainsKey("norm_base_unit_id") && !DBNull.Value.Equals(dict["norm_base_unit_id"]))
                    normBaseUnitId = Convert.ToInt32(dict["norm_base_unit_id"]);
                if (dict.ContainsKey("active"))
                    active = Convert.ToBoolean(dict["active"]);
                nameWithUnit = name + (Unit != null ? ", " + Unit.name : "");
            }
        }

        public ParametersCollection getParametersCollection()
        {
            ParametersCollection parameters = new ParametersCollection();
            if (id != null)
                parameters.Add("id", id, System.Data.DbType.Int32);
            parameters.Add("code", code, System.Data.DbType.Int32);
            parameters.Add("name", name, System.Data.DbType.String);
            parameters.Add("direction", direction, System.Data.DbType.String);
            parameters.Add("unit_id", unitId, System.Data.DbType.Int32);
            parameters.Add("norm_base_unit_id", normBaseUnitId, System.Data.DbType.Int32);
            parameters.Add("active", active, System.Data.DbType.Boolean);
            return parameters;
        }
    }
}
