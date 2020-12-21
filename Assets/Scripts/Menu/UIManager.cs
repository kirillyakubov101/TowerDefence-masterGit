using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	[SerializeField] AudioClip startButtonClip = null;
	AudioSource audioSource;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public void StartGameButton()
	{
		StartCoroutine(StartGame());	
	}

	private IEnumerator StartGame()
	{
		if(startButtonClip == null)
		{
			yield return null;
		}
		audioSource.clip = startButtonClip;
		audioSource.Play();
		
		yield return new WaitForSeconds(startButtonClip.length);
		Time.timeScale = 1f;
		SceneManager.LoadScene(1);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void LoadMenuScene()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(0);
	}

}
