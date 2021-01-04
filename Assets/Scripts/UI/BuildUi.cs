using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence.UI
{
	//FIX THIS SCRIPT. NEEDS TO SHOW THE UI AND DISABLE THE REST
	public class BuildUi : MonoBehaviour
	{
		[SerializeField] GameObject buildingTowersContainer;
		[SerializeField] GameObject flag;

		private void Start()
		{
			buildingTowersContainer.SetActive(false);
		}


		public void ActivateOnlyOneUiElement()
		{
			BuildUi[] buidUiObjects = FindObjectsOfType<BuildUi>();
			foreach (BuildUi uiElement in buidUiObjects)
			{
				if (this != uiElement)
				{
					uiElement.buildingTowersContainer.SetActive(false);
					uiElement.flag.SetActive(true);


				}
				else
				{
					uiElement.buildingTowersContainer.SetActive(true);
					uiElement.flag.SetActive(false);
				}
			}
		}

		public static void DisableAll()
		{
			var allBuildUi = FindObjectsOfType<BuildUi>();
			foreach (BuildUi uiElement in allBuildUi)
			{
				uiElement.buildingTowersContainer.SetActive(false);
				uiElement.flag.SetActive(true);
			}
		}

	}
}

