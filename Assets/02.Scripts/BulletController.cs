using System.Threading;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 1.0f;
    Rigidbody2D rBody;

    private void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 direction)
    {
        rBody.linearVelocity = direction.normalized * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rBody.linearVelocity = Vector2.zero;
        rBody.angularVelocity = 0f;
        rBody.constraints = RigidbodyConstraints2D.FreezeAll;
        Destroy(gameObject, 0.5f);
    }
}
