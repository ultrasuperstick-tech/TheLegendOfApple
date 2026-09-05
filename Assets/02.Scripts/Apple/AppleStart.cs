using UnityEngine;

public class AppleStart : MonoBehaviour
{
    GameObject apple;

    private void Start()
    {
        apple = GameObject.Find("Apple");
        if (apple != null)
        {
            apple.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            apple.transform.position = transform.position;
        }
    }

}
