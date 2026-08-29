using UnityEngine;

public class AppleTwincle: MonoBehaviour
{
    Animator animator;

    // 사과가 눈을 깜박이는 간격의 최소 시간.
    public float minAppleTwincleTime = 2f;
    // 사과가 눈을 깜박이는 간격의 최대 시간.
    public float maxAppleTwincleTime = 5f;

    // 타이머.
    private float blinkTimer;

    void Start()
    {
        // 애니메이터 컴포넌트 캐싱.
        animator = GetComponent<Animator>();
        // blinkTimer는 minAppleTwincleTime와 minAppleTwincleTime 사이의 랜덤한 시간.
        blinkTimer = Random.Range(minAppleTwincleTime, minAppleTwincleTime);
    }

    void Update()
    {
        // blinkTimer에서 시간을 계속 감소시킨다
        blinkTimer -= Time.deltaTime;

        // 0보다 작아지면 눈을 깜박거린다.
        if (blinkTimer <= 0f)
        {
            // AppleTwincle 애니메이션을 작동시킨다.
            animator.SetTrigger("AppleTwincle");
            // blinkTimer는 minAppleTwincleTime와 minAppleTwincleTime 사이의 랜덤한 시간을 다시 정한다.
            blinkTimer = Random.Range(minAppleTwincleTime, maxAppleTwincleTime);
        }
    }
}
