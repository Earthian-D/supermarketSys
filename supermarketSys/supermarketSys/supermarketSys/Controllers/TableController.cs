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
            int Page = Convert.ToInt32(Request.Params["page"]);
            int Limit = Convert.ToInt32(Request.Params["limit"]);

            // string sql = "select top "+Convert.ToInt32(Page) * Convert.ToInt32(Limit)+"* from " + tablename+" where "+codes;
            string sql1="select * from " + tablename + " where " + codes;
           // DataTable tb = new DBHelper().GetDataTableBySql(sql);
            DataTable tb1 = new DBHelper().GetDataTableBySql(sql1);
            return DataTableToJson(tb1,Page,Limit);
        }
        public static string DataTableToJson(DataTable dt, int Page,int Limit)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"code\":0,\"msg\":\"\",\"count\":"+ dt.Rows.Count + ",\"data\":[");
            int num = Page - 1;
            int End = (Page * Limit)> dt.Rows.Count ? dt.Rows.Count : (Page * Limit);
            for (int i = num*Limit; i < End; i++)
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