using UnityEngine;

public class DialogDetection : MonoBehaviour
{
    Transform appleTr;
    public DialogueManager dialogueManager;
    public float interactionDist = 1.0f;

    public Sprite dialogerImage;
    public string[] dialoges;
    public bool canDailog = false; // true면 대화창 무조건 열림. 대화 1번 하고나면 false
    public bool isDailog = true; // 대화 가능하냐 - 끝나면 false.

    private void Awake()
    {
        canDailog = false;
        isDailog = true;
    }

    private void Start()
    {
        appleTr = GameObject.Find("Apple").transform;
    }

    private void Update()
    {
        // 만약에 E키를 누른다면.
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isDailog == true) // 대화 가능하면 대화 진행
            {
                // 사과와 이 오브젝트의 거리를 측정하여 조건을 충족한다면 isClosed가 참이 된다.
                bool isClosed = CheckDistance();

                if (isClosed == true) // 가까이 있으면 대화 진행
                {
                    canDailog = true; // true로 바꿔서 대화창 열기
                    dialogueManager.SetDialog(dialoges, dialogerImage, GetComponent<DialogDetection>());
                }
            }
        }
    }

    bool CheckDistance()
    {
        bool isClosed = false;

        // 거리는 이 위치 - 사과 위치.
        float distance = (transform.position - appleTr.position).magnitude;

        // 감지
        if (distance < interactionDist)
        {
            isClosed = true;
        }

        return isClosed;
    }

}
