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
            cooldown_Text.text = Mathf.RoundToInt(bulletReady - bulletTimer) + " Left";
        }

        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.E))
        {
            Arrow.SetActive(true);
        }
        else
        {
            Arrow.SetActive(false);
        }
                
        if ((Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.E)) && bulletTimer > bulletReady)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);

            BulletController bulletController = bullet.GetComponent<BulletController>();

            bulletController.SetDirection(firePoint.transform.up);

            bulletTimer = 0;
        }
    }
}
