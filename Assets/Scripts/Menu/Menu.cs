using System.Collections;
using System.Collections.Generic;
using TowerDefence.Core;
using UnityEngine;

public class Menu : MonoBehaviour
{
	[SerializeField] private GameObject MenuContainer = null;
	[SerializeField] private GameObject menuIcon = null;
	[SerializeField] private GameObject WinGameImage = null;
	[SerializeField] private GameObject LoseGameImage = null;
	[SerializeField] private GameObject winLosePanel = null;

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
		winLosePanel.SetActive(true);
		WinGameImage.SetActive(true);
		Time.timeScale = 0f;

	}

	private void HandleLoseGame()
	{
		winLosePanel.SetActive(true);
		LoseGameImage.SetActive(true);
		Time.timeScale = 0f;
	}

}
