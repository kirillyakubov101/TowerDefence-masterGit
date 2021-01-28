using System.Collections;
using System.Collections.Generic;
using TowerDefence.Core;
using UnityEngine;

public class Menu : MonoBehaviour
{
	[SerializeField] private GameObject MenuContainer = null;
	[SerializeField] private GameObject optionWindow = null;
	[SerializeField] private GameObject menuIcon = null;
	[SerializeField] private GameObject WinGameImage = null;
	[SerializeField] private GameObject LoseGameImage = null;
	[SerializeField] private GameObject winLosePanel = null;

	bool isWon = false;

	private void Start()
	{
		LevelController.WonGame += HandleWinGame;
		LevelController.LostGame += HandleLoseGame;
	}

	private void OnDestroy()
	{
		LevelController.WonGame -= HandleWinGame;
		LevelController.LostGame -= HandleLoseGame;
	}

	public void EnableMenu()
	{
		MenuContainer.SetActive(true);
		menuIcon.SetActive(false);
		Time.timeScale = 0f;

	}

	public void DesableMenu()
	{
		MenuContainer.SetActive(false);
		menuIcon.SetActive(true);
		Time.timeScale = 1f;
	}

	private void HandleWinGame()
	{
		isWon = true;
		StartCoroutine(WinLoseConditionScreen());
	}

	private void HandleLoseGame()
	{
		isWon = false;
		StartCoroutine(WinLoseConditionScreen());
	}

	private IEnumerator WinLoseConditionScreen()
	{
		if(isWon)
		{
			yield return new WaitForSeconds(2f);
			winLosePanel.SetActive(true);
			WinGameImage.SetActive(true);
			Time.timeScale = 0f;
		}
		else
		{
			yield return new WaitForSeconds(2f);
			winLosePanel.SetActive(true);
			LoseGameImage.SetActive(true);
			Time.timeScale = 0f;
		}
	}

}
