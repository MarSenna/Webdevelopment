using System.Data;
using Dapper;
using WebdevProjectStarterTemplate.Models;

namespace WebdevProjectStarterTemplate.Repositories;

public class ProductRepository
{
    private IDbConnection GetConnection()
    {
        return new DbUtils().GetDbConnection();
    }
    
    public IEnumerable<Product> GetProductWithCategory()
    {
        string sql = @"    SELECT * 
                            FROM Product as P
                                JOIN Category as C ON P.CategoryId = C.CategoryId 
                            ORDER BY C.Name, P.Name";
            
        using var connection = GetConnection();
        var productsWithCategory = connection.Query<Product, Category, Product>(
            sql, 
            map: (product, category) =>
            {
                product.Category = category;
                return product;
            }, 
            splitOn: "CategoryId"
        );
        return productsWithCategory;
    }
    
    public IEnumerable<Product> GetProductByCategory(int CategoryId)
    {
        string sql = @"    SELECT * 
                            FROM Product as P
                                JOIN Category as C ON P.CategoryId = C.CategoryId 
                                 WHERE P.CategoryId = @CategoryId
                            ORDER BY C.Name, P.Name";
            
        using var connection = GetConnection();
        var productsByCategory = connection.Query<Product, Category, Product>(
            sql,
            map: (product, category) =>
            {
                product.Category = category;
                return product;
            },
            splitOn: "CategoryId",
            param: new {CategoryId}
        );
        return productsByCategory;
    }
    
    public Product Get(int productId)
    {
        string sql = "SELECT * FROM Product WHERE ProductId = @ProductId";
            
        using var connection = GetConnection();
        Product product = connection.QuerySingle<Product>(sql, new { productId });
        return product;
    }
    
    public Product Add(Product? product)
    {
        string sql = @"
                INSERT INTO Product (Name, Price, CategoryId) 
                VALUES (@Name, @Price, @CategoryId); 
                SELECT * FROM Product WHERE ProductId = LAST_INSERT_ID()";
            
        using var connection = GetConnection();
        var addedProduct = connection.QuerySingle<Product>(sql, product);
        return addedProduct;
    }
    
    public bool Delete(int ProductId)
    {
        string sql = @"DELETE FROM Product WHERE ProductId = @ProductId";
            
        using var connection = GetConnection();
        int numOfEffectedRows = connection.Execute(sql, new { ProductId });
        return numOfEffectedRows == 1;
    }
    
    public Product Update(Product product)
    {
        string sql = @"
                UPDATE Product SET 
                    Name = @Name, Price = @Price, CategoryId = @CategoryId
                WHERE ProductId = @ProductId;
                SELECT * FROM Product WHERE ProductId = @ProductId";
            
        using var connection = GetConnection();
        var updatedProduct = connection.QuerySingle<Product>(sql, product);
        return updatedProduct;
    }
}