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
        if (dialogDetection.isDailog == false)
        {
            robinFly.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
