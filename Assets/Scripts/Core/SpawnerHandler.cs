using System.Collections;
using UnityEngine;

namespace TowerDefence.Core
{
	public class SpawnerHandler : MonoBehaviour
	{
		[SerializeField] EnemySpawner[] spawners = new EnemySpawner[0];
		[SerializeField] float timeBetweenSpawn = 10f;

		int numberOfEnemies = 0;

		private void Start()
		{
			InitilaizeNumberOfEnemies();
		}

		private void InitilaizeNumberOfEnemies()
		{
			foreach (EnemySpawner spawner in spawners)
			{
				numberOfEnemies += spawner.GetSumOfEnemiesInAllWaves();
			}
		}

		private void OnEnable()
		{
			VillagersController.onVillagersFinish += HandleStartSpawn;
		}

		private void OnDisable()
		{
			VillagersController.onVillagersFinish -= HandleStartSpawn;
		}

		private void HandleStartSpawn()
		{
			StartCoroutine(StartSpawners());
		}

		IEnumerator StartSpawners()
		{
			foreach (EnemySpawner spawner in spawners)
			{
				spawner.gameObject.SetActive(true);
				yield return new WaitForSeconds(timeBetweenSpawn);
				
			}
		}

		public int GetNumberOfEnemies()
		{
			return numberOfEnemies;
		}
	}
}


