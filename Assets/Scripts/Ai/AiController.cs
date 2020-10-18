using TowerDefence.Core;
using UnityEngine;
using UnityEngine.AI;

namespace TowerDefence.AI
{
	public class AiController : MonoBehaviour
	{

		NavMeshAgent meshAgent;
		EnemySpawner enemySpawner;

		private void Awake()
		{
			meshAgent = GetComponent<NavMeshAgent>();
			enemySpawner = FindObjectOfType<EnemySpawner>();
		}

		// Update is called once per frame
		void Update()
		{
			meshAgent.destination = enemySpawner.GetTarget().position;

		}

		public void StopAgent()
		{
			meshAgent.isStopped = true;
		}
	}

}