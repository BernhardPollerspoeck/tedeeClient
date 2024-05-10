using System;
using System.Text.Json.Serialization;
using tedeeClient.Core.Converters;

namespace tedeeClient.Core.Dtos;

public record LockSettingDto(
	[property:
		JsonPropertyName("autoLockEnabled"),
		JsonConverter(typeof(IntBoolConverter))]
			bool AutoLockEnabled,
	[property:
		JsonPropertyName("autoLockDelay"),
		JsonConverter(typeof(IntTimeSpanConverter))]
			TimeSpan AutoLockDelay,
	[property:
		JsonPropertyName("autoLockImplicitEnabled"),
		JsonConverter(typeof(IntBoolConverter))]
			bool AutoLockImplicitEnabled,
	[property:
		JsonPropertyName("autoLockImplicitDelay"),
		JsonConverter(typeof(IntTimeSpanConverter))]
			TimeSpan AutoLockImplicitDelay,
	[property:
		JsonPropertyName("pullSpringEnabled"),
		JsonConverter(typeof(IntBoolConverter))]
			bool PullSpringEnabled,
	[property:
		JsonPropertyName("pullSpringDuration"),
		JsonConverter(typeof(IntTimeSpanConverter))]
			TimeSpan PullSpringDuration,
	[property:
		JsonPropertyName("autoPullSpringEnabled"),
		JsonConverter(typeof(IntBoolConverter))]
			bool AutoPullSpringEnabled,
	[property:
		JsonPropertyName("postponedLockEnabled"),
		JsonConverter(typeof(IntBoolConverter))]
			bool PostponedLockEnabled,
	[property:
		JsonPropertyName("postponedLockDelay"),
		JsonConverter(typeof(IntTimeSpanConverter))]
			TimeSpan PostponedLockDelay,
	[property:
		JsonPropertyName("buttonLockEnabled"),
		JsonConverter(typeof(IntBoolConverter))]
			bool ButtonLockEnabled,
	[property:
		JsonPropertyName("buttonUnlockEnabled"),
		JsonConverter(typeof(IntBoolConverter))]
			bool ButtonUnlockEnabled);