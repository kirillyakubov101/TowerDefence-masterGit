using TowerDefence.Friendly;
using UnityEngine;
using TowerDefence.Statistics;

namespace TowerDefence.AI
{
	public class Health : MonoBehaviour
	{
		[SerializeField] StatsConfig statsConfig = null;

		[SerializeField] float health;
		float maxHealth;
		Death death;

		//For mage
		public bool HasShield { get; set; }

		private void Awake()
		{
			death = GetComponent<Death>();
		}

		private void Start()
		{
			health = statsConfig.Health;
			maxHealth = health;
		}

		//from towers and projectiles
		public void takeDamage(float damage)
		{
			if (HasShield) { return; }
			health = Mathf.Max(health - damage,0);
			
			if(health == 0)
			{

				death.Die();

				Destroy(this);
			}

		}

		//from soldiers
		public void takeDamageFromSoldiers(float damage,FriendlyFighter instigator)
		{
			health = Mathf.Max(health - damage, 0);

			if (health == 0)
			{
				instigator.StopAttacking();
				death.Die();

				Destroy(this);
			}
		}

		public float GetHealth()
		{
			return health;
		}

		public float GetMaxHealth()
		{
			return maxHealth;
		}

		public StatsConfig StatsConfig { get => statsConfig;  }
	}
}
