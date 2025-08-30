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
    [SerializeField] private GameObject day1TimelineCanvas;

    public static StoryManagerScript instance;

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

    void Start()
    {
        day1TimelineCanvas.SetActive(false);

        EventManagerScript_Counter.instance.OnDayEnd.AddListener(RunDay1End);

        if (GamestateManager.instance.day == 1)
        {
            StartCoroutine(Day1Start());
        }
    }

    private IEnumerator Day1Start()
    {
        day1TimelineCanvas.SetActive(true);
        day1Director.Play();
        yield return new WaitForSeconds(2.6f);
        day1TimelineCanvas.SetActive(false);
        // landlord.SetActive(true);
        DialogueManager.GetInstance().EnterDialogueMode(landlordJSON, "Introduction");
    }

    private IEnumerator Day1End(int dayNum)
    {
        if (dayNum == 1)
        {
            yield return null;
            DialogueManager.GetInstance().EnterDialogueMode(demonJSON, "Day1");
        }
    }

    private void RunDay1End(int dayNum)
    {
        StartCoroutine(Day1End(dayNum));
    }
}
