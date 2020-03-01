using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using supermarketSys.SQL;
using System.Data;
using System.Text;

namespace supermarketSys.Controllers
{
    public class SQLtoDBController : Controller
    {
        // GET: SQLtoDB
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 查找是否存在数据 
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>"True""False"</returns>
        public bool FindData(string sql)
        {
            object obj = new DBHelper().ExcuteSqlWord(sql);
            bool msg;
            if (obj != null) msg = true;
            else msg = false;
            return msg;
        }
        /// <summary>
        /// 将datatable转json输出
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>[{"id":"XX"},{...}]格式</returns>
        public string GetJson(string sql)
        {
            DataTable tb = new DBHelper().GetDataTableBySql(sql);
            return DataTableToArry(tb);
        }
        public static string DataRowToJson(DataRow[] drArr)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("[");
            if (drArr.Length > 0)
            {
                foreach (DataRow dr in drArr)
                {
                    jsonBuilder.Append("{");
                    for (int drIndex = 0; drIndex < dr.ItemArray.Length; drIndex++)
                    {
                        jsonBuilder.AppendFormat("\"{0}\":\"{1}\",",
                            dr.Table.Columns[drIndex].ColumnName, dr[drIndex].ToString().Replace('"', '‘').Replace("'", "‘").Trim());
                    }
                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                    jsonBuilder.Append("},");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            }
            jsonBuilder.Append("]");
            return jsonBuilder.ToString();
        }
        public static string DataTableToArry(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("[");
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
            jsonBuilder.Append("]");
            return jsonBuilder.ToString();
        }
    }
}