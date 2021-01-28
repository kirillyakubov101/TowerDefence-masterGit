﻿using System;
using TowerDefence.AI;
using TowerDefence.Combat;
using UnityEngine;

namespace TowerDefence.Towers
{
	public class TowerArcher : MonoBehaviour
	{
		[SerializeField] float range;
		[SerializeField] Transform bowPos;
		[SerializeField] Projectile arrow;  //FIX AND MAKE A NORMAL SCRIPT
		[SerializeField] float damage = 10f;
		[SerializeField] LayerMask mask;

		public static event Action onArrowLaunch;

		Health enemy; 
		Animator animator;
		Quaternion rotatationStart;


		private void Awake()
		{
			animator = GetComponent<Animator>();
		}

		// Start is called before the first frame update
		void Start()
		{
			transform.rotation = rotatationStart;
		}

		// Update is called once per frame
		void Update()
		{
			CastSphere();
			AimAndShootManager();
		}

		private void AimAndShootManager()
		{
			if (enemy == null) { StopShooting(); return; }
			float distance = Vector3.Distance(transform.parent.position, enemy.transform.position);
			if (distance <= range + 2)
			{
				var lookPos = enemy.transform.position - transform.position;

				lookPos.y = 0;
				var rotation = Quaternion.LookRotation(lookPos);
				transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 1f);
				if (enemy == null) { StopShooting(); return; }
				animator.SetBool("shoot", true);
			}
			else
			{
				StopShooting();
			}
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(transform.position, range);
		}

		//Animation Event
		private void Hit()
		{
			if (enemy == null) { StopShooting(); return; }
			onArrowLaunch?.Invoke(); //sound 
			var newArrow = Instantiate(arrow, bowPos.position, Quaternion.identity); 
			newArrow.AssignTarget(enemy, damage);

		}

		void CastSphere()
		{
			if (enemy != null) { return; }
			var hits = Physics.OverlapSphere(transform.position, range, mask);

			foreach (var hit in hits)
			{
				AssignNewEnemy(hit);
				return;
			}
		}

		private void AssignNewEnemy(Collider hit)
		{
			enemy = hit.gameObject.GetComponent<Health>();
		}

		private void StopShooting()
		{
			animator.SetBool("shoot", false);
			//transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * .5f); //maybe remove this, it rotates the archer back
			enemy = null;

		}
	}
}

