using DatabaseLib;
using OSZN.Model;
using System;
using System.Data;

namespace OSZN.DAO
{
    class FamilyMembersDAO : CommonDAO
    {
        public int insertFamilyMember(FamilyMember familyMember)
        {
            return db.Insert("family_members", familyMember.getParametersCollection());
        }

        public void updateFamilyMember(FamilyMember familyMember)
        {
            db.Update("family_members", familyMember.getParametersCollection(), "id = " + familyMember.id);
        }

        public void deleteFamilyMember(int id)
        {
            db.Delete("family_members", "id = " + id);
        }

        public FamilyMember getFamilyMemberById(int id)
        {
            Select query = new Select()
                .From("family_members")
                .Where("id = " + id);
            FamilyMember fm = new FamilyMember(db.FetchOneRow(query));
            if (fm.relationshipDegreeId != null)
                fm.relationshipDegree = new RelationshipDegreeDAO(db).getRelationshipDegreeById(fm.relationshipDegreeId.Value);
            return fm;
        }

        public DataTable getExemptFamilyMembers(int exemptId)
        {
            Select select = new Select()
                .From("family_members")
                .Where("exempt_id = " + exemptId)
                .Order("id ASC");
            DataTable dt = db.Execute(select);
            if (dt != null)
            {
                DataColumn address = new DataColumn();
                address.ColumnName = "relationship_degree";
                dt.Columns.Add("relationship_degree");
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["relationship_degree_id"] != null && !DBNull.Value.Equals(dr["relationship_degree_id"]))
                        dr["relationship_degree"] = new RelationshipDegreeDAO(db).getRelationshipDegreeById(Convert.ToInt32(dr["relationship_degree_id"])).name;
                }
            }
            return dt;
        }
    }
}
