using UnityEngine;

public class AppleStart : MonoBehaviour
{
    GameObject apple;

    private void Start()
    {
        apple = GameObject.Find("Apple");
        Debug.Log(apple.name);
        if (apple != null)
        {
            apple.transform.position = transform.position;
        }
    }

}
