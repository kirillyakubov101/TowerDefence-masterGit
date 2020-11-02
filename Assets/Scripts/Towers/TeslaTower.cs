using System.Collections;
using System.Collections.Generic;
using TowerDefence.AI;
using UnityEngine;

namespace TowerDefence.Towers
{
	public class TeslaTower : MonoBehaviour
	{
		[SerializeField] LayerMask mask;
		[SerializeField] Health enemy; //remove the serialize
		[SerializeField] float range = 5f;
		[SerializeField] List<Health> enemiesNearBy = null;
		[SerializeField] float towerDamage = 50f;
		[SerializeField] Transform shootingPoint = null;


		//Cache
		LineRenderer laser;

		private void Awake()
		{
			laser = GetComponent<LineRenderer>();
		}


		// Update is called once per frame
		void Update()
		{
			CastSphere();
			Shoot();
		}

		private void CastSphere()
		{
			var hits = Physics.OverlapSphere(transform.position, range, mask);
			foreach (var hit in hits)
			{
				if (hit.gameObject.GetComponent<Health>() && !enemiesNearBy.Contains(hit.gameObject.GetComponent<Health>()))
				{
					AssignNewEnemy(hit);
				}
			}
			laser.positionCount = enemiesNearBy.Count + 1; //dynaimecly setting size of linerenderer
		}

		private void AssignNewEnemy(Collider hit)
		{
			enemy = hit.gameObject.GetComponent<Health>();
			enemiesNearBy.Add(enemy);
		}

		private void Shoot()
		{
			if (enemy == null) { StopShooting();  return; }
			float distance = Vector3.Distance(transform.position, enemy.transform.position);
			if (distance <= range && enemiesNearBy.Count > 0)
			{
				GenerateLightning();
				GenerateNoise();
			}
			else
			{
				StopShooting();


			}
		}

		private void GenerateNoise()
		{
			float randomOffsetX = Random.Range(-0.5f, 0.5f); //the lightning effect noise happens here!
			float randomOffsetY = Random.Range(-0.1f, 0.1f);
			laser.material.mainTextureOffset = new Vector2(randomOffsetX, randomOffsetY);
		}

		private void StopShooting()
		{
			laser.enabled = false;
			enemy = null;
			enemiesNearBy.Clear();
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(transform.position, range);
		}

		void GenerateLightning()
		{
			
			laser.enabled = true;
			Vector3[] arrayOfEnemiesPositions = new Vector3[enemiesNearBy.Count];

			laser.SetPosition(0, shootingPoint.position);
			for (int i = 0; i < enemiesNearBy.Count; i++)
			{
				if (enemiesNearBy[i] == null) { continue; } //avoid dead enemy
				arrayOfEnemiesPositions[i] = enemiesNearBy[i].transform.position;
				Vector3 newPosOffset = new Vector3 (arrayOfEnemiesPositions[i].x, arrayOfEnemiesPositions[i].y + 2f, arrayOfEnemiesPositions[i].z);
				laser.SetPosition(i + 1, newPosOffset);
				enemiesNearBy[i].takeDamage(towerDamage);
			}
			arrayOfEnemiesPositions = null;
		}
		
	}


}


