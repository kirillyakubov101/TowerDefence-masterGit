using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TowerDefence.Core
{
	public class LevelController : MonoBehaviour
	{
		[SerializeField] int lives = 20;
		[SerializeField] int gold = 200;
		[SerializeField] Text goldPoints = null;
		[SerializeField] Text lifePoints = null;

		bool isGameOver = false;

		//event for savingSystem
		public static event Action<int> onLevelPassed;

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
			if(numberOfEnemies <= 0 && !isGameOver)
			{
				SaveProgress();
				WonGame?.Invoke();
				isGameOver = true;
			}
		}

		private void SaveProgress()
		{
			//for saving system
			string levelName = SceneManager.GetActiveScene().name;
			levelName = levelName.Substring(levelName.Length - 1);
			int levelNumber = Int32.Parse(levelName);
			onLevelPassed?.Invoke(levelNumber + 1);
		}

		private void LoseLifePoint()
		{
			numberOfEnemies--;
			lives--;
		}

		private void CheckIfLost()
		{
			if (lives <= 0 && !isGameOver)
			{
				lives = 0;
				LostGame?.Invoke();
				isGameOver = true;
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


