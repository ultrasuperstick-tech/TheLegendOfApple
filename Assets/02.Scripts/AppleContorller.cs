using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppleContorller : MonoBehaviour
{
    Rigidbody2D rBody;             
    public float torquePower = 1.0f;   // 구르는 힘, 
    public float jumpPower = 1.0f;  // 점프하는 힘.
    public string sceneName;    // 바뀔 scene 이름.
    public float maxSpeed = 300f;

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // FInish 라는 테그을 가지고있는 다른 오브젝트와 충돌하면 scene을 sceneName(변수)로 전환한다.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.y <= -2f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        Move();

        Jump();

        LimitMaxSpeed();
    }

    /// <summary>
    /// 사과의 최대속력을 제한합니다.
    /// </summary>
    void LimitMaxSpeed()
    {
        // MathF,Abs.() => 절대값.
        // rbody.angularVelocity => 회전속도.
        if ((rBody.angularVelocity) > maxSpeed)
        {
            rBody.angularVelocity = maxSpeed;
        }
        if ((rBody.angularVelocity) < -maxSpeed)
        {
            rBody.angularVelocity = -maxSpeed;
        }
    }

    /// <summary>
    /// 사과의 점프와 점프높이를 조절합니다.
    /// </summary>
    void Jump()
    {
        // 스페이스 키를 누르고 linearVelocityY가 0 이라면 Vector2.up 에 jumpPower만큼 곱해 위로 힘을 준다.
        if (Input.GetKeyDown(KeyCode.Space) && this.rBody.linearVelocityY == 0)
        {
            rBody.AddForce(Vector2.up * jumpPower);
        }
    }

    /// <summary>
    /// 사과의 움직임을 제어합니다.
    /// </summary>
    void Move()
    {
        // D키를 누르면 torquePower 에 +1을 곱한 값을 움직인다.
        if (Input.GetKey(KeyCode.D))
        {
            rBody.AddTorque(-torquePower);
        }

        // A키를 누르면 torquePower 에 -1을 곱한 값을 움직인다.
        if (Input.GetKey(KeyCode.A))
        {
            rBody.AddTorque(torquePower);
        }
    }

   

}
