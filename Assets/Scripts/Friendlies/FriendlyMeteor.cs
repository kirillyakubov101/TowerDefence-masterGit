using TowerDefence.AI;
using UnityEngine;

public class FriendlyMeteor : MonoBehaviour
{
	[SerializeField] float hitRange = 20f;
	[SerializeField] LayerMask mask = new LayerMask();
	[SerializeField] float damage = 50f;
	[SerializeField] float speed = 5f;

	private void Update()
	{
		transform.Translate(-transform.up * speed * Time.deltaTime);
	}

	private void OnTriggerEnter(Collider other)
	{
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
