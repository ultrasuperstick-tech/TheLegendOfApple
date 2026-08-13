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
        StartFade();
    }

    public void StartFade()
    {
        StartCoroutine(StartFadeInCo());
    }

    IEnumerator StartFadeInCo()
    {
        yield return new WaitForSeconds(2.0f);

        while (alpha > 0)
        {
            alpha -= Time.deltaTime;
            color = new Color(0, 0, 0, alpha);
            image.color = color;

            yield return null;
        }
    }
}
