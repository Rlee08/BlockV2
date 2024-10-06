using UnityEngine;

namespace Es.Utility
{
	/// <summary>
	/// Make it possible to operate cameras like Scene view in Game view.
	/// </summary>
	[RequireComponent(typeof(Camera))]
	public class SceneViewCamera : MonoBehaviour
	{
		[SerializeField, Range(0.1f, 100f)]
		private float wheelSpeed = 1f;

		[SerializeField, Range(0.1f, 100f)]
		private float moveSpeed = 0.3f;

		[SerializeField, Range(0.1f, 1f)]
		private float rotateSpeed = 0.3f;

		private Vector3 preMousePos;
		public float MoveSpeed = 10;

		private void Update()
		{
			MouseUpdate();
			

			// get input values
        	float inputX = Input.GetAxis("Horizontal");
        	float inputY = Input.GetAxis("Fly");
        	float inputZ = Input.GetAxis("Vertical");

        	// directions
        	Vector3 dirForward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up).normalized;
        	Vector3 dirSide = Camera.main.transform.right;
        	Vector3 dirUp = Vector3.up;

        	Vector3 moveDir = (inputX * dirSide) + (inputY * dirUp) + (inputZ * dirForward);

        	// move camera
        	transform.position += moveDir * MoveSpeed * Time.deltaTime;

			return;
		}

		private void MouseUpdate()
		{
			float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
			if(scrollWheel != 0.0f)
				MouseWheel(scrollWheel);

			if(Input.GetMouseButtonDown(0))
				preMousePos = Input.mousePosition;

			MouseDrag(Input.mousePosition);
		}

		private void MouseWheel(float delta)
		{
			transform.position += transform.forward * delta * wheelSpeed;
			return;
		}

		private void MouseDrag(Vector3 mousePos)
		{
			Vector3 diff = mousePos - preMousePos;

			if(diff.magnitude < Vector3.kEpsilon)
				return;

			if(Input.GetMouseButton(2))
				transform.Translate(-diff * Time.deltaTime * moveSpeed);
			else if(Input.GetMouseButton(0))
				CameraRotate(new Vector2(-diff.y, diff.x) * rotateSpeed);

			preMousePos = mousePos;
		}

		public void CameraRotate(Vector2 angle)
		{
			transform.RotateAround(transform.position, transform.right, angle.x);
			transform.RotateAround(transform.position, Vector3.up, angle.y);
		}
	}
}