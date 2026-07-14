using UnityEngine;
using UnityEngine.UI;

//이 클래스는 HpBar를 조절하는 역할을 가지고 있습니다.
public class Health : MonoBehaviour
{
    public Rigidbody2D rBody;
    public GameObject hpBar;
    public float hp;
    float Damage;
    public WormDamage wormDamage;
    public float knockbackPower;


    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        {
            Vector2 knockbackDirection = new Vector2(-1f, 1f);
            
            if (wormDamage != null)
            {
                Damage = wormDamage.wormDamage * 0.01f;
            }

            if (collision.gameObject.CompareTag("Bug"))
            {
                hpBar.GetComponent<Image>().fillAmount -= Damage;
                rBody.AddForce(knockbackDirection * knockbackPower, ForceMode2D.Impulse);
            }

        }
    }
}
