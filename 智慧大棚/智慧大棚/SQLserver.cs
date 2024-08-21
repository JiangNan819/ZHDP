using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 智慧大鹏
{
    public static class SQLserver
    {
        static string Strsql = "Server='LAPTOP-62S7LNFF';Database='GreenData';Uid='sa';Pwd='123456'";

        /// <summary>
        /// 执行增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Update(string sql)
        {
            SqlConnection connection = new SqlConnection(Strsql);
            SqlCommand cmd = new SqlCommand(sql,connection);
            try
            {
                connection.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                connection.Close();
            }

        }

        public static DataSet GetDataSet(string sql)
        {
            SqlConnection connection = new SqlConnection( Strsql);
            SqlCommand cmd = new SqlCommand(sql,connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                da.Fill(ds);
                return ds;
            }
            catch (Exception )
            {

                return null;
            }
            finally
            {
                connection.Close();
            }


        }



    }
}
