using tedeeClient.Core;
using tedeeClient.Core.TedeeClientConfiguration;
using tedeeClient.Local;
using tedeeClient.Local.Extensions;
using tedeeClient.Local.TedeeClientConfiguration;

const string API_TOKEN = "3yFwPqR8JbPt";
const string LOCAL_IP_ADDRESS = "192.168.0.211";

const int LOCK_ID = 117339;


var localConfiguration = new LocalTedeeClientConfiguration
{
	BridgeIpAddress = LOCAL_IP_ADDRESS,
	ApiToken = API_TOKEN,
	IsApiTokenEncrypted = false,
	ApiVersion = EApiVersion.V1_0,
};

var factory = new TedeeApiClientFactory();
var client = factory.BuildLocalClient(localConfiguration);


var bridgeDetail = await client.GetBridgeDetails();
//var locks = await client.GetLocks();
//var lockDetail = await client.GetLockDetails(LOCK_ID);
//await client.LockLock(LOCK_ID);
//await client.UnlockLock(LOCK_ID);
//await client.PullLock(LOCK_ID);


Console.WriteLine("");



//TODO: on cloud implementation:
//TODO: - Bridge Item how to handle non intersecting properties?
//TODO: - How to handle non intersecting calls?

//TODO: how to structure request execution


//TODO: partial mapper keys in different binaries?






