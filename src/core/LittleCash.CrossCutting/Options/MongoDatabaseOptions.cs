namespace LittleCash.CrossCutting.Options;

public class MongoDatabaseOptions
{
    public string ConnectionString { get; init; } = default;
    public string DatabaseName { get; set; }
}