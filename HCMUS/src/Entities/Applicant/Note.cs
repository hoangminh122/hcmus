﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCMUS.src.Entities.Applicant
{
    public class Note
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InternalId { get; set; }

        [BsonElement("id")]
        //[Column("id")]
        // [Required]
        public string Id { get; set; }

        [BsonElement("body")]
        public string Body { get; set; } = string.Empty;

        [BsonDateTimeOptions]
        [BsonElement("updated_on")]
        public DateTime UpdatedOn { get; set; } = DateTime.Now;

        [BsonElement("head_image")]
        public NoteImage HeadImage { get; set; }

        [BsonElement("user_id")]
        public int UserId { get; set; } = 0;
    }
}
