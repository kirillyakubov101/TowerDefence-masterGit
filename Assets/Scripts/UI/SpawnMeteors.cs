using UnityEngine;
using UnityEngine.UI;

public class SpawnMeteors : MonoBehaviour,ISpawnable
{
	[SerializeField] GameObject meteorsPrefab = null;
	[SerializeField] LayerMask mask = new LayerMask();
	[SerializeField] float spawnCoolDown = 1f;
	[SerializeField] Image image = null;
	[SerializeField] Button btn = null;
	[SerializeField] Vector3 spawnHightOffset = Vector3.zero;

	float fillAmount = 1;   //the image fill amount
	public bool isPrefabReady = false;  //if the soldier/btn was selected and ready to spawn

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
}
