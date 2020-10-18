using UnityEngine;

namespace TowerDefence.Core
{
	public class CameraController : MonoBehaviour
	{
		[SerializeField] float clampRadius = 12f;
		[SerializeField] float minZoomDis;
		[SerializeField] float maxZoomDis;
		[SerializeField] float moveSpeed;
		[SerializeField] float zoomSpeed;

		Camera cam;

		private void Awake()
		{
			cam = Camera.main;
		}

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

			Vector3 dir = Vector3.left * zInput + Vector3.forward * xInput;

			transform.position = Vector3.ClampMagnitude(transform.position += dir * moveSpeed * Time.deltaTime, clampRadius);

		}

		private void Zoom()
		{
			float scrollInput = Input.GetAxis("Mouse ScrollWheel");

			float dist = cam.transform.position.y - transform.position.y;


			if (dist < minZoomDis && scrollInput > 0f)
			{
				return;
			}
			else if (dist > maxZoomDis && scrollInput < 0f)
			{
				return;
			}

			cam.transform.position += cam.transform.forward * scrollInput * zoomSpeed;
		}



	}
}

