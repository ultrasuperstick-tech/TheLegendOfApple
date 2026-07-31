using UnityEngine;

public class JumpWormController : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    Rigidbody2D rBody;
    Vector2 spawnPos;
    public float wormSpeed = 1f;
    public float originalWormSpeed = 1f;
    public float senseDist = 6;
    public float wormJumpPower = 300f;
    public float returnDist = 10;
    GameObject apple;
    float applePosX;
    float wormPosX;
    int wormDir = 1;
    bool goHome = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        apple = GameObject.Find("Apple");
        rBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        wormSpeed = originalWormSpeed;
        spawnPos = transform.position;
    }


    private void Update()
    {
        applePosX = apple.transform.position.x;
        wormPosX = transform.position.x;

        // 애벌레와 사과와의 거리.
        float distance = Mathf.Abs(wormPosX - applePosX);
        // 스폰된 위치로 부터 현재거리.
        float fromHomeDist = Mathf.Abs(spawnPos.x - wormPosX);
        // 일정거리 멀어지면 처음위치로 돌아감.
        if (fromHomeDist > returnDist)
        {
            goHome = true;
            spriteRenderer.flipX = !spriteRenderer.flipX;
            wormDir = -wormDir;
            wormSpeed = 10f;
        }
        // 집에 거의 다 도착하면 다시 작동.
        else if (fromHomeDist < 1)
        {
            goHome = false;
            wormSpeed = originalWormSpeed;
        }

        if (distance < senseDist && goHome == false)
        {
            // 플래이어가 점프할때 이 애벌래도 같이 점프함.
            if (Input.GetKeyDown(KeyCode.Space) && rBody.linearVelocityY == 0)
            {
                rBody.AddForce(Vector2.up * wormJumpPower);
            }

            // 방향과 바라보는 방향 조정.
            if (wormPosX < applePosX)
            {
                wormDir = 1;
                spriteRenderer.flipX = true;
            }
            else
            {
                wormDir = -1;
                spriteRenderer.flipX = false;
            }
        }

        Move();
    }

    // 움직임 관리.
    void Move()
    {
        this.transform.position += Vector3.right * wormDir * wormSpeed * Time.deltaTime;
    }
}
