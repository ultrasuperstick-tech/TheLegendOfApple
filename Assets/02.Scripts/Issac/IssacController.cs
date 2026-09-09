using UnityEngine;
using UnityEngine.UI;

public class IssacController : MonoBehaviour
{
    public GameObject letterBox;
    public GameObject issac;
    public GameObject issacRun;
    public GameObject apple;
    DialogueManager dialogueManager;
    Rigidbody2D appleRBody;
    public float issacSpeed;
    public bool startIntro = false;

    private void Awake()
    {
        appleRBody = apple.GetComponent<Rigidbody2D>();
        dialogueManager = GetComponent<DialogueManager>();
    }
    private void Start()
    {
        letterBox.SetActive(false);
        issacRun.SetActive(false);

        startIntro = true;
    }

    private void Update()
    {
        if (startIntro == true)
        {
            appleRBody.constraints = RigidbodyConstraints2D.FreezeAll;
            if (dialogueManager.isDailog == false)
            {

            }
        }
    }

}
