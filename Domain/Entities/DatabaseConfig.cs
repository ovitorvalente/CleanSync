namespace CleanSync.Domain.Entities
{
    public class DatabaseConfig
    {
        public string DataSource { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int Timeout { get; set; }
    }
}
