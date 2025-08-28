using System.Linq;
using UnityEngine;

public class CustomerManagerScript : MonoBehaviour
{
    [SerializeField] private int[] customersVisited;

    void Start()
    {
        SpawnCustomer();
    }

    private void SpawnCustomer()
    {
        int randomCustomer = Random.Range(0, 5);
        while (customersVisited.Contains(randomCustomer))
        {
            randomCustomer = Random.Range(0, 5);
        }
        EventManagerScript_Counter.instance.SpawnCustomer(randomCustomer);
    }
}
