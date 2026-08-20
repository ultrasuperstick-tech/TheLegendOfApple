using UnityEngine;

public class SpikeController : MonoBehaviour
{
    public GameObject apple;
    Rigidbody2D rBody;
    public float spikeSpeed = 1.0f;

    private void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        apple = GameObject.Find("Apple");
    }

    public void SetDirection(Vector2 direction)
    {
        transform.forward = direction;
        rBody.linearVelocity = direction.normalized * spikeSpeed;
        Destroy(gameObject, 100f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rBody.linearVelocity = Vector2.zero;
        rBody.angularVelocity = 0f;
        rBody.constraints = RigidbodyConstraints2D.FreezeAll;
        Destroy(gameObject, 0.5f);
    }
}
