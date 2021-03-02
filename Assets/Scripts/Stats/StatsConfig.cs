using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Statistics
{
	[CreateAssetMenu(fileName ="new stat", menuName = "Stat")]
	public class StatsConfig : ScriptableObject
	{
		[SerializeField] new string name = null;
		[SerializeField] float damage = 0f;
		[SerializeField] float health = 0f;
		[SerializeField] float magicResistance = 0f;
		[SerializeField] float pierceArmor = 0f;
		[SerializeField] Sprite avatarSprite = null;

		public float Damage { get => damage; }
		public float Health { get => health;  }
		public float MagicResistance { get => magicResistance;  }
		public float PierceArmor { get => pierceArmor;  }
		public string Name { get => name;  }
		public Sprite AvatarSprite { get => avatarSprite;  }
	}
}


