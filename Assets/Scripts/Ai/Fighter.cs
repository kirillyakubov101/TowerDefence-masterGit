using UnityEngine;
using TowerDefence.Friendly;
using TowerDefence.Statistics;

namespace TowerDefence.AI
{
	public class Fighter : MonoBehaviour
	{
		[SerializeField] StatsConfig statsConfig = null;
		[SerializeField] float searchRange = 5f;
		[SerializeField] LayerMask mask = new LayerMask();
		

		Animator animator;
		AiController aiController;
		public float damage;
		FriendlyFighter enemy = null;
		Transform originalPath = null;

		

		private void Awake()
		{
			animator = GetComponent<Animator>();
			aiController = GetComponent<AiController>();
			
		}

		private void Start()
		{
			originalPath = aiController.GetOriginalPath();
			damage = statsConfig.Damage;
		}


		private void Update()
		{
			CastSearchSphere();

			if (enemy != null)
			{
				EngageTarget();
			}
		}

		private void CastSearchSphere()
		{
			if (enemy != null) { return; }
			var hits = Physics.OverlapSphere(transform.position, searchRange, mask);

			foreach (var hit in hits)
			{
				FriendlyFighter tempComparedObject = hit.gameObject.GetComponent<FriendlyFighter>();
				if (!tempComparedObject.GetIsFightingSomeone())
				{
					AssignNewEnemy(hit);
					return;
				}
			}

			enemy = null;
		}

		private void AssignNewEnemy(Collider hit)
		{
			enemy = hit.gameObject.GetComponent<FriendlyFighter>();
			enemy.SetIsFightingSomeone(true);
		}

		private void EngageTarget()
		{
			if (Vector3.Distance(transform.position, enemy.transform.position) > 3)
			{
				aiController.AssignPath(enemy.transform);
			}
			//when reached, look at and attack the target
			else
			{
				LookTowardsEnemy();
				animator.SetBool("attack", true); //use the same paramater name for every animation instance
				aiController.StopAgent();
			}
		}

		private void Hit()
		{
			if(enemy == null) { StopAttacking(); return; }

			enemy.TakeDamage(Damage,this);
		}

		public void StopAttacking()
		{
			animator.SetBool("attack", false); //use the same paramater name for every animation instance
			aiController.AssignPath(originalPath);
			aiController.StartAgent();
			enemy = null;
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(transform.position, searchRange);
		}

		private void LookTowardsEnemy()
		{
			Vector3 lookDirection = enemy.transform.position - transform.position;
			lookDirection.y = 0;
			transform.rotation = Quaternion.LookRotation(lookDirection);
		}

		public float Damage { get => damage; }
	}
}

