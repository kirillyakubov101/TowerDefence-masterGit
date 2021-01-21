using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TowerDefence.Core;
using UnityEngine.EventSystems;

public class SpawnFriendly : MonoBehaviour,ISpawnable
{
	[SerializeField] GameObject friendlyPrefab = null;
	[SerializeField] LayerMask mask = new LayerMask();
	[SerializeField] float spawnCoolDown = 1f;
	[SerializeField] Image image = null;
	[SerializeField] Button btn = null;

	[SerializeField] Texture2D wrongPlacementTexture = null;

	float fillAmount = 1;   //the image fill amount
	public bool isPrefabReady = false;  //if the soldier/btn was selected and ready to spawn

	//cache it for the cursor change
	GameSession gameSession;

	private void Awake()
	{
		gameSession = FindObjectOfType<GameSession>();
	}

	private void Update()
	{
		
		ProccessSpawn();

		image.fillAmount = fillAmount;
	}

	//whenever the btn gets clicked, give the green light to spawn
	public void AssignSpecialSkill()
	{
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
				float randomX = Random.Range(-2, 2); //random offset to avoid stack spawn
				float randomZ = Random.Range(-2, 2);
				Vector3 spawnOffSet = new Vector3(randomX, 0, randomZ);

				Instantiate(friendlyPrefab, hit.point, Quaternion.identity);
				Instantiate(friendlyPrefab, hit.point + spawnOffSet, Quaternion.identity);


				//reset the fill and make the prefab "NOT" ready again to make the user click again
				fillAmount = 0;
				isPrefabReady = false;

			}
			//if something "wrong" was pressed, reset the btn
			else
			{
				StartCoroutine(ChangeCursor(wrongPlacementTexture));
				isPrefabReady = false; //can add a small 'X' to disable the prefab selection
			}
		}


	}

	private IEnumerator ChangeCursor(Texture2D texture)
	{
		Cursor.SetCursor(texture, Vector3.zero, CursorMode.Auto);

		yield return new WaitForSeconds(0.2f);

		Cursor.SetCursor(gameSession.defaultCursor, Vector3.zero, CursorMode.Auto);
	}

	//increment the fill amount based on time
	public void ProccessFillAmount()
	{
		if (fillAmount >= 1)
		{
			btn.interactable = true;
		}
		else
		{
			btn.interactable = false;
			fillAmount += Time.deltaTime;
		}
	}


	//get the mouse to screen ray
	private Ray MouseToRay()
	{
		return Camera.main.ScreenPointToRay(Input.mousePosition);
	}
}
