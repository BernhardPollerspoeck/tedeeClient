using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using tedeeClient.Core.ApiModels;

namespace tedeeClient.Core;

public class RequestExecutor
{
	public async Task<ApiResult<TResult>> ExecuteGet<TResult>(string url)
		where TResult : class
	{
		var client = new HttpClient();
		try
		{
			var resonse = await client.GetAsync(url);
			return new ApiResult<TResult>
			{
				Success = resonse.IsSuccessStatusCode,
				Result = resonse.IsSuccessStatusCode
					? JsonSerializer.Deserialize<TResult>(await resonse.Content.ReadAsStreamAsync())
					: null,
				Message = resonse.IsSuccessStatusCode
					? null
					: await resonse.Content.ReadAsStringAsync()
			};
		}
		catch (Exception ex)
		{
			return new ApiResult<TResult>
			{
				Success = false,
				Result = default,
				Message = ex.Message,
			};
		}
	}
	public async Task<ApiResult> ExecutePost(string url)
	{
		var client = new HttpClient();
		try
		{
			var resonse = await client.PostAsync(url, null);
			return new ApiResult
			{
				Success = resonse.IsSuccessStatusCode,
				Message = resonse.IsSuccessStatusCode
					? null
					: await resonse.Content.ReadAsStringAsync()
			};
		}
		catch (Exception ex)
		{
			return new ApiResult
			{
				Success = false,
				Message = ex.Message,
			};
		}
	}
}