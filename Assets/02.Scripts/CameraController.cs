using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    GameObject apple;
    Rigidbody2D rBody;
    Rigidbody2D appleRBody;
    public float smallCameraSize = 1;
    public float normalCameraSize = 4;
    public float cameraSpeed = 2;
    public float maxCameraTime = 5;
    float cameraTimer = 0;



    private void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        apple = GameObject.Find("Apple");
        appleRBody = apple.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Camera.main.orthographicSize = normalCameraSize;
    }

    private void Update()
    {
        cameraTimer += Time.deltaTime;
    }

    private void LateUpdate()
    {
        Vector3 pos = target.position;
        pos.z = -10;

        transform.position = pos;

        if (!Input.GetMouseButton(0) && appleRBody.linearVelocity.x == 0 && appleRBody.linearVelocity.y == 0 && cameraTimer > maxCameraTime)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, smallCameraSize, Time.deltaTime * cameraSpeed);
        }
        else if (Input.GetMouseButton(0) || appleRBody.linearVelocity.x != 0 || appleRBody.linearVelocity.y != 0)
        {
            Camera.main.orthographicSize = normalCameraSize;
            cameraTimer = 0;
        }
    }
}
