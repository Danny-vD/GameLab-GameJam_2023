﻿using System;
using UnityEngine;
using VDFramework;

namespace PhysicsScripts
{
	public class TriggerCallback : BetterMonoBehaviour
	{
		public event Action<Collider> OnTriggerEntered = delegate { };
		public event Action<Collider> OnTriggerExited = delegate { };

		private void OnTriggerEnter(Collider other)
		{
			OnTriggerEntered.Invoke(other);
		}

		private void OnTriggerExit(Collider other)
		{
			OnTriggerExited.Invoke(other);
		}
	}
}