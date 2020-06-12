using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB_POC.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB_POC.API.Services
{
    public class MongoDbService
    {
        public IMongoCollection<TodoModel> TodoCollection { get; }

        public MongoDbService(string databaseName, string collectionName, string databaseUrl)
        {
            var mongoClient = new MongoClient(databaseUrl);
            var mongoDatabase = mongoClient.GetDatabase(databaseName);
            TodoCollection = mongoDatabase.GetCollection<TodoModel>(collectionName);
        }

        public async Task InsertTodo(TodoModel todo)
        {
            await TodoCollection.InsertOneAsync(todo);
        }

        public async Task<List<TodoModel>> GetAllTodos()
        {
            var todos = new List<TodoModel>();

            var allDocuments = await TodoCollection.FindAsync(new BsonDocument());
            await allDocuments.ForEachAsync(doc => todos.Add(doc));

            return todos;
        }
    }
}
