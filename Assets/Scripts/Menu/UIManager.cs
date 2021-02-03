using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	[SerializeField] AudioClip startButtonClip = null;
	[SerializeField] float startGameDelayTime = 1.5f;
	AudioSource audioSource;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public void StartGameButton()
	{
		StartCoroutine(StartGame());	
	}
	//remove this function, it does the same thing as "LoadNextLevel" but with the start sound. make a different method for the sound 
	private IEnumerator StartGame()
	{
		if(startButtonClip == null)
		{
			yield return null;
		}
		audioSource.clip = startButtonClip;
		audioSource.Play();
		
		yield return new WaitForSeconds(startGameDelayTime);
		Time.timeScale = 1f;
		FindObjectOfType<Fader>().FadeInAction();
		StartCoroutine(NextLevel());
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void LoadMenuScene()
	{
		SceneManager.LoadScene(0);
		Time.timeScale = 1f;
	}

	public void ReloadTheLevel()
	{
		int currentIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadSceneAsync(currentIndex);


	}

	public void LoadNextLevel()
	{
		FindObjectOfType<Fader>().FadeInAction();
		StartCoroutine(NextLevel());
	}

	private IEnumerator NextLevel()
	{
		Time.timeScale = 1f;
		int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
		if (currentLevelIndex != SceneManager.sceneCountInBuildSettings-1)
		{
			yield return new WaitForSeconds(1f);
			SceneManager.LoadScene(currentLevelIndex + 1);
		}
		else
		{
			yield return new WaitForSeconds(1f);
			LoadMenuScene();
		}
	}

}
