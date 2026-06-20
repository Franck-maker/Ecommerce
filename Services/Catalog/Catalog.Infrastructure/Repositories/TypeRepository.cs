using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        private readonly IMongoCollection<ProductType> _Types;
        public TypeRepository(IOptions<DatabaseSettings> options)
        {
            var settings = options.Value; 
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);
            _Types = db.GetCollection<ProductType>(settings.TypeCollectionName);
        }
        public async Task<IEnumerable<ProductType>> GetAllTypes()
        {
            return await _Types.Find(type => true).ToListAsync();
        }

        public async Task<ProductType> GetByIdAsync(string id)
        {
            return await _Types.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
