using UnityEngine;

namespace TowerDefence.AI
{
	public class Health : MonoBehaviour
	{
		[SerializeField] float health = 100f;

		float maxHealth;

		Death death;

		private void Awake()
		{
			death = GetComponent<Death>();
		}

		private void Start()
		{
			maxHealth = health;
		}

		public void takeDamage(float damage)
		{
			if (damage >= health)
			{
				health = 0;
				death.Die();
				Destroy(this);
			}

			health -= damage;

		}

		public float GetHealth()
		{
			return health;
		}

		public float GetMaxHealth()
		{
			return maxHealth;
		}
	}
}
