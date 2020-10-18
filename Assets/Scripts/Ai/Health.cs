using TowerDefence.Core;
using UnityEngine;

namespace TowerDefence.AI
{
	public class Health : MonoBehaviour
	{
		[SerializeField] float health = 100f;
		[SerializeField] int goldAmount = 50;
		[SerializeField] ParticleSystem deathCoins = null;

		Animator animator;
		LevelController levelController;
		AiController aiController;


		private void Awake()
		{
			levelController = FindObjectOfType<LevelController>();
			aiController = GetComponent<AiController>();
			animator = GetComponent<Animator>();
		}

		public void takeDamage(float damage)
		{
			if (damage >= health)
			{
				Die();
			}

			health -= damage;

		}

		private void Die()
		{
			animator.SetTrigger("die");
			health = 0;
			aiController.StopAgent();
			deathCoins.Play();
			levelController.GainGold(goldAmount);
			Destroy(gameObject, 1f);

		}
	}
}
