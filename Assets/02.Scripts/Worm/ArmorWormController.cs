using UnityEngine;

public class ArmorWormController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
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
    bool appleFindFlag = false;


    private void Awake()
    {
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

        if (distance < senseDist && appleFindFlag == false)
        {
            appleFindFlag = true;

            wormSpeed = rushSpeed;

            if (wormPosX < applePositionX)
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
        else if (appleFindFlag == false)
        {
            wormSpeed = originalWormSpeed;
        }

        this.transform.position += Vector3.right * wormDir * wormSpeed * Time.deltaTime;

        // 웨이포인트 끝에 가면 방향 반대로
        if (wormPosX < wP_L.transform.position.x)
        {
            wormDir = 1;
            spriteRenderer.flipX = true;
            appleFindFlag = false;
        }

        if (wormPosX > wP_R.transform.position.x)
        {
            wormDir = -1;
            spriteRenderer.flipX = false;
            appleFindFlag = false;
        }
        
    }
}
        
