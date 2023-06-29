using System.Data;
using Dapper;
using WebdevProjectStarterTemplate.Models;

namespace WebdevProjectStarterTemplate.Repositories;

public class RegisterRepository
{
    private IDbConnection GetConnection()
    {
        return new DbUtils().GetDbConnection();
    }
    
    

    public void Set(string Username, string Password, string Mail)
    {
        var Connection = GetConnection();
        string sql = @"INSERT INTO Gebruiker (Username, Password, Mail)
                VALUES  (@Username, @Password, @Mail)";
        var execute = Connection.Execute(sql, new {Username, Password, Mail});
    }

    public int count(string Username)
    {
        string sql = @"SELECT COUNT(UserId) FROM gebruiker WHERE Username= @Username";
        using var connection = GetConnection();
        int count = connection.ExecuteScalar<int>(sql, new { Username });
        return count;
    }
            
            
}