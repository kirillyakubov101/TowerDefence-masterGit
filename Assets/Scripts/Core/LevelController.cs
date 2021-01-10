﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence.Core
{
	public class LevelController : MonoBehaviour
	{
		[SerializeField] int lives = 20;
		[SerializeField] int gold = 200;
		[SerializeField] Text goldPoints;
		[SerializeField] Text lifePoints;


		public static event Action WonGame;
		public static event Action LostGame;

		[SerializeField] int numberOfEnemies;
		SpawnerHandler spawnerHandler;

		private void Awake()
		{
			spawnerHandler = FindObjectOfType<SpawnerHandler>();
		}

		private void Start()
		{
			numberOfEnemies = spawnerHandler.GetNumberOfEnemies();
			Time.timeScale = 1f;
		}

		private void OnEnable()
		{
			FinishLine.onFinishLineCrossed += HandleFinishLineCrossed;
		}

		private void OnDisable()
		{
			FinishLine.onFinishLineCrossed -= HandleFinishLineCrossed;
		}

		// Update is called once per frame
		void Update()
		{
			goldPoints.text = gold.ToString();
			lifePoints.text = lives.ToString(); //FIX THIS

			CheckIfLost();
			CheckIfWon();

		}

		private void CheckIfWon()
		{	
			if(numberOfEnemies <= 0)
			{
				WonGame?.Invoke();
			}
		}

		private void LoseLifePoint()
		{
			numberOfEnemies--;
			lives--;
		}

		private void CheckIfLost()
		{
			if (lives <= 0)
			{
				lives = 0;
				LostGame?.Invoke();
			}
		}

		/*private void OnTriggerEnter(Collider other)
		{
			if (other.tag == "Enemy")
			{
				LoseLifePoint();
				Destroy(other.gameObject);
			}
		}*/

		private void HandleFinishLineCrossed(GameObject enemyObj)
		{
			LoseLifePoint();
			Destroy(enemyObj);
		}

		public void GainGold(int goldAmount)
		{
			gold += goldAmount;
		}

		public void PayForTower(int price)
		{
			gold -= price;
		}

		public int GetGoldAmount()
		{
			return gold;
		}

		public void ReduceEnemy()
		{
			numberOfEnemies--;
		}
	}
}


