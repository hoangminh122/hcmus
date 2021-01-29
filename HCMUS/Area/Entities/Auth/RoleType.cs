using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCMUS.src.Entities.Auth
{
    public class RoleType
    {
        [BsonElement("code")]
        public string Code { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("date_created")]
        public string DateCreated { get; set; }

        [BsonElement("date_updated")]
        public DateTime DateUpdated { get; set; }
    }
}
