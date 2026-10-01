using UnityEngine;

public class RobinController : MonoBehaviour
{
    // 사과 관련변수
    // 사과의 위치를 제어하기 위한 변수
    GameObject apple;
    // 로빈에게 고정됄 위치
    public Transform applePos;
    Transform appleTr;

    // 나는 에니매이션을 제어하는 변수
    Animator animator;

    // 날아가는 소리를 제어하는 변수
    AudioSource audioSource;
    // 날아가는 소리
    public AudioClip flying;

    // 상호작용 가능 거리.
    float interactionDist = 2f;

    // 몇초동안 나는지 정함
    float flyTimer = 0;
    float passTime = 5;
    
    // 넘어갈 씬 정함
    public StageValue stage = StageValue.Stage1;
    // 로빈이 나는 속도
    public float robinSpeed = 1;
    // 날수있는지 없는지 여부
    public bool canFly;

    private void Awake()
    {
        // 캐싱
        apple = GameObject.Find("Apple");
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
        appleTr = apple.transform;

        if (Input.GetKeyDown(KeyCode.E))
        {
            // 사과와 대상 오브젝트와의 거리.
            bool isClosed = CheckDistance();

            if (isClosed == true)
            {
                // 사과 태우기
                TakeApple();
                canFly = true;
                GameObject.Find("FadeOut").GetComponent<FadeOut>().StartFade();
                // 새의 애니매이션을 날고있는 모션으로 바꾼다
                animator.SetBool("IsFly", true);
                // 나는 소리 재생
                audioSource.PlayOneShot(flying);
            }
        }

        if (canFly == true)
        {
            // 로빈을 이번 프레임에 이동할 거리 = 방향(->) * 속도 * 프래임 간격 시간
            this.transform.position += Vector3.right * robinSpeed * Time.deltaTime;
            flyTimer += Time.deltaTime;
            // 사과를 로빈 등에 고정
            appleTr.position = applePos.position;
        }

        // 만약 타이머가 만료되면
        if (flyTimer >= passTime)
        {
            // 나는걸 막음
            canFly = false;

            // apple.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            // 씬을 넘어감
            SceneSwitch();
        }
    }

    void SceneSwitch()
    {
        // BGM을 다음 스테이지 BGM으로 바꿈
        SoundManager.instance.StartBGM(stage);
        // SceneManager.LoadScene(stage.ToString());
        // 다음 스테이지로 넘어감
        LoadingManager.LoadScene(stage.ToString());
    }

    bool CheckDistance()
    {
        bool isClosed = false; // 사과와 로빈이 충분히 가까운지를 판단.


        // 시과와 로빈의 거리의 크기
        float distance = (transform.position - appleTr.position).magnitude;

        // 사과와 로빈의 거리의 크기가 감지거리보다 크면
        if (distance < interactionDist)
        {
            isClosed = true;
        }

        return isClosed;
    }

    void TakeApple()
    {
        // 사과를 멈추게함
        apple.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        appleTr.localPosition = Vector3.zero;
    }
}
