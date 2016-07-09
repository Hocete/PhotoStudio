using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Collections;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Configuration;

namespace PhotoStudio.Common
{
    public class DatabaseMain
    {

        /// <summary>  
        /// 备份数据库  
        /// </summary>  
        /// <param name="fileName">备份文件的路径</param>  
        public static void Backup(string fileName)
        {
            //TODO SQL Server only now  
            string sqlConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString.ToString();
            using (SqlConnection conn = new SqlConnection(sqlConnectionString))
            {
                string dbName = new SqlConnectionStringBuilder(sqlConnectionString).InitialCatalog;
                string commandText = string.Format(
                    "BACKUP DATABASE [{0}] TO DISK = '{1}' WITH FORMAT",
                    dbName,
                    fileName);

                DbCommand dbCommand = new SqlCommand(commandText, conn);
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                dbCommand.ExecuteNonQuery();
            }
        }

        /// <summary>  
        /// 还原数据库 database  
        /// </summary>  
        /// <param name="fileName">要还原的数据库文件路径</param>  
        public static void RestoreBackup(string fileName)
        {
            string sqlConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString.ToString();
            //clear all pools  
            SqlConnection.ClearAllPools();
            using (SqlConnection conn = new SqlConnection(sqlConnectionString))
            {
                string dbName = new SqlConnectionStringBuilder(sqlConnectionString).InitialCatalog;
                string commandText = string.Format(
                    "DECLARE @ErrorMessage NVARCHAR(4000) " +
                    "ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE " +
                    "BEGIN TRY " +
                       "USE MASTER " +
                        "RESTORE DATABASE [{0}] FROM DISK = '{1}' WITH REPLACE " +
                    "END TRY " +
                    "BEGIN CATCH " +
                        "SET @ErrorMessage = ERROR_MESSAGE() " +
                    "END CATCH " +
                    "ALTER DATABASE [{0}] SET MULTI_USER WITH ROLLBACK IMMEDIATE " +
                    "IF (@ErrorMessage is not NULL) " +
                    "BEGIN " +
                        "RAISERROR (@ErrorMessage, 16, 1) " +
                    "END",
                    dbName,
                    fileName);
                DbCommand dbCommand = new SqlCommand(commandText, conn);
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                dbCommand.ExecuteNonQuery();
            }

            //clear all pools  
            SqlConnection.ClearAllPools();
            
        }
    }
}
