using UnityEngine;
using System.Collections;

public enum StageValue
{
    Stage1, // 0

    Stage2, // 1

}
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip stage1BGM;
    public AudioClip stage2BGM;
    public AudioSource bgmSource;
    Coroutine coroutine;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        bgmSource.volume = 0f;
        StartBGM(StageValue.Stage1);
    }

    public void SwitchBGM(StageValue stage)
    {
        if (stage == StageValue.Stage1)
        {
            bgmSource.clip = stage1BGM;
        }
        else if (stage == StageValue.Stage2)
        {
            bgmSource.clip = stage2BGM;
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
