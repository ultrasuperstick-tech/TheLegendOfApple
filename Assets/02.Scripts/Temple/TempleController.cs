using Unity.VectorGraphics;
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

    private void Start()
    {

    }

    private void Update()
    {
        applePosX = apple.transform.position.x;

        if (Input.GetKey(KeyCode.E) && Mathf.Abs(transform.position.x) - Mathf.Abs(applePosX) < Mathf.Abs(2))
        {
            SceneManager.LoadScene("Temple");
        }
    }

}
