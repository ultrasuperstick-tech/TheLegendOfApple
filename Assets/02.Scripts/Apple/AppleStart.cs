using UnityEngine;

public class AppleStart : MonoBehaviour
{
    GameObject apple;

    private void Start()
    {
        apple = GameObject.Find("Apple");
        // 씬이 시작하였을때 사과 오브젝트가 비어있지 않으면 사과의 위치를 이 오브젝트 위치로 함
        if (apple != null)
        {
            apple.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation; // (사과의 기본설정)
            apple.transform.position = transform.position;
        }
    }

}
