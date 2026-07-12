using UnityEngine;
using UnityEngine.UI;

//이 클래스는 HpBar를 조절하는 역할을 가지고 있습니다.
public class Health : MonoBehaviour
{
    public GameObject hpBar;

    private void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject == "Bug")
        // 만약에 충돌체의 태그가 "Bug"와 같다면...
        if (collision.gameObject.CompareTag("Bug"))
        {
            // 나의 Hp가 깎이는 일.
            hpBar.GetComponent<Image>().fillAmount -= 0.1f;
        }
    }
}
