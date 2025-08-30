using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerManagerScript : MonoBehaviour
{
    public static CustomerManagerScript instance { get; private set; }
    public List<int> customersVisited = new List<int> {};

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

    void Start()
    {
        EventManagerScript_Counter.instance.OnDayBegin.AddListener(RunWaitWithInt);
        EventManagerScript_Counter.instance.OnCustomerServed += RunWait;
    }

    private void SpawnRandomCustomer()
    {
        int randomCustomer = Random.Range(0, 5);
        while (customersVisited.Contains(randomCustomer))
        {
            randomCustomer = Random.Range(0, 5);
        }

        Debug.Log("Spawning customer: " + randomCustomer);

        OrderTracker.instance.customerIndex = randomCustomer;
        customersVisited.Add(randomCustomer);
        EventManagerScript_Counter.instance.SpawnRandomCustomer(randomCustomer);

        if (customersVisited.Count == 5) // If change this number, change DialogueManagerScript_Counter line 138
        {
            EventManagerScript_Counter.instance.OnCustomerServed -= RunWait;
        }
    }

    public void StartSpawnCustomerFlow()
    {
        customersVisited = new List<int> {};
        EventManagerScript_Counter.instance.OnCustomerServed += RunWait;
    }

    private void RunWait()
    {
        StartCoroutine(WaitToSpawn());
    }

    private void RunWaitWithInt(int day)
    {
        StartCoroutine(WaitToSpawn());
    }

    private IEnumerator WaitToSpawn()
    {
        yield return new WaitForSeconds(0.5f);
        SpawnRandomCustomer();
    }
}
