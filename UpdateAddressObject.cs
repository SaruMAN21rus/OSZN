using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSZN.ru.nalog.fias;
using System.Data.SQLite;
using System.IO;
using System.Net;

namespace OSZN
{
    class UpdateAddressObject
    {
        public static void update(SQLiteConnection conn)
        {
            string UpdateFolderPath = @"UpdateFolder";

            WebClient webClient;
            
            DownloadService downloadService = new DownloadService();
            DownloadFileInfo lastUpdateFile = downloadService.GetLastDownloadFileInfo();
            string lastVersionFromDB = "select max(VERSION) from FIAS_UPDATE_VERSION";
            SQLiteCommand command = new SQLiteCommand(lastVersionFromDB, conn);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            int lastVersion = reader.GetInt16(0);
            if (lastVersion < lastUpdateFile.VersionId)
            {
                if (Directory.Exists(UpdateFolderPath))
                {
                    Directory.Delete(UpdateFolderPath, true);
                }
                Directory.CreateDirectory(UpdateFolderPath);
                if (lastVersion < lastUpdateFile.VersionId - 1)
                {
                    DownloadFileInfo[] allUpdateFiles = downloadService.GetAllDownloadFileInfo();
                    foreach (var item in allUpdateFiles)
                    {
                        if (item.VersionId > lastVersion)
                        {
                            using (webClient = new WebClient())
                            {
                                webClient.DownloadFile(item.FiasDeltaXmlUrl, UpdateFolderPath + "\\" + item.VersionId + ".rar");
                            }
                        }
                    }
                }
                else
                {
                    using (webClient = new WebClient())
                    {
                        webClient.DownloadFile(lastUpdateFile.FiasDeltaXmlUrl, UpdateFolderPath + "\\" + lastUpdateFile.VersionId + ".rar");
                    }
                }
            }
        }
    }
}
