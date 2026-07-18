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
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bug"))
        {
            WormDamage wormDamage = collision.gameObject.GetComponent<WormDamage>();
            float WormPosX = collision.gameObject.transform.position.x;

            GetDamage(wormDamage.damage);

            KnockBack(WormPosX);

            GetDamage = null;

            
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
            
    }
}
