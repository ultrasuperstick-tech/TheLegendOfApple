using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LetterBoxController : MonoBehaviour
{
    Image image;
    Coroutine co;

    public float speed = 0.5f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        image = GetComponent<Image>();
    }
    private void Start()
    {
        gameObject.SetActive(true);
    }
    public void ShowLetterBox()
    {
        if (co != null)
        {
            StopCoroutine(co);
        }
        co = StartCoroutine(ShowLetterBoxCo());
    }

    public void HideLetterBox()
    {
        if (co != null)
        {
            StopCoroutine(co);
        }
        co = StartCoroutine(HideLetterBoxCo());
    }

    IEnumerator ShowLetterBoxCo()
    {
        while (transform.localScale.x > 1)
        {
            transform.localScale -= new Vector3(speed, speed, 0) * Time.deltaTime;
            yield return null;
        }
      
    }

    IEnumerator HideLetterBoxCo()
    {
        while (transform.localScale.x <= 1.5)
        {
            transform.localScale += new Vector3(speed, speed, 0) * Time.deltaTime;
            yield return null;
        }
       
    }
}
