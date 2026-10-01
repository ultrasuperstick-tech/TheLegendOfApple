using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    DialogDetection dialogDetection;
    public GameObject issac;

    private void Start()
    {
        dialogDetection = issac.GetComponent<DialogDetection>();
    }
    private void Update()
    {
        if (dialogDetection.isDailog == false)
        {
            // Clear 씬을 가져오고 브금도 Clear씬의 브금으로 함
            SoundManager.instance.StartBGM(StageValue.Clear);
            LoadingManager.LoadScene(StageValue.Clear.ToString());
        }
    }
}
