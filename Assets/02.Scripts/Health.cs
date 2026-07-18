using TMPro;
using UnityEngine;
using UnityEngine.UI;

//이 클래스는 HpBar를 조절하는 역할을 가지고 있습니다.
public class Health : MonoBehaviour
{
    Rigidbody2D rBody;
    AppleController appleController;
    Image hpBar;
    TMP_Text hpText;
    GameObject hpBarObject;
    GameObject hpTextObject;
    public float maxHp = 100f;
    public float hp = 100f;
    public float knockbackPower;
    public float timer = 0;
    public float timer2 = 0;
    public float invincibleTime = 3f;
    public float defenselessTime = 3f;
    bool layerCollision = false;

    private void Awake()
    {
        //캐싱
        rBody = GetComponent<Rigidbody2D>();
        appleController = GetComponent<AppleController>();
        hpBarObject = GameObject.Find("HpBar");
        hpBar = hpBarObject.GetComponent<Image>();
        hpTextObject = GameObject.Find("HpText");
        hpText = hpTextObject.GetComponent<TMP_Text>();
    }

    private void Start()
    {
        hp = maxHp;
    }

    private void Update()
    {
        // 시간체크해서 일정시간 지나면 충돌가능하게 변경 - 레이어 충돌 넣기

        if (layerCollision == true)
        {
            timer += Time.deltaTime;
        }

        if (layerCollision == true && timer > invincibleTime)
        {
            layerCollision = false;
            Physics2D.IgnoreLayerCollision(6, 7, layerCollision);
            timer = 0;
        }

        if (appleController.enabled == false)
        {
            timer2 += Time.deltaTime;
        }

        if (appleController.enabled == false && timer2 > defenselessTime)
        {
            appleController.enabled = true;
            timer2 = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bug"))
        {
            WormDamage wormDamage = collision.gameObject.GetComponent<WormDamage>();
            float WormPosX = collision.gameObject.transform.position.x;

            GetDamage(wormDamage.damage);

            KnockBack(WormPosX);

<<<<<<< HEAD
            GetDamage = null;

            
=======
            // 레이어 충돌 해제
            layerCollision = true;

            Physics2D.IgnoreLayerCollision(6, 7, layerCollision);
>>>>>>> 6db0fa5461edd7c446c8d1cc2bb4664fb564b2f4
        }
    }

    void BeInvincible()
    {

    }
    void GetDamage(float damage)
    {
        hp = hp - damage;

        hpBar.fillAmount = hp / maxHp;
        hpText.text = hpBar.fillAmount * 100 + "%";
    }

    void KnockBack(float wormPosX)
    {
        float knockbackDir = 1f;

        if (wormPosX < this.gameObject.transform.position.x)
        {
            knockbackDir = 1;
        }
        else
        {
            knockbackDir = -1;
        }

        Vector2 knockbackDirection = new Vector2(knockbackDir, 1f);

        rBody.AddForce(knockbackDirection * knockbackPower, ForceMode2D.Impulse);

        appleController.enabled = false;

        
    }
}
