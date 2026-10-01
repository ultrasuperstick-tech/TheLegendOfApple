using UnityEngine;

public class IssacController : MonoBehaviour
{
    // 기본 아이작 이미지
    public GameObject issac;
    // 달리는 아이작 이미지
    public GameObject issacRun;
    // 아이작이 달리는 속도
    public float issacSpeed = 5;

    // 사과의 리지드바디 관리
    public GameObject apple;
    Rigidbody2D appleRBody;

    // 대화감지시스템
    DialogDetection dialogDetection;
    
    public bool startIntro = false;

    private void Awake()
    {
        // 캐싱
        appleRBody = apple.GetComponent<Rigidbody2D>();
        dialogDetection = issac.GetComponent<DialogDetection>();
    }
    private void Start()
    {
        // 시작하면 인트로 시작하기
        issacRun.SetActive(false);

        startIntro = true;
    }

    private void Update()
    {
        // 만약 인트로가 시작되었으면
        if (startIntro == true)
        {
            // 사과의 위치 고정시키기
            appleRBody.constraints = RigidbodyConstraints2D.FreezeAll;
            // 대화가 끝났다면
            if (dialogDetection.isDailog == false)
            {
                issac.SetActive(false);
                issacRun.SetActive(true);

                issacRun.transform.position += Vector3.right * issacSpeed * Time.deltaTime;

                if (issacRun.transform.position.x >= 1)
                {
                    issacRun.SetActive(false);
                    startIntro = false;
                    appleRBody.constraints = RigidbodyConstraints2D.FreezeRotation;
                }
            }
        }
    }

}
