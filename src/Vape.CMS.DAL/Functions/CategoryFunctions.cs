using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using Vape.CMS.DAL.Entities;

namespace Vape.CMS.DAL.Functions
{
    public static class CategoryFunctions
    {
        private static readonly Database Db = new Database();

        #region Category Specific Functions
        //get Categories
        public static List<Category> GetAll()
        {
            var sqlQuery = $"SELECT * FROM categories WHERE Deleted = FALSE";
            var dt = (DataTable)Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, null, Database.ReturnType.DataTable, false);
            return dt.AsEnumerable().Select(row =>
                new Category
                {
                    CategoryId = Convert.ToInt32(SqlHelperFunctions.NullCheck(row["CategoryId"])),
                    CategoryDesc = SqlHelperFunctions.NullCheck(row["CategoryDesc"]),
                }).ToList();
        }

        //get Category
        public static Category Get(Category category)
        {
            var sqlQuery = $"SELECT * FROM categories WHERE CategoryId = @CategoryId";
            var sqlParams = new List<MySqlParameter>() {
                new MySqlParameter("@CategoryId", category.CategoryId)
            };
            var dt = (DataTable)Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.DataTable, false);
            if(dt.Rows.Count > 0)
            {
                category.CategoryId = Convert.ToInt32(SqlHelperFunctions.NullCheck(dt.Rows[0]["CategoryId"]));
                category.CategoryDesc = SqlHelperFunctions.NullCheck(dt.Rows[0]["CategoryDesc"]);
            };
            return category;
        }

        //create Category
        public static void Create(Category category)
        {
            var sqlQuery = "INSERT INTO categories (CategoryDesc, Updated) VALUES (@CategoryDesc, @Updated)";
            var sqlParams = new List<MySqlParameter>() {
                new MySqlParameter("@CategoryDesc", category.CategoryDesc),
                 new MySqlParameter("@Updated", DateTime.Now)
            };
            Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.None, false);
        }

        //update Category
        public static void Update(Category category)
        {
            var sqlQuery = "UPDATE Categories SET CategoryDesc = @CategoryDesc, Updated = @Updated, UserIdUpdated = @UserIdUpdated  WHERE CategoryId = @CategoryId";
            var sqlParams = new List<MySqlParameter>() {
                 new MySqlParameter("@CategoryDesc", category.CategoryDesc),
                 new MySqlParameter("@Updated", DateTime.Now),
                 new MySqlParameter("@UserIdUpdated", category.UserIdUpdated), //use identity user
                 new MySqlParameter("@CategoryId", category.CategoryId),
            };
            Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.None, false);
        }

        //delete Category
        public static void Delete(Category category)
        {
            var sqlQuery = "UPDATE Categories SET Deleted = True, Updated = @Updated, UserIdUpdated = @UserIdUpdated  WHERE CategoryId = @CategoryId";
            var sqlParams = new List<MySqlParameter>() {
                 new MySqlParameter("@Updated", DateTime.Now),
                 new MySqlParameter("@UserIdUpdated", category.UserIdUpdated), //use identity user
                 new MySqlParameter("@CategoryId", category.CategoryId),
            };
            Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.None, false);
        }
        #endregion

    }
}

