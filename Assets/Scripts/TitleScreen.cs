using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource ding;

    void Start()
    {
        music.Play();
    }

    public void OnClick()
    {
        StartCoroutine(OnClickEn());
    }

    private IEnumerator OnClickEn()
    {
        FadeOutCoroutine(music, 2);
        ding.Play();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Counter");
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
