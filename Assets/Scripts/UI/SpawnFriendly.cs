using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnFriendly : MonoBehaviour
{
	[SerializeField] GameObject friendlyPrefab = null;
	[SerializeField] LayerMask mask = new LayerMask();
	[SerializeField] float spawnCoolDown = 1f;
	[SerializeField] Image image = null;
	[SerializeField] Button btn = null;

	float fillAmount = 1;   //the image fill amount
	public bool isPrefabReady = false;  //if the soldier/btn was selected and ready to spawn



	private void Update()
	{
		
		ProccessSpawn();

		image.fillAmount = fillAmount;
	}

	//whenever the btn gets clicked, give the green light to spawn
	public void AssisgnSoldiers()
	{
		isPrefabReady = true;
	}

	private void ProccessSpawn()
	{
		//check if CoolDown HAS PASSED
		ProccessFillAmount();

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

				randomX = Random.Range(-2, 2);
				randomZ = Random.Range(-2, 2);
				spawnOffSet = new Vector3(randomX, 0, randomZ);

				Instantiate(friendlyPrefab, hit.point - spawnOffSet, Quaternion.identity);

				//reset the fill and make the prefab "NOT" ready again to make the user click again
				fillAmount = 0;
				isPrefabReady = false;

			}
			//if something "wrong" was pressed, reset the btn
			else
			{
				isPrefabReady = false;
			}
		}


	}

	//increment the fill amount based on time
	private void ProccessFillAmount()
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
