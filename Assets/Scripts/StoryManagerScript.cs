using UnityEngine;
using UnityEngine.Playables;
using System.Collections;
using Unity.XR.GoogleVr;

public class StoryManagerScript : MonoBehaviour
{
    [Header("Demon & Landlord Data")]
    [SerializeField] private TextAsset demonJSON;
    [SerializeField] private TextAsset landlordJSON;
    [SerializeField] private GameObject landlord;
    [SerializeField] private GameObject demon;
    private StoryCharacterScript landlordScript;
    private StoryCharacterScript demonScript;

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
        landlordScript = landlord.GetComponent<StoryCharacterScript>();
        demonScript = demon.GetComponent<StoryCharacterScript>();

        day1TimelineCanvas.SetActive(false);
        landlord.SetActive(false);
        demon.SetActive(false);

        EventManagerScript_Counter.instance.OnDayEnd.AddListener(RunDay1End);
        EventManagerScript_Counter.instance.OnDayBegin.AddListener(Day1StoryEnd);
        EventManagerScript_Counter.instance.OnBiscuitFinished.AddListener(ReassignChars);

        if (GamestateManager.instance.day == 1)
        {
            StartCoroutine(Day1Start());
        }
    }

    private void ReassignChars(int num)
    {
        StartCoroutine(WaitReassignChars());
    }

    private IEnumerator WaitReassignChars()
    {
        while (GameObject.FindWithTag("Landlord") == null || GameObject.FindWithTag("Demon") == null)
        {
            yield return null;
        }

        landlord = GameObject.FindWithTag("Landlord");
        demon = GameObject.FindWithTag("Demon");
        landlordScript = landlord.GetComponent<StoryCharacterScript>();
        demonScript = demon.GetComponent<StoryCharacterScript>();

        landlord.SetActive(false);
        demon.SetActive(false);
    }

    private IEnumerator Day1Start()
    {
        day1TimelineCanvas.SetActive(true);
        day1Director.Play();
        yield return new WaitForSeconds(2.6f);
        day1TimelineCanvas.SetActive(false);
        landlord.SetActive(true);
        landlordScript.Appear();
        landlordScript.PopUpAnim();
        DialogueManager.GetInstance().EnterDialogueMode(landlordJSON, "Introduction");
    }

    private void Day1StoryEnd(int day)
    {
        landlordScript.PopDownAnim();
        StartCoroutine(SetActiveAfterSeconds());
    }

    private IEnumerator SetActiveAfterSeconds()
    {
        yield return new WaitForSeconds(0.3f);
        landlordScript.Disappear();
        landlord.SetActive(false);
    }

    private IEnumerator Day1End(int dayNum)
    {
        if (dayNum == 1)
        {
            yield return new WaitForSeconds(0.7f);
            demon.SetActive(true);
            demonScript.Appear();
            demonScript.PopUpAnim();
            DialogueManager.GetInstance().EnterDialogueMode(demonJSON, "Day1");
        }
    }

    private void RunDay1End(int dayNum)
    {
        StartCoroutine(Day1End(dayNum));
    }
}
