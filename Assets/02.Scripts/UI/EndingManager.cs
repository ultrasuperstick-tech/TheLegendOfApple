using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    GameObject apple;

    private void Start()
    {
        apple = GameObject.Find("Apple");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == apple)
        {
            SceneManager.LoadScene("Clear");
        }
    }
}
