using DatabaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSZN.Model
{
    class CommunicationFolders
    {
        public string loadFolder { get; set; }
        public string unloadFolder { get; set; }

        public CommunicationFolders() { }

        public CommunicationFolders(Dictionary<string, object> dict)
        {
            if (dict != null && dict.Count > 0)
            {
                if (dict.ContainsKey("load_folder"))
                    loadFolder = dict["load_folder"].ToString();
                if (dict.ContainsKey("unload_folder"))
                    unloadFolder = dict["unload_folder"].ToString();
            }
        }

        public ParametersCollection getParametersCollection()
        {
            ParametersCollection parameters = new ParametersCollection();
            parameters.Add("load_folder", loadFolder, System.Data.DbType.String);
            parameters.Add("unload_folder", unloadFolder, System.Data.DbType.String);
            return parameters;
        }
    }
}
