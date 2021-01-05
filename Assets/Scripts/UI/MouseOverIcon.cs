using TowerDefence.Core;
using TowerDefence.Resources;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence.UI
{
	public class MouseOverIcon : MonoBehaviour
	{
		[SerializeField] GameObject TowerToPreview = null;

		LevelController levelController;
		Button btn;
		bool showOnHover;
		int towerPrice;
		


		private void Awake()
		{
			levelController = FindObjectOfType<LevelController>();
			btn = GetComponent<Button>();
		}

		private void Start()
		{
			towerPrice = DetermineTowerPrice();
			showOnHover = true;
			
		}

		private void Update()
		{
			if (levelController.GetGoldAmount() < towerPrice) 
			{
				btn.interactable = false;
				showOnHover = false;
			}
			else
			{
				btn.interactable = true;
				showOnHover = true;
			}
		}

		private void OnMouseOver()
		{
			if (!showOnHover) { return; }
			TowerToPreview.SetActive(true);
		}

		private void OnMouseExit()
		{
			TowerToPreview.SetActive(false);
		}

		private int DetermineTowerPrice()
		{
			int price = 0;
			string tagName = TowerToPreview.tag;
			switch (tagName)
			{
				case "ghostArcher":
					price = TowerEconomics.archerTowerPrice;
					break;

				case "ghostTesla":
					price = TowerEconomics.teslaTowerPrice;
					break;

				case "ghostCannon":
					price = TowerEconomics.cannonTowerPrice;
					break;

				case "ghostMage":
					price = TowerEconomics.mageTowerPrice;
					break;


			}
			return price;
		}
	}
}


