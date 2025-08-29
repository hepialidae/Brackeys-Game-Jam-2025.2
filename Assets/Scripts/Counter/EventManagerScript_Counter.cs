using UnityEngine;
using System;
using UnityEngine.Events;

public class EventManagerScript_Counter : MonoBehaviour
{
    public static EventManagerScript_Counter instance;

    [Serializable]
    public class IntEvent : UnityEvent<int> { }

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one instance of EventManagerScript_Counter found.");
        }
        else
        {
            instance = this;
        }
    }

    public static EventManagerScript_Counter GetInstance()
    {
        return instance;
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
}
