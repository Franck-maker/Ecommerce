using Catalog.Core.Entities;
using Catalog.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Text.Json;


///<summary>
///It'll help initialize the database with seed data
///</summary>
namespace Catalog.Infrastructure.Data
{
    public class DatabaseSeeder
    {
        public static async Task SeedAsync(IOptions<DatabaseSettings> options)
        {
            var settings = options.Value;
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);
            var types = db.GetCollection<ProductType>(settings.TypeCollectionName);
            var brands = db.GetCollection<ProductBrand>(settings.BrandCollectionName);
            var products = db.GetCollection<Product>(settings.ProductCollectionName);

            var SeedBasePath = Path.Combine("Data", "SeedData");

            //Seed Brands 
            List<ProductBrand> brandList = new();
            if((await brands.CountDocumentsAsync(_ => true) == 0))
            {
                var brandData = await File.ReadAllTextAsync(Path.Combine(SeedBasePath, "brands.json")); 
                brandList = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                await brands.InsertManyAsync(brandList);
            }
            else
            {
                // just assign the list to BrandList
                brandList = await brands.Find(_ => true).ToListAsync();
            }

            //Seed Types 
            List<ProductType> TypeList = new();
            if ((await types.CountDocumentsAsync(_ => true) == 0))
            {
                var typeData = await File.ReadAllTextAsync(Path.Combine(SeedBasePath, "types.json"));
                TypeList = JsonSerializer.Deserialize<List<ProductType>>(typeData);
                await types.InsertManyAsync(TypeList);
            }else
            {
                // just assign the list to TypeList
                TypeList = await types.Find(_ => true).ToListAsync();
            }

            //Seed Products 
            List<Product> productList = new();
            if ((await products.CountDocumentsAsync(_ => true) == 0))
            {
                var productData = await File.ReadAllTextAsync(Path.Combine(SeedBasePath, "products.json"));
                productList = JsonSerializer.Deserialize<List<Product>>(productData);
                foreach(var product in productList)
                {
                    //Reset Id to let Mongo generate one 
                    product.Id = null;
                    //Default Created Date if not set
                    if (product.CreatedDate == default)
                    {
                        product.CreatedDate = DateTime.UtcNow; 
                    }
                }
                await products.InsertManyAsync(productList);
            }
        }



    }
    
}
