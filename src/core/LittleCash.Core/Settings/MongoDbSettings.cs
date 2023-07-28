namespace LittleCash.Core.Settings;

public class MongoDbSettings
{
    public string ConnectionString { get; init; } = default!;
    public bool EnableCaptureCommandText { get; init; } = false;
    public string DatabaseName { get; set; }
}