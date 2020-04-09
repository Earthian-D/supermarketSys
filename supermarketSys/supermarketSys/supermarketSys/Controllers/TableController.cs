using supermarketSys.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace supermarketSys.Controllers
{
    
    public class TableController : Controller
    {
        public static string tablename;
        // GET: Table
        public ActionResult Table(string name,string cols)
        {

           // name = "Commodity";
            ViewBag.name = name;
            ViewBag.cols = cols;
            tablename = name;
            return View("~/Views/Table/BootstrapTable.cshtml");
        }
        public string GetJson()
        {
            string sql = "select * from " + tablename;
            DataTable tb = new DBHelper().GetDataTableBySql(sql);
            return DataTableToJson(tb);
        }
        public static string DataTableToJson(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"code\":0,\"msg\":\"\",\"count\":1000,\"data\":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]}");
            return jsonBuilder.ToString();
        }
    }
}