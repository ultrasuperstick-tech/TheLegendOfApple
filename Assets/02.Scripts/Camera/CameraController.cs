using UnityEngine;

public class CameraController : MonoBehaviour
{
    // 티겟 오브젝트 지정.
    public Transform target;
    GameObject apple;
    Rigidbody2D appleRBody;
    // 확대된 카메라 크기 조정,
    public float smallCameraSize = 1;
    // 평소 카메라 사이즈 조정.
    public float normalCameraSize = 4;
    // 카메라 확대되는 속도.
    public float cameraSpeed = 2;
    public float maxCameraTime = 5;
    float cameraTimer = 0;



    private void Awake()
    {
        // apple 오브젝트 캐싱.
        apple = GameObject.Find("Apple");
        // 사과의 리지드바디 컴포넌트 캐싱.
        appleRBody = apple.GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // 카메라 사이즈를 기본 사이즈로 한다.
        Camera.main.orthographicSize = normalCameraSize;
    }

    private void Update()
    {
        // 가만히 얼마나 오래있는지 측정.
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
            // 카메라 사이즈를 원래대로 돌려둔다.
            Camera.main.orthographicSize = normalCameraSize;
            // 타이머 초기화.
            cameraTimer = 0;
        }
        else
        {
            // 가만히 오래있으면,
            if (cameraTimer > maxCameraTime)
            {
                // 카메라 사이즈를 축소시킨다.
                Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, smallCameraSize, Time.deltaTime * cameraSpeed);
            }
        }
    }
}
