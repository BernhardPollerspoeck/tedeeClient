using System;

namespace tedeeClient.Core.Dtos;

public record LockSettingDto(
	bool AutoLockEnabled,
	TimeSpan AutoLockDelay,
	bool AutoLockImplicitEnabled,
	TimeSpan AutoLockImplicitDelay,
	bool PullSpringEnabled,
	TimeSpan PullSpringDuration,
	bool AutoPullSpringEnabled,
	bool PostponedLockEnabled,
	TimeSpan PostponedLockDelay,
	bool ButtonLockEnabled,
	bool ButtonUnlockEnabled);