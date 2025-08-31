using Unity.Mathematics;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] public AudioSource day1;
    [SerializeField] public AudioSource day2;
    [SerializeField] public AudioSource day3;
    [SerializeField] public AudioSource day4;
    [SerializeField] public AudioSource demonTheme;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Play(AudioSource audio)
    {
        audio.volume = 1;
        audio.Play();
    }

    public void FadeOut(AudioSource audio, float fadeDuration)
    {
        StartCoroutine(FadeOutCoroutine(audio, fadeDuration));
    }

    private IEnumerator FadeOutCoroutine(AudioSource audioSource, float fadeDuration)
    {
        float startVolume = audioSource.volume;

        float time = 0;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0, time / fadeDuration);
            yield return null;
        }

        audioSource.volume = 0;
        audioSource.Stop(); // optional: stop after fading out
    }
}
