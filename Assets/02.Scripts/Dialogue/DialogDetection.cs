using UnityEngine;

public class DialogDetection : MonoBehaviour
{
    Transform appleTr;
    public DialogueManager dialogueManager;
    public float interactionDist = 1.0f;

    private void Start()
    {
        appleTr = GameObject.Find("Apple").transform;
    }

    private void Update()
    {
        // 만약에 E키를 누른다면.
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (dialogueManager.isDailog == true)
            {
                // 사과와 이 오브젝트의 거리를 측정하여 조건을 충족한다면 isClosed가 참이 된다.
                bool isClosed = CheckDistance();

                if (isClosed == true)
                {
                    dialogueManager.canDailog = true;
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
