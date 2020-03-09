using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace supermarketSys.SQL
{
    class DBHelper
    {
        private static string DBConnectString = ConfigurationManager.ConnectionStrings["sql"].ToString();
        private static SqlConnection conn;
        private static SqlDataAdapter da;//存放数据集
        private static SqlCommand cmd;//存放SQL语句
        private static DBHelper dBHelper;

        public DBHelper()
        {
            //初始化，赋予数据库字符串
            conn = new SqlConnection(DBConnectString);
        }
        public static DBHelper Instance()
        {
            //判定是否是第一次打开数据库
            if (dBHelper == null)
            {
                dBHelper = new DBHelper();
            }
            return dBHelper;

        }
        public void DBOpen()
        {
            //打开数据库连接，conn.State 连接器的状态
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        public void DBClose()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        /*-------------------------------------------------*/
        public DataTable GetDataTableBySql(string sql)
        {
            //传SQL语句，返回一个数据表
            DBOpen();
            DataTable dt = new DataTable();//空的数据表
            da = new SqlDataAdapter(sql, conn);
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                DBClose();
            }
        }
        public bool ExcuteSql(string sql)//用于SELECT，delete,insert语句
        {
            //传SQL语句，返回真假值，判定是否执行成功
            DBOpen();
            cmd = new SqlCommand(sql, conn);
            try
            {

                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                DBClose();
            }
        }

        public object ExcuteSqlWord(string sql)//用于select语句
        {
            //传SQL语句，返回第一行第一列

            DBOpen();
            cmd = new SqlCommand(sql, conn);
            try
            {
                object a = cmd.ExecuteScalar();
                return a;

            }
            catch
            {
                return null;
            }
            finally
            {
                DBClose();
            }
        }
        public int ExecuteUpdate(string sql)//用于update语句，返回受影响行数
        {
            DBOpen();
            cmd = new SqlCommand(sql, conn);
            try
            {
                int a = cmd.ExecuteNonQuery();
                return a;

            }
            catch
            {
                return 0;
            }
            finally
            {
                DBClose();
            }
        }
        /*-----------------------存储过程----------------------------------*/
        public DataTable GetDataTableByProcesure(string ProName, SqlParameter[] paras)
        {
            /*ProName是存储过程的名称,paras是存储过程参数，数组存放*/
            DBOpen();
            cmd = new SqlCommand(ProName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            for (int i = 0; i < paras.Length; i++)
            {
                cmd.Parameters.Add(paras[i]);
            }
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                DBClose();
            }
        }

        public bool ExcuteProcedure(string ProName, string paras)
        {
            DBOpen();
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                string sql = "exec " + ProName + " " + paras + "";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                DBClose();
            }

        }


    }
}