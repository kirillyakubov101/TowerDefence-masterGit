using System.Collections;
using TowerDefence.AI;
using TowerDefence.Core;
using TowerDefence.Friendly;
using TowerDefence.Towers;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	[SerializeField] AudioSource audioSourceCoins = null;
	[SerializeField] AudioSource audioSourceMeteorLaunch = null;
	[SerializeField] AudioSource audioSourceTowerShow = null;

	//Announcer
	[Header("Announcer-Win")]
	[SerializeField] AudioSource audioSourceWinShout = null;
	[SerializeField] AudioClip[] winClips = null;
	[Header("Announcer-Lose")]
	[SerializeField] AudioSource audioSourceLoseShout = null;
	[SerializeField] AudioClip[] loseClips = null;

	private void Awake()
	{
		int count = FindObjectsOfType<SoundManager>().Length;
		if (count > 1)
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
	}


	private void OnEnable()
	{
		Death.onCoinGained += HandleCoinsGainedSound;
		SpecialSkillsHandler.OnMeteorLaunch += HandleMeteorLaunch;
		Tower.OnTowerUp += HandleTowerShow;

		//Announcer
		LevelController.WonGame += HandleWonGameSound;
		LevelController.LostGame += HandleLoseGameSound;
	}

	

	private void OnDisable()
	{
		Death.onCoinGained -= HandleCoinsGainedSound;
		SpecialSkillsHandler.OnMeteorLaunch -= HandleMeteorLaunch;
		Tower.OnTowerUp -= HandleTowerShow;

		LevelController.WonGame -= HandleWonGameSound;
		LevelController.LostGame -= HandleLoseGameSound;
	}

	private void HandleCoinsGainedSound()
	{
		audioSourceCoins.Play();
	}

	private void HandleMeteorLaunch()
	{
		audioSourceMeteorLaunch.Play();
	}

	private void HandleTowerShow()
	{
		audioSourceTowerShow.Play();
	}

	private void HandleWonGameSound()
	{
		StartCoroutine(PlayWinAudioSequentially());
	}

	private void HandleLoseGameSound()
	{
		StartCoroutine(PlayLoseAudioSequentially());
	}

	IEnumerator PlayWinAudioSequentially()
	{
		yield return null;

		//1.Loop through each AudioClip
		for (int i = 0; i < winClips.Length; i++)
		{
			//2.Assign current AudioClip to audiosource
			audioSourceWinShout.clip = winClips[i];

			//3.Play Audio
			audioSourceWinShout.Play();

			//4.Wait for it to finish playing
			while (audioSourceWinShout.isPlaying)
			{
				yield return null;
			}

			//5. Go back to #2 and play the next audio in the adClips array
		}
	}

	IEnumerator PlayLoseAudioSequentially()
	{
		yield return null;

		//1.Loop through each AudioClip
		for (int i = 0; i < loseClips.Length; i++)
		{
			//2.Assign current AudioClip to audiosource
			audioSourceLoseShout.clip = loseClips[i];

			//3.Play Audio
			audioSourceLoseShout.Play();

			//4.Wait for it to finish playing
			while (audioSourceLoseShout.isPlaying)
			{
				yield return null;
			}

			//5. Go back to #2 and play the next audio in the adClips array
		}
	}
}
