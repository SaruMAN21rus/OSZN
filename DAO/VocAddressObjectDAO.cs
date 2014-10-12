using DatabaseLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSZN.DAO
{
    class VocAddressObjectDAO : CommonDAO
    {
        public DataTable getTreeRootNode()
        {
            return db.Execute("select ao.AOGUID, ao.FORMALNAME, at.SCNAME "
                + "from VOC_ADDRESS_OBJECT ao "
                + "left join VOC_ADDRESS_TYPE at on ao.AOLEVEL = at.LEVEL and ao.SHORTNAME = at.SOCRNAME "
                + "where ao.CURRSTATUS = 0 and ao.PARENTGUID is null");
        }

        public DataTable getTreeChildNode(string parentNodeId)
        {
            return db.Execute("select ao.AOGUID, ao.FORMALNAME, CASE WHEN at.SCNAME is null THEN ao.SHORTNAME ELSE at.SCNAME END, "
                + "CASE WHEN ao.AOLEVEL <> 7 THEN (select count(*) from VOC_ADDRESS_OBJECT ao2 where ao2.CURRSTATUS = 0 AND ao2.PARENTGUID = ao.AOGUID) ELSE 0 END as CHILDCOUNT "
                + "from VOC_ADDRESS_OBJECT ao "
                + "left join VOC_ADDRESS_TYPE at on ao.AOLEVEL = at.LEVEL and ao.SHORTNAME = at.SOCRNAME "
                + "where ao.CURRSTATUS = 0 and ao.PARENTGUID = '" + parentNodeId + "'"
                + "order by CODE ASC");
        }

        public DataTable getTableData(string parentNodeId, string searchText)
        {
            string query = "select ao.AOGUID, ao.FORMALNAME, CASE WHEN at.SCNAME is null THEN ao.SHORTNAME ELSE at.SCNAME END as TYPE, ao.CODE "
                + "from VOC_ADDRESS_OBJECT ao "
                + "left join VOC_ADDRESS_TYPE at on ao.AOLEVEL = at.LEVEL and ao.SHORTNAME = at.SOCRNAME "
                + "where ao.CURRSTATUS = 0 and ao.PARENTGUID = '" + parentNodeId + "' ";
            if (!String.IsNullOrEmpty(searchText))
            {
                query += "and (lower(ao.FORMALNAME) LIKE ('%" + searchText.ToLower() + "%') or lower(at.SCNAME) LIKE ('%" + searchText.ToLower() + "%') or ao.CODE LIKE ('%" + searchText + "%')) ";
            }
            query += "order by PLAINCODE ASC";
            return db.Execute(query);
        }

        public void insertAddress(string name, int level, string typeBrief, string code, string parentAddressGuid)
        {
            int codeLength = code.Length;
            int maxId = Convert.ToInt32(db.Execute("select max(id) from VOC_ADDRESS_OBJECT").Rows[0][0]) + 1;
            
            ParametersCollection parameters = new ParametersCollection();
            parameters.Add("aoguid", maxId, System.Data.DbType.String);
            parameters.Add("formalname", name, System.Data.DbType.String);
            parameters.Add("regioncode", "21", System.Data.DbType.String);
            parameters.Add("autocode", "", System.Data.DbType.String);
            parameters.Add("areacode", code.Substring(2, 3), System.Data.DbType.String);
            parameters.Add("citycode", code.Substring(5, 3), System.Data.DbType.String);
            parameters.Add("ctarcode", "000", System.Data.DbType.String);
            parameters.Add("placecode", code.Substring(8, 3), System.Data.DbType.String);
            if (codeLength == 17)
            {
                parameters.Add("streetcode", code.Substring(11, 4), System.Data.DbType.String);
            }
            else
            {
                parameters.Add("streetcode", "0000", System.Data.DbType.String);
            }
            parameters.Add("extrcode", "0000", System.Data.DbType.String);
            parameters.Add("sextcode", "000", System.Data.DbType.String);
            parameters.Add("offname", name, System.Data.DbType.String);
            parameters.Add("updatedate", DateTime.Now, System.Data.DbType.Date);
            parameters.Add("shortname", typeBrief, System.Data.DbType.String);
            parameters.Add("aolevel", level, System.Data.DbType.Int32);
            parameters.Add("parentguid", parentAddressGuid, System.Data.DbType.String);
            parameters.Add("aoid", maxId, System.Data.DbType.String);
            parameters.Add("code", code, System.Data.DbType.String);
            parameters.Add("plaincode", code.Substring(0, codeLength - 2), System.Data.DbType.String);
            parameters.Add("actstatus", 1, System.Data.DbType.Int32);
            parameters.Add("centstatus", 0, System.Data.DbType.Int32);
            parameters.Add("operstatus", 10, System.Data.DbType.Int32);
            parameters.Add("currstatus", code.Substring(codeLength - 2, 2), System.Data.DbType.Int32);
            parameters.Add("startdate", DateTime.Now, System.Data.DbType.Date);
            parameters.Add("enddate", DateTime.Parse("2079-06-06"), System.Data.DbType.Date);
            parameters.Add("livestatus", 1, System.Data.DbType.Int32);
            db.Insert("VOC_ADDRESS_OBJECT", parameters);
        }

        public Dictionary<string, object> getAddressByAOGUID(string aoguid)
        {
            return db.FetchOneRow("select ao.FORMALNAME, ao.SHORTNAME, ao.CODE, l.NAME, ao.ID, l.ID as levelId "
                + "from VOC_ADDRESS_OBJECT ao "
                + "left join VOC_LEVEL l on ao.AOLEVEL = l.ID "
                + "where CURRSTATUS = 0 and ao.AOGUID = '" + aoguid + "'");
        }

        public int getAddressObjectsUpdateLastVersion()
        {
            return Convert.ToInt32(db.FetchOneRow("select max(VERSION) as maxVersion from FIAS_UPDATE_VERSION")["maxVersion"]);
        }

        public void insertOrUpdateAddressObjects(ParametersCollection parameters, string aoid)
        {
            DataTable dt = db.FetchByColumn("VOC_ADDRESS_OBJECT", "AOID", "AOID = '" + aoid + "'");
            if (dt != null && dt.Rows.Count > 0)
            {
                db.Update("VOC_ADDRESS_OBJECT", parameters, "AOID = '" + aoid + "'");
            }
            else
            {
                db.Insert("VOC_ADDRESS_OBJECT", parameters);
            }
        }

        public void insertUpdateVersion(int version)
        {
            ParametersCollection parameter = new ParametersCollection();
            parameter.Add("version", version, System.Data.DbType.Int32);
            parameter.Add("update_date", DateTime.Now, System.Data.DbType.Date);
            db.Insert("FIAS_UPDATE_VERSION", parameter);
        }

        public void deleteAddressObject(int id)
        {
            ParametersCollection parameter = new ParametersCollection();
            parameter.Add("currstatus", 1, System.Data.DbType.Int32);
            db.Update("VOC_ADDRESS_OBJECT", parameter, "id = " + id);
        }

        public DataTable getCityAndArea()
        {
            Select select = new Select()
                .From("VOC_ADDRESS_OBJECT as ao")
                .Join("VOC_ADDRESS_TYPE at", "ao.AOLEVEL = at.LEVEL and ao.SHORTNAME = at.SOCRNAME", SQLJoinTypes.LEFT_JOIN)
                .Columns("ao.id, ao.formalname, ao.aoguid, CASE WHEN at.SCNAME is null THEN ao.SHORTNAME ELSE at.SCNAME END as type"
                        + ", ao.SHORTNAME as typeBrief, at.POINT, at.LEFT")
                .Where("aolevel in (3,4) and currstatus = 0 and parentguid = (select aoguid from voc_address_object where currstatus = 0 and parentguid is null)")
                .Order("ao.code ASC");
            DataTable dt = db.Execute(select);
            DataColumn name = new DataColumn();
            name.ColumnName = "name";
            name.Expression = "formalname + ' ' + type";
            dt.Columns.Add(name);
            return dt;
        }

        public DataTable getPlaceByParentGUID(string parentAddressGuid)
        {
            Select select = new Select()
                .From("VOC_ADDRESS_OBJECT as ao")
                .Join("VOC_ADDRESS_TYPE at", "ao.AOLEVEL = at.LEVEL and ao.SHORTNAME = at.SOCRNAME", SQLJoinTypes.LEFT_JOIN)
                .Columns("ao.id, ao.formalname, ao.aoguid, CASE WHEN at.SCNAME is null THEN ao.SHORTNAME ELSE at.SCNAME END as type"
                        + ", ao.SHORTNAME as typeBrief, at.POINT, at.LEFT")
                .Where("aolevel = 6 and currstatus = 0 and parentguid='" + parentAddressGuid + "'")
                .Order("ao.code ASC");
            DataTable dt = db.Execute(select);
            if (dt != null)
            {
                DataColumn name = new DataColumn();
                name.ColumnName = "name";
                name.Expression = "formalname + ' ' + type";
                dt.Columns.Add(name);
            }
            return dt;
        }

        public DataTable getStreetByParentGUID(string parentAddressGuid)
        {
            Select select = new Select()
                .From("VOC_ADDRESS_OBJECT as ao")
                .Join("VOC_ADDRESS_TYPE at", "ao.AOLEVEL = at.LEVEL and ao.SHORTNAME = at.SOCRNAME", SQLJoinTypes.LEFT_JOIN)
                .Columns("ao.id, ao.formalname, ao.aoguid, CASE WHEN at.SCNAME is null THEN ao.SHORTNAME ELSE at.SCNAME END as type"
                        + ", ao.SHORTNAME as typeBrief, at.POINT, at.LEFT")
                .Where("aolevel in (7) and currstatus = 0 and parentguid='" + parentAddressGuid + "'")
                .Order("ao.code ASC");
            DataTable dt = db.Execute(select);
            if (dt != null)
            {
                DataColumn name = new DataColumn();
                name.ColumnName = "name";
                name.Expression = "formalname + ' ' + type";
                dt.Columns.Add(name);
            }
            return dt;
        }

        public bool checkCode(string code)
        {
            Dictionary<string, object> res = db.FetchOneRow("select ao.FORMALNAME, ao.SHORTNAME, ao.CODE, l.NAME, ao.ID "
                + "from VOC_ADDRESS_OBJECT ao "
                + "left join VOC_LEVEL l on ao.AOLEVEL = l.ID "
                + "where CURRSTATUS = 0 and ao.CODE = '" + code + "'");
            return res.Count == 0;
        }

        public void updateAddress(string name, int level, string typeBrief, string code, int id)
        {
            int codeLength = code.Length;

            ParametersCollection parameters = new ParametersCollection();
            parameters.Add("formalname", name, System.Data.DbType.String);
            parameters.Add("areacode", code.Substring(2, 3), System.Data.DbType.String);
            parameters.Add("citycode", code.Substring(5, 3), System.Data.DbType.String);
            parameters.Add("placecode", code.Substring(8, 3), System.Data.DbType.String);
            if (codeLength == 17)
            {
                parameters.Add("streetcode", code.Substring(11, 4), System.Data.DbType.String);
            }
            parameters.Add("offname", name, System.Data.DbType.String);
            parameters.Add("updatedate", DateTime.Now, System.Data.DbType.Date);
            parameters.Add("shortname", typeBrief, System.Data.DbType.String);
            parameters.Add("aolevel", level, System.Data.DbType.Int32);
            parameters.Add("code", code, System.Data.DbType.String);
            parameters.Add("plaincode", code.Substring(0, codeLength - 2), System.Data.DbType.String);
            parameters.Add("currstatus", code.Substring(codeLength - 2, 2), System.Data.DbType.Int32);
            db.Update("VOC_ADDRESS_OBJECT", parameters, "id = " + id);
        }

        public VocAddressObject getAddressById(int id)
        {
            Dictionary<string, object> a = db.FetchOneRow("select ao.ID, ao.FORMALNAME, ao.SHORTNAME,  at.POINT, at.LEFT "
                + "from VOC_ADDRESS_OBJECT ao "
                + "left join VOC_ADDRESS_TYPE at on ao.AOLEVEL = at.LEVEL and ao.SHORTNAME = at.SOCRNAME "
                + "where ao.ID = " + id);
            VocAddressObject vao = new VocAddressObject();
            vao.id = Convert.ToInt32(a["ID"]);
            vao.name = a["FORMALNAME"].ToString();
            vao.typeBrief = a["SHORTNAME"].ToString();
            vao.typeBriefHasPoint = Convert.ToBoolean(a["POINT"]);
            vao.typeBriefInLeft = Convert.ToBoolean(a["LEFT"]);
            return vao;
        }
    }
}
