using DatabaseLib;
using OSZN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSZN.DAO
{
    class CommunicationFoldersDAO : CommonDAO
    {
        public CommunicationFolders getFolders()
        {
            Select select = new Select()
                .From("communication_folders");

            return new CommunicationFolders(db.FetchOneRow(select));
        }

        public void saveFolders(CommunicationFolders folders)
        {
            Dictionary<string, object> foldersFromDb = db.FetchOneRow("select * from communication_folders");
            if (foldersFromDb == null || foldersFromDb.Count <= 0 )
                db.Insert("communication_folders", folders.getParametersCollection());
            else
                db.Update("communication_folders", folders.getParametersCollection(), "(select count(*) from communication_folders) > 0");
        }
    }
}
