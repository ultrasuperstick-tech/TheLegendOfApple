using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppleContorller : MonoBehaviour
{
    Rigidbody2D rbody;             
    public float torquePower = 1.0f;   // 구르는 힘, 
    public float jumpPower = 1.0f;  // 점프하는 힘.
    public string sceneName;    // 바뀔 scene 이름.

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // FInish 라는 테그을 가지고있는 다른 오브젝트와 충돌하면 scene을 sceneName(변수)로 전환한다.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    private void Update()
    {
        if (transform.position.y <= -2f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void FixedUpdate()
    {
        // D키를 누르면 torquePower 에 -1을 곱한 값을 움직인다.
        if (Input.GetKey(KeyCode.D))
        {
            rbody.AddTorque(-torquePower);
        }

        // A키를 누르면 torquePower 에 1을 곱한 값을 움직인다.
        if (Input.GetKey(KeyCode.A))
        {
            rbody.AddTorque(torquePower);
        }

        // 이건 모름.
        if (Mathf.Abs(rbody.angularVelocity) > 300f)
        {
            rbody.angularVelocity = Mathf.Sign(rbody.angularVelocity) * 300f;
        }

        // 스페이스 키를 누르고 linearVelocityY가 0 이라면 Vector2.up 에 jumpPower만큼 곱해 위로 힘을 준다.
        if (Input.GetKey(KeyCode.Space) && this.rbody.linearVelocityY == 0)
        {
            rbody.AddForce(Vector2.up * jumpPower);
        }
    }
}
