using System.Linq;
using UnityEngine;
using System.Collections;

public class CustomerManagerScript : MonoBehaviour
{
    [SerializeField] private int[] customersVisited;

    void Start()
    {
        StartCoroutine(Wait());
    }

    private void SpawnCustomer()
    {
        int randomCustomer = Random.Range(0, 5);
        while (customersVisited.Contains(randomCustomer))
        {
            randomCustomer = Random.Range(0, 5);
        }
        Debug.Log("Spawning customer: " + randomCustomer);
        EventManagerScript_Counter.instance.SpawnCustomer(randomCustomer);
    }

    private IEnumerator Wait()
    {
        yield return null;
        SpawnCustomer();
    }
}
