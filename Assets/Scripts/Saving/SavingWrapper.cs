using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefence.Core;
using UnityEngine;

public class SavingWrapper : MonoBehaviour
{
	
	public int CurrentLevel = 1;
	PlayerData data;

	private void Awake()
	{
		int count = FindObjectsOfType<SavingWrapper>().Length;
		if(count > 1)
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
		LevelController.onLevelPassed += HandleSaveLevel;
	}

	private void OnDisable()
	{
		LevelController.onLevelPassed -= HandleSaveLevel;
	}

	private void HandleSaveLevel(int level)
	{
		if(CurrentLevel >= level) { return; } //avoid overwrite save if the level is smaller than the current one
		CurrentLevel = level;
		print(level);
		Save();
	}

	private void Start()
	{
		if(SavingSystem.IsFileExist())
		{
			data = SavingSystem.LoadPlayer();
			CurrentLevel = data.currentUnlockedLevel;
		}
		else
		{
			data = new PlayerData();
		}
	}

	public void Save()
	{
		data.currentUnlockedLevel = CurrentLevel;
		print("saved " + CurrentLevel + "to data: " + data.currentUnlockedLevel);
		SavingSystem.SavePlayer(data);
	}

	public void Load()
	{
		data = SavingSystem.LoadPlayer();
		CurrentLevel = data.currentUnlockedLevel;

	}

	public void Delete()
	{
		SavingSystem.DeleteFile(SavingSystem.path);
	}
}
