using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefence.AI;
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

		//remove or change
		EnemySpawner enemySpawner;


		public static event Action WonGame;
		public static event Action LostGame;

		private void Awake()
		{
			enemySpawner = FindObjectOfType<EnemySpawner>();
		}

		private void Start()
		{
			Time.timeScale = 1f;
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
			if (FindObjectsOfType<Health>().Length <= 0 && enemySpawner != null)
			{
				WonGame?.Invoke();
			}
		}

		private void LoseLifePoint()
		{
			lives--;
		}

		private void CheckIfLost()
		{
			if (lives <= 0)
			{
				LostGame?.Invoke();
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.tag == "Enemy")
			{
				LoseLifePoint();
				Destroy(other.gameObject);
			}
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
	}
}


