using DatabaseLib;
using OSZN.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSZN.DAO
{
    class RelationshipDegreeDAO : CommonDAO
    {
        public RelationshipDegreeDAO(DbFacadeSQLite db)
            : base(db)
        {
            this.db = db;
        }

        public RelationshipDegreeDAO()
            : base()
        {
            this.db = db;
        }

        public int insertRelationshipDegree(RelationshipDegree relationshipDegree)
        {
            return db.Insert("voc_relationship_degree", relationshipDegree.getParametersCollection());
        }

        public DataTable getRelationshipDegrees(string searchText)
        {
            Select select = new Select()
                .From("voc_relationship_degree");
            if (!String.IsNullOrEmpty(searchText) && searchText != "Все")
            {
                if (searchText == "Активные")
                    select.Where("active = 1");
                else
                    select.Where("active = 0");
            }
            select.Order("name ASC");
            return db.Execute(select);
        }

        public RelationshipDegree getRelationshipDegreeById(int id)
        {
            Select query = new Select()
                .From("voc_relationship_degree")
                .Where("id = " + id);
            return new RelationshipDegree(db.FetchOneRow(query));
        }

        public void updateRelationshipDegree(RelationshipDegree relationshipDegree)
        {
            db.Update("voc_relationship_degree", relationshipDegree.getParametersCollection(), "id = " + relationshipDegree.id);
        }
    }
}
