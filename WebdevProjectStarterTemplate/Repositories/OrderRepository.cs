using System.Data;
using Dapper;
using WebdevProjectStarterTemplate.Models;

namespace WebdevProjectStarterTemplate.Repositories;

public class OrderRepository
{
    private IDbConnection GetConnection()
    {
        return new DbUtils().GetDbConnection();
    }
    
    public OrderLine Add(int ProductId)
    {
        string sql = @"
                INSERT INTO orderline (ProductId, TableId, Amount) 
                VALUES (@ProductId, 1, 1); 
                SELECT * FROM orderline WHERE ProductId = @ProductId AND TableId = 1";
            
        using var connection = GetConnection();
        var addedOrderline = connection.QuerySingle<OrderLine>(sql, new {ProductId});
        return addedOrderline;
    }
}