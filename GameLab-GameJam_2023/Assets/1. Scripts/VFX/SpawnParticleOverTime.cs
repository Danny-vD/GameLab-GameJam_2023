using System;
using Events.Gameplay;
using UnityEngine;
using Utility.PhysicsUtil;
using VDFramework;
using VDFramework.Extensions;
using VDFramework.Utility.TimerUtil;
using VDFramework.Utility.TimerUtil.TimerHandles;

namespace VFX
{
	public class SpawnParticleOverTime : BetterMonoBehaviour
	{
		[SerializeField]
		private float timeBetweenSpawns = 5;

		[SerializeField]
		private GameObject[] particleSystemsToSpawn;

		private GroundedChecker groundedChecker;

		private TimerHandle timerHandle;

		private void Awake()
		{
			groundedChecker = GetComponent<GroundedChecker>();
		}

		private void Start()
		{
			PlayerReachedGroundEvent.ParameterlessListeners += Enable;

			Disable();

			timerHandle = TimerManager.StartNewTimer(timeBetweenSpawns, SpawnParticle, true);
		}

		private void Update()
		{
			timerHandle.SetPause(!groundedChecker.IsGrounded);
		}

		private void Enable()
		{
			enabled = true;
		}

		private void Disable()
		{
			enabled = false;
		}

		private void SpawnParticle()
		{
			Vector3 position = groundedChecker.ContactPoints.GetRandomElement().point;

			Instantiate(particleSystemsToSpawn.GetRandomElement(), position, Quaternion.identity);
		}

		private void OnDestroy()
		{
			PlayerReachedGroundEvent.ParameterlessListeners -= Enable;
		}
	}
}