using TowerDefence.Towers;
using TowerDefence.UI;
using UnityEngine;

namespace TowerDefence.Core
{
	public class GameSession : MonoBehaviour
	{
		[SerializeField] Texture2D defaultCursor = null;

		private void Start()
		{
			Cursor.SetCursor(defaultCursor, Vector3.zero, CursorMode.Auto);
		}

		private void Update()
		{
			//IF the ground is being clicked
			CheckRandomClicks();

		}

		private void CheckRandomClicks()
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

		public Texture2D GetDefaultCursorTexture()
		{
			return defaultCursor;
		}
	}
}

