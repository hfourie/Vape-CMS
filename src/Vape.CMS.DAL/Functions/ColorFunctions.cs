using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using Vape.CMS.DAL.Entities;

namespace Vape.CMS.DAL.Functions
{
    public static class ColorFunctions
    {
        private static readonly Database Db = new Database();

        #region Color Specific Functions
        //get Colors
        public static List<Color> GetAll()
        {
            var sqlQuery = $"SELECT * FROM colors WHERE Deleted = False";
            var dt = (DataTable)Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, null, Database.ReturnType.DataTable, false);
            return dt.AsEnumerable().Select(row =>
                new Color
                {
                    ColorId = Convert.ToInt32 (SqlHelperFunctions.NullCheck(row["ColorId"])),
                    ColorDesc = SqlHelperFunctions.NullCheck(row["Color"]),
                }).ToList();
        }

        //get Color
        public static Color Get(Color color)
        {
            var sqlQuery = $"SELECT * FROM colors WHERE ColorId = @ColorId";
            var sqlParams = new List<MySqlParameter>() {
                new MySqlParameter("@ColorId", color.ColorId)
            };
            var dt = (DataTable)Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.DataTable, false);
            if (dt.Rows.Count > 0){
                color.ColorId = Convert.ToInt32(SqlHelperFunctions.NullCheck(dt.Rows[0]["ColorId"]));
                color.ColorDesc = SqlHelperFunctions.NullCheck(dt.Rows[0]["Color"]);
            };
            return color;
        }

        //create Color
        public static void Create(Color color)
        {
            var sqlQuery = "INSERT INTO colors (Color, Updated) VALUES (@Color, @Updated)";
            var sqlParams = new List<MySqlParameter>() {
                new MySqlParameter("@Color", color.ColorDesc),
                 new MySqlParameter("@Updated", DateTime.Now)
            };
            Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.None, false);
        }

        //update Color
        public static void Update(Color color)
        {
            var sqlQuery = "UPDATE colors SET Color = @Color, Updated = @Updated, UserIdUpdated = @UserIdUpdated  WHERE ColorId = @ColorId";
            var sqlParams = new List<MySqlParameter>() {
                 new MySqlParameter("@Color", color.ColorDesc),
                 new MySqlParameter("@Updated", DateTime.Now),
                 new MySqlParameter("@UserIdUpdated", color.UserIdUpdated), //use identity user
                 new MySqlParameter("@ColorId", color.ColorId),
            };
            Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.None, false);
        }

        //delete Color
        public static void Delete(Color color)
        {
            var sqlQuery = "UPDATE Colors SET Deleted = True WHERE  ColorId = @ColorId";
            var sqlParams = new List<MySqlParameter>() {
                new MySqlParameter("@ColorId", color.ColorId)
            };
            Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.None, false);
        }
        #endregion

    }
}