using UnityEngine;

public class AppleTwincle: MonoBehaviour
{
    Animator animator;

    public float minAppleTwincleTime = 2f;
    public float maxAppleTwincleTime = 5f;

    private float blinkTimer;

    void Start()
    {
        animator = GetComponent<Animator>();
        blinkTimer = Random.Range(minAppleTwincleTime, maxAppleTwincleTime);
    }

    void Update()
    {
        blinkTimer -= Time.deltaTime;

        if (blinkTimer <= 0f)
        {
            animator.SetTrigger("AppleTwincle");
            blinkTimer = Random.Range(minAppleTwincleTime, maxAppleTwincleTime);
        }
    }
}
