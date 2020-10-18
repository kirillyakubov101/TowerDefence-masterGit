using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence.UI
{
	public class BuildUi : MonoBehaviour
	{
		[SerializeField] Image buildImage;
		[SerializeField] GameObject ghostTower;
		[SerializeField] GameObject flag;

		private void Awake()
		{
			buildImage.enabled = false;
			ghostTower.SetActive(false);
		}


		public void ActivateOnlyOneUiElement()
		{
			BuildUi[] buidUiObjects = FindObjectsOfType<BuildUi>();
			foreach (BuildUi uiElement in buidUiObjects)
			{
				if (this != uiElement)
				{
					uiElement.GetBuildUiImage().enabled = false;
					uiElement.ghostTower.SetActive(false);
					uiElement.flag.SetActive(true);


				}
				else
				{
					uiElement.GetBuildUiImage().enabled = true;
					uiElement.ghostTower.SetActive(true);
					uiElement.flag.SetActive(false);
				}
			}
		}

		private Image GetBuildUiImage()
		{
			return buildImage;
		}

		public static void DisableAll()
		{
			var allBuildUi = FindObjectsOfType<BuildUi>();
			foreach (BuildUi uiElement in allBuildUi)
			{
				uiElement.GetBuildUiImage().enabled = false;
				uiElement.ghostTower.SetActive(false);
				uiElement.flag.SetActive(true);
			}
		}

	}
}

