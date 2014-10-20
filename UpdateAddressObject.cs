using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSZN.ru.nalog.fias;
using System.Data.SQLite;
using System.IO;
using System.Net;
using NUnrar.Archive;
using NUnrar.Common;
using NUnrar.Reader;
using DatabaseLib;
using System.Xml;
using System.Data;
using System.Windows.Forms;
using OSZN.DAO;
using OSZN.Forms;

namespace OSZN
{
    class UpdateAddressObject
    {
        static string UpdateFolderPath = @"UpdateFolder";
        
        public static string update(WaitWindow wait)
        {
            WebClient webClient;
            
            DownloadService downloadService = new DownloadService();
            DownloadFileInfo lastUpdateFile = downloadService.GetLastDownloadFileInfo();
            VocAddressObjectDAO aoDAO = new VocAddressObjectDAO();
            int lastVersion = aoDAO.getAddressObjectsUpdateLastVersion();
            if (lastVersion < lastUpdateFile.VersionId)
            {
                wait.SetMessage("Обновление...");
                SortedSet<int> versions = new SortedSet<int>();
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
                                versions.Add(item.VersionId);
                            }
                        }
                    }
                }
                else
                {
                    using (webClient = new WebClient())
                    {
                        webClient.DownloadFile(lastUpdateFile.FiasDeltaXmlUrl, UpdateFolderPath + "\\" + lastUpdateFile.VersionId + ".rar");
                        versions.Add(lastUpdateFile.VersionId);
                    }
                }
                extractAllArchive();
                xmlToDb(versions);
                return "Классификатор адресов успешно обновлен.";
            }
            else
            {
                return "Класификатор адресов актуален. Обновление не требуется.";
            }
        }

        private static void extractAllArchive() {
            DirectoryInfo di = new DirectoryInfo(UpdateFolderPath);
            FileInfo[] fi = di.GetFiles();
            foreach (var item in fi)
            {
                using (FileStream fs = File.OpenRead(item.FullName))
                {
                    RarArchive archive = RarArchive.Open(fs);
                    string fileName = Path.GetFileNameWithoutExtension(item.Name);
                    foreach (RarArchiveEntry entry in archive.Entries)
                    {
                        if (entry.FilePath.StartsWith("AS_ADDROBJ"))
                        {
                            entry.WriteToFile(UpdateFolderPath + "\\" + fileName + ".xml", ExtractOptions.ExtractFullPath | ExtractOptions.Overwrite);
                        }
                    }
                }
                item.Delete();
            }
        }

        private static void xmlToDb(SortedSet<int> versions)
        {
            VocAddressObjectDAO aoDAO = new VocAddressObjectDAO();
            aoDAO.vacuum();
            aoDAO.beginTransaction();
            
            foreach (var item in versions)
            {
                using (XmlReader xml = XmlReader.Create(UpdateFolderPath + "\\" + item + ".xml"))
                {
                    while (true)
                    {
                        if (xml.NodeType == XmlNodeType.Element && xml.Name == "Object")
                        {
                            AddressObject a = new AddressObject(xml.ReadOuterXml());
                            if ("21".Equals(a.REGIONCODE) && a.AOLEVEL <= 7)
                            {
                                ParametersCollection parameters = new ParametersCollection();
                                parameters.Add("aoguid", a.AOGUID, System.Data.DbType.String);
                                parameters.Add("formalname", a.FORMALNAME, System.Data.DbType.String);
                                parameters.Add("regioncode", a.REGIONCODE, System.Data.DbType.String);
                                parameters.Add("autocode", a.AUTOCODE, System.Data.DbType.String);
                                parameters.Add("areacode", a.AREACODE, System.Data.DbType.String);
                                parameters.Add("citycode", a.CITYCODE, System.Data.DbType.String);
                                parameters.Add("ctarcode", a.CTARCODE, System.Data.DbType.String);
                                parameters.Add("placecode", a.PLACECODE, System.Data.DbType.String);
                                parameters.Add("streetcode", a.STREETCODE, System.Data.DbType.String);
                                parameters.Add("extrcode", a.EXTRCODE, System.Data.DbType.String);
                                parameters.Add("sextcode", a.SEXTCODE, System.Data.DbType.String);
                                parameters.Add("offname", a.OFFNAME, System.Data.DbType.String);
                                parameters.Add("postalcode", a.POSTALCODE, System.Data.DbType.String);
                                parameters.Add("ifnsfl", a.IFNSFL, System.Data.DbType.String);
                                parameters.Add("terrifnsfl", a.TERRIFNSFL, System.Data.DbType.String);
                                parameters.Add("ifnsul", a.IFNSUL, System.Data.DbType.String);
                                parameters.Add("terrifnsul", a.TERRIFNSUL, System.Data.DbType.String);
                                parameters.Add("okato", a.OKATO, System.Data.DbType.String);
                                parameters.Add("oktmo", a.OKTMO, System.Data.DbType.String);
                                parameters.Add("updatedate", a.UPDATEDATE, System.Data.DbType.Date);
                                parameters.Add("shortname", a.SHORTNAME, System.Data.DbType.String);
                                parameters.Add("aolevel", a.AOLEVEL, System.Data.DbType.Int32);
                                parameters.Add("parentguid", a.PARENTGUID, System.Data.DbType.String);
                                parameters.Add("aoid", a.AOID, System.Data.DbType.String);
                                parameters.Add("previd", a.PREVID, System.Data.DbType.String);
                                parameters.Add("nextid", a.NEXTID, System.Data.DbType.String);
                                parameters.Add("code", a.CODE, System.Data.DbType.String);
                                parameters.Add("plaincode", a.PLAINCODE, System.Data.DbType.String);
                                parameters.Add("actstatus", a.ACTSTATUS, System.Data.DbType.Int32);
                                parameters.Add("centstatus", a.CENTSTATUS, System.Data.DbType.Int32);
                                parameters.Add("operstatus", a.OPERSTATUS, System.Data.DbType.Int32);
                                parameters.Add("currstatus", a.CURRSTATUS, System.Data.DbType.Int32);
                                parameters.Add("startdate", a.STARTDATE, System.Data.DbType.Date);
                                parameters.Add("enddate", a.ENDDATE, System.Data.DbType.Date);
                                parameters.Add("normdoc", a.NORMDOC, System.Data.DbType.String);
                                parameters.Add("livestatus", a.LIVESTATUS, System.Data.DbType.Int32);
                                aoDAO.insertOrUpdateAddressObjects(parameters, a.AOID);
                            }
                        }
                        else
                        {
                            if (!xml.Read())
                            {
                                break;
                            }
                        }
                    }
                }
                aoDAO.insertUpdateVersion(item);
            }
            aoDAO.commitTransaction();
        }
    }
}
