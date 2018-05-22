using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Vape.CMS.DAL.Functions
{
    public class SqlHelperFunctions
    {
        public static string NullCheck(object field)
        {
            return field == DBNull.Value ? null : field.ToString();
        }

        public static string FormatFields(string[] sqlQueryFields)
        {
            return string.Join(", ", sqlQueryFields);
        }

        public static string FormatWhereFields(string[] sqlQueryValues)
        {

            //var values = new List<string>();
            //for (int i = 0; i < sqlQueryValues.Length; i++)
            //{
            //    var test = sqlQueryValues[0].Split('.');
            //    values.Add(sqlQueryValues + " = @" + test[1]);
            //}

            var values = sqlQueryValues.Select(t => t + " = @" + t).ToList();
            return string.Join(" AND ", values);
        }

        public static string FormatUpdateFields(string[] sqlQueryValues)
        {
            var values = sqlQueryValues.Select(t => t + " = @" + t).ToList();
            return string.Join(", ", values);
        }

        public static string FormatInsertParameterValues(string[] sqlQueryFields)
        {
            for (var i = 0; i < sqlQueryFields.Length; i++)
                sqlQueryFields[i] = "@" + sqlQueryFields[i];

            return string.Join(", ", sqlQueryFields);
        }

        public static IDbDataParameter[] SqlParams(object[] sqlQueryValueData, string[] sqlQueryFields = null, string[] sqlQueryWhereValues = null)
        {

            var data = new List<string>();
            if (sqlQueryFields != null) data.AddRange(sqlQueryFields);
            if (sqlQueryWhereValues != null) data.AddRange(sqlQueryWhereValues);

            return data.Select((t, i) => new MySqlParameter("@" + t, sqlQueryValueData[i])).ToArray();
        }

       
    }
}


