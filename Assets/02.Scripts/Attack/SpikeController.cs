using UnityEngine;

public class SpikeController : MonoBehaviour
{
    // 충돌했을 때 효과.
    public GameObject spikeEffect;
    // 리지드바디 컴포넌트
    Rigidbody2D rBody;
    // 가시의 속도.
    public float spikeSpeed = 1.0f;


    private void Awake()
    {
        // 리지드바디 컴포넌트 캐싱.
        rBody = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 direction)
    {
        // 방향을 다른 클래스에서 지정해주면 그 방향으로 속도를 곱해 날아가게 한다.
        transform.up = direction;
        rBody.linearVelocity = direction.normalized * spikeSpeed;
        // 5초 이 오브젝트를 삭제.
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌했을 떄 효과 소환.
        Instantiate(spikeEffect, transform.position, transform.rotation);
        // 이 오브젝트가 충돌했을때 삭제.
        Destroy(gameObject);
    }
}
