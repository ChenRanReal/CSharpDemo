using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using System;

namespace ConnstringStringBuildDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var oracsb = new OracleConnectionStringBuilder()
            {
                DataSource = "//host:[port]/[service_name]",//oracle端口非默認的1521端口時，可如此填寫即：//host:port/service_name，如為1521，可按如下幾種方式填寫1、//host/service_name，2：host/service_name，3：host
                UserID = "userid",
                Password = "password",
            };
            using (var conn = new OracleConnection(oracsb.ConnectionString))
            {
                conn.Open();
                Console.WriteLine("Oracle 連接成功");
            }

            var mysqlcbs = new MySqlConnectionStringBuilder()
            {
                Server = "host",
                UserID = "userid",
                Password = "password",
                Port = 3306,//默認值
                Database = "database",//默認數據庫
                SslMode = MySqlSslMode.Disabled,
                CharacterSet = "utf8"
            };

            using (var conn = new MySqlConnection(mysqlcbs.ConnectionString))
            {
                conn.Open();
                Console.WriteLine("MySql 連接成功");
            }

            var mssqlcbs = new SqlConnectionStringBuilder()
            {
                DataSource = "host,port",
                UserID = "userid",
                Password = "password",
                Encrypt = false,
            };
            using (var conn = new SqlConnection(mssqlcbs.ConnectionString))
            {
                conn.Open();
                Console.WriteLine("MsSql 連接成功");
            }

            var pgsqlcbs = new NpgsqlConnectionStringBuilder()
            {
                Username = "username",
                Password = "password",
                Host = "host",
                Port = 5433,
                Database = "database"
            };
            using (var conn = new NpgsqlConnection(pgsqlcbs.ConnectionString))
            {
                conn.Open();
                Console.WriteLine("PgSql 連接成功");
            }
            Console.ReadLine();
        }
    }
}