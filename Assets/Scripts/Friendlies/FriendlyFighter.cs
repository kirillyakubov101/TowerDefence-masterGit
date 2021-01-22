using UnityEngine;
using TowerDefence.AI;
using System;

namespace TowerDefence.Friendly
{
	public class FriendlyFighter : MonoBehaviour
	{
		[SerializeField] private bool isFightingSomeone = false;
		[SerializeField] float health = 20f;
		[SerializeField] float damage = 15f;
		[SerializeField] Animator animator = null;
		[SerializeField] float range = 2f;
		[SerializeField] LayerMask mask = new LayerMask();

		[SerializeField] Fighter enemy = null;


		private void Update()
		{
			CastSphere();
		}

		private void CastSphere()
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
			enemy = hit.gameObject.GetComponent<Fighter>();
			LookTowardsEnemy();
			animator.SetBool("attack", true);
		}

		private void LookTowardsEnemy()
		{
			Vector3 lookDirection = enemy.transform.position - transform.position;
			lookDirection.y = 0;
			transform.rotation = Quaternion.LookRotation(lookDirection);
		}

		public void StopAttacking()
		{
			enemy = null;
			animator.SetBool("attack", false);
			isFightingSomeone = false;
		}

		public void TakeDamage(float damage,Fighter instigator)
		{
			health = Mathf.Max(health - damage, 0f);

			if (health <= 0f)
			{
				instigator.StopAttacking();
				Destroy(gameObject);
			}
		}

		//animation event
		private void Hit()
		{
			if(enemy == null) { StopAttacking(); return; }
			if(enemy.GetComponent<Health>() == null) { StopAttacking(); return; }
			enemy.GetComponent<Health>().takeDamageFromSoldiers(damage,this);
			
		}

		public bool GetIsFightingSomeone()
		{
			return isFightingSomeone;
		}

		public void SetIsFightingSomeone(bool value)
		{
			isFightingSomeone = value;
		}
	}
}

