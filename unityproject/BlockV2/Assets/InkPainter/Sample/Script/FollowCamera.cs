using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    Camera cam;
    public Vector3 offset = new Vector3 (0, 7, -9);

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //offset camera position to player
        transform.position = cam.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
