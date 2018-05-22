using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Vape.CMS.DAL
{
    public class Database
    {
        private const string Server = "127.0.0.1";
        private const string Db = "vapecms";
        private const string User = "root";
        private const string Pass = "H@lcyon60*";
        //private const string Pass = "Corne1991";
        readonly MySqlConnection _connection;

        public enum DatabaseProcedureType
        {
            Text = 1,
            StoredProcedure = 2
        }

        public enum ReturnType
        {
            None = 1,
            DataReader = 2,
            DataSet = 3,
            DataAdapter = 4,
            DataTable = 5,
            ReturnParameter = 6
        }

        // Constructor
        public Database()
        {
            var connectionString =$"Data Source={Server};Initial Catalog={Db};Persist Security Info=True;User ID={User};Password={Pass};pooling=false;";

            _connection = new MySqlConnection(connectionString);
        }

        public object ExecDb(string procedureName, DatabaseProcedureType procedureType, IDbDataParameter[] parameters, ReturnType returnType, bool newConnection, string returnParameter = null, int pageSize = 0, int pageNo = 0)
        {

            if ((_connection != null) && _connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }

            //set the command type
            var cmdSpec = new MySqlCommand(procedureName, _connection)
            {
                CommandType = procedureType == DatabaseProcedureType.Text
                    ? CommandType.Text
                    : CommandType.StoredProcedure
            };

            //add any parameters that were defined
            if (parameters != null)
            {
                cmdSpec.Parameters.AddRange(parameters);
            }

            cmdSpec.CommandTimeout = 300000;

            //execute the correct statement
            switch (returnType)
            {
                case ReturnType.None:
                    if (_connection == null) return null;
                    _connection?.Open();
                    var rowsAffected = cmdSpec.ExecuteNonQuery();
                    _connection.Close();
                    return rowsAffected;
                case ReturnType.DataReader:
                    _connection?.Open();
                    var result = cmdSpec.ExecuteReader(CommandBehavior.CloseConnection);
                    return result;
                case ReturnType.DataSet:
                {
                    var myDataAdapter = new MySqlDataAdapter();
                    var myDataset = new DataSet();

                    myDataAdapter.SelectCommand = cmdSpec;
                    if (pageSize == 0 && pageNo == 0)
                        myDataAdapter.Fill(myDataset);
                    else
                        myDataAdapter.Fill(myDataset, pageNo * pageSize, pageSize, "MyTable");

                    return myDataset;
                }
                case ReturnType.DataAdapter:
                    return new MySqlDataAdapter(cmdSpec);
                case ReturnType.DataTable:
                {
                    var myDataAdapter = new MySqlDataAdapter();
                    var myDataTable = new DataTable();
                    myDataAdapter.SelectCommand = cmdSpec;
                    myDataAdapter.Fill(myDataTable);
                    return myDataTable;
                }
                case ReturnType.ReturnParameter:
                    if (_connection != null)
                    {
                        _connection.Open();
                        cmdSpec.ExecuteNonQuery();
                        object ret = cmdSpec.Parameters[returnParameter].Value;
                        _connection.Close();

                        return ret;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(returnType), returnType, null);
            }

            return null;

        }
    }
}
