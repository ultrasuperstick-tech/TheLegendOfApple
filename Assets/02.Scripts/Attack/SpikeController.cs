using UnityEngine;

public class SpikeController : MonoBehaviour
{
    public GameObject spikeEffect;
    GameObject apple;
    Rigidbody2D rBody;
    public float spikeSpeed = 1.0f;


    private void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        apple = GameObject.Find("Apple");
    }

    public void SetDirection(Vector2 direction)
    {
        transform.up = direction;
        rBody.linearVelocity = direction.normalized * spikeSpeed;
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(spikeEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
