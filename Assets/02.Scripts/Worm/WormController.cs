using UnityEngine;

public class WormController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public GameObject wP_L;
    public GameObject wP_R;
    public float wormSpeed = 1f;
    int wormDir = 1;
    

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        // 이번 프레임에 이동할 거리 = 방향 * 속도 * 시간보정.
        this.transform.position += Vector3.right * wormDir * wormSpeed * Time.deltaTime;

        if (this.transform.position.x < wP_L.transform.position.x)
        {
            wormDir = 1;
            spriteRenderer.flipX = true;
        }

        if (this.transform.position.x > wP_R.transform.position.x)
        {
            wormDir = -1;
            spriteRenderer.flipX = false;
        }
    }

        //this.rBody.AddForce(Vector2.right * wormDir * wormSpeed);
}
