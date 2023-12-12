using Labb3_NET22.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3_NET22.Data
{
    internal class MongoCRUD
    {
        private IMongoDatabase db;

        public MongoCRUD(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);
        }

        public void AddQuestion(string table, Question question)
        {
            var collection = db.GetCollection<Question>(table);
            collection.InsertOne(question);
        }

        public void UpdateQuestion(string table, Question question)
        {
            var collection = db.GetCollection<Question>(table);

            collection.ReplaceOne(x => x.Id == question.Id, question, new ReplaceOptions { IsUpsert = false });
        }

        public List<Question> GetAllQuestions(string table)
        {
            var collection = db.GetCollection<Question>(table);
            return collection.Find(_ => true).ToList();
        }

        public void DeleteQuestion(string table, Question question)
        {
            var collection = db.GetCollection<Question>(table);
            collection.DeleteOne(q => q.Id == question.Id);
        }
    }
}
