using UnityEngine;
using UnityEngine.SceneManagement;

public class TempleController : MonoBehaviour
{
    AudioSource audioSource;
    GameObject apple;
    Transform spawnPosTr;
    Transform appleTr;
    float interactionDist = 4f;
    public AudioClip openDoor;
    public bool quizEnd = false;

    private void Awake()
    {
        apple = GameObject.Find("Apple");

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        quizEnd = false;
        appleTr = apple.transform;
    }

    private void Update()
    {
        if (quizEnd == true)
        {
            this.transform.position += Vector3.down * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.E) && quizEnd == false)
        {

            bool isClosed = CheckDistance();

            if (isClosed == true)
            {
                audioSource.PlayOneShot(openDoor);
                spawnPosTr = GameObject.Find("SpawnPos").transform;
                appleTr.position = spawnPosTr.position;
            }
        }
    }

    bool CheckDistance()
    {
        bool isClosed = false; // 사과와 신전이 충분히 가까운지를 판단.

        float distance = (transform.position - appleTr.position).magnitude;

        if (distance < interactionDist)
        {
            isClosed = true;
        }

        return isClosed;
    }

}
