using UnityEngine;
using UnityEngine.SceneManagement;

public class RobinController : MonoBehaviour
{
    GameObject apple;
    GameObject robin;
    public Transform applePos;
    Transform appleTr;
    Transform robinTr;
    float interactionDist = 2f;
    float flyTimer = 0;
    float passTime = 5;
    public float robinSpeed = 1;
    bool canFly;

    private void Awake()
    {
        apple = GameObject.Find("Apple");
        robin = GameObject.Find("Robin");
    }

    private void Start()
    {
        canFly = false;
    }

    private void Update()
    {
        appleTr = apple.transform;
        robinTr = robin.transform;

        if (Input.GetKeyDown(KeyCode.E))
        {
            bool isClosed = CheckDistance();

            if (isClosed == true)
            {
                TakeApple();
                canFly = true;
            }
        }

        if (canFly == true)
        {
            this.transform.position += Vector3.right * robinSpeed * Time.deltaTime;
            flyTimer += Time.deltaTime;
            appleTr.position = applePos.position;
        }

        if (flyTimer >= passTime)
        {
            SceneSwitch();
            appleTr.position = Vector3.zero;
            apple.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
    }

    void SceneSwitch()
    {
        SceneManager.LoadScene("Stage2");
    }

    bool CheckDistance()
    {
        bool isClosed = false; // 사과와 로빈이 충분히 가까운지를 판단.

        float distance = (robinTr.position - appleTr.position).magnitude;

        if (distance < interactionDist)
        {
            isClosed = true;
        }

        return isClosed;
    }

    void TakeApple()
    {
        apple.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        appleTr.localPosition = Vector3.zero;
    }
}
