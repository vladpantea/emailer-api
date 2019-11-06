namespace Emailer.API.Models
{
    public class EmailDatabaseSettings : IEmailDatabaseSettings
    {
        public string EmailCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IEmailDatabaseSettings
    {
        string EmailCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}