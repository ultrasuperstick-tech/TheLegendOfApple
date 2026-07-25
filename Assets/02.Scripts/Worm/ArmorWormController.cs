using UnityEngine;

public class ArmorWormController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Rigidbody2D rBody;
    public GameObject wP_L;
    public GameObject wP_R;
    public float wormSpeed = 1f;
    public float originalWormSpeed = 1f;
    public float rushSpeed = 20;
    public float senseDist = 6;
    GameObject apple;
    float applePositionX;
    float wormPosX;
    int wormDir = 1;


    private void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        apple = GameObject.Find("Apple");
    }

    private void Start()
    {
        wormSpeed = originalWormSpeed;
    }


    private void Update()
    {
        applePositionX = apple.transform.position.x;
        wormPosX = gameObject.transform.position.x;

        float distance = Mathf.Abs(wormPosX - applePositionX);

        Debug.Log(distance);

        if (distance < senseDist)
        {
            wormSpeed = rushSpeed;
        }
        else
        {
            wormSpeed = originalWormSpeed;
        }

        this.transform.position += Vector3.right * wormDir * wormSpeed * Time.deltaTime;

        if (wormPosX < wP_L.transform.position.x)
        {
            wormDir = 1;
            spriteRenderer.flipX = true;
        }

        if (wormPosX > wP_R.transform.position.x)
        {
            wormDir = -1;
            spriteRenderer.flipX = false;
        }
        if (wormPosX < applePositionX)
        {
            wormDir = 1;
            spriteRenderer.flipX = true;
        }
        if (wormPosX > applePositionX)
        {
            wormDir = -1;
            spriteRenderer.flipX = false;
        }
    }
}
        
