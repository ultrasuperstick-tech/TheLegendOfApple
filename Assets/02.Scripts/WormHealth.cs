using Unity.VisualScripting;
using UnityEngine;

public class WormHealth : MonoBehaviour
{
    public float maxWormHp = 100;
    float wormHp;

    private void Start()
    {
        wormHp = maxWormHp;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            wormHp -= 50;
        }
    }

    private void Update()
    {
        if (wormHp <= 0)
        {
           gameObject.SetActive(false);
        }
    }
}
