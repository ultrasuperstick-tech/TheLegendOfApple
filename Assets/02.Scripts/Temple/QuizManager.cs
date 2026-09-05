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
    AppleHealth appleHealth;
    TempleController templeController;
    GameObject apple;
    GameObject temple;
    AudioSource audioSource;
    public AudioClip correctAnswer;
    public AudioClip wrongAnswer;

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
        apple = GameObject.Find("Apple");
        temple = GameObject.Find("Temple");
        appleTr = apple.transform;
        appleHealth = apple.GetComponent<AppleHealth>();
        templeController = temple.GetComponent<TempleController>();
        audioSource = GetComponent<AudioSource>();
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
                if (SceneManager.GetActiveScene().name == "Stage2")
                {
                    quiz.quiz = "사과를 자르면 갈색으로 변하는 가장 직접적인 원인은 무엇일까?";
                    quiz.selectA = "산소와 반응한 포도당이\n 갈변한다";
                    quiz.selectB = "폴리페놀 화합물이 \n폴리페놀 산화효소(PPO)에 의해 산화된다";
                    quiz.answer = 1;
                }
                if (SceneManager.GetActiveScene().name == "Stage3")
                {
                    quiz.quiz = "가장 강한 사과는 무엇이냐";
                    quiz.selectA = "단단한 사과";
                    quiz.selectB = "끝가지 포기하지 않는 사과";
                    quiz.answer = 0;
                }
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
            audioSource.PlayOneShot(correctAnswer);
            if (appleHealth.hp >= 80)
            {
                appleHealth.hp = appleHealth.maxHp;
            }
            else
            {
                appleHealth.hp += 20;
            }

            appleHealth.ShowHp();
        }
        else
        {
            Debug.Log("오답입니다.");
            audioSource.PlayOneShot(wrongAnswer);
        }

        QuizEnd();
        appleTr.position = exitPos.position;
    }

    void QuizEnd()
    {
        quizPanel.SetActive(false);
        templeController.quizEnd = true;
    }
}
