using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LetterBoxController : MonoBehaviour
{
    // 코루틴 변수
    Coroutine co;

    // 레터박스 내려오고 올라오는 속도
    public float speed = 0.5f;

    private void Start()
    {
        gameObject.SetActive(true);
    }
    public void ShowLetterBox()
    {
        // 코루틴 안이 비어있지 않다면 실행중인 코루틴을 중단 시킨다
        if (co != null)
        {   
            StopCoroutine(co);
        }
        // 레터박스 보이게하는 코루틴 함수 실행
        co = StartCoroutine(ShowLetterBoxCo());
    }

    public void HideLetterBox()
    {
        // 코루틴 안이 비어있지 않다면 실행중인 코루틴을 중단 시킨다
        if (co != null)
        {
            StopCoroutine(co);
        }
        // 레터박스 숨기게하는 코르틴 함수 실행
        co = StartCoroutine(HideLetterBoxCo());
    }

    IEnumerator ShowLetterBoxCo()
    {
        // 레터박스 스케일의 x값이 1.1 보다 클동안
        while (transform.localScale.x > 1.1)
        {
            // 크기에서 speed *  Time.deltaTime 만큼을 계속 뺌
            transform.localScale -= new Vector3(speed, speed, 0) * Time.deltaTime;
            // 한 프레임 기다리기
            yield return null;
        }
      
    }

    IEnumerator HideLetterBoxCo()
    {
        // 레터박스 스케일의 x값이 1.5 보다 작거나 같을 동안
        while (transform.localScale.x <= 1.5)
        {
            // 크기에서 speed *  Time.deltaTime 만큼을 계속 더함
            transform.localScale += new Vector3(speed, speed, 0) * Time.deltaTime;
            // 한 프레임 기다리기
            yield return null;
        }
       
    }
}
