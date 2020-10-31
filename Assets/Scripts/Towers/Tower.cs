using UnityEngine;

namespace TowerDefence.Towers
{
	public class Tower : MonoBehaviour
	{
		[SerializeField] float baseSpawnLevel = -0.2f;
		[SerializeField] float spawnSpeed = 2f;

		//need to remove this or something
		TeslaTower tesla;

		bool isTowerShowed = false;

		private void Start()
		{
			tesla = GetComponent<TeslaTower>();
		}

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
				if(tesla!=null)
				{
					tesla.enabled = true;
				}
					
		
			}
		}
	}
}

