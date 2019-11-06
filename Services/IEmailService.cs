using Emailer.API.Models;
using System.Collections.Generic;

namespace Emailer.API.Services
{
    public interface IEmailService
    {
        List<Email> Get();
        public Email Get(string id);
        public Email Create(Email email);

        public void Update(string id, Email newEmail);

        public void Remove(string id);
    }
}