using UnityEngine;
using System.Collections;

public enum StageValue
{
    Main, // 0

    Stage1, // 1

    Stage2, // 2

    Stage3, // 3

    Clear // 4
}
public class SoundManager : MonoBehaviour
{
    // 싱글톤 기법
    public static SoundManager instance;
    // 장점
    // 1. 어디서든 쉽게 접근 가능
    // 2. 게임 전채를 관리하는 기능을 한곳에서 관리할수있다

    public GameObject mainmenuManager;
    public AudioClip mainManuBGM;
    // 스테이지 별 브금들
    public AudioClip stage1BGM;
    public AudioClip stage2BGM;
    public AudioClip stage3BGM;
    public AudioSource bgmSource;
    Coroutine coroutine;

    private void Awake()
    {
        // instance가 null이 아닐때
        if (instance != null)
        {
            // 이 게임오브젝트를 파괴
            Destroy(gameObject);
        }
        // instance가 null일때
        else
        {
            // instance는 자기자신
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        bgmSource.volume = 0f;
        StartBGM(StageValue.Main);
    }
    public void SwitchBGM(StageValue stage)
    {
        // 스테이지 밸류의 따라 브금 변경
        if (stage == StageValue.Main)
        {
            bgmSource.clip = mainManuBGM;
        }
        else if (stage == StageValue.Stage2)
        {
            bgmSource.clip = stage2BGM;
        }
        else if (stage == StageValue.Stage3)
        {
            bgmSource.clip = stage3BGM;
        }
        else if (stage == StageValue.Stage1)
        {
            bgmSource.clip = stage1BGM;
        }   
        else if (stage == StageValue.Clear)
        {
            bgmSource.clip = stage1BGM;
        }

        bgmSource.Play();
    }
    public void StartBGM(StageValue stage)
    {
        // 코루틴이 null이 아니라면
        if (coroutine != null)
        {
            // 진행중인 코르틴 멈추기 (코르틴이 중복으로 재생되는걸 막기위해)
            StopCoroutine(coroutine);
        }
        // 코루틴을 시작하고 저장
        coroutine =  StartCoroutine(StartFadeBGM(stage));
    }

    IEnumerator StartFadeBGM(StageValue stage)
    {
        // 소리를 FadeOut 시킨다
        while (bgmSource.volume > 0)
        {
            bgmSource.volume -= 0.05f * Time.deltaTime;
            // 한프레임 대기
            yield return null;
        }

        SwitchBGM(stage);
        // 소리를 FadeIn 시킨다
        while (bgmSource.volume < 0.1f)
        {
            bgmSource.volume += 0.05f * Time.deltaTime;
            // 한프레임 대기
            yield return null;
        }
        // 코루틴 비우기
        coroutine = null;
    }
}
