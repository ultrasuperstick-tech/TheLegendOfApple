using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool mainMenuEnd = false;
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            SoundManager.instance.StartBGM(StageValue.Stage1);
            LoadingManager.LoadScene(StageValue.Stage1.ToString());
        }
    }
}
