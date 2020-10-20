using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Towers
{
	public class TeslaTower : MonoBehaviour
	{
		[SerializeField] LayerMask mask;
		[SerializeField] CombatTarget enemy; //remove the serialize
		[SerializeField] float range = 5f;
		[SerializeField] ParticleSystem lighting;

		float delay = 0;

		// Start is called before the first frame update
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
			CastSphere();
			Shoot();
		}

		private void CastSphere()
		{
			if (enemy != null) { return; }
			var hits = Physics.OverlapSphere(transform.position, range, mask);

			foreach (var hit in hits)
			{
				if (hit.gameObject.GetComponent<CombatTarget>())
					AssignNewEnemy(hit);
				return;
			}

			enemy = null;
		}

		private void AssignNewEnemy(Collider hit)
		{
			enemy = hit.gameObject.GetComponent<CombatTarget>();
		}

		private void Shoot()
		{
			if (enemy == null) { StopShooting();  return; }
			float distance = Vector3.Distance(transform.position, enemy.transform.position);
			if (distance <= range)
			{
				ActivateLightning();
			}
			else
			{
				enemy = null;
			}
		}

		private void StopShooting()
		{
			enemy = null;
		}

		void ActivateLightning()
		{
			lighting.transform.LookAt(enemy.transform.position); //aim towards the enemy
			if (delay >= 2f)
			{
				lighting.Play();
				delay = 0;
			}
			delay += Time.deltaTime;
		}


		private void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(transform.position, range);
		}


	}


}


