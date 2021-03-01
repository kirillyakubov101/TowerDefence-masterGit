using System;
using TowerDefence.AI;
using TowerDefence.Towers;
using TowerDefence.UI;
using UnityEngine;
using TowerDefence.Statistics;

namespace TowerDefence.Core
{
	public class GameSession : MonoBehaviour
	{
		[SerializeField] Texture2D defaultCursor = null;
		[SerializeField] GameObject enemyCard = null;
		[SerializeField] LayerMask enemyLayerMask = new LayerMask();
		[SerializeField] Card card = null;

		StatsConfig currentStat;

		private void Start()
		{
			Cursor.SetCursor(defaultCursor, Vector3.zero, CursorMode.Auto);
		}

		private void Update()
		{
			//IF the ground is being clicked
			CheckRandomClicks();
			//IF the enemy is being clicked
			CheckEnemyClicks();

		}

		private void CheckEnemyClicks()
		{
			if (Input.GetMouseButtonUp(0))
			{
				bool isHit = Physics.Raycast(mouseRay(), out RaycastHit hit, Mathf.Infinity,enemyLayerMask);
				if (isHit)
				{
					//stats
					currentStat = hit.collider.GetComponent<Health>().StatsConfig; //get the stat from the health comp
					card.DisplayStats(currentStat.Health,currentStat.Damage, currentStat.Name);
					enemyCard.SetActive(true);
				}
				else
				{
					enemyCard.SetActive(false);
				}
			}
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

