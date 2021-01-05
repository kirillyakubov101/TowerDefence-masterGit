using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VillagersController : MonoBehaviour
{
	[SerializeField] Transform destination = null;
	[SerializeField] GameObject villCamera = null;
	[SerializeField] Animator animator = null;
	NavMeshAgent agent;

	public static event Action onVillagersFinish;

    // Start is called before the first frame update
    void Awake()
    {
		agent = GetComponent<NavMeshAgent>();
		

	}

	private void Start()
	{
		if (animator == null) { return; }
		animator.SetTrigger("appearText");
	}

	// Update is called once per frame
	void Update()
    {
		agent.destination = destination.position;
		if (agent.hasPath)
		{
			

			if (agent.remainingDistance <= 2f)
			{
				if (villCamera != null)
				{
					Destroy(villCamera);
				}

				onVillagersFinish?.Invoke();
				Destroy(gameObject,0.1f);
			}
		}
		

	}
}
