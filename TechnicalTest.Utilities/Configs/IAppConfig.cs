namespace TechnicalTest.Utilities.Configs
{
    public interface IAppConfig
    {
        string ConnectionString { get; }
        string SecretKey { get; }
        string MaxHours { get; }
        string LeaderNotFound { get; }
    }
}