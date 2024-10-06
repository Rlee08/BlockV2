using UnityEngine;

public class NewCameraController : MonoBehaviour
{

    public Vector2 CameraSpeed = new Vector2(180, 180);
    public float MoveSpeed = 10;

    private float Pitch = 0;
    private float Yaw = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // look around
        Pitch += -Input.GetAxis("Mouse Y") * CameraSpeed.x * Time.deltaTime;
        Yaw += Input.GetAxis("Mouse X") * CameraSpeed.y * Time.deltaTime;

        Camera.main.transform.eulerAngles = new Vector3(Pitch, Yaw, 0);

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
        Camera.main.transform.position += moveDir * MoveSpeed * Time.deltaTime;        
    }
}
