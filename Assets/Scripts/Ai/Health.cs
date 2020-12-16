using UnityEngine;

namespace TowerDefence.AI
{
	public class Health : MonoBehaviour
	{
		[SerializeField] float health = 100f;

		Death death;

		private void Awake()
		{
			death = GetComponent<Death>();
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
	}
}
