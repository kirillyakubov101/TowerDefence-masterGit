using System.Collections;
using System.Collections.Generic;
using TowerDefence.AI;
using TowerDefence.Combat;
using UnityEngine;

public class CanonTower : MonoBehaviour
{
	[SerializeField] float range;
	[SerializeField] Transform ball;  //FIX AND MAKE A NORMAL SCRIPT
	[SerializeField] float damage = 100f;
	[SerializeField] LayerMask mask;
	[SerializeField] Health enemy; // //remove the serialize
	[SerializeField] Transform shootPoint;
	[SerializeField] float delayMax = 5f;
	float shootDelay = 0f;
	bool canShoot = true;

	//U - initial velocity, V- final velocity

	private void Update()
	{
		shootDelay += Time.deltaTime;

		if(shootDelay >= delayMax)
		{
			CastSphere();
			AimAndShootManager();
			shootDelay = 0f;
		}
	}

	

	private void CastSphere()
	{
		if (enemy != null) { return; }
		var hits = Physics.OverlapSphere(transform.position, range, mask);

		foreach (var hit in hits)
		{
			if (hit.gameObject.GetComponent<Health>())
				AssignNewEnemy(hit);
			return;
		}

		enemy = null;
	}

	private void AssignNewEnemy(Collider hit)
	{
		enemy = hit.gameObject.GetComponent<Health>();
	}

	private void AimAndShootManager()
	{
		if (enemy == null) {return; }

		float distance = Vector3.Distance(transform.position, enemy.transform.position);


		if (distance <= range)
		{
			Shoot();
		}
		else
		{
			enemy = null;
		}
	}


	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, range);
	}

	void Shoot()
	{
		var newProjectile = Instantiate(ball, shootPoint.position, Quaternion.identity);
		newProjectile.GetComponent<CanonBomb>().AssignTarget(enemy.transform,damage);
		enemy = null;
	}
}
