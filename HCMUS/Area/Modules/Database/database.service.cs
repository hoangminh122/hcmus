using HCMUS.src.Entities.Base;
using HCMUS.src.Entities.Setting;
using HCMUS.src.Shared.Filters;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HCMUS.src.Modules.Database
{
    public class MongoRepository<TEntity, TprimaryKey> : IMongoRepository<TEntity, TprimaryKey> where TEntity : class, IEntity<TprimaryKey>
    {

        private readonly IMongoDatabase _database = null;

        public MongoRepository(IOptions<MongoDbSettings> mongoConfiguration)
        {
            var client = new MongoClient(mongoConfiguration.Value.ConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase(mongoConfiguration.Value.Database);
            }
        }

        public async Task<List<TEntity>> GetAllListAsync(FilterDefinition<TEntity> filterResult, PaginationFilter page)
        {
           return await Collection.Find(filterResult)
                        .Skip((page.PageNumber - 1) * page.PageSize)
                            .Limit(page.PageSize)
                                .ToListAsync();
        }

        public IMongoCollection<TEntity> Collection
        {
            get
            {
                return _database.GetCollection<TEntity>(typeof(TEntity).Name);
            }
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predication)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TprimaryKey id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> predication)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(TprimaryKey id)
        {
            throw new NotImplementedException();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity FirstOrDefault(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public TEntity FirstOrDefault(TprimaryKey id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FirstOrDefaultAsync(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FirstOrDefaultAsync(TprimaryKey id)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(TprimaryKey id)
        {
            throw new NotImplementedException();
        }

        public  IQueryable<TEntity> GetAll()
        {
            return  Collection.Find(_ => true).ToList().AsQueryable();
        }

        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAllList()
        {
            return Collection.Find(_ => true).ToList();
        }

        public List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> GetAllListAsync()
        {
            return await Collection.Find(_ => true).ToListAsync();
        }

        public Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }


        public Task<TEntity> GetAsync(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(TprimaryKey id)
        {
            throw new NotImplementedException();
        }


        public TEntity Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TprimaryKey InsertAndGetId(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TprimaryKey> InsertAndGetIdAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await Collection.InsertOneAsync(entity);
            return entity;
        }

        public TEntity InsertOrUpdate(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TprimaryKey InsertOrUpdateAndGetId(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TprimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> InsertOrUpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Load(TprimaryKey id)
        {
            throw new NotImplementedException();
        }

        public long LongCount()
        {
            throw new NotImplementedException();
        }

        public long LongCount(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T Query<T>(Func<IQueryable<TEntity>, T> queryMethod)
        {
            throw new NotImplementedException();
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TprimaryKey id, Action<TEntity> updateAction)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(ObjectId id, Func<TEntity, Task<TEntity>> updateAction)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TprimaryKey id, Func<TEntity, Task> updateAction)
        {
            throw new NotImplementedException();
        }

        void IMongoRepository<TEntity, TprimaryKey>.Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void IMongoRepository<TEntity, TprimaryKey>.Delete(TprimaryKey id)
        {
            throw new NotImplementedException();
        }

        void IMongoRepository<TEntity, TprimaryKey>.Delete(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task IMongoRepository<TEntity, TprimaryKey>.DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task IMongoRepository<TEntity, TprimaryKey>.DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        Task IMongoRepository<TEntity, TprimaryKey>.DeleteAsync(TprimaryKey id)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetByIdAsync(TprimaryKey id)
        {
            return await Collection
                .Find(x => x.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public Task<TEntity> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(TprimaryKey id)
        {
            return  Collection
                .Find(x => x.Id.Equals(id))
                .FirstOrDefault();
        }
    }

}
