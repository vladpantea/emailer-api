using Emailer.API.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Emailer.API.Services
{
    public class EmailService : IEmailService
    {
        private readonly IMongoCollection<Email> _emails;
        private readonly IMongoDatabase _mongoDB;

        private readonly MongoClient _mongoClient;

        public EmailService(IEmailDatabaseSettings settings)
        {
            try
            {
                _mongoClient = new MongoClient(settings.ConnectionString);

                _mongoDB = _mongoClient.GetDatabase(settings.DatabaseName);

                _emails = _mongoDB.GetCollection<Email>(settings.EmailCollectionName);
            }
            catch (MongoDB.Driver.MongoConnectionException ex)
            {
                throw ex;
            }
        }

        public List<Email> Get() => _emails.Find(email => true).ToList();
        
        public Email Get(string id) => _emails.Find<Email>(email => email.Id == id).FirstOrDefault();

        public Email Create(Email email)
        {   
            
            _emails.InsertOne(email);
            return email;
        }

        public void Update(string id, Email newEmail) => _emails.ReplaceOne(email => email.Id == id, newEmail);

        public void Remove(string id) => _emails.DeleteOne(email => email.Id == id);
    }
}