using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            Destroy(Camera.main);
            Destroy(GameObject.Find("Apple"));

            SceneManager.LoadScene("Main");
        }
    }
}
