using UnityEngine;
using UnityEngine.SceneManagement;

public class TempleController : MonoBehaviour
{
    GameObject apple;
    Rigidbody2D rBody;
    float applePosX;

    private void Awake()
    {
        apple = GameObject.Find("Apple");
        rBody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        applePosX = apple.transform.position.x;

        // 신전 거리와 플레이어 거리 차이가 2 미만이면 E를 눌러 입장가능.
        if (Input.GetKey(KeyCode.E) && Mathf.Abs(transform.position.x) - Mathf.Abs(applePosX) < Mathf.Abs(2))
        {
            SceneManager.LoadScene("Temple"); 
        }
    }

}
