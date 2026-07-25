using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempleController : MonoBehaviour
{
    GameObject apple;
    GameObject button;
    Rigidbody2D rBody;

    private void Awake()
    {
        apple = GameObject.Find("Apple");
        button = GameObject.Find("Button"); 
        rBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rBody.linearVelocity = Vector2.zero;
        rBody.angularVelocity = 0f;
        rBody.constraints = RigidbodyConstraints2D.FreezeAll;
        button.SetActive(false);
    }

    private void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("OK");
            SceneManager.LoadScene("Temple");    
        }
    }
}
