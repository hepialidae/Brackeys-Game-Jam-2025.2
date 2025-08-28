using UnityEngine;
using TMPro;
using Ink.Runtime;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;

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
    private string[] tags;

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
        DialogueCanvas.SetActive(true);

        currentStory = new Story(inkJSON.text);
        DialogueIsPlaying = true;

        currentStory.ChoosePathString(knotName);

        if (knotName.Contains("Default") || knotName.Contains("Special"))
        {
            BindLeaveCounter();
            List<string> knotTags = currentStory.TagsForContentAtPath(knotName).ToList();
            OrderTracker.instance.SetOrder(knotTags);
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
            SceneManager.LoadScene("Cooking1");
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
        }
        else
        {
            ExitDialogueMode();
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
