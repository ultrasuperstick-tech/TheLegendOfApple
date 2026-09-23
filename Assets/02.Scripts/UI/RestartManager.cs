using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            Restart();
        }
    }
    
    public void Restart()   
    {
        Destroy(GameObject.Find("Apple"));
        Destroy(Camera.main);
        SceneManager.LoadScene("Main");
    }
}
