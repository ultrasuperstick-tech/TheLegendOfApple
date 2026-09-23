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
    public static SoundManager instance;
    MainMenu mainMenu;

    public GameObject mainmenuManager;
    public AudioClip mainManuBGM;
    public AudioClip stage1BGM;
    public AudioClip stage2BGM;
    public AudioClip stage3BGM;
    public AudioSource bgmSource;
    Coroutine coroutine;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        mainMenu = mainmenuManager.GetComponent<MainMenu>();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        bgmSource.volume = 0f;
        StartBGM(StageValue.Main);
    }
    public void SwitchBGM(StageValue stage)
    {
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
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine =  StartCoroutine(StartFadeBGM(stage));
    }

    IEnumerator StartFadeBGM(StageValue stage)
    {
        // FadeOut
        while (bgmSource.volume > 0)
        {
            bgmSource.volume -= 0.05f * Time.deltaTime;
            yield return null;
        }

        SwitchBGM(stage);
        // FadeIn
        while (bgmSource.volume < 0.1f)
        {
            bgmSource.volume += 0.05f * Time.deltaTime;
            yield return null;
        }

        coroutine = null;
    }
}
