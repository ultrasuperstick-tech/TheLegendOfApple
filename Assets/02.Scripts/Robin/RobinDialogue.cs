using UnityEngine;

public class RobinDialogue : MonoBehaviour
{
    public GameObject robinFly;
    DialogDetection dialogDetection;

    private void Awake()
    {
        dialogDetection = GetComponent<DialogDetection>();
        robinFly.SetActive(false);
    }

    private void Update()
    {
        // 만약 대화가 끝났다면 지금 이 오브젝트를 숨기고 날아가는 로빈 보이게함
        if (dialogDetection.isDailog == false)
        {
            robinFly.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
