using UnityEngine;

public class AppleTwincle: MonoBehaviour
{
    Animator animator;

    public float minappletwincleTime = 2f;
    public float maxappletwincleTime = 5f;

    private float blinkTimer;

    void Start()
    {
        animator = GetComponent<Animator>();
        blinkTimer = Random.Range(minappletwincleTime, maxappletwincleTime);
    }

    void Update()
    {
        blinkTimer -= Time.deltaTime;

        if (blinkTimer <= 0f)
        {
            animator.SetTrigger("AppleTwincle");
            blinkTimer = Random.Range(minappletwincleTime, maxappletwincleTime);
        }
    }
}
