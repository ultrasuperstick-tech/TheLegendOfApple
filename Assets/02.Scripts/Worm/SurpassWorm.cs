using UnityEngine;

public class SurpassWorm : MonoBehaviour
{
   Rigidbody2D rBody;
    public LayerMask groundLayer;
    SpriteRenderer spr;

    // 애벌래가 뛰는 힘
    public float jumpPower = 500;
    // 감지하는 거리
    public float distance = 1.0f;

    private void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector2 direction;

        // 보고있는 방향에 따라서 direction 을 정함
        if (spr.flipX == false)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.right;
        }

        // distance 거리 이내에 벽이 있는지 감지하기 위해 Ray를 쏨
        // Ray가 충돌한 정보를 hit 변수에 넣음
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, groundLayer);

        // 맞은 물체가 있다면
        if(hit.transform != null)
        {
            // 점프 도중이 아니라면
            if (this.rBody.linearVelocityY < 0.1f)
            {
                // 넘어간다
                Surpass();
            }
        }

        // Raycast를 빨간색으로 그린다
        Debug.DrawRay(transform.position, direction * distance, Color.red, 0.1f);
    }

    void Surpass()
    {
        // 위로 힘을 jumpPower만큼 한번에 준다
        rBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }
}
