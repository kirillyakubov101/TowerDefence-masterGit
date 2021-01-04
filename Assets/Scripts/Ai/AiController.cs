using TowerDefence.Core;
using UnityEngine;
using UnityEngine.AI;

namespace TowerDefence.AI
{
	public class AiController : MonoBehaviour
	{

		NavMeshAgent meshAgent;
		EnemySpawner enemySpawner;
		Transform goalTransform;

		private void Awake()
		{
			meshAgent = GetComponent<NavMeshAgent>();
			enemySpawner = FindObjectOfType<EnemySpawner>();
			
		}

		private void Start()
		{
			goalTransform = enemySpawner.GetTarget();
		}

		// Update is called once per frame
		void Update()
		{
			if(enemySpawner == null) { return; }
			meshAgent.destination = goalTransform.position;

		}

		public void StopAgent()
		{
			meshAgent.isStopped = true;
		}
	}

}