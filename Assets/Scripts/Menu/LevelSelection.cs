using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
	public int maxUnlockedLevel = 1;
	public Button[] Levels = new Button[0];

	public SavingWrapper savingWrapper;


	private void Awake()
	{
		savingWrapper = FindObjectOfType<SavingWrapper>();
	}

	// Start is called before the first frame update
	void Start()
	{ 
        CheckCurrentUnlockedLevels();
		print("new current " +savingWrapper.CurrentLevel);
    }

	private void Update()
	{
		savingWrapper = FindObjectOfType<SavingWrapper>();
		CheckCurrentUnlockedLevels();
	}


	private void CheckCurrentUnlockedLevels()
    {

		maxUnlockedLevel = savingWrapper.CurrentLevel;


		for (int i =0; i < Levels.Length; i ++)
		{
			if(i > maxUnlockedLevel - 1)
			{
				Levels[i].interactable = false;
			}
			else
			{
				Levels[i].interactable = true;
			}
		}

	}

	public void LoadLevel(string levelName)
	{
		SceneManager.LoadSceneAsync(levelName);
	}
}
