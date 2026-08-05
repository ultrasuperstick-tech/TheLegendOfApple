using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public class Quiz
{
    public string quiz;
    public string selectA;
    public string selectB;
    public int answer; // 0이면 A가 정답, 1이면 B가 정답
}
public class QuizManager : MonoBehaviour
{
    public Transform statueTr; // 석상 트렌스폼.
    Transform appleTr; // 사과 트렌스폼.
    Transform exitPos;
    public float interactionDist;

    // public List<Quiz> quizList = new List<Quiz>();
    public Quiz quiz = new Quiz();

    public GameObject quizPanel;

    // int curQuizIndex = 0; // 현제 들고있는 퀴즈의 인덱스

    [Header("퀴즈 GUI")]
    public TMP_Text quizText;
    public TMP_Text selectAText;
    public TMP_Text selectBText;
    public Button selectA_Btn;
    public Button selectB_Btn;

    private void Awake()
    {
        appleTr = GameObject.Find("Apple").transform;
    }

    private void Start()
    {
        quizPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            bool isClosed = CheckDistance();

            if (isClosed == true)
            {
                Debug.Log("상호작용");
                quizPanel.SetActive(true);
                QuizStart();
            }
        }
    }
    bool CheckDistance()
    {
        bool isClosed = false; // 사과와 석상이 충분히 가까운지를 판단.

        float distance = (statueTr.position - appleTr.position).magnitude;

        if (distance < interactionDist)
        {
            isClosed = true;
        }

        return isClosed;
    }
    void QuizStart()
    {
        // Quiz quiz = quizList[curQuizIndex];
        quizText.text = quiz.quiz;
        selectAText.text = quiz.selectA;
        selectBText.text = quiz.selectB;
    }

    public void SelectA()
    {
        JudgeAnswer(0);
    }

    public void SelectB()
    {
        JudgeAnswer(1);
    }

    void JudgeAnswer(int answer)
    {
        // 정답을 판별하는 함수
        // Quiz quiz = quizList[curQuizIndex];
        exitPos = GameObject.Find("ExitSpawnPos").transform;

        if (quiz.answer == answer)
        {
            Debug.Log("정답입니다.");

        }
        else
        {
            Debug.Log("오답입니다.");
        }

        QuizEnd();
        appleTr.position = exitPos.position;
    }

    void QuizEnd()
    {
        quizPanel.SetActive(false);
    }
}
