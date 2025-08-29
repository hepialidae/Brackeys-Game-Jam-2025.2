using System.Linq;
using UnityEngine;
using System.Collections;

public class CustomerManagerScript : MonoBehaviour
{
    public static CustomerManagerScript instance { get; private set; }
    [SerializeField] private int[] customersVisited;

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
        EventManagerScript_Counter.instance.OnCustomerServed += RunWait;

        StartCoroutine(Wait());
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
        EventManagerScript_Counter.instance.SpawnRandomCustomer(randomCustomer);
    }

    private void RunWait()
    {
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        SpawnRandomCustomer();
    }
}
