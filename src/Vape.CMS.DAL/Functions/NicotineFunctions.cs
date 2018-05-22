using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Vape.CMS.DAL.Entities;

namespace Vape.CMS.DAL.Functions
{
    public static class NicotineFunctions
    {
        private static readonly Database Db = new Database();

        #region Nicotine Specific Functions
        //get Nicotine
        public static List<Nicotine> GetAll()
        {
            var sqlQuery = $"SELECT * FROM nicotine WHERE Deleted = False";
            var dt = (DataTable)Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, null, Database.ReturnType.DataTable, false);
            return dt.AsEnumerable().Select(row =>
                new Nicotine
                {
                    NicotineId = Convert.ToInt32(SqlHelperFunctions.NullCheck(row["NicotineId"])),
                    NicotineStrength = Convert.ToInt32(Convert.ToDouble(SqlHelperFunctions.NullCheck(row["Nicotine"]))),
                }).ToList();
        }

        //get Nicotine
        public static Nicotine Get(Nicotine nicotine)
        {
            var sqlQuery = $"SELECT * FROM nicotine WHERE NicotineId = @NicotineId";
            var sqlParams = new List<MySqlParameter>() {
                new MySqlParameter("@NicotineId", nicotine.NicotineId)
            };
            var dt = (DataTable)Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.DataTable, false);
            if (dt.Rows.Count > 0)
            {
                nicotine.NicotineId = Convert.ToInt32(SqlHelperFunctions.NullCheck(dt.Rows[0]["NicotineId"]));
                nicotine.NicotineStrength = Convert.ToInt32(SqlHelperFunctions.NullCheck(dt.Rows[0]["Nicotine"]));
            };
            return nicotine;
        }

        //create Nicotine
        public static void Create(Nicotine nicotine)
        {
            var sqlQuery = "INSERT INTO nicotine (Nicotine, Updated) VALUES (@Nicotine, @Updated)";
            var sqlParams = new List<MySqlParameter>() {
                new MySqlParameter("@Nicotine", nicotine.NicotineStrength),
                 new MySqlParameter("@Updated", DateTime.Now)
            };
            Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.None, false);
        }

        //update Nicotine
        public static void Update(Nicotine nicotine)
        {
            var sqlQuery = "UPDATE nicotine SET Nicotine = @Nicotine, Updated = @Updated, UserIdUpdated = @UserIdUpdated  WHERE NicotineId = @NicotineId";
            var sqlParams = new List<MySqlParameter>() {
                 new MySqlParameter("@Nicotine", nicotine.NicotineStrength),
                 new MySqlParameter("@Updated", DateTime.Now),
                 new MySqlParameter("@UserIdUpdated", nicotine.UserIdUpdated), //use identity user
                 new MySqlParameter("@NicotineId", nicotine.NicotineId),
            };
            Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.None, false);
        }

        //delete Nicotine
        public static void Delete(Nicotine nicotine)
        {
            var sqlQuery = "UPDATE nicotine SET Deleted = True WHERE NicotineId = @NicotineId";
            var sqlParams = new List<MySqlParameter>() {
                 new MySqlParameter("@NicotineId", nicotine.NicotineId),
            };
            Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.None, false);
        }
        #endregion

    }
}