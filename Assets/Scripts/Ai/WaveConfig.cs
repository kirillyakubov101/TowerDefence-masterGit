using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
	[SerializeField] GameObject enemyPrefab;
	[SerializeField] int numberOfEnemies;
	[SerializeField] float timeBetweenSpawns;
	

	public GameObject GetEnemyPrefab()
	{
		return enemyPrefab;
	}

	public int NumberOfEnemies()
	{
		return numberOfEnemies;
	}

	public float TimeBetweenSpawn()
	{
		return timeBetweenSpawns;
	}



	
	}








