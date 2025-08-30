using UnityEngine;
using UnityEngine.Playables;
using System.Collections;

public class StoryManagerScript : MonoBehaviour
{
    [Header("Demon & Landlord Data")]
    [SerializeField] private TextAsset demonJSON;
    [SerializeField] private TextAsset landlordJSON;
    // [SerializeField] private GameObject landlord;
    // [SerializeField] private GameObject demon;

    [Header("Timelines")]
    [SerializeField] private PlayableDirector day1Director;

    void Start()
    {
        if (GamestateManager.instance.day == 1)
        {
            StartCoroutine(Day1IntroFlow());
        }
    }

    private IEnumerator Day1IntroFlow()
    {
        day1Director.Play();
        yield return new WaitForSeconds(2.6f);
        // landlord?.SetActive(true);
        DialogueManager.GetInstance().EnterDialogueMode(landlordJSON, "Introduction");
    }
}
