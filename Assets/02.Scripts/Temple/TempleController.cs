using UnityEngine;
using UnityEngine.SceneManagement;

public class TempleController : MonoBehaviour
{
    GameObject apple;
    Transform spawnPosTr;
    Transform appleTr;
    float interactionDist = 4f;

    private void Awake()
    {
        apple = GameObject.Find("Apple");
    }

    private void Start()
    {
        appleTr = apple.transform;
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {

            bool isClosed = CheckDistance();

            if (isClosed == true)
            {
                spawnPosTr = GameObject.Find("SpawnPos").transform;
                appleTr.position = spawnPosTr.position;
            }
        }
    }

    bool CheckDistance()
    {
        bool isClosed = false; // 사과와 로빈이 충분히 가까운지를 판단.

        float distance = (transform.position - appleTr.position).magnitude;

        if (distance < interactionDist)
        {
            isClosed = true;
        }

        return isClosed;
    }

}
