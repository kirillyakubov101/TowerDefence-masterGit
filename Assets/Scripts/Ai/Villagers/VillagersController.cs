﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VillagersController : MonoBehaviour
{
	[SerializeField] Transform destination = null;
	[SerializeField] GameObject villCamera = null;
	NavMeshAgent agent;

    // Start is called before the first frame update
    void Awake()
    {
		agent = GetComponent<NavMeshAgent>();

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
			
				Destroy(gameObject,0.1f);
			}
		}
		

	}
}