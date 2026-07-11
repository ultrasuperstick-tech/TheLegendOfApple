using UnityEngine;

public class Damage : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject == "Bug")
        // 만약에 충돌체의 태그가 "Bug"와 같다면...
        if (collision.gameObject.CompareTag("Bug"))
        {
            // 나의 Hp가 깎이는 일.
        }
    }

    void GetDamage()
    {
        
    }
}
