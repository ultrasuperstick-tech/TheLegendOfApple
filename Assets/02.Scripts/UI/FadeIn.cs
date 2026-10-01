using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    Color color;
    Image image;
    float alpha;

    private void Start()
    {
        image = this.gameObject.GetComponent<Image>();
        alpha = 1f;
        // 색깔을 기본값으로 설정
        color = new Color(0, 0, 0, alpha);
        StartFade();
    }

    public void StartFade()
    {
        // 페이드 인 코루틴 시작
        StartCoroutine(StartFadeInCo());
    }

    IEnumerator StartFadeInCo()
    {
        yield return new WaitForSeconds(2.0f);

        // 알파값이 0보다 클때 동안
        while (alpha > 0)
        {
            // 알파값을 계속 감소시켜줌
            alpha -= Time.deltaTime;
            // 색깔을 그에 마추어 바꿈
            color = new Color(0, 0, 0, alpha);
            image.color = color;

            // 1프레임 기다리기
            yield return null;
        }
    }
}
