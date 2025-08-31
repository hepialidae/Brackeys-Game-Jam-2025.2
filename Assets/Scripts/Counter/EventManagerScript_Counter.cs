using UnityEngine;
using System;
using UnityEngine.Events;

public class EventManagerScript_Counter : MonoBehaviour
{
    public static EventManagerScript_Counter instance { get; private set; }

    [Serializable]
    public class IntEvent : UnityEvent<int> { }

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

    public static EventManagerScript_Counter GetInstance()
    {
        return instance;
    }

    // Day starts (after story)
    public IntEvent OnDayBegin;
    public void StartDay(int dayNum)
    {
        OnDayBegin.Invoke(dayNum);
    }

    // Spawns random customer (for the first time)
    public IntEvent OnRandomCustomerSpawned;
    public void SpawnRandomCustomer(int customer)
    {
        OnRandomCustomerSpawned.Invoke(customer);
    }

    // Brings back customer
    public IntEvent OnBiscuitFinished;
    public void BiscuitFinished(int customer)
    {
        Debug.Log("BiscuitFinished activated. Customer: " + customer);
        OnBiscuitFinished.Invoke(customer);
    }

    // Customer leaves
    public event Action OnCustomerServed;
    public void ServeCustomer()
    {
        OnCustomerServed.Invoke();
    }

    // End of day
    public IntEvent OnDayEnd;
    public void EndDay(int day)
    {
        Debug.Log("OnDayEnd invoked. Day: " + day);
        OnDayEnd.Invoke(day);
    }
}
