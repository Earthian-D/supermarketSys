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
        public static string codes;
        // GET: Table
        public ActionResult Table(string name,string code)
        {

            //name = "v_Commodity";
            ViewBag.name = name;
            tablename = name;
            codes = (code==null?"1=1":code);
            return View("~/Views/Table/BootstrapTable.cshtml");
        }
        public string GetJson()
        {
            string sql = "select * from " + tablename+" where "+codes;
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