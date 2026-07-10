using EFCore.BulkExtensions;
using RetailInventory.Data;

using var context = new AppDbContext();

var products = context.Products.ToList();

foreach (var product in products)
{
    product.Price += 100;
}

context.BulkUpdate(products);

Console.WriteLine("Bulk Update Completed!");

var deleteProducts = context.Products
                            .Where(p => p.Price > 5000)
                            .ToList();

context.BulkDelete(deleteProducts);

Console.WriteLine("Bulk Delete Completed!");