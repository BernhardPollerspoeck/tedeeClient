using tedeeClient.Core;
using tedeeClient.Core.Enumerations;

const string API_TOKEN = "3yFwPqR8JbPt";
const string LOCAL_IP_ADDRESS = "192.168.0.211";

const int LOCK_ID = 117339;


ITedeeClientConfiguration localConfiguration = new LocalTedeeClientConfiguration
{
	BridgeIpAddress = LOCAL_IP_ADDRESS,
	ApiToken = API_TOKEN,
	IsApiTokenEncrypted = false,
};
ITedeeClientConfiguration cloudConfiguration = new CloudTedeeClientConfiguration
{

};

var client = new TedeeApiClient(
	clientConfiguration: localConfiguration,
	apiVersion: EApiVersion.V1_0);


var bridgeDetail = await client.GetBridgeDetails();
var locks = await client.GetLocks();
var lockDetail = await client.GetLockDetails(LOCK_ID);
//await client.LockLock(LOCK_ID);
//await client.UnlockLock(LOCK_ID);
//await client.PullLock(LOCK_ID);


Console.WriteLine("");







