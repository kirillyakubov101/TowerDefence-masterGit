using UnityEngine;

namespace TowerDefence.Core
{
	public class CameraController : MonoBehaviour
	{
		//[SerializeField] float clampRadius = 12f;
		[SerializeField] float minZoomDis;
		[SerializeField] float maxZoomDis;
		[SerializeField] float moveSpeed;
		[SerializeField] float zoomSpeed;
		//Borders
		[SerializeField] Transform screenTopYBorder = null;
		[SerializeField] Transform screenBotYBorder = null;
		[SerializeField] Transform screenLeftXBorder = null;
		[SerializeField] Transform screenRightXBorder = null;




		// Update is called once per frame
		void Update()
		{
			Move();
			Zoom();
		}

		private void Move()
		{
			float xInput = Input.GetAxis("Horizontal");
			float zInput = Input.GetAxis("Vertical");


			if (screenLeftXBorder.position.z >= transform.position.z && xInput < 0)
			{
				xInput = 0f;
			}

			if (screenRightXBorder.position.z <= transform.position.z && xInput > 0)
			{
				xInput = 0f;
			}

			if(screenTopYBorder.position.x >= transform.position.x && zInput > 0)
			{
				zInput = 0f;
			}

			if(screenBotYBorder.position.x <= transform.position.x && zInput < 0)
			{
				zInput = 0f;
			}
			

			Vector3 dir = Vector3.left * zInput + Vector3.forward * xInput;

			//transform.position = Vector3.ClampMagnitude(transform.position += dir * moveSpeed * Time.deltaTime, clampRadius);
			transform.position += dir * moveSpeed * Time.deltaTime;
		}

		private void Zoom()
		{
			
			float scrollInput = Input.GetAxis("Mouse ScrollWheel");


			float dist = transform.position.y;

			if (dist > minZoomDis && scrollInput < 0f)
			{
				return;
			}
			else if (dist < maxZoomDis && scrollInput > 0f)
			{
				return;
			}

			transform.position += transform.up * (-scrollInput) * zoomSpeed;
		}



	}
}

