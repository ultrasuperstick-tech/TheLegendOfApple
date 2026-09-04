using UnityEngine;

public class AppleController : MonoBehaviour
{
    AudioSource audioSource;
    Rigidbody2D rBody;
    public Transform appleVisual;
    public AudioClip jumpSound;

    // 움직이는 속도 조정.
    public float movePower = 20f;
    // 움직이는 속도 제한.
    public float maxMoveSpeed = 1f;
    // 점프하는 힘 증가.
    public float jumpPower = 300f;
    // 움직이는 방향.
    float moveInput = 0f;
    // 움직일 수 있는지 없는지 가능 여부.
    bool canMove = true;

    // 숫자가 작을수록 사과 그림이 천천히 회전함
    public float rollingSpeed = 300f;

    private void Awake()
    {
        // 리지드바디 컴포넌트 캐싱.
        rBody = GetComponent<Rigidbody2D>();

        // 실제 오브젝트는 회전하지 않게 고정
        audioSource = GetComponent<AudioSource>();
        rBody.freezeRotation = true;
        DontDestroyOnLoad(gameObject);
    }

    // 1초에 60번만 작동함 움직임을 관리할때는 이게 나아서 이렇게 함.
    private void FixedUpdate()
    {
        if (canMove == true)
        {
            // 쉬프트 키를 누르면 속도를 감속함.
            if (Input.GetKey(KeyCode.LeftShift))
            {
                movePower = 10;
                maxMoveSpeed = 1;
            }
            // 아니면 그냥 평소 속도로 움직임.
            else
            {
                movePower = 100;
                maxMoveSpeed = 2;
            }

            // 플래이어의 움직임을 담당함.
            AppleMove();

            // 플래이어의 이동속도를 제한함.
            MaxMoveSpeed();

            // 플래이어의 회전속도를 담당함.
            AppleSpin();
        }
    }
    private void Update()
    {
        // 플레이어의 점프를 담당함.
        AppleJump();
    }
    void AppleMove()
    {
        moveInput = 0f;

        // D를 눌러 방향을 오른쪽으로 함.
        if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1f;
        }

        // A를 눌러 방향을 왼쪽으로 함.
        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1f;
        }
        // 좌우로 이동
        rBody.AddForce(Vector2.right * moveInput * movePower);
    }

    void AppleJump()
    {
        // 스페이스 키를 누르고 linearVelocityY가 0 이라면 Vector2.up 에 jumpPower만큼 곱해 위로 힘을 준다.
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(this.rBody.linearVelocityY) <= 0.1f)
        {
            audioSource.PlayOneShot(jumpSound);
            rBody.AddForce(Vector2.up * jumpPower);
        }
    }

    void AppleSpin()
    {
        // 이동 속도는 유지하면서 그림만 천천히 회전.
        if (appleVisual != null)
        {
            float rotateAmount = -rBody.linearVelocity.x * rollingSpeed * Time.fixedDeltaTime;
            appleVisual.Rotate(0f, 0f, rotateAmount);
        }
    }

    void MaxMoveSpeed()
    {
        // 최대 이동 속도 제한.
        if (rBody.linearVelocity.x > maxMoveSpeed)
        {
            rBody.linearVelocity = new Vector2(maxMoveSpeed, rBody.linearVelocity.y);
        }
        else if (rBody.linearVelocity.x < -maxMoveSpeed)
        {
            rBody.linearVelocity = new Vector2(-maxMoveSpeed, rBody.linearVelocity.y);
        }
    }

    // 사과가 움직일 수 있는지 없는지를 관리함.
    public void SetMove(bool canMove)
    {
        this.canMove = canMove;
    }

    public bool GetMove()
    {
        return canMove;
    }
}
