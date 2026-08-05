using UnityEngine;
using UnityEngine.SceneManagement;

public class SenceManager : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene("Temple", LoadSceneMode.Additive);
    }
}
