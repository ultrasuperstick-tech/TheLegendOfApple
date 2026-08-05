using UnityEngine;
using UnityEngine.SceneManagement;

public class RobinController : MonoBehaviour
{
    GameObject apple;
    GameObject robin;
    Transform appleTr;
    Transform robinTr;
    float interactionDist = 2f;

    private void Awake()
    {
        apple = GameObject.Find("Apple");
        robin = GameObject.Find("Robin");
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
                SceneSwitch();
            }
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
}
