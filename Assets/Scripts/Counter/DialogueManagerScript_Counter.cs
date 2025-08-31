using UnityEngine;
using TMPro;
using Ink.Runtime;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;
    public bool DialogueIsPlaying;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject DialogueCanvas;
    [SerializeField] private TextMeshProUGUI DialogueText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    [Header("Ink")]
    private Story currentStory;

    [Header("Debug/Testing")]
    [SerializeField] TextAsset inkJSON = null;
    [SerializeField] string knotName = null;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one dialogue manager");
        }
        else
        {
            instance = this;
        }
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    void Start()
    {
        DialogueIsPlaying = false;

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>(true);
            index++;
        }

        DialogueText.text = "";
        DialogueCanvas.SetActive(false);

        if (inkJSON != null && knotName != null)
        {
            EnterDialogueMode(inkJSON, knotName);
        }
    }

    void Update()
    {
        if (!DialogueIsPlaying)
        {
            return;
        }
        else
        {
            if (currentStory.currentChoices.Count == 0 && InputManagerScript.instance.GetLeftClickPerformed())
            {
                ContinueStory();
            }
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON, string knotName)
    {
        Debug.Log("EnterDialogueMode entered");
        DialogueCanvas.SetActive(true);

        currentStory = new Story(inkJSON.text);
        DialogueIsPlaying = true;

        currentStory.ChoosePathString(knotName);

        if (knotName.Contains("Default"))
        {
            List<string> knotTags = currentStory.TagsForContentAtPath(knotName).ToList();
            BindLeaveCounter();
            OrderTracker.instance.SetOrder(knotTags);
        }

        if (knotName.Contains("Special"))
        {
            List<string> knotTags = currentStory.TagsForContentAtPath(knotName).ToList();
            BindLeaveCounter();
            BindEndOrder();
            OrderTracker.instance.SetOrder(knotTags);
        }

        if (knotName.Contains("Good") || knotName.Contains("Okay") || knotName.Contains("Bad"))
        {
            BindLeaveCounter();
            BindEndOrder();
        }

        if (knotName.Contains("Introduction"))
        {
            BindStartDay();
        }

        if (knotName.Contains("Day"))
        {
            BindDemons();
        }

        ContinueStory();
    }

    public void BindLeaveCounter()
    {
        currentStory.BindExternalFunction("leaveCounter", () =>
        {
            // Debug.Log($"OrderDoughIndex: {OrderTracker.instance.orderDoughIndex}");
            // Debug.Log($"OrderCreamIndex: {OrderTracker.instance.orderCreamIndex}");
            // Debug.Log($"OrderToppingIndex: {OrderTracker.instance.orderToppingIndex}");
            StartCoroutine(LeaveCounter());
        });
    }

    private IEnumerator LeaveCounter()
    {
        GamestateManager.instance.ChangeMoney(OrderTracker.instance.orderPrice);
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene("Cooking1");
    }

    public void BindEndOrder()
    {
        currentStory.BindExternalFunction("endOrder", () =>
        {
            ExitDialogueMode();
            EventManagerScript_Counter.instance.ServeCustomer();

            if (CustomerManagerScript.instance.customersVisited.Count == GamestateManager.instance.customersPerDay)
            {
                EventManagerScript_Counter.instance.EndDay(GamestateManager.instance.day);
            }
        });
    }

    public void BindStartDay()
    {
        currentStory.BindExternalFunction("startDay", (int day) =>
        {
            ExitDialogueMode();
            EventManagerScript_Counter.instance.StartDay(day);
        });
    }

    public void BindDemons()
    {
        currentStory.BindExternalFunction("finger", () =>
        {
            ExitDialogueMode();
            StoryManagerScript.instance.StartFinger();
        });

        currentStory.BindExternalFunction("end", () =>
        {
            ExitDialogueMode();
        });

        currentStory.BindExternalFunction("hand", () =>
        {
            ExitDialogueMode();
        });

        currentStory.BindExternalFunction("eye", () =>
        {
            ExitDialogueMode();
        });

        currentStory.BindExternalFunction("lifeforce", () =>
        {
            ExitDialogueMode();
        });
    }

    private void ExitDialogueMode()
    {
        DialogueIsPlaying = false;
        DialogueCanvas.SetActive(false);
        DialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            DialogueText.text = currentStory.Continue();
            DisplayChoices();

            List<string> lineTags = currentStory.currentTags;
            if (lineTags != null && lineTags.Count != 0)
            {
                HandleTags(lineTags);
            }
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void HandleTags(List<string> tags)
    {
        int len = tags.Count;
        switch (len)
        {
            case 1:
                if (tags[0] == "red")
                {
                    DialogueText.color = Color.red;
                    break;
                }
                if (tags[0] == "normal")
                {
                    DialogueText.color = ColorUtility.TryParseHtmlString("#925B6E", out var c) ? c : Color.white;
                    break;
                }
                break;
        }

    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices than the UI can support");
        }
        else
        {
            int index = 0;
            foreach (Choice choice in currentChoices)
            {
                choices[index].gameObject.SetActive(true);
                choicesText[index].text = choice.text;
                index++;
            }
            for (int i = index; i < choices.Length; i++)
            {
                choices[i].gameObject.SetActive(false);
            }
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();

        if (!currentStory.canContinue && currentStory.currentChoices.Count == 0)
        {
            ExitDialogueMode();
        }
    }
}
