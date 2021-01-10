using UnityEngine;
using TowerDefence.AI;
using System;

namespace TowerDefence.Friendly
{
	public class FriendlyFighter : MonoBehaviour
	{
		[SerializeField] private bool isFightingSomeone = false;
		[SerializeField] float health = 20f;


		public void TakeDamage(float damage,Fighter instigator)
		{
			health = Mathf.Max(health - damage, 0f);

			if (health <= 0f)
			{
				instigator.StopAttacking();
				Destroy(gameObject);
			}
		}

		public bool GetIsFightingSomeone()
		{
			return isFightingSomeone;
		}

		public void SetIsFightingSomeone(bool value)
		{
			isFightingSomeone = value;
		}
	}
}

