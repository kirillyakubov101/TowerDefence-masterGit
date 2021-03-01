using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence.Statistics
{
    public class Card : MonoBehaviour
    {
        [SerializeField] Text hpText = null;
        [SerializeField] Text damageText = null;
		[SerializeField] Text nameText = null;

		const string hp = "HP: ";
		const string dmg = "Dmg: ";

		public void DisplayStats(float hitPoints,float damage,string name)
		{
			hpText.text = hp + hitPoints.ToString();
			damageText.text = dmg + damage.ToString();
			nameText.text = name;
		}


	}
}


