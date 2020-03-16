using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using supermarketSys.SQL;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

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
            bool obj = new DBHelper().ExcuteSql(sql);
            return obj;
        }
        /// <summary>
        /// 将datatable转json输出
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>[{id:"XX"},{...}]格式</returns>
        public string GetJson(string sql)
        {
            DataTable tb = new DBHelper().GetDataTableBySql(sql);
            return DataTableToJson(tb);
        }
        public bool FnExecProcedure(string pro, string code)
        {
            object obj = new DBHelper().ExcuteProcedure(pro, code);
            bool msg;
            if (obj != null) msg = true;
            else msg = false;
            return msg;
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
        public static string DataTableToJson(DataTable dt)
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
        public bool Save(string  tablename)
        {
            DataTable tb = JsonToDataTable(Request["data"]);
            bool msg = new DBHelper().ExcuteInsertDatatable(tablename, tb);
            return msg;
        }
        /// <summary>
        /// 私有类 将一个jsonobject转换成datatable
        /// </summary>
        /// <param name="strJson"></param>
        /// <returns></returns>
        private DataTable JsonToDataTable(string strJson)
        {
            //转换json格式
            strJson = strJson.Replace(",\"", "*\"").Replace("\":", "\"#").ToString();
            //取出表名  
            var rg = new Regex(@"(?<={)[^:]+(?=:\[)", RegexOptions.IgnoreCase);
            string strName = rg.Match(strJson).Value;
            DataTable tb = null;
            //去除表名  
            //strJson = strJson.Substring(strJson.IndexOf("[") + 1);
            //strJson = strJson.Substring(0, strJson.IndexOf("]"));
            //获取数据  
            rg = new Regex(@"(?<={)[^}]+(?=})");
            MatchCollection mc = rg.Matches(strJson);
            for (int i = 0; i < mc.Count; i++)
            {
                string strRow = mc[i].Value;
                string[] strRows = strRow.Split('*');
                //创建表  
                if (tb == null)
                {
                    tb = new DataTable();
                    tb.TableName = strName;
                    foreach (string str in strRows)
                    {
                        var dc = new DataColumn();
                        string[] strCell = str.Split('#');
                        if (strCell[0].Substring(0, 1) == "\"")
                        {
                            int a = strCell[0].Length;
                            dc.ColumnName = strCell[0].Substring(1, a - 2);
                        }
                        else
                        {
                            dc.ColumnName = strCell[0];
                        }
                        tb.Columns.Add(dc);
                    }
                    tb.AcceptChanges();
                }
                //增加内容  
                DataRow dr = tb.NewRow();
                for (int r = 0; r < strRows.Length; r++)
                {
                    dr[r] = strRows[r].Split('#')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("\"", "");
                }
                tb.Rows.Add(dr);
                tb.AcceptChanges();
            }
            return tb;
        }
    }
}