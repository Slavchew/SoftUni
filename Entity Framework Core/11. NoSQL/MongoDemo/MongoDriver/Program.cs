using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace MongoDriver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MongoClient client = new MongoClient("mongodb://127.0.0.1:27017");
            var datebase = client.GetDatabase("Softuni");
            var collection = datebase.GetCollection<BsonDocument>("Students");
            var student = new BsonDocument
            {
                { "name", "peshoStudent" }
            };
            collection.InsertOne(student);

            var allStudents = collection.Find<BsonDocument>(new BsonDocument()).ToList();

            foreach (var item in allStudents)
            {
                Console.WriteLine(item);
            }
        }
    }
}
