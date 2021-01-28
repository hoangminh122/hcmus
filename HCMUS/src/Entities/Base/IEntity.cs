using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCMUS.src.Entities.Base
{
    public interface IEntity<TPrimaryKey>
    {
        [BsonId]
        TPrimaryKey Id { get; set; }
    }
}
