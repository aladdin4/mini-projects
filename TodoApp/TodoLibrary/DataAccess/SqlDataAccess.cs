using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoLibrary.DataAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {

        _config = config;
    }

    public async Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
    {
        string connectionString = _config.GetConnectionString(connectionStringName);
        using IDbConnection connection = new SqlConnection(connectionString);
        List<T> rows = (await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure)).ToList();
        return rows;
    }

    //returning the task, hence, the execution will be Sync. And the waiting is expected to be done by the caller
    public Task SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
    {
        string connectionString = _config.GetConnectionString(connectionStringName);
        using IDbConnection connection = new SqlConnection(connectionString);
        return connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
}
