    using System.Threading;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // 총알의 속도 조정.
    public float bulletSpeed = 1.0f;
    // 리지드바디 컴포넌트.
    Rigidbody2D rBody;

    private void Awake()
    {
        // 리지드바디 컴포넌트 캐싱.
        rBody = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 direction)
    {
        // 방향을 다른 클래스에서 지정해주면 그 방향으로 속도를 곱해 날아가게 한다.
        rBody.linearVelocity = direction.normalized * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌시 움직임을 전부 멈추고 0.5초 뒤에 이 오브젝트를 삭제시킨다.
        rBody.linearVelocity = Vector2.zero;
        rBody.angularVelocity = 0f;
        rBody.constraints = RigidbodyConstraints2D.FreezeAll;
        Destroy(gameObject, 0.5f);
    }
}
