using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Vape.CMS.DAL.Entities;

namespace Vape.CMS.DAL.Functions
{
    public static class UserFunctions
    {
        private static readonly Database Db = new Database();

        #region User Specific Functions
        //get users
        public static List<User> GetAll()
        {
            var sqlQuery = $"SELECT * FROM Users WHERE Deleted = False";
            var dt = (DataTable)Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, null, Database.ReturnType.DataTable, false);

            return dt.AsEnumerable().Select(row =>
                new User
                {
                    UserId = Convert.ToInt32(SqlHelperFunctions.NullCheck(row["UserId"])),
                    RoleId = Convert.ToInt32(SqlHelperFunctions.NullCheck(row["RoleId"])),
                    ProfilePictureId = Convert.ToInt32(SqlHelperFunctions.NullCheck(row["ProfilePictureId"])),
                    Name = SqlHelperFunctions.NullCheck(row["Name"]),
                    Surname = SqlHelperFunctions.NullCheck(row["Surname"]),
                    Email = SqlHelperFunctions.NullCheck(row["Email"]),
                }).ToList();
        }

        //get user
        public static User Get(User user)
        {
            var sqlQuery = $"SELECT * FROM Users WHERE UserId = @UserId";
            var sqlParams = new List<MySqlParameter>() {
                new MySqlParameter("@UserId", user.UserId)
            };
            var dt = (DataTable)Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.DataTable, false);
            if (dt.Rows.Count > 0)
            {
                user.UserId = Convert.ToInt32(SqlHelperFunctions.NullCheck(dt.Rows[0]["UserId"]));
                user.Name = SqlHelperFunctions.NullCheck(dt.Rows[0]["Name"]);
                user.Surname = SqlHelperFunctions.NullCheck(dt.Rows[0]["Surname"]);
                user.Email = SqlHelperFunctions.NullCheck(dt.Rows[0]["Email"]);
                user.ProfilePictureId = Convert.ToInt32(SqlHelperFunctions.NullCheck(dt.Rows[0]["ProfilePictureId"]));
                user.RoleId = Convert.ToInt32(SqlHelperFunctions.NullCheck(dt.Rows[0]["RoleId"]));
            };
            return user;

        }

        //create user
        public static void Create(User user)
        {
            var sqlQuery = "INSERT INTO users (Name, Surname, Email, ContactViaEmail, ProfilePictureId, RoleId) " +
                            "VALUES (@Name, @Surname, @Email, @ContactViaEmail, @ProfilePictureId, @RoleId)";
            var sqlParams = new List<MySqlParameter>() {
                 new MySqlParameter("@Name", user.Name),
                 new MySqlParameter("@Surname", user.Surname),
                 new MySqlParameter("@Email", user.Email), //use identity user
                 new MySqlParameter("@ContactViaEmail", user.ContactViaEmail),
                 new MySqlParameter("@ProfilePictureId", user.ProfilePictureId),
                 new MySqlParameter("@RoleId", user.RoleId)
            };
            Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.None, false);
        }

        //update user
        public static void Update(User user)
        {
            var sqlQuery = "UPDATE Users SET " +
                           "Name = @Name, Surname = @Surname, Email = @Email, ContactViaEmail = @ContactViaEmail, ProfilePictureId = @ProfilePictureId, RoleId = @RoleId " +
                           "WHERE UserId = @UserId";
            var sqlParams = new List<MySqlParameter>() {
                 new MySqlParameter("@UserId", user.UserId),
                 new MySqlParameter("@Name", user.Name),
                 new MySqlParameter("@Surname", user.Surname),
                 new MySqlParameter("@Email", user.Email), //use identity user
                 new MySqlParameter("@ContactViaEmail", user.ContactViaEmail),
                 new MySqlParameter("@ProfilePictureId", user.ProfilePictureId),
                 new MySqlParameter("@RoleId", user.RoleId)
            };
            Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.None, false);
        }

        //delete user
        public static void Delete(User user)
        {
            var sqlQuery = "UPDATE Users SET Deleted = True WHERE UserId = @UserId";
            var sqlParams = new List<MySqlParameter>() {
                 new MySqlParameter("@UserId", user.UserId)
            };
            Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.None, false);
        }
        #endregion

        #region Role Functions

        public static IEnumerable<Role> GetUserRoles()
        {
            var sqlQuery = $"SELECT * FROM Roles";
            var dt = (DataTable)Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, null, Database.ReturnType.DataTable, false);
            return dt.AsEnumerable().Select(row =>
                new Role
                {
                    RoleId = Convert.ToInt32(SqlHelperFunctions.NullCheck(row["RoleId"])),
                    RoleDiscription = SqlHelperFunctions.NullCheck(row["RoleDiscription"])

                });
        }

        #endregion
    }
}
