using System;
using TowerDefence.AI;
using UnityEngine;
using UnityEngine.Events;

public class CanonBomb : MonoBehaviour
{
	[SerializeField] float h = 25f; //maximumVerticalDisplacement
	[SerializeField] Transform target;
	[SerializeField] float damage = 50f; //this needs to be on the tower
	[SerializeField] float range = 5f;
	[SerializeField] LayerMask mask = new LayerMask();
	[SerializeField] ParticleSystem explosiveVFX = null;
	[SerializeField] UnityEvent onCannonHit = null;

	float gravity;
	Rigidbody rb;
	bool isHit = false;


	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}


	// Start is called before the first frame update
	void Start()
    {
		gravity = Physics.gravity.y;
		rb.useGravity = true;
		rb.velocity = CalculateLaunchVelocity(transform, target, gravity, h);
	}


	Vector3 CalculateLaunchVelocity(Transform projectile, Transform target, float gravity, float h)
	{
		float displacementY = target.position.y - projectile.position.y;
		Vector3 displacementXZ = new Vector3(target.position.x - projectile.position.x, 0, target.position.z - projectile.position.z);

		Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
		Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity));

		return velocityY + velocityXZ;
	}

	public void AssignTarget(Transform target,float damage)
	{
		this.damage = damage;
		this.target = target;
	}


	private void OnTriggerEnter(Collider other)
	{
		if(other.tag =="Tower") { return; }

		if (isHit) { return; }

		Instantiate(
			explosiveVFX, new Vector3(transform.position.x,
			transform.position.y + 2f,
			transform.position.z),
			Quaternion.identity
			);

		//events for the sound system
		onCannonHit?.Invoke();


		isHit = true;

		var hits = Physics.OverlapSphere(transform.position, range, mask);

		foreach (var hit in hits)
		{
			if (hit.GetComponent<Health>())
			{
				hit.GetComponent<Health>().takeDamage(damage);
			}
			
		}

			

		Destroy(gameObject,2f);
		
	}
}
