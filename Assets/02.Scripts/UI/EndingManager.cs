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
            SoundManager.instance.StartBGM(StageValue.Clear);
            LoadingManager.LoadScene(StageValue.Clear.ToString());
        }
    }
}
