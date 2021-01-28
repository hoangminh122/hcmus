using HCMUS.src.Entities.Base;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCMUS.src.Entities.Applicant
{
    public class AppUsers : IEntity<ObjectId>
    {
        public string FirstName { get; set; }


        public ObjectId Id { get; set; }
    }
}
