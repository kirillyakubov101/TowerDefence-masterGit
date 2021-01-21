using System;
using TowerDefence.Core;
using UnityEngine;

namespace TowerDefence.AI
{
	public class Death : MonoBehaviour
	{
		[SerializeField] ParticleSystem deathCoins = null;
		[SerializeField] int goldAmount = 50;

		Animator animator;
		LevelController levelController;
		AiController aiController;

		public static event Action onCoinGained;

		private bool isDead = false;

		// Start is called before the first frame update
		void Awake()
		{
			levelController = FindObjectOfType<LevelController>();
			aiController = GetComponent<AiController>();
			animator = GetComponent<Animator>();
		}

		public void Die()
		{
			if(isDead == true) { return; }
			isDead = true;
			animator.SetTrigger("die");
			aiController.StopAgent();
			deathCoins.Play();

			//sound effect event
			onCoinGained?.Invoke();

			if (levelController) //it is avoid null in the sandBox, the IF can be removed later
			{
				levelController.GainGold(goldAmount);
				levelController.ReduceEnemy();
			}
			
			Destroy(gameObject, 1f);

		}
	}

}
