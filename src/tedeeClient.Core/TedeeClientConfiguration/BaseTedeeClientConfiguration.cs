namespace tedeeClient.Core.TedeeClientConfiguration;

public abstract class BaseTedeeClientConfiguration : ITedeeClientConfiguration
{
	public required EApiVersion ApiVersion { get; init; }
}
