using TowerDefence.AI;
using UnityEngine;

namespace TowerDefence.Friendly
{
	public class FriendlyMeteor : MonoBehaviour
	{
		[SerializeField] float hitRange = 20f;
		[SerializeField] LayerMask mask = new LayerMask();
		[SerializeField] float damage = 50f;
		[SerializeField] float speed = 5f;
		[SerializeField] ParticleSystem explosiveVFX = null;

		private void Update()
		{
			transform.Translate(-transform.up * speed * Time.deltaTime);
		}

		private void OnTriggerEnter(Collider other)
		{

			GameObject particleInstanse = Instantiate(
					explosiveVFX.gameObject, new Vector3(transform.position.x,
					transform.position.y + 2f,
					transform.position.z),
					Quaternion.identity
					);

			//Destroy(particleInstanse, 1f);

			var hits = Physics.OverlapSphere(transform.position, hitRange, mask);

			foreach (var hit in hits)
			{
				if (hit.GetComponent<Health>())
				{
					hit.GetComponent<Health>().takeDamage(damage);
				}
			}
		}
	}
}

