using UnityEngine;
using UnityEngine.Playables;
using System.Collections;
using System.Security.Cryptography;

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
    [SerializeField] private PlayableDirector chopDirector;
    [SerializeField] private GameObject chopTimelineCanvas;
    [SerializeField] private PlayableDirector day2Director;
    [SerializeField] private GameObject day2TimelineCanvas;
    [SerializeField] private PlayableDirector day3Director;
    [SerializeField] private GameObject day3TimelineCanvas;
    [SerializeField] private PlayableDirector day4Director;
    [SerializeField] private GameObject day4TimelineCanvas;

    [Header("Finger")]
    [SerializeField] private GameObject fingerCanvas;
    [SerializeField] public int fingerIndex = 0;
    [SerializeField] private GameObject[] fingers;

    [Header("Eye")]
    [SerializeField] private GameObject eyeCanvas;
    [Header("Lifeforce")]
    [SerializeField] private GameObject jumpscare;
    [SerializeField] private GameObject end;

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
        DontDestroyOnLoad(day1TimelineCanvas);
        DontDestroyOnLoad(day2TimelineCanvas);
        DontDestroyOnLoad(day3TimelineCanvas);
        DontDestroyOnLoad(day4TimelineCanvas);
        DontDestroyOnLoad(chopTimelineCanvas);
        DontDestroyOnLoad(fingerCanvas);
        DontDestroyOnLoad(eyeCanvas);
        DontDestroyOnLoad(jumpscare);
        DontDestroyOnLoad(end);
    }

    void Start()
    {
        landlordScript = landlord.GetComponent<StoryCharacterScript>();
        demonScript = demon.GetComponent<StoryCharacterScript>();

        day1TimelineCanvas.SetActive(false);
        landlord.SetActive(false);
        demon.SetActive(false);
        fingerCanvas.SetActive(false);
        chopTimelineCanvas.SetActive(false);
        eyeCanvas.SetActive(false);
        day2TimelineCanvas.SetActive(false);
        day3TimelineCanvas.SetActive(false);
        day4TimelineCanvas.SetActive(false);
        jumpscare.SetActive(false);
        end.SetActive(false);


        EventManagerScript_Counter.instance.OnDayEnd.AddListener(RunDayEnd);
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
        if (day == 1 || day == 2)
        {
            landlordScript.PopDownAnim();
            StartCoroutine(SetActiveAfterSeconds());
        }
    }

    private IEnumerator SetActiveAfterSeconds()
    {
        yield return new WaitForSeconds(0.3f);
        landlordScript.Disappear();
        landlord.SetActive(false);
    }

    private IEnumerator DayEnd(int dayNum)
    {
        yield return new WaitForSeconds(0.7f);
        demon.SetActive(true);
        demonScript.Appear();
        demonScript.PopUpAnim();

        switch (dayNum)
        {
            case 1:
                DialogueManager.GetInstance().EnterDialogueMode(demonJSON, "Day1");
                break;
            case 2:
                DialogueManager.GetInstance().EnterDialogueMode(demonJSON, "Day2");
                break;
            case 3:
                DialogueManager.GetInstance().EnterDialogueMode(demonJSON, "Day3");
                break;
            case 4:
                DialogueManager.GetInstance().EnterDialogueMode(demonJSON, "Day4");
                break;
            default:
                Debug.LogWarning("Day is something other than 1-4. Day: " + dayNum);
                break;
        }
    }

    private void RunDayEnd(int dayNum)
    {
        StartCoroutine(DayEnd(dayNum));
    }

    public void StartFinger()
    {
        fingerCanvas.SetActive(true);
    }

    public void ChooseFinger(int finger)
    {
        StartCoroutine(FingerChosen(finger));
    }

    public IEnumerator FingerChosen(int finger)
    {
        fingerIndex = finger;
        fingerCanvas.SetActive(false);

        chopTimelineCanvas.SetActive(true);
        demonScript.Disappear();
        demonScript.PopDownAnim();
        chopDirector.Play();
        yield return new WaitForSeconds(1f);

        chopTimelineCanvas.SetActive(false);
        day2TimelineCanvas.SetActive(true);
        day2Director.Play();
        yield return new WaitForSeconds(2.5f);

        demon.SetActive(false);
        day2TimelineCanvas.SetActive(false);
        GamestateManager.instance.NextDay();
        float demonOwes = 100 - GamestateManager.instance.money;
        GamestateManager.instance.ChangeMoney(demonOwes);
        landlord.SetActive(true);
        landlordScript.Appear();
        landlordScript.PopUpAnim();
        DialogueManager.GetInstance().EnterDialogueMode(landlordJSON, "Introduction2");
    }

    public void StartHand()
    {
        fingerCanvas.SetActive(true);
        if (fingerIndex != 0)
        {
            fingers[fingerIndex - 1].SetActive(false);
        }
        else
        {
            Debug.Log("FingerIndex is 0 in StartHand()");
        }
    }

    public void ChooseHand()
    {
        StartCoroutine(HandChosen());
    }

    private IEnumerator HandChosen()
    {
        fingerCanvas.SetActive(false);

        chopTimelineCanvas.SetActive(true);
        demonScript.Disappear();
        demonScript.PopDownAnim();
        chopDirector.Play();
        yield return new WaitForSeconds(1f);

        chopTimelineCanvas.SetActive(false);
        day3TimelineCanvas.SetActive(true);
        day3Director.Play();
        yield return new WaitForSeconds(2.5f);

        demon.SetActive(false);
        day3TimelineCanvas.SetActive(false);
        GamestateManager.instance.NextDay();
        EventManagerScript_Counter.instance.StartDay(GamestateManager.instance.day);
    }

    public void StartEye()
    {
        eyeCanvas.SetActive(true);
    }

    public void ChooseEye()
    {
        StartCoroutine(EyeChosen());
    }

    private IEnumerator EyeChosen()
    {
        eyeCanvas.SetActive(true);

        chopTimelineCanvas.SetActive(true);
        demonScript.Disappear();
        demonScript.PopDownAnim();
        chopDirector.Play();
        yield return new WaitForSeconds(1f);

        chopTimelineCanvas.SetActive(false);
        day4TimelineCanvas.SetActive(true);
        day4Director.Play();
        yield return new WaitForSeconds(2.5f);

        demon.SetActive(false);
        day4TimelineCanvas.SetActive(false);
        GamestateManager.instance.NextDay();
        EventManagerScript_Counter.instance.StartDay(GamestateManager.instance.day);
    }

    public void StartLifeforce()
    {
        jumpscare.SetActive(true);
    }

    public void End()
    {
        end.SetActive(true);
    }

    // for days without landlord to start the day, invoke OnDayBegin yourself
}
