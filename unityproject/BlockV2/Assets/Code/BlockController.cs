using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter.Sample;
// using System.Numerics;

public class BlockController : MonoBehaviour {

    // public variables visible in inspector
    // public Vector2 CameraSpeed = new Vector2(180, 180);
    // public float MoveSpeed = 10;
    public GameObject BlockPrefab;
    [SerializeField] GameObject blockOutline;
    // MousePainter mousePainter;

    // Camera cam;

    // private variables
    // private float Pitch = 0;
    // private float Yaw = 0;
    private RaycastHit Hit;
    // public Ray ray;

    // public Vector3 pos;

    [SerializeField] GameObject makeButtonToggle;
    [SerializeField] GameObject makeButton;
    // [SerializeField] GameObject paintButtonToggle;
    [SerializeField] GameObject clearButtonToggle;
    [SerializeField] GameObject clearButton;

    // Start is called before the first frame update
    void Start() {
        // Cursor.lockState = CursorLockMode.Locked;
        // cam = Camera.main;

        // mousePainter = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MousePainter>();
        // mousePainter.enabled = false;
    }

    // Update is called once per frame
    void Update() {

        // STEP 1

        // // look around
        // Pitch += -Input.GetAxis("Mouse Y") * CameraSpeed.x * Time.deltaTime;
        // Yaw += Input.GetAxis("Mouse X") * CameraSpeed.y * Time.deltaTime;

        // Camera.main.transform.eulerAngles = new Vector3(Pitch, Yaw, 0);

        // STEP 2

        // // get input values
        // float inputX = Input.GetAxis("Horizontal");
        // float inputY = Input.GetAxis("Fly");
        // float inputZ = Input.GetAxis("Vertical");

        // // directions
        // Vector3 dirForward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up).normalized;
        // Vector3 dirSide = Camera.main.transform.right;
        // Vector3 dirUp = Vector3.up;

        // Vector3 moveDir = (inputX * dirSide) + (inputY * dirUp) + (inputZ * dirForward);

        // // move camera
        // Camera.main.transform.position += moveDir * MoveSpeed * Time.deltaTime;

        // STEP 3

        // raycast
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // looking at a block
        if (Physics.Raycast(ray, out Hit)) {

            Vector3 pos = Hit.point;

            // move away from the surface slightly
            pos += Hit.normal * 0.1f;

            // round the position values to whole numbers
            pos = new Vector3(
                Mathf.Floor(pos.x),
                Mathf.Floor(pos.y),
                Mathf.Floor(pos.z));

            // offset position by half a block
            pos += Vector3.one * 1f;

            // set outline block position for preview
            blockOutline.transform.position = pos;

            // left click
            if (Input.GetMouseButtonDown(0)) {
                if (makeButtonToggle.activeSelf) {
                    Instantiate(BlockPrefab, pos, Quaternion.identity);
                }
                else if (clearButtonToggle.activeSelf){
                    Debug.Log ("it should clear now");
                    if (Hit.collider.name == "Cube")
                    Destroy(Hit.collider.gameObject);
                }
            }

            // right click
            // else if (Input.GetMouseButtonDown(1)) {
            //     Debug.Log ("right down");
            //     if (Hit.collider.name == "Cube"){
            //         Debug.Log("i hit");
            //         Destroy(Hit.collider.gameObject);
            //     }
            //     else {
            //         Debug.Log("didnt hit");
            //     }

            // }
        }
    }

    // public void OnPaint() {
    //     mousePainter.enabled = true;
    // }

    // public void OffPaint() {
    //     mousePainter.enabled = false;
    // }

    // public void OnMakeBlock() {
        
    //     Instantiate(BlockPrefab, pos, Quaternion.identity);
    // }

    // private void OnDrawGizmos() {

    //     // camera ray
    //     Gizmos.color = Color.blue;
    //     Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 99999);

    //     // collision point
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawSphere(Hit.point, 0.05f);

    //     // surface direction
    //     Gizmos.DrawRay(Hit.point, Hit.normal);
    // }
}
