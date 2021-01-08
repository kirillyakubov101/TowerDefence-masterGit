using UnityEngine;
using UnityEngine.AI;

namespace TowerDefence.AI
{
	public class AiController : MonoBehaviour
	{

		NavMeshAgent meshAgent;
		Transform goalTransform = null;

		private void Awake()
		{
			meshAgent = GetComponent<NavMeshAgent>();
			
		}

		void Update()
		{
			if(goalTransform == null) { return; }

			meshAgent.destination = goalTransform.position;

		}

		public void StopAgent()
		{
			meshAgent.isStopped = true;
		}

		public void AssignPath(Transform path)
		{
			goalTransform = path;
		}
	}

}