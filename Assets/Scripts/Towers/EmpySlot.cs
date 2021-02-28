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
		[SerializeField] Tower archerTower = null; 
		[SerializeField] Transform archerTowerPos = null;
		[Header("Tesla")]
		[SerializeField] Tower teslaTower = null;
		[SerializeField] Transform teslaTowerPos = null;
		[Header("Cannon")]
		[SerializeField] Tower cannonTower = null;
		[SerializeField] Transform cannonTowerPos = null;
		[Header("Mage")]
		[SerializeField] Tower mageTower = null;
		[SerializeField] Transform mageTowerPos = null;
		[Header("UI")]
		[SerializeField] BuildUi buildUI = null;
		[SerializeField] Animator animator = null;
		[Header("Smoke Particle Effect")]
		[SerializeField] Transform smokePartcileTransform = null;
		[SerializeField] ParticleSystem smokeParticleEffect = null;

		LevelController levelController;
		

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
				archerTowerPos.position = AdjustNewTowerPosition(archerTowerPos);
				levelController.PayForTower(ArcherTowerPrice);
				Instantiate(archerTower, archerTowerPos.position, transform.rotation);
				SmokeTrail();
				SelfDestroyPaltform();
			}
		}

		public void BuildTeslaTower()
		{
			if (levelController.GetGoldAmount() >= TeslaTowerPrice)
			{
				teslaTowerPos.position = AdjustNewTowerPosition(teslaTowerPos);
				levelController.PayForTower(TeslaTowerPrice);
				Instantiate(teslaTower, teslaTowerPos.position, transform.rotation);
				SmokeTrail();
				SelfDestroyPaltform();
			}
		}

		public void BuildCannonTower()
		{
			if (levelController.GetGoldAmount() >= CannonTowerPrice)
			{
				cannonTowerPos.position = AdjustNewTowerPosition(cannonTowerPos);
				levelController.PayForTower(CannonTowerPrice);
				Instantiate(cannonTower, cannonTowerPos.position, transform.rotation);
				SmokeTrail();
				SelfDestroyPaltform();
			}
		}

		public void BuildMageTower()
		{
			if (levelController.GetGoldAmount() >= mageTowerPrice)
			{
				mageTowerPos.position = AdjustNewTowerPosition(mageTowerPos);
				levelController.PayForTower(mageTowerPrice);
				Instantiate(mageTower, mageTowerPos.position, transform.rotation);
				SmokeTrail();
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

		private Vector3 AdjustNewTowerPosition(Transform towerPos)
		{
			towerPos.position = new Vector3(towerPos.position.x, towerPos.position.y - 5, towerPos.position.z);
			return towerPos.position;
		}

		private void SmokeTrail()
		{
			Instantiate(smokeParticleEffect, smokePartcileTransform.position, smokePartcileTransform.rotation);
		}

	}
}


