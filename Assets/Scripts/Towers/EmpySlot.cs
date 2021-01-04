using TowerDefence.Core;
using TowerDefence.Resources;
using TowerDefence.UI;
using UnityEngine;

namespace TowerDefence.Towers
{
	[SelectionBase]
	public class EmpySlot : MonoBehaviour
	{
		[Header("Archer")]
		[SerializeField] Tower archerTower = null; //check if i can change all to TOWER script
		[Header("Tesla")]
		[SerializeField] TeslaTower teslaTower = null;
		[Header("Cannon")]
		[SerializeField] CanonTower canonTower = null;
		[Header("Mage")]
		[SerializeField] Tower mageTower = null;
		[Header("UI")]
		[SerializeField] BuildUi buildUI = null;
		[SerializeField] Animator animator = null;
		[Header("Flag")]
		[SerializeField] Renderer flagMat = null;

		[SerializeField] Transform towerPlace = null;

		Vector3 newTowerPos;
		LevelController levelController;
		Color flagColor;

		//vars
		int ArcherTowerPrice;
		int TeslaTowerPrice;
		int CannonTowerPrice;
		int mageTowerPrice;

		private void Awake()
		{
			levelController = FindObjectOfType<LevelController>();

		}

		private void Start()
		{
			InitializeTowerPrices();
			newTowerPos = towerPlace.position;
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

		public void BuildMageTower()
		{
			if (levelController.GetGoldAmount() >= mageTowerPrice)
			{
				levelController.PayForTower(mageTowerPrice);
				Instantiate(mageTower, newTowerPos, transform.rotation);
				SelfDestroyPaltform();
			}
		}

		private void SelfDestroyPaltform()
		{
			Destroy(transform.parent.gameObject);
			
		}

		private void InitializeTowerPrices()
		{
			ArcherTowerPrice = TowerEconomics.archerTowerPrice;
			TeslaTowerPrice = TowerEconomics.teslaTowerPrice;
			CannonTowerPrice = TowerEconomics.cannonTowerPrice;
			mageTowerPrice = TowerEconomics.mageTowerPrice;

		}

	}
}


