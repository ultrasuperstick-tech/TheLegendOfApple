using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    GameObject apple;
    Rigidbody2D appleRBody;
    public float smallCameraSize = 1;
    public float normalCameraSize = 4;
    public float cameraSpeed = 2;
    public float maxCameraTime = 5;
    float cameraTimer = 0;



    private void Awake()
    {
        apple = GameObject.Find("Apple");
        appleRBody = apple.GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(this);
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
        // 카메라가 사과를 따라다님.
        Vector3 pos = target.position;
        pos.z = -10;

        transform.position = pos;

        // 아무 행동도 하지않고 일정시간이 지나면 카메라가 서서히 확대됌.
        if (Input.GetMouseButton(0) || appleRBody.linearVelocity.x != 0 || appleRBody.linearVelocity.y != 0)
        {
            Camera.main.orthographicSize = normalCameraSize;
            cameraTimer = 0;
        }
        else
        {
            if (cameraTimer > maxCameraTime)
            {
                Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, smallCameraSize, Time.deltaTime * cameraSpeed);
            }
        }
    }
}
