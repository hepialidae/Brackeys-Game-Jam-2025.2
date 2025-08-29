using System;
using UnityEngine;
using UnityEngine.Events;

public class EventManagerScript_Cooking2 : MonoBehaviour
{
    public static EventManagerScript_Cooking2 instance;

    [Serializable]
    public class IntEvent : UnityEvent<int> { }

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of EventManagerScript_Cooking2 found.");
        }
        else
        {
            instance = this;
        }
    }

    public EventManagerScript_Cooking2 GetInstance()
    {
        return instance;
    }

    // Player adds whipped cream
    public IntEvent OnCreamAdded;
    public void CreamAdded(int creamIndex)
    {
        OnCreamAdded.Invoke(creamIndex);
    }

    // Player adds topping (cream on biscuit)
    public IntEvent OnToppingAddedCream;
    public void ToppingAddedCream(int toppingIndex)
    {
        OnToppingAddedCream.Invoke(toppingIndex);
    }

    // Player adds topping (no cream on biscuit)
    public IntEvent OnToppingAddedNoCream;
    public void ToppingAddedNoCream(int toppingIndex)
    {
        OnToppingAddedNoCream.Invoke(toppingIndex);
    }

    // Trash button
    public event Action OnTrashPressed;
    public void TrashPressed()
    {
        OnTrashPressed.Invoke();
    }

    // Player presses done
    public event Action OnDonePressed;
    public void DonePressed()
    {
        OnDonePressed.Invoke();
    }
}
