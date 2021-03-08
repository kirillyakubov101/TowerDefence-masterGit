using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Props
{
	public class WindMill : MonoBehaviour
	{
		[SerializeField] Transform windTurbine = null;
		[SerializeField] float rotationSpeed = 2f;

		float zAngle = 0f;

		private void Update()
		{
			if (zAngle >= 360f)
			{
				zAngle = 0f;
			}

			zAngle += Time.deltaTime * rotationSpeed;
			windTurbine.localRotation = Quaternion.Euler(0f, 0f, zAngle);


		}
	}
}

