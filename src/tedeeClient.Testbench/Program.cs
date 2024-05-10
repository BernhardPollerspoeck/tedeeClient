using tedeeClient.Core;
using tedeeClient.Core.Enumerations;

const int LOCK_ID = 117339;


var client = new TedeeApiClient(
	ipAddress: "192.168.0.211",
	apiVersion: EApiVersion.V1_0,
	apiToken: API_TOKEN,
	encryptToken: false);


var bridgeDetail = await client.GetBridgeDetails();
var locks = await client.GetLocks();

//var lockResult = await client.LockLock(LOCK_ID);
//var unlockResult = await client.UnlockLock(LOCK_ID);
//var pullResult = await client.PullLock(LOCK_ID);
await Task.Delay(2000);

var lockDetail = await client.GetLockDetails(LOCK_ID);


Console.WriteLine("");







