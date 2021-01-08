using System;
using UnityEngine;


namespace TowerDefence.Core
{
	public class FinishLine : MonoBehaviour
	{
		public static event Action<GameObject> onFinishLineCrossed;

		private void OnTriggerEnter(Collider other)
		{
			if (other.tag == "Enemy")
			{
				onFinishLineCrossed?.Invoke(other.gameObject);
			}
		}
	}
}

