using UnityEngine;
using UnityEngine.SceneManagement;

public class RobinController : MonoBehaviour
{
    GameObject apple;
    GameObject robin;
    public Transform applePos;
    SoundManager soundManager;
    Transform appleTr;
    Transform robinTr;
    Animator animator;
    AudioSource audioSource;
    public AudioClip flying;
    float interactionDist = 2f;
    float flyTimer = 0;
    float passTime = 5;
    public StageValue stage = StageValue.Stage1;
    public float robinSpeed = 1;
    public bool canFly;

    private void Awake()
    {
        // 캐싱
        apple = GameObject.Find("Apple");
        robin = GameObject.Find("Robin");
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        SoundManager soundManager = GetComponent<SoundManager>();
    }

    private void Start()
    {
        // 못 날아가게 한다.
        canFly = false;
    }

    private void Update()
    {
        // apple의 Transform;
        // robin의 Transform;
        appleTr = apple.transform;
        robinTr = robin.transform;

        if (Input.GetKeyDown(KeyCode.E))
        {
            // 사과와 대상 오브젝트와의 거리.
            bool isClosed = CheckDistance();

            if (isClosed == true)
            {
                // 
                TakeApple();
                canFly = true;
                GameObject.Find("FadeOut").GetComponent<FadeOut>().StartFade();
                animator.SetBool("IsFly", true);
                audioSource.PlayOneShot(flying);
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
            canFly = false;
            appleTr.position = Vector3.zero;
            apple.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            SceneSwitch();
        }
    }

    void SceneSwitch()
    {
        stage++; // stage = stage + 1와 같다.

        SoundManager.instance.StartBGM(stage);
        // SceneManager.LoadScene(stage.ToString());
        LoadingManager.LoadScene(stage.ToString());
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
