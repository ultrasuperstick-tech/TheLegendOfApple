using UnityEngine;

public class AppleController : MonoBehaviour
{

    public Rigidbody2D rBody;
    public Transform appleVisual;

    public float movePower = 20f;
    public float maxMoveSpeed = 1f;
    public float jumpPower = 300f;

    // 숫자가 작을수록 사과 그림이 천천히 회전함
    public float rollingSpeed = 300f;

    private void Awake()
    {
        if (rBody == null)
        {
            rBody = GetComponent<Rigidbody2D>();
        }

        // 실제 오브젝트는 회전하지 않게 고정
        rBody.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        float moveInput = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1f;
        }

        // 스페이스 키를 누르고 linearVelocityY가 0 이라면 Vector2.up 에 jumpPower만큼 곱해 위로 힘을 준다.
        if (Input.GetKey(KeyCode.Space) && this.rBody.linearVelocityY == 0)
        {
            rBody.AddForce(Vector2.up * jumpPower);
        }

        // 좌우로 이동
        rBody.AddForce(Vector2.right * moveInput * movePower);

        // 최대 이동 속도 제한
        if (rBody.linearVelocity.x > maxMoveSpeed)
        {
            rBody.linearVelocity = new Vector2(maxMoveSpeed, rBody.linearVelocity.y);
        }
        else if (rBody.linearVelocity.x < -maxMoveSpeed)
        {
            rBody.linearVelocity = new Vector2(-maxMoveSpeed, rBody.linearVelocity.y);
        }

        // 이동 속도는 유지하면서 그림만 천천히 회전
        if (appleVisual != null)
        {
            float rotateAmount = -rBody.linearVelocity.x * rollingSpeed * Time.fixedDeltaTime;

            appleVisual.Rotate(0f, 0f, rotateAmount);
        }
    }

}
