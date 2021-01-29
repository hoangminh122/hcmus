using HCMUS.src.Entities.Applicant;
using HCMUS.src.Modules.Database;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCMUS.src.Modules.Test
{
    public class TestService : ITestService
    {
        //private readonly IMongoRepository<AppUsers, ObjectId> _repository;

        //public TestService(IMongoRepository<AppUsers, ObjectId> repository)
        //{
        //    _repository = repository;
        //}
        //public async Task<IEnumerable<AppUsers>> GetAll()
        //{
        //    try
        //    {
        //        var result = await _repository.GetAllListAsync();
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public Task<IEnumerable<AppUsers>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
