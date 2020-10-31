using TowerDefence.Core;
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
			if (levelController.GetGoldAmount() < towerPrice) //magic number..need to fix
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

		//manually input the price of the tower based on its tag
		private int DetermineTowerPrice()
		{
			int price = 0;
			string tagName = TowerToPreview.tag;
			switch (tagName)
			{
				case "ghostArcher":
					price = 100;
					break;

				case "ghostTesla":
					price = 200;
					break;
				
			}
			return price;
		}
	}
}


