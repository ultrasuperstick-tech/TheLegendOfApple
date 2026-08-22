using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//이 클래스는 HpBar를 조절하는 역할을 가지고 있습니다.
public class AppleHealth : MonoBehaviour
{
    Rigidbody2D rBody;
    AppleController appleController;
    Image hpBar;
    TMP_Text hpText;
    Animator animator;
    GameObject hpBarObject;
    GameObject hpTextObject;
    public float hp = 100f;
    public float maxHp = 100f;
    public float knockbackPower;
    float invincibleTimer = 0;
    float defenselessTimer = 0;
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
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        hp = maxHp;
    }

    private void Update()
    {

        // 무적이면 무적시간 타이머 시작, 에니메이션 시작
        if (layerCollision == true)
        {
            invincibleTimer += Time.deltaTime;
            animator.SetBool("AppleGetDamage", true);
        }

        // 타이머가 지나면 무적 헤제
        if (layerCollision == true && invincibleTimer > invincibleTime)
        {
            layerCollision = false;
            Physics2D.IgnoreLayerCollision(6, 7, layerCollision);
            invincibleTimer = 0;
            animator.SetBool("AppleGetDamage", false);
        }

        // 움직일 수 없는 시간부터 타이머 시작.
        if (appleController.GetMove() == false)
        {
            defenselessTimer += Time.deltaTime;
        }

        // 무방비시간 끝.
        if (appleController.GetMove() == false && defenselessTimer > defenselessTime)
        {
            appleController.SetMove(true);
            defenselessTimer = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 에벌레랑 충돌했을때.
        if ( collision.gameObject.CompareTag("Bug"))
        {
            WormDamage wormDamage = collision.gameObject.GetComponent<WormDamage>();
            float enemyPosX = collision.gameObject.transform.position.x;

            // 데미지 입음.
            GetDamage(wormDamage.damage);

            // 넉백 당함.
            EnemyKnockBack(enemyPosX);

            // 레이어 충돌 해제
            layerCollision = true;
            Physics2D.IgnoreLayerCollision(6, 7, layerCollision);
        }

        if (collision.gameObject.CompareTag("Spike"))
        {
            Spike spikeDamage = collision.gameObject.GetComponent<Spike>();

            GetDamage(spikeDamage.spikeDamage);

            trapKnockBack();

            layerCollision = true;
            Physics2D.IgnoreLayerCollision(6, 7, layerCollision);
        }
    }

    void GetDamage(float damage)
    {
        // hp바에서 데미지 만큼 빼 보여줌.
        hp = hp - damage;

        hpBar.fillAmount = hp / maxHp;
        hpText.text = hpBar.fillAmount * 100 + "%";
    }

    void EnemyKnockBack(float enemyPosX)
    {
        float knockbackDir = 1f;

        // 맞은 방향에 따라서 넉백당하는 방향을 정함,
        if (enemyPosX < this.gameObject.transform.position.x)
        {
            knockbackDir = 1;
        }
        else
        {
            knockbackDir = -1;
        }

        // 넉백 당함.
        Vector2 knockbackDirection = new Vector2(knockbackDir, 1f);

        rBody.AddForce(knockbackDirection * knockbackPower, ForceMode2D.Impulse);

        // 사과의 움직임을 멈춤.
        appleController.SetMove(false);
    }

    void trapKnockBack()
    {
        float knockbackDir = -1f;

        // 넉백 당함.
        Vector2 knockbackDirection = new Vector2(knockbackDir, 1f);

        rBody.AddForce(knockbackDirection * knockbackPower, ForceMode2D.Impulse);

        // 사과의 움직임을 멈춤.
        appleController.SetMove(false);
    }
}
