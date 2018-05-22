using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Vape.CMS.DAL.Entities;

namespace Vape.CMS.DAL.Functions
{
    public static class SizeFunctions
    {
        private static readonly Database Db = new Database();

        #region Size Specific Functions
        //get Sizes
        public static List<Size> GetAll()
        {
            var sqlQuery = $"SELECT * FROM sizes WHERE Deleted = False";
            var dt = (DataTable)Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, null, Database.ReturnType.DataTable, false);
            return dt.AsEnumerable().Select(row =>
                new Size
                {
                    SizeId = Convert.ToInt32(SqlHelperFunctions.NullCheck(row["SizeId"])),
                    SizeDesc = Convert.ToInt32(SqlHelperFunctions.NullCheck(row["Size"])),
                }).ToList();
        }

        //get Size
        public static Size Get(Size size)
        {
            var sqlQuery = $"SELECT * FROM sizes WHERE SizeId = @SizeId";
            var sqlParams = new List<MySqlParameter>() {
                new MySqlParameter("@SizeId", size.SizeId)
            };
            var dt = (DataTable)Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.DataTable, false);
            if (dt.Rows.Count > 0)
            {
                size.SizeId = Convert.ToInt32(SqlHelperFunctions.NullCheck(dt.Rows[0]["SizeId"]));
                size.SizeDesc = Convert.ToInt32(SqlHelperFunctions.NullCheck(dt.Rows[0]["Size"]));
            };
            return size;
        }

        //create Size
        public static void Create(Size size)
        {
            var sqlQuery = "INSERT INTO sizes (Size, Updated) VALUES (@Size, @Updated)";
            var sqlParams = new List<MySqlParameter>() {
                new MySqlParameter("@Size", size.SizeDesc),
                new MySqlParameter("@Updated", DateTime.Now)
            };
            Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.None, false);
        }

        //update Size
        public static void Update(Size size)
        {
            var sqlQuery = "UPDATE sizes SET Size = @Size, Updated = @Updated, UserIdUpdated = @UserIdUpdated  WHERE SizeId = @SizeId";
            var sqlParams = new List<MySqlParameter>() {
                 new MySqlParameter("@Size", size.SizeDesc),
                 new MySqlParameter("@Updated", DateTime.Now),
                 new MySqlParameter("@UserIdUpdated", size.UserIdUpdated), //use identity user
                 new MySqlParameter("@SizeId", size.SizeId),
            };
            Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.None, false);
        }

        //delete Size
        public static void Delete(Size size)
        {
            var sqlQuery = "UPDATE sizes SET Deleted = True WHERE SizeId = @SizeId";
            var sqlParams = new List<MySqlParameter>() {
                 new MySqlParameter("@SizeId", size.SizeId),
            };
            Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.None, false);
        }
        #endregion

    }
}