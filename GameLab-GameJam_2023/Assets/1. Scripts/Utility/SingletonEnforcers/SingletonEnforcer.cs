using UnityEngine;
using VDFramework;
using VDFramework.Singleton;

namespace Utility.SingletonEnforcers
{
	public class SingletonEnforcer<TSingleton> : BetterMonoBehaviour where TSingleton : Singleton<TSingleton>
	{
		[SerializeField]
		private TSingleton singleton;

		private void Awake()
		{
			if (Singleton<TSingleton>.IsInitialized)
			{
				Destroy(singleton);
				return;
			}
			
			singleton.gameObject.SetActive(true);
		}
	}
}
