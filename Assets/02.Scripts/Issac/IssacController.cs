using UnityEngine;
using UnityEngine.UI;

public class IssacController : MonoBehaviour
{
    public GameObject issac;
    public GameObject issacRun;
    public GameObject apple;
    DialogueManager dialogueManager;
    DialogDetection dialogDetection;
    Rigidbody2D appleRBody;
    public float issacSpeed;
    public bool startIntro = false;

    private void Awake()
    {
        appleRBody = apple.GetComponent<Rigidbody2D>();
        dialogueManager = GetComponent<DialogueManager>();
        dialogDetection = issac.GetComponent<DialogDetection>();
    }
    private void Start()
    {
        issacRun.SetActive(false);

        startIntro = true;
    }

    private void Update()
    {
        if (startIntro == true)
        {
            appleRBody.constraints = RigidbodyConstraints2D.FreezeAll;
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
