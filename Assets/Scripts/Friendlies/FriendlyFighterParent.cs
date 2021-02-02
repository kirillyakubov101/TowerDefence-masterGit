using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Friendly
{
	public class FriendlyFighterParent : MonoBehaviour
	{
		public int count = 0;
		public FriendlyFighter[] childrenFighter = new FriendlyFighter[0];


		private void OnEnable()
		{
			foreach (var child in childrenFighter)
			{
				child.OnDeath += HandleChildDeath;
			}
		}

		private void OnDisable()
		{
			foreach (var child in childrenFighter)
			{
				child.OnDeath -= HandleChildDeath;
			}
		}

		//if all children are dead, remove this object
		private void HandleChildDeath()
		{
			count++;
			if (count == 2)
			{
				Destroy(gameObject);
			}
			
		}
	}
}


