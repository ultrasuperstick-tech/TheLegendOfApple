using UnityEngine;

public class AppleController2 : MonoBehaviour
{

    public Rigidbody2D rbody;
    public Transform appleVisual;

    public float movePower = 20f;
    public float maxMoveSpeed = 1f;

    // 숫자가 작을수록 사과 그림이 천천히 회전함
    public float rollingSpeed = 300f;

    private void Awake()
    {
        if (rbody == null)
        {
            rbody = GetComponent<Rigidbody2D>();
        }

        // 실제 오브젝트는 회전하지 않게 고정
        rbody.freezeRotation = true;
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

        // 좌우로 이동
        rbody.AddForce(Vector2.right * moveInput * movePower);

        // 최대 이동 속도 제한
        if (rbody.linearVelocity.x > maxMoveSpeed)
        {
            rbody.linearVelocity = new Vector2(maxMoveSpeed, rbody.linearVelocity.y);
        }
        else if (rbody.linearVelocity.x < -maxMoveSpeed)
        {
            rbody.linearVelocity = new Vector2(-maxMoveSpeed, rbody.linearVelocity.y);
        }

        // 이동 속도는 유지하면서 그림만 천천히 회전(이건 AI)
        if (appleVisual != null)
        {
            float rotateAmount = -rbody.linearVelocity.x * rollingSpeed * Time.fixedDeltaTime;

            appleVisual.Rotate(0f, 0f, rotateAmount);
        }
    }
}
