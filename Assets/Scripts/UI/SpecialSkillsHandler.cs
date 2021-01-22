using UnityEngine;
using TowerDefence.UI;
using System.Collections.Generic;
using System;

namespace TowerDefence.Friendly
{
	public class SpecialSkillsHandler : MonoBehaviour
	{
		[SerializeField] List<GameObject> allActiveSkills = new List<GameObject>(); //0 - friendly 1- meteor

		GameObject activeSkillPrefab = null;

		public static event Action OnFriendlySpawnComplete;
		public static event Action OnMeteorSpawnComplete;

		public GameObject GetaAtiveSkillPrefab()
		{
			return activeSkillPrefab;
		}

		private void OnEnable()
		{
			SpawnFriendly.OnFriendlySpawn += HandleFriendlySpawn;
			SpawnFriendly.OnFriendlySelect += HandleSelectedSkill;
			SpawnMeteors.OnMeteorSpawn += HandleMeteorSpawn;
			SpawnMeteors.OnMeteorSelect += HandleSelectedSkill;
		}

		private void OnDisable()
		{
			SpawnFriendly.OnFriendlySpawn -= HandleFriendlySpawn;
			SpawnMeteors.OnMeteorSpawn -= HandleMeteorSpawn;
			SpawnFriendly.OnFriendlySelect -= HandleSelectedSkill;
			SpawnMeteors.OnMeteorSelect -= HandleSelectedSkill;
		}

		private void HandleFriendlySpawn(Vector3 hit)
		{
			if(allActiveSkills[0] != activeSkillPrefab) { return; }

			Instantiate(activeSkillPrefab, hit, Quaternion.identity);

			OnFriendlySpawnComplete?.Invoke();

		}

		private void HandleSelectedSkill(GameObject selectedPrefab)
		{
			activeSkillPrefab = selectedPrefab;
		}

		private void HandleMeteorSpawn(Vector3 hit)
		{
			if (allActiveSkills[1] != activeSkillPrefab) { return; }
			Vector3 spawnHightOffset = new Vector3(0, 50, 0); //remove later and show in inspector
			GameObject meteorsInstace = Instantiate(activeSkillPrefab, hit + spawnHightOffset, Quaternion.identity);
			Destroy(meteorsInstace, 4f);

			OnMeteorSpawnComplete?.Invoke();
		}
	}
}


