using TowerDefence.AI;
using UnityEngine;

namespace TowerDefence.Combat
{
	public class Projectile : MonoBehaviour
	{
		[SerializeField] float arrowSpeed;
		[SerializeField] Health target; //remove the serialize


		float damage;
		bool isHit = false;


		// Update is called once per frame
		void Update()
		{
			if (target == null || isHit) { Destroy(gameObject); return; }
			transform.LookAt(target.transform.position);
			transform.Translate(Vector3.forward * arrowSpeed * Time.deltaTime);
		}

		public void AssignTarget(Health newTarget, float damage)
		{
			this.damage = damage;
			target = newTarget;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.tag == "Ground")
			{
				isHit = true;
				Destroy(gameObject, 5f);
			}

			Health enemy = other.gameObject.GetComponent<Health>();

			if (enemy != null)
			{
				enemy.takeDamage(damage);
				Destroy(gameObject);
			}

		}
	}
}

