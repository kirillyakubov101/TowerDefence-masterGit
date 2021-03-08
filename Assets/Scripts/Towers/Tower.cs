using System;
using UnityEngine;

namespace TowerDefence.Towers
{
	public class Tower : MonoBehaviour
	{
		[SerializeField] float spawnSpeed = 2f;

		static public event Action OnTowerUp; //change this to spartial volume event

		bool isTowerShowed = false;
		float goalSpawnLevel;

		private void Start()
		{
			OnTowerUp?.Invoke();
			goalSpawnLevel = transform.position.y + EmpySlot.towerSpawnOffset;
		}

		private void Update()
		{
			if (isTowerShowed) {Destroy(this); }
			ShowTower();
		}

		private void ShowTower()
		{
			if (transform.position.y < goalSpawnLevel)
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

