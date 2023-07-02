using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Data
{
  public class DataContextDapper
  {
    // private IConfiguration _config;
    private string? _connectionString;
    public DataContextDapper(IConfiguration config)
    {
      // _config = config;
      _connectionString = config.GetConnectionString("DefaultConnection");
    }
    public IEnumerable<T> LoadData<T>(string sql)
    {
      IDbConnection dbConnection = new SqlConnection(_connectionString);
      return dbConnection.Query<T>(sql);
    }

    public T LoadDataSingle<T>(string sql)
    {
      IDbConnection dbConnection = new SqlConnection(_connectionString);
      return dbConnection.QuerySingle<T>(sql);
    }

    public bool ExecuteSql<T>(string sql)
    {
      IDbConnection dbConnection = new SqlConnection(_connectionString);
      return (dbConnection.Execute(sql) > 0);
    }

    // public ExecuteSql(){
    //   IDbConnection dbConnection = new SqlConnection(_connectionString);
    // }
  }
};