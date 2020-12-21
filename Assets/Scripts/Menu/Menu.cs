using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
	[SerializeField] private GameObject MenuContainer = null;
	[SerializeField] private GameObject menuIcon = null;

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

}
