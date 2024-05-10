using tedeeClient.Core.Enumerations;

namespace tedeeClient.Core.Dtos;

public record LockDto(
	int Id,
	string Name,
	ELockType LockType,
	string SerialNumber,
	bool IsConnected,
	int Rssi,
	int DeviceRevision,
	string Version,
	ELockState State,
	bool Jammed,
	byte BatteryLevel,
	bool IsCharging,
	LockSettingDto DeviceSettings);
