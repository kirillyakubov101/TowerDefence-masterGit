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
			health = Mathf.Max(health - damage,0);
			
			if(health == 0)
			{

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
	}
}
