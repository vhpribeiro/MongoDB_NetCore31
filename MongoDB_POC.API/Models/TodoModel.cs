using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoDB_POC.API.Models
{
    public class TodoModel
    {
        [BsonId]
        public ObjectId TodoId { get; set; }
        [BsonRequired]
        public string Title { get; set; }
        public bool Completed { get; set; }
        public DateTime? OptimalLine { get; set; }
    }
}
