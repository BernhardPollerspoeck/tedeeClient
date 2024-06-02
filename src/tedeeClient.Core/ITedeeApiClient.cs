using System.Threading.Tasks;
using tedeeClient.Core.Result;

namespace tedeeClient.Core;

public interface ITedeeApiClient
{
	Task<ApiResult<IBridgeItem>> GetBridgeDetails();

}