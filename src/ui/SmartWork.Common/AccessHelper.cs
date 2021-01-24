using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.OleDb;
using System.Web;

namespace SmartWork.Common
{
  public  class AccessHelper
    {
        //连接字符串

        static string connStr = ConfigurationManager.AppSettings["accessCon"];


        /// <summary>
        /// 返回受影响的行数
        /// </summary>
        /// <param name="comText"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string comText, params OleDbParameter[] param)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                using (OleDbCommand cmd = new OleDbCommand(comText, conn))
                {
                    if (param != null && param.Length != 0)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// 返回数据对象
        /// </summary>
        /// <param name="comText"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string comText, params OleDbParameter[] param)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                using (OleDbCommand cmd = new OleDbCommand(comText, conn))
                {
                    if (param != null && param.Length != 0)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }
        /// <summary>
        /// 返回table
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static DataTable Adapter(string cmdText, params OleDbParameter[] param)
        {
            DataTable dt = new DataTable();
            //OleDbConnection con = new OleDbConnection();
            using (OleDbDataAdapter oda = new OleDbDataAdapter(cmdText, connStr))
            {
                if (param != null && param.Length != 0)
                {
                    oda.SelectCommand.Parameters.AddRange(param);
                }
                if (new OleDbConnection().State == ConnectionState.Closed)
                {
                    new OleDbConnection(connStr).Open();
                }
                oda.Fill(dt);
            }
            return dt;

            /*
            using (SqlDataAdapter sda = new SqlDataAdapter(cmdText, connStr))
            {
                if (param != null && param.Length != 0)
                {
                    sda.SelectCommand.Parameters.AddRange(param);
                }
                sda.Fill(dt);
            }
            return dt;
             * */
        }
        /// <summary>
        /// 向前读取记录
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static OleDbDataReader ExectueReader(string cmdText, params OleDbParameter[] param)
        {
            OleDbConnection conn = new OleDbConnection(connStr);
            using (OleDbCommand cmd = new OleDbCommand(cmdText, conn))
            {
                if (param != null && param.Length != 0)
                {
                    cmd.Parameters.AddRange(param);
                }
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }
        /// <summary>
        /// 读取存储过程
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="type"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static DataTable GetPro(string cmdText, CommandType type, params OleDbParameter[] param)
        {
            DataTable dt = new DataTable();
            using (OleDbDataAdapter sda = new OleDbDataAdapter(cmdText, connStr))
            {
                new OleDbCommand().CommandType = CommandType.StoredProcedure;
                if (param != null && param.Length != 0)
                {
                    sda.SelectCommand.Parameters.AddRange(param);
                }
                sda.Fill(dt);
            }
            return dt;
        }
    }
}
