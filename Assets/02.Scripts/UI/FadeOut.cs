using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    Color color;
    Image image;
    float alpha;

    private void Start()
    {
        // 알파값을 0으로 설정
        alpha = 0f;

        image = this.gameObject.GetComponent<Image>();
    }
    public void StartFade()
    {
        StartCoroutine(StartFadeOutCo());
    }

    IEnumerator StartFadeOutCo()
    {
        // 2초 동안 기다리기 (있어보이게 하려고)
        yield return new WaitForSeconds(2.0f);

        // 알파값이 1보다 작을때
        while(color.a < 1.0f)
        {
            // 알파값을 올려줌
            alpha += Time.deltaTime;
            // 색깔을 그에 마추어 바꿈
            color = new Color(0, 0, 0, alpha);
            image.color = color;

            // 1프레임 기다리기
            yield return null;
        }
    }
}
