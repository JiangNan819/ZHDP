using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 智慧大鹏
{
    public  class SQLserver
    {
        // 连接字符串
        private static string connStr = ConfigurationManager.
            ConnectionStrings["connStr"].ConnectionString;



        public static object GetSingleResult()
        {
            return "返回结果";
        }

        // 主分支进行修改

        // 查询
        public static SqlDataReader SelectResult(string sql)
        {
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sql, conn);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                return reader;
            }
            catch (Exception ex) 
            { 
                return null;
            }
        }


        //增删改

        public static int Update(string sql)
        {
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sql, conn);

            try
            {
                conn.Open();
                int count = cmd.ExecuteNonQuery();
                return count;
            }
            catch (Exception ex) 
            { 
                return 0;
            }
        }


        // 事务


    }
}
