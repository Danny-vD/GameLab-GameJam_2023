using UnityEngine;
using Utility.PhysicsUtil;
using VDFramework;
using VDFramework.Extensions;

namespace VFX
{
	public class SpawnParticlesOnFall : BetterMonoBehaviour
	{
		[SerializeField]
		private GameObject firstTimeSpawn;

		[SerializeField]
		private GameObject[] particles;

		private GroundedChecker groundedChecker;

		private bool spawnedFirst = false;

		private bool falling = true;
		
		private void Awake()
		{
			groundedChecker = GetComponent<GroundedChecker>();
		}

		private void Update()
		{
			if (groundedChecker.IsGrounded)
			{
				if (falling)
				{
					SpawnParticle(groundedChecker.ContactPoints.GetRandomElement().point);

					falling = false;
					return;
				}
			}
			else
			{
				falling = true;
			}
		}

		private void SpawnParticle(Vector3 position)
		{
			if (spawnedFirst)
			{
				Instantiate(particles.GetRandomElement(), position, Quaternion.identity);
			}
			else
			{
				Instantiate(firstTimeSpawn, position, Quaternion.identity);
				spawnedFirst = true;
			}
		}
	}
}