using System;
using UnityEngine;
using UnityEngine.Events;

public class EventManagerScript : MonoBehaviour
{
    public static EventManagerScript instance;

    [Serializable]
    public class IntEvent : UnityEvent<int> { }

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of EventManagerScript found.");
        }
        else
        {
            instance = this;
        }
    }

    public EventManagerScript GetInstance()
    {
        return instance;
    }

    // When the player clicks on one of the three doughs
    public IntEvent OnDoughChosen;
    public void ChooseDoughType(int doughNum)
    {
        OnDoughChosen.Invoke(doughNum);
    }

    // When the player clicks on the oven to bake the dough
    public event Action OnDoughBaked;
    public void BakeDough()
    {
        OnDoughBaked.Invoke();
    }

    // When the player takes the dough out of the oven
    public IntEvent OnBiscuitPlated;
    public void PlateBiscuit(int barScore)
    {
        OnBiscuitPlated.Invoke(barScore);
    }

    // When the player presses the next button
    public event Action OnNextPressed;
    public void NextPressed()
    {
        OnNextPressed.Invoke();
    }
}
