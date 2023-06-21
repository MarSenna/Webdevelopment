using System.Data;
using Dapper;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Pages;

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

    // public IEnumerable<OrderLine> GetOrder()
    // {
    //     string sql = "SELECT * FROM orderline ORDER BY Amount";
    //         
    //     using var connection = GetConnection();
    //     var placeorder = connection.Query<OrderLine>(sql);
    //     return placeorder;
    // }

    public IEnumerable<OrderLine> GetOrder()
    {
        string sql = @"    SELECT * 
                            FROM Orderline as O
                                JOIN Product as P ON O.ProductId = P.ProductId WHERE TableId = 1";

        using var connection = GetConnection();
        var placeorder = connection.Query<OrderLine>(sql);
        return placeorder;
    }


    public List<OrderLine> GetOverzicht(int TableId)
    {
        string sql = @"SELECT product.Name, product.Price, orderline.Amount, orderLine.ProductId, orderLine.TableId
        FROM product  INNER JOIN  orderline ON product.ProductId = orderline.ProductId
        WHERE orderline.TableId = @TableId";
        using var connection = GetConnection();
        return connection.Query<OrderLine>(sql, new {TableId}).ToList();
    }
    
    public void Order(int ProductId, int TableId, int AmountAdd) // Increment en decrement
    {
        var connection = GetConnection();
        string sql;
    
        int sqlok = (int) connection.ExecuteScalar<int>(
            $@"SELECT Amount FROM orderline WHERE TableId = @TableId AND ProductId = @ProductId",
            new {ProductId, TableId});
    
        int newAmount = sqlok + AmountAdd;
        if (newAmount > 0)
        {
            sql =
                @"Update orderline SET Amount = Amount + @AmountAdd WHERE ProductId = @ProductId AND TableId = @TableId";
            connection.Execute(sql, new {AmountAdd, ProductId, TableId});
            // return updateOrderLine;
        }
        else if (newAmount <= 0)
        {
            sql = @"DELETE FROM orderLine WHERE ProductId = @ProductId AND TableId = @TableId";
            connection.Execute(sql, new {ProductId, TableId});
            
        }
        else
        {
            sql = @"INSERT INTO orderLine (TableId, ProductId, Amount, AmountPaid) VALUES (@TableId, @ProductId, 1, 0)";
            connection.Execute(sql, new {ProductId, TableId});
        }
    }

    public List<OrderLine> Overzicht(int TableId) 
    {
        string sql =
            @"SELECT product.Name, product.Price, orderline.Amount, orderline.ProductId FROM product INNER JOIN orderline ON product.ProductId = orderline.ProductId WHERE orderline.TableId = @TableId ";
            using var connection = GetConnection();
            return connection.Query<OrderLine>(sql, new {TableId}).ToList();
    }
}