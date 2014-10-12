using DatabaseLib;
using System.Data.SQLite;

namespace OSZN.DAO
{
    class CommonDAO
    {
        private static SQLiteConnectionStringBuilder connectionStringBuilder = 
            new SQLiteConnectionStringBuilder("Data Source=OSZN.sqlite;Version=3;Pooling=True;Max Pool Size=100;");

        protected DbFacadeSQLite db;

        public CommonDAO()
        {
            db = new DbFacadeSQLite(connectionStringBuilder);
        }

        public CommonDAO(DbFacadeSQLite db)
        {
            this.db = db;
        }

        ~CommonDAO()
        {
            db.Close();
        }

        public void beginTransaction() {
            db.BeginTransaction();
        }

        public void commitTransaction()
        {
            db.CommitTransaction();
        }

        public void vacuum()
        {
            db.Vacuum();
        }
    }
}
