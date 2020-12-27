using TowerDefence.Core;
using TowerDefence.UI;
using UnityEngine;

namespace TowerDefence.Towers
{
	[SelectionBase]
	public class EmpySlot : MonoBehaviour
	{
		[Header("Archer")]
		[SerializeField] Tower archerTower = null;
		[SerializeField] int ArcherTowerPrice = 100;
		[Header("Tesla")]
		[SerializeField] TeslaTower teslaTower = null;
		[SerializeField] int TeslaTowerPrice = 200;
		[Header("Cannon")]
		[SerializeField] CanonTower canonTower = null;
		[SerializeField] int CannonTowerPrice = 250;
		[Header("UI")]
		[SerializeField] BuildUi buildUI = null;
		[SerializeField] Animator animator = null;
		[Header("Flag")]
		[SerializeField] Renderer flagMat = null;

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
			flagMat.material.SetColor("_EmissionColor", flagColor * 0.1f);
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

			if (levelController.GetGoldAmount() >= ArcherTowerPrice)
			{
				levelController.PayForTower(ArcherTowerPrice);
				Instantiate(archerTower, newTowerPos, transform.rotation);
				SelfDestroyPaltform();
			}
		}

		public void BuildTeslaTower()
		{
			if (levelController.GetGoldAmount() >= TeslaTowerPrice)
			{
				levelController.PayForTower(TeslaTowerPrice);
				Instantiate(teslaTower, newTowerPos, transform.rotation);
				SelfDestroyPaltform();
			}
		}

		public void BuildCannonTower()
		{
			if (levelController.GetGoldAmount() >= CannonTowerPrice)
			{
				levelController.PayForTower(CannonTowerPrice);
				Instantiate(canonTower, newTowerPos, transform.rotation);
				SelfDestroyPaltform();
			}
		}

		private void SelfDestroyPaltform()
		{
			Destroy(transform.parent.gameObject);
			
		}

	}
}


