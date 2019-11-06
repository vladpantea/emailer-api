using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Emailer.API.Models
{
    public class Email
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string From { get; set; }

        [Required]
        public List<string> To { get; set; }

        public List<string> CC { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 6)]
        public string Content { get; set; }

        public decimal Updated { get; set; }
    }
}