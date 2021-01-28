using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefence.AI;
using TowerDefence.Towers;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	[SerializeField] AudioSource audioSourceCannonExplosion = null;
	[SerializeField] AudioSource audioSourceFireball = null;
	[SerializeField] AudioSource audioSourceCoins = null;
	[SerializeField] AudioSource audioSourceCannonBallLaunch = null;
	[SerializeField] AudioSource audioSourceArrowLaunch = null;



	private void OnEnable()
	{
		CanonBomb.onExplosion += HandleExplosionHitSound;
		MageTower.onFireBallLaunch += HandleFireBallLaunchSound;
		Death.onCoinGained += HandleCoinsGainedSound;
		CanonTower.onCannonBallLaunch += HandleCannonBallLaunch;
		TowerArcher.onArrowLaunch += HandleArrowLaunch;
	}

	

	private void OnDisable()
	{
		CanonBomb.onExplosion -= HandleExplosionHitSound;
		MageTower.onFireBallLaunch -= HandleFireBallLaunchSound;
		Death.onCoinGained -= HandleCoinsGainedSound;
		CanonTower.onCannonBallLaunch -= HandleCannonBallLaunch;
		TowerArcher.onArrowLaunch -= HandleArrowLaunch;
	}

	private void HandleExplosionHitSound()
	{
		audioSourceCannonExplosion.Play();
	}

	private void HandleFireBallLaunchSound()
	{
		audioSourceFireball.Play();
	}

	private void HandleCoinsGainedSound()
	{
		audioSourceCoins.Play();
	}

	private void HandleCannonBallLaunch()
	{
		audioSourceCannonBallLaunch.Play();
	}

	private void HandleArrowLaunch()
	{
		audioSourceArrowLaunch.Play();
	}
}
