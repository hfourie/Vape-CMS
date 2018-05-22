using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Vape.CMS.DAL.Entities;

namespace Vape.CMS.DAL.Functions
{
    public class FileFunctions
    {
        private static readonly Database Db = new Database();

        //get Files
        public static File Get(File file)
        {
            const string sqlQuery = @"Select FileName, FileContentType, FileSize, FileBytes FROM Files WHERE FileId = @FileId";
            var sqlParams = new List<MySqlParameter>{
                new MySqlParameter("@FileId", file.FileId),
            };
            var dt = (DataTable)Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.DataTable, false);

            return (dt.Rows.Count == 0) ? new File() : new File
            {
                FileName = dt.Rows[0]["FileName"].ToString(),
                FileContentType = dt.Rows[0]["FileContentType"].ToString(),
                FileSize = int.Parse(dt.Rows[0]["FileSize"].ToString()),
                FileBytes = (byte[])dt.Rows[0]["FileBytes"]
            };
        }

        //create File
        public static int Create(File file)
        {
            var sqlQuery = "INSERT INTO Files (FileName, FileContentType, FileSize, FileBytes) VALUES (@FileName, @FileContentType, @FileSize, @FileBytes); " +
                           "SELECT LAST_INSERT_ID() as FileId";
            var sqlParams = new List<MySqlParameter>() {
                 new MySqlParameter("@FileName", file.FileName),
                 new MySqlParameter("@FileContentType", file.FileContentType),
                 new MySqlParameter("@FileSize", file.FileSize),
                 new MySqlParameter("@FileBytes", file.FileBytes)
            };
            var dt = (DataTable)Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.DataTable, false);

            return (dt.Rows.Count > 0) ? int.Parse(dt.Rows[0]["FileId"].ToString()) : 0;
        }
    }
}
