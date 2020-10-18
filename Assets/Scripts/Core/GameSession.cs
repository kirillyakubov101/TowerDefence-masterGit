using TowerDefence.Towers;
using TowerDefence.UI;
using UnityEngine;

namespace TowerDefence.Core
{
	public class GameSession : MonoBehaviour
	{
		private void Update()
		{
			if (Input.GetMouseButtonUp(0))
			{
				RaycastHit hit;
				bool isHit = Physics.Raycast(mouseRay(), out hit);
				if (isHit)
				{
					if (!hit.collider.GetComponent<EmpySlot>())
					{
						BuildUi.DisableAll();
					}
				}
			}

		}

		private Ray mouseRay()
		{
			return Camera.main.ScreenPointToRay(Input.mousePosition);
		}
	}
}

