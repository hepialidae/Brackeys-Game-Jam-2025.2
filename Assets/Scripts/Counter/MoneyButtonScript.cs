using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;
using DG.Tweening;
using System.Collections;

public class MoneyButtonScript : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public static MoneyButtonScript instance;
    [SerializeField] private GameObject moneyUI;
    [SerializeField] private TextMeshProUGUI moneyUIText;
    [SerializeField] private GameObject outline;
    [SerializeField] private TextMeshProUGUI moneyAnimText;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(moneyUI);

        moneyAnimText.text = "";
    }

    void Start()
    {
        moneyUI.SetActive(false);
        outline.SetActive(false);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        outline.SetActive(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        outline.SetActive(false);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        float currentMoney = GamestateManager.instance.money;
        float dailyGoal = 0f;
        switch (GamestateManager.instance.day)
        {
            case 1:
                dailyGoal = 100f;
                break;
            case 2:
                dailyGoal = 200f;
                break;
            case 3:
                dailyGoal = 300f;
                break;
            case 4:
                dailyGoal = 400f;
                break;
            case 5:
                dailyGoal = 0f;
                break;
            default:
                Debug.LogWarning("Day is something other than 1-4. Day: " + GamestateManager.instance.day);
                break;
        }

        moneyUI.SetActive(true);
        moneyUIText.text = $"Total: ${currentMoney:F2}{Environment.NewLine}Today's Goal: ${dailyGoal:F2}";
    }

    public void MoneyUIOff()
    {
        moneyUI.SetActive(false);
    }

    public void RunMoneyChanged(float amount)
    {
        StartCoroutine(MoneyChanged(amount));
    }

    private IEnumerator MoneyChanged(float amount)
    {
        if (amount >= 0)
        {
            moneyAnimText.text = $"+${amount:F2}";
            moneyAnimText.color = Color.green;
            yield return new WaitForSeconds(2f);
            moneyAnimText.text = "";
        }
        else
        {
            moneyAnimText.text = $"-${amount * -1:F2}";
            moneyAnimText.color = Color.red;
            yield return new WaitForSeconds(2f);
            moneyAnimText.text = "";
        }
    }
}
