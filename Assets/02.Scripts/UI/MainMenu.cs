using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private void Update()
    {

        // 아무키나 누른다면
        if (Input.anyKeyDown)
        {
            // 스테이지 1 브금으로 변경
            SoundManager.instance.StartBGM(StageValue.Stage1);
            // 스테이지 1 가기 전 비동기 씬 로드 불러오기
            LoadingManager.LoadScene(StageValue.Stage1.ToString());
        }
    }
}
