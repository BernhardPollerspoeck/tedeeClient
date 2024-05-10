namespace tedeeClient.Core.ApiModels;


public class ApiResult
{
	public required bool Success { get; init; }
	public required string? Message { get; init; }
}

public class ApiResult<TResult> : ApiResult
	where TResult : class
{
	public required TResult? Result { get; init; }
}
