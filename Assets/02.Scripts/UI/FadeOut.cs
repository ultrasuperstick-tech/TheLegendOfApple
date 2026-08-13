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
        image = this.gameObject.GetComponent<Image>();
        alpha = 0f;
    }
    public void StartFade()
    {
        StartCoroutine(StartFadeOutCo());
    }

    IEnumerator StartFadeOutCo()
    {
        // 2초 동안 기다리기.
        yield return new WaitForSeconds(2.0f);

        while(color.a < 1.0f)
        {
            alpha += Time.deltaTime;
            color = new Color(0, 0, 0, alpha);
            image.color = color;

            yield return null;
        }
    }
}
