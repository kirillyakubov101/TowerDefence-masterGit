using System;
using UnityEngine;

namespace TowerDefence.Towers
{
	public class Tower : MonoBehaviour
	{
		[SerializeField] float baseSpawnLevel = -0.2f;
		[SerializeField] float spawnSpeed = 2f;

		static public event Action OnTowerUp;

		private void Start()
		{
			OnTowerUp?.Invoke();
		}

		bool isTowerShowed = false;

		private void Update()
		{
			if (isTowerShowed) { return; }
			ShowTower();
		}

		private void ShowTower()
		{
			if (transform.position.y < baseSpawnLevel)
			{
				transform.Translate(Vector3.up * spawnSpeed * Time.deltaTime);
			}
			else
			{
				isTowerShowed = true;
				
		
			}
		}
	}
}

