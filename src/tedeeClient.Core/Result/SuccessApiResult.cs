namespace tedeeClient.Core.Result;

public class SuccessApiResult : ApiResult
{
}
public class SuccessApiResult<TResult> : ApiResult<TResult>
	where TResult : class
{
	public required TResult? Result { get; init; }
}