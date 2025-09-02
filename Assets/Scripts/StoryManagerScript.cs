using UnityEngine;
using UnityEngine.Playables;
using System.Collections;
using TMPro;

public class StoryManagerScript : MonoBehaviour
{
    [Header("Demon & Landlord Data")]
    [SerializeField] private TextAsset demonJSON;
    [SerializeField] private TextAsset landlordJSON;
    [SerializeField] private GameObject landlord;
    [SerializeField] private GameObject demon;
    private StoryCharacterScript landlordScript;
    private StoryCharacterScript demonScript;
    private int debt = 0;

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
    [SerializeField] private GameObject frame;
    [SerializeField] private GameObject apology;
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
        DontDestroyOnLoad(frame);
        DontDestroyOnLoad(apology);
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
        frame.SetActive(false);
        apology.SetActive(false);


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
        yield return new WaitForSeconds(4.1f);
        AudioManager.instance.Play(AudioManager.instance.day1);
        day1TimelineCanvas.SetActive(false);
        landlord.SetActive(true);
        landlordScript.Appear();
        landlordScript.PopUpAnim();
        yield return new WaitForSeconds(0.3f);
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
        AudioManager.instance.FadeOut(AudioManager.instance.day1, 0.7f);
        AudioManager.instance.FadeOut(AudioManager.instance.day2, 0.7f);
        AudioManager.instance.FadeOut(AudioManager.instance.day3, 0.7f);
        AudioManager.instance.FadeOut(AudioManager.instance.day4, 0.7f);
        yield return new WaitForSeconds(0.7f);
        AudioManager.instance.Play(AudioManager.instance.demonTheme);
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
        AudioManager.instance.FadeOut(AudioManager.instance.demonTheme, 0.1f);
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
        yield return new WaitForSeconds(4.1f);

        demon.SetActive(false);
        day2TimelineCanvas.SetActive(false);
        AudioManager.instance.Play(AudioManager.instance.day2);
        GamestateManager.instance.NextDay();
        float demonOwes = 100 - GamestateManager.instance.money;
        GamestateManager.instance.ChangeMoney(demonOwes);
        landlord.SetActive(true);
        landlordScript.Appear();
        landlordScript.PopUpAnim();
        yield return new WaitForSeconds(0.3f);
        DialogueManager.GetInstance().EnterDialogueMode(landlordJSON, "Introduction2");
    }

    public IEnumerator NormalEnd1()
    {
        day2TimelineCanvas.SetActive(true);
        day2Director.Play();
        yield return new WaitForSeconds(4.1f);

        demon.SetActive(false);
        day2TimelineCanvas.SetActive(false);
        AudioManager.instance.Play(AudioManager.instance.day2);
        GamestateManager.instance.NextDay();
        debt += 100;
        landlord.SetActive(true);
        landlordScript.Appear();
        landlordScript.PopUpAnim();
        yield return new WaitForSeconds(0.3f);
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
        AudioManager.instance.FadeOut(AudioManager.instance.demonTheme, 0.1f);
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
        yield return new WaitForSeconds(4.1f);

        demon.SetActive(false);
        day3TimelineCanvas.SetActive(false);
        AudioManager.instance.Play(AudioManager.instance.day3);
        GamestateManager.instance.NextDay();
        float demonOwes = 200 - debt - GamestateManager.instance.money;
        GamestateManager.instance.ChangeMoney(demonOwes);
        EventManagerScript_Counter.instance.StartDay(GamestateManager.instance.day);
    }

    public IEnumerator NormalEnd2()
    {
        day3TimelineCanvas.SetActive(true);
        day3Director.Play();
        yield return new WaitForSeconds(4.1f);

        demon.SetActive(false);
        day3TimelineCanvas.SetActive(false);
        AudioManager.instance.Play(AudioManager.instance.day3);
        GamestateManager.instance.NextDay();
        debt += 100;
        EventManagerScript_Counter.instance.StartDay(GamestateManager.instance.day);
    }

    public void StartEye()
    {
        eyeCanvas.SetActive(true);
    }

    public void ChooseEye()
    {
        AudioManager.instance.FadeOut(AudioManager.instance.demonTheme, 0.1f);
        StartCoroutine(EyeChosen());
    }

    private IEnumerator EyeChosen()
    {
        eyeCanvas.SetActive(false);

        chopTimelineCanvas.SetActive(true);
        demonScript.Disappear();
        demonScript.PopDownAnim();
        chopDirector.Play();
        yield return new WaitForSeconds(1f);

        chopTimelineCanvas.SetActive(false);
        day4TimelineCanvas.SetActive(true);
        day4Director.Play();
        yield return new WaitForSeconds(4.1f);

        demon.SetActive(false);
        day4TimelineCanvas.SetActive(false);
        AudioManager.instance.Play(AudioManager.instance.day4);
        GamestateManager.instance.NextDay();
        frame.SetActive(true);
        float demonOwes = 300 - debt - GamestateManager.instance.money;
        GamestateManager.instance.ChangeMoney(demonOwes);
        EventManagerScript_Counter.instance.StartDay(GamestateManager.instance.day);
    }

    public IEnumerator NormalEnd3()
    {
        day4TimelineCanvas.SetActive(true);
        day4Director.Play();
        yield return new WaitForSeconds(4.1f);

        demon.SetActive(false);
        day4TimelineCanvas.SetActive(false);
        AudioManager.instance.Play(AudioManager.instance.day4);
        GamestateManager.instance.NextDay();
        frame.SetActive(true);
        debt += 100;
        EventManagerScript_Counter.instance.StartDay(GamestateManager.instance.day);
    }

    public void StartLifeforce()
    {
        frame.SetActive(false);
        AudioManager.instance.FadeOut(AudioManager.instance.demonTheme, 0.1f);
        jumpscare.SetActive(true);
        StartCoroutine(EndlessOption());
    }

    private IEnumerator EndlessOption()
    {
        yield return new WaitForSeconds(2f);
        apology.SetActive(true);
    }

    public void End()
    {
        frame.SetActive(false);
        AudioManager.instance.FadeOut(AudioManager.instance.demonTheme, 0.1f);
        end.SetActive(true);
    }

    public void StartEndless()
    {
        demon.SetActive(false);
        apology.SetActive(false);
        jumpscare.SetActive(false);
        GamestateManager.instance.NextDay();
        EventManagerScript_Counter.instance.StartDay(GamestateManager.instance.day);
    }

    // for days without landlord to start the day, invoke OnDayBegin yourself
}
