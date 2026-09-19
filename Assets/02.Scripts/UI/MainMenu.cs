using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            LoadingManager.LoadScene(StageValue.Stage1.ToString());
        }
    }
}
