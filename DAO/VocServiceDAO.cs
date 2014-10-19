﻿using DatabaseLib;
using OSZN.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSZN.DAO
{
    class VocServiceDAO : CommonDAO
    {
        public VocServiceDAO(DbFacadeSQLite db)
            : base(db)
        {
            this.db = db;
        }

        public VocServiceDAO()
            : base()
        {
            this.db = db;
        }

        public int insertVocService(VocService vocService)
        {
            return db.Insert("voc_service", vocService.getParametersCollection());
        }

        public DataTable getVocServices(string searchText)
        {
            Select select = new Select()
                .From("voc_service");
            if (!String.IsNullOrEmpty(searchText) && searchText != "Все")
            {
                if (searchText == "Активные")
                    select.Where("active = 1");
                else
                    select.Where("active = 0");
            }
            select.Order("code ASC");
            DataTable dt = db.Execute(select);
            if (dt != null)
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = "codeName";
                dc.Expression = "code + ' - ' + ISNULL(name, '')";
                dt.Columns.Add(dc);
            } 
            return dt;
        }

        public VocService getVocServiceById(int id)
        {
            Select query = new Select()
                .From("voc_service")
                .Where("id = " + id);
            return new VocService(db.FetchOneRow(query));
        }

        public void updateVocService(VocService vocService)
        {
            db.Update("voc_service", vocService.getParametersCollection(), "id = " + vocService.id);
        }

        public int getNextCode()
        {
            Select query = new Select()
                .From("voc_service")
                .Columns("max(code) as maxCode")
                .Where("active = 1");
            Dictionary<string,object> s = db.FetchOneRow(query);
            int maxCode = 0;
            int nextCode = 1000;
            if (s != null && s.Count > 0)
            {
                maxCode = Convert.ToInt32(s["maxCode"]);
                nextCode = (maxCode / 1000 + 1) * 1000;
            }
            return nextCode;
        }

        public VocService getVocServiceByCode(int code)
        {
            Select query = new Select()
                .From("voc_service")
                .Where("active = 1 and code = " + code);
            return new VocService(db.FetchOneRow(query));
        }
    }
}