using System.Collections;
using System.Collections.Generic;
using TowerDefence.AI;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
	[SerializeField] Image healthBarImage = null;
	[SerializeField] Health health = null;


	private Transform cameraTransform;

	

	// Start is called before the first frame update
	void Start()
	{
		cameraTransform = Camera.main.transform;

	}

	private void Update()
	{
		HandleHealthUpdated(health.GetHealth(),health.GetMaxHealth());
	}

	// Update is called once per frame
	void LateUpdate()
	{
		transform.LookAt(

			transform.position + cameraTransform.rotation * Vector3.forward,
			cameraTransform.rotation * Vector3.up

			);

	}

	private void HandleHealthUpdated(float currentHealth, float maxHealth)
	{
		healthBarImage.fillAmount = currentHealth / maxHealth;
	}
}
