using UnityEngine;

public class SurpassWorm : MonoBehaviour
{
   Rigidbody2D rBody;
    public LayerMask groundLayer;
    SpriteRenderer spr;

    public float jumpPower;
    public float distance = 1.0f;

    private void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector2 direction;

        if (spr.flipX == false)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.right;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, groundLayer);
        if(hit.transform != null)
        {
            if (this.rBody.linearVelocityY < 0.1f)
            {
                Surpass();
            }
        }

        Debug.DrawRay(transform.position, direction * distance, Color.red, 0.1f);
    }

    void Surpass()
    {
        rBody.AddForce(Vector2.up * jumpPower);
    }
}
