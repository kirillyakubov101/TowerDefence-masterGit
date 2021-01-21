using System.Collections;
using TowerDefence.Core;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpawnMeteors : MonoBehaviour,ISpawnable
{
	[SerializeField] GameObject meteorsPrefab = null;
	[SerializeField] LayerMask mask = new LayerMask();
	[SerializeField] LayerMask UImask = new LayerMask();
	
	[SerializeField] float spawnCoolDown = 1f;
	[SerializeField] Image image = null;
	[SerializeField] Button btn = null;
	[SerializeField] Vector3 spawnHightOffset = Vector3.zero;

	[SerializeField] Texture2D wrongPlacementTexture = null;

	float fillAmount = 1;   //the image fill amount
	public bool isPrefabReady = false;  //if the soldier/btn was selected and ready to spawn

	//cache it for the cursor change
	GameSession gameSession;

	private void Awake()
	{
		gameSession = FindObjectOfType<GameSession>();
	}

	public void AssignSpecialSkill()
	{
		isPrefabReady = true;
	}

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

	public void ProccessSpawn()
	{
		//check if CoolDown HAS PASSED
		ProccessFillAmount();

		//left mouse click
		if (Input.GetMouseButtonDown(0) && btn.interactable && isPrefabReady)
		{
			//avoid raycast through buttons
			if(EventSystem.current.IsPointerOverGameObject())
			{
				return;
			}
				//hit only the spawn triggers
			if (Physics.Raycast(MouseToRay(), out RaycastHit hit, Mathf.Infinity, mask))
			{
				GameObject meteorsInstace = Instantiate(meteorsPrefab, hit.point + spawnHightOffset, Quaternion.identity);
				Destroy(meteorsInstace, 4f);

				//reset the fill and make the prefab "NOT" ready again to make the user click again
				fillAmount = 0;
				isPrefabReady = false;

			}
			//if something "wrong" was pressed, reset the btn
			else
			{
				StartCoroutine(ChangeCursor(wrongPlacementTexture));
				isPrefabReady = false;
			}
		}

	}

	//get the mouse to screen ray
	private Ray MouseToRay()
	{
		return Camera.main.ScreenPointToRay(Input.mousePosition);
	}

	private void Update()
	{
		ProccessSpawn();
		image.fillAmount = fillAmount;
	}

	private IEnumerator ChangeCursor(Texture2D texture)
	{
		Cursor.SetCursor(texture, Vector3.zero, CursorMode.Auto);

		yield return new WaitForSeconds(0.2f);

		Cursor.SetCursor(gameSession.defaultCursor, Vector3.zero, CursorMode.Auto);
	}
}
