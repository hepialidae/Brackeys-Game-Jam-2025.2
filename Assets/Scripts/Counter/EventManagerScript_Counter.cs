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

    // Spawns customer
    public IntEvent OnCustomerSpawned;
    public void SpawnCustomer(int customer)
    {
        Debug.Log("EventManager: Invoking OnCustomerSpawned with " + customer);
        OnCustomerSpawned.Invoke(customer);
    }
}
