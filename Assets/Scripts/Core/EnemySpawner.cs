﻿using System.Collections;
using System.Collections.Generic;
using TowerDefence.AI;
using UnityEngine;

namespace TowerDefence.Core
{
	public class EnemySpawner : MonoBehaviour
	{
		[SerializeField] List<WaveConfig> waves = null;
		[SerializeField] Transform target;

		private int numberOfEnemies;

		// Start is called before the first frame update
		void Start()
		{
			StartCoroutine(SpawnAllWaves());
		}

		public Transform GetTarget()
		{
			return target;
		}

		//spawns all the waves in the List
		IEnumerator SpawnAllWaves()
		{
			for (int i = 0; i < waves.Count; i++)
			{
				var currentWave = waves[i];
				yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
			}
		}

		IEnumerator SpawnAllEnemiesInWave(WaveConfig wave)
		{

			for (int enemyCount = 0; enemyCount < wave.NumberOfEnemies(); enemyCount++)
			{
				var newEnemy = Instantiate(wave.GetEnemyPrefab(), transform.position, Quaternion.identity);
				newEnemy.transform.parent = transform;
				newEnemy.GetComponent<AiController>().AssignPath(target);
				yield return new WaitForSeconds(wave.TimeBetweenSpawn());
			}
		}

		public int GetSumOfEnemiesInAllWaves()
		{
			for (int i = 0; i < waves.Count; i++)
			{
				numberOfEnemies += waves[i].NumberOfEnemies();
			}

			return numberOfEnemies;
		}
	}
}

