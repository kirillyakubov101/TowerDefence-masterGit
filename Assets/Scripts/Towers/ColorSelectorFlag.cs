using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelectorFlag : MonoBehaviour
{
	[Header("Flag")]
	[SerializeField] Renderer flagMat = null;


	private void OnMouseOver()
	{
		flagMat.material.EnableKeyword("_EMISSION");
	}

	private void OnMouseExit()
	{
		flagMat.material.DisableKeyword("_EMISSION");
	}
}
