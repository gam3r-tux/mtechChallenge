using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace com.test.employees.api.Models
{
    [Serializable]
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [MinLength(10)]
        [MaxLength(13)]
        [RegularExpression(@"^[a-zñA-ZÑ]{4}([0][1-9]|[1-9][0-9])([0][1-9]|[1][0-2])([0][1-9]|[1][0-9]|[2][0-9]|[3][0-1])([a-zñA-ZÑ\d]{3})?$",
         ErrorMessage = "RFC format not well formed.")]

        [BsonElement("rfc")]
        public string RFC { get; set; }

        [BsonElement("bornDate")]
        public DateTime BornDate { get; set; }

        [BsonElement("status")]
        public int Status { get; set; }
    }
}
