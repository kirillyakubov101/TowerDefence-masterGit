using System.Collections;
using System.Collections.Generic;
using TowerDefence.Resources;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPrices : MonoBehaviour
{
	[SerializeField] Text archerTowerPriceValue = null;
	[SerializeField] Text teslaTowerPriceValue = null;
	[SerializeField] Text cannonTowerPriceValue = null;

	private void Update()
	{
		archerTowerPriceValue.text = TowerEconomics.archerTowerPrice.ToString();
		teslaTowerPriceValue.text = TowerEconomics.teslaTowerPrice.ToString();
		cannonTowerPriceValue.text = TowerEconomics.cannonTowerPrice.ToString();
	}
}
