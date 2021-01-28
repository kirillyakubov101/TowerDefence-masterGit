using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TowerDefence.Core;
using UnityEngine.EventSystems;
using System;
using TowerDefence.Friendly;

namespace TowerDefence.UI
{
	public class SpawnFriendly : MonoBehaviour, ISpawnable
	{
		[SerializeField] GameObject friendlyPrefab = null;
		[SerializeField] LayerMask mask = new LayerMask();
		[SerializeField] float spawnCoolDown = 1f;
		[SerializeField] Image image = null;
		[SerializeField] Button btn = null;
		[SerializeField] Texture2D wrongPlacementTexture = null;

		public static event Action<Vector3> OnFriendlySpawn; //event to notify the handler
		public static event Action<GameObject> OnFriendlySelect;

		float fillAmount = 1;   //the image fill amount
		public bool isPrefabReady = false;  //if the soldier/btn was selected and ready to spawn

		//chache
		GameSession gameSession;

		private void Awake()
		{
			gameSession = FindObjectOfType<GameSession>();
		}

		private void OnEnable()
		{
			SpecialSkillsHandler.OnFriendlySpawnComplete += HandleSpawnComplete;
		}

		private void OnDisable()
		{
			SpecialSkillsHandler.OnFriendlySpawnComplete -= HandleSpawnComplete;
		}

		private void Update()
		{

			ProccessSpawn();

			image.fillAmount = fillAmount;
		}

		//whenever the btn gets clicked, give the green light to spawn
		public void AssignSpecialSkill()
		{
			OnFriendlySelect?.Invoke(friendlyPrefab);
			isPrefabReady = true;
		}

		public void ProccessSpawn()
		{
			//check if CoolDown HAS PASSED
			ProccessFillAmount();

			//avoid raycast through buttons
			if (EventSystem.current.IsPointerOverGameObject())
			{
				return;
			}

			//left mouse click
			if (Input.GetMouseButtonDown(0) && btn.interactable && isPrefabReady)
			{
				//hit only the spawn triggers
				if (Physics.Raycast(MouseToRay(), out RaycastHit hit, Mathf.Infinity, mask))
				{
					Spawn(hit);
				}
				//if something "wrong" was pressed, reset the btn
				else
				{
					StartCoroutine(ChangeCursor(wrongPlacementTexture));
					isPrefabReady = false; //can add a small 'X' to disable the prefab selection
				}
			}
		}

		private void Spawn(RaycastHit hit)
		{
			OnFriendlySpawn?.Invoke(hit.point);
		}

		private IEnumerator ChangeCursor(Texture2D texture)
		{
			Cursor.SetCursor(texture, Vector3.zero, CursorMode.Auto);

			yield return new WaitForSeconds(0.2f);

			Cursor.SetCursor(gameSession.GetDefaultCursorTexture(), Vector3.zero, CursorMode.Auto);
		}

		//increment the fill amount based on time
		public void ProccessFillAmount()
		{
			if (fillAmount >= 1)
			{
				btn.interactable = true;
			}
			else if (fillAmount < 1 && !isPrefabReady)
			{
				btn.interactable = false;
				fillAmount += Time.deltaTime / spawnCoolDown;
			}
		}


		//get the mouse to screen ray
		private Ray MouseToRay()
		{
			return Camera.main.ScreenPointToRay(Input.mousePosition);
		}

		//when the spawn is successfully complete, start the cooldwon UI
		private void HandleSpawnComplete()
		{
			fillAmount = 0;
			isPrefabReady = false;
		}
	}

}

