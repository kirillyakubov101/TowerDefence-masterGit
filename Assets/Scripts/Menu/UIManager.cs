using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	[SerializeField] AudioClip startButtonClip = null;
	[SerializeField] float startGameDelayTime = 3f;
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
		
		yield return new WaitForSeconds(startGameDelayTime);
		Time.timeScale = 1f;
		SceneManager.LoadScene(1); //change to "NOT A MAGIC NUMBER"
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

	public void ReloadTheLevel()
	{
		int currentIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadSceneAsync(currentIndex);
		
	}

	public void NextLevel()
	{
	
		int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
		if (currentLevelIndex != SceneManager.sceneCountInBuildSettings-1)
		{
			SceneManager.LoadScene(currentLevelIndex + 1);
		}
		else
		{
			LoadMenuScene();
		}
	}

}
