using Unity.VisualScripting;
using UnityEngine;

public class WormHealth : MonoBehaviour
{
    // 애벌래의 체력.
    public float maxWormHp = 100;
    float wormHp;

    private void Start()
    {
        wormHp = maxWormHp;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 애벌래가 총알에 쳐맞으면 체력이 감소함.
        if (collision.gameObject.CompareTag("Bullet"))
        {
            wormHp -= 50;
        }
    }

    private void Update()
    {
        if (wormHp <= 0)
        {
           // 체력이 0보다 작거나 같아지면 사라지게 함.
           gameObject.SetActive(false);
        }
    }
}
