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
}
