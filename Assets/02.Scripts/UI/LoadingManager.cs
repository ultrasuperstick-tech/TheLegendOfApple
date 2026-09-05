using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingManager : MonoBehaviour
{
    static string nextScene;
    public Image fillImg;
    public TMP_Text progressText;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    // 실제 로드할 씬을 sceneManager으로 전달하고 로딩씬을 호출.
    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("Loading");
    }

    IEnumerator LoadScene()
    {
        // 비동기 씬 로드
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);

        // 다음씬 로딩이 100%가 되어도 씬이 넘어가는 것을 방지.
        op.allowSceneActivation = false; 

        float timer = 0f;

        // op.isDone => false 라면 아직 로딩 작업이 완료되지 않았다는 뜻. (씬 로딩이 완료되기 전까지만 반복)
        while (op.isDone == false)
        {
            // 진행도가 60% 미만일때는 즉각 반영.
            if (op.progress < 0.6f)
            {
                fillImg.fillAmount = op.progress;
                progressText.text = ((int)(op.progress * 100)).ToString() + "%";
            }
            // 진행도가 90% 이상이면 천천히 반영.
            else
            {
                timer += Time.unscaledDeltaTime;

                // Mathf.Lerp(A, B, Time);
                // Time이 0이면 A
                // Time이 1이면 B
                // 0.5면 A와 B의 중간
                fillImg.fillAmount = Mathf.Lerp(0.6f, 1f, timer); // 게이지를 부드럽게 증가시키기.
                progressText.text = ((int)(fillImg.fillAmount * 100)).ToString() + "%";

                // 게이지가 100% 다 채워지면 다음 씬 보여주기.
                if (fillImg.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true; // 다음 씬으로 넘어가는 걸 허가.
                    yield break; // 코루틴을 여기서 끝내기
                }
            }

            yield return null;
        }
    }
}
