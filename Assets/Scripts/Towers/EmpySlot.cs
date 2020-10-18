using TowerDefence.Core;
using TowerDefence.UI;
using UnityEngine;

namespace TowerDefence.Towers
{
	[SelectionBase]
	public class EmpySlot : MonoBehaviour
	{
		[Header("Tower")]
		[SerializeField] Tower tower;
		[SerializeField] int towerPrice = 100;
		[Header("UI")]
		[SerializeField] BuildUi buildUI;
		[SerializeField] Animator animator;
		[Header("Flag")]
		[SerializeField] Renderer flagMat;

		Vector3 newTowerPos;
		LevelController levelController;
		Color flagColor;

		private void Awake()
		{
			levelController = FindObjectOfType<LevelController>();

		}

		private void Start()
		{
			newTowerPos = new Vector3(transform.position.x, transform.position.y - 5f, transform.position.z);
			flagColor = new Color(248f, 41f, 31f);
		}

		private void OnMouseOver()
		{
			flagMat.material.SetColor("_EmissionColor", flagColor * 0.4f);
		}

		private void OnMouseExit()
		{
			flagMat.material.SetColor("_EmissionColor", flagColor * 0);
		}

		private void OnMouseUpAsButton() //Make tower
		{
			buildUI.ActivateOnlyOneUiElement();
			animator.SetTrigger("appear");
		}

		//on mouse leave/click somewhere else, need to disable it

		public void BuildArcherTower()
		{

			if (levelController.GetGoldAmount() >= towerPrice)
			{
				levelController.PayForTower(towerPrice);
				Instantiate(tower, newTowerPos, transform.rotation);
				Destroy(transform.parent.gameObject);
			}
		}


	}
}


