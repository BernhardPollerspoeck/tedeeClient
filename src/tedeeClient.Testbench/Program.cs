using tedeeClient.Core;
using tedeeClient.Core.Enumerations;

const string API_TOKEN = "3yFwPqR8JbPt";
const int LOCK_ID = 117339;


var client = new TedeeApiClient(
	ipAddress: "192.168.0.211",
	//connectionMode: EConnectionMode.Local,
	apiVersion: EApiVersion.V1_0,
	apiToken: API_TOKEN,
	encryptToken: false);


var bridgeDetail = await client.GetBridgeDetails();
//var locks = await client.GetLocks();
//var lockDetail = await client.GetLockDetails(LOCK_ID);
//await client.LockLock(LOCK_ID);
//await client.UnlockLock(LOCK_ID);
//await client.PullLock(LOCK_ID);


Console.WriteLine("");







