using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject firePoint;
    public GameObject Arrow;
    public GameObject bulletColdown;
    TMP_Text cooldown_Text;
    float bulletTimer = 0;
    public float bulletReady = 5;

    private void Start()
    {
        // 총알 쿨타임 표시 장치.
        cooldown_Text = bulletColdown.GetComponent<TMP_Text>(); 
    }

    private void Update()
    {
        bulletTimer += Time.deltaTime;

        if (bulletTimer >= bulletReady)
        {
            cooldown_Text.text = "READY!";
        }
        else
        {
            // 몇초 남았는지 표시함.
            cooldown_Text.text = Mathf.RoundToInt(bulletReady - bulletTimer) + " Left";
        }

        // 총알을 발싸하려 하면 발싸 방향을 보여주는 화살표 소환.
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.F))
        {
            Arrow.SetActive(true);
        }
        else
        {
            Arrow.SetActive(false);
        }
                
        if ((Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.F)) && bulletTimer > bulletReady)
        {
            // 총알을 만듬.
            GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);

            BulletController bulletController = bullet.GetComponent<BulletController>();

            // 총알의 방향은 사과의 위(firePoint)임.
            bulletController.SetDirection(firePoint.transform.up);

            // 총알 쿨타임 초기화.
            bulletTimer = 0;
        }
    }
}
