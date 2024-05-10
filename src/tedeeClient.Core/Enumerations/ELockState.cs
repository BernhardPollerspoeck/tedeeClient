namespace tedeeClient.Core.Enumerations;

public enum ELockState
{
    Uncalibrated = 0,
    Calibration = 1,
    Open = 2,
    PartiallyOpen = 3,
    Opening = 4,
    Closing = 5,
    Closed = 6,
    PullSpring = 7,
    Pulling = 8,
    Unknown = 9,
    Unpulling = 255,
}

//{
//Lock state: 0-uncalibrated, 1-calibration, 2-open, 3-partially_open,
//4-opening, 5-closing, 6-closed, 7-pull_spring, 8-pulling, 9-unknown,
//255-unpulling


//Lock type: 2 - Lock PRO, 4 - Lock GO
// "type": 4,
// "id": 117339,
// "name": "Haustüre",
// "serialNumber": "24120402-000441",
// "isConnected": 1,
// "rssi": -74,
//  "deviceRevision": 7,
//  "version": "2.0.22238",
//  "state": 2,
//  "jammed": 0,
//  "batteryLevel": 99,
//  "isCharging": 0,
//  "deviceSettings": {
//    "autoLockEnabled": 0,
//    "autoLockDelay": 60,
//    "autoLockImplicitEnabled": 0,
//    "autoLockImplicitDelay": 5,
//    "pullSpringEnabled": 1,
//    "pullSpringDuration": 2,
//    "autoPullSpringEnabled": 0,
//    "postponedLockEnabled": 1,
//    "postponedLockDelay": 5,
//    "buttonLockEnabled": 1,
//    "buttonUnlockEnabled": 1
//  }
//}