using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OilSlow : MonoBehaviour
{
	[SerializeField] float slowSpeed = 1f;
	float startingSpeed = 5f;

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Enemy"))
		{

			other.GetComponent<NavMeshAgent>().speed = slowSpeed;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			other.GetComponent<NavMeshAgent>().speed = startingSpeed;
		}
	}
}
