using System;

namespace tedeeClient.Core.Result;

public class ErrorApiResult : ApiResult
{
    public required Exception? Exception { get; init; }
    public required string Message { get; init; }
}
public class ErrorApiResult<TResult> : ApiResult<TResult>
{
	public required Exception? Exception { get; init; }
	public required string Message { get; init; }
}