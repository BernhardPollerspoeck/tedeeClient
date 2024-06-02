using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using tedeeClient.Core.Result;

namespace tedeeClient.Core.Request;

public class RequestExecutor
{
    public async Task<ApiResult<TResult>> ExecuteGet<TResult>(TedeeRequest request)
        where TResult : class
    {
        var client = new HttpClient();
        try
        {
            var resonse = await client.GetAsync(request.Url);
            return resonse.IsSuccessStatusCode switch
            {
                true => new SuccessApiResult<TResult>
                {
                    Result = JsonSerializer.Deserialize<TResult>(await resonse.Content.ReadAsStreamAsync())
                },
                _ => new ErrorApiResult<TResult>
                {
                    Exception = null,
                    Message = await resonse.Content.ReadAsStringAsync()
                }
            };
        }
        catch (Exception ex)
        {
            return new ErrorApiResult<TResult>
            {
                Exception = ex,
                Message = ex.Message,
            };
        }
    }

    public async Task<ApiResult> ExecutePost(TedeeRequest request)
    {
        var client = new HttpClient();
        try
        {
            var resonse = await client.GetAsync(request.Url);
            return resonse.IsSuccessStatusCode switch
            {
                true => new SuccessApiResult(),
                _ => new ErrorApiResult
                {
                    Exception = null,
                    Message = await resonse.Content.ReadAsStringAsync()
                }
            };
        }
        catch (Exception ex)
        {
            return new ErrorApiResult
            {
                Exception = ex,
                Message = ex.Message,
            };
        }
    }
}