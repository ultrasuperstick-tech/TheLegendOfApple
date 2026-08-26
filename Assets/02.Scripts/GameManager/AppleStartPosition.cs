using UnityEngine;

public class AppleStartPosition : MonoBehaviour
{
    GameObject apple;
    GameObject appleStart;
    void Start()
    {
        apple = GameObject.Find("Apple");
        appleStart = GameObject.Find("AppleStart");

        if (apple != null)
        {
            apple.transform.position = appleStart.transform.position;
        }
    }
}
