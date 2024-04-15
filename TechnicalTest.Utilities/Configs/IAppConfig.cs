namespace TechnicalTest.Utilities.Interfaces
{
    public interface IAppConfig
    {
        string ConnectionString { get; }
        string SecretKey { get; }
        string MaxHours { get; }
        string LeaderNotFound { get; }
    }
}