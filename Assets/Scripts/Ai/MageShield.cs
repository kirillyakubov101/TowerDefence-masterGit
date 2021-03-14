using System.Collections;
using System.Collections.Generic;
using TowerDefence.AI;
using UnityEngine;

public class MageShield : MonoBehaviour
{
    [SerializeField] GameObject forceShield = null;
	[SerializeField] float forceShieldCooldown = 3f;
	[SerializeField] float activeShieldTime = 3f;
	[SerializeField] Animator animator = null;

	float shieldOnTimer = 0f;
	float shieldOffTimer = 0f;
	bool isShieldOn = true;

	Health health;

	private void Awake()
	{
		health = GetComponent<Health>();
	}

	private void Update()
	{
		if(health == null) { return; }
		if(isShieldOn)
		{
			shieldOnTimer += Time.deltaTime;
			if (shieldOnTimer >= activeShieldTime) { DeactivateShield(); }
		}
		else
		{
			shieldOffTimer += Time.deltaTime;
			if(shieldOffTimer >= forceShieldCooldown) { ActivateShield(); }
			
		}
		
	}

	private void ActivateShield()
	{
		if (isShieldOn) { return; }
		animator.SetTrigger("float");
		forceShield.SetActive(true);
		isShieldOn = true;
		shieldOffTimer = 0f;
		health.HasShield = true;
	}

	private void DeactivateShield()
	{
		if (!isShieldOn) { return; }
		animator.SetTrigger("CoolDown");
		forceShield.SetActive(false);
		isShieldOn = false;
		shieldOnTimer = 0f;
		health.HasShield = false;
	}
}
