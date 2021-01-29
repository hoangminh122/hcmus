using HCMUS.src.Entities.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCMUS.src.Entities.Applicant
{
    public class Students : IEntity<ObjectId>
    {
        public ObjectId Id { get; set; }

        [BsonElement("student_id")]
        public string StudentId;

        [BsonElement("last_name")]
        public string LastName;
    }
}
