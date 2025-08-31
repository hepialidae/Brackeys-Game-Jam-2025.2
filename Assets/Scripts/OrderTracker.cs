using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class OrderTracker : MonoBehaviour
{
    public static OrderTracker instance { get; private set; }

    // Order variables
    public int customerIndex = 99;
    public int orderDoughIndex = 99;
    public int orderCreamIndex = 99;
    public int orderToppingIndex = 99;
    public float orderPrice = 0;

    // Player variables
    public int playerDoughIndex = 99;
    public int playerCookScore = 99;
    public int playerCreamIndex = 99;
    public int playerToppingIndex = 99;

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
        StartCoroutine(WaitAndSetListeners());
    }

    private void ResetVariables(int customer)
    {
        Debug.Log("customer as seen in OrderTracker: " + customer);
        customerIndex = customer;
        playerDoughIndex = 99;
        playerCookScore = 99;
        playerCreamIndex = 99;
        playerToppingIndex = 99;
    }

    private IEnumerator WaitAndSetListeners()
    {
        yield return null;
        Debug.Log("Subscribers set");
        EventManagerScript_Counter.GetInstance().OnRandomCustomerSpawned.AddListener(ResetVariables);
    }

    public void SetOrder(List<string> tags)
    {
        Debug.Log("Setting order...tag 1: " + tags[0]);
        orderDoughIndex = int.Parse(tags[0].Trim());
        orderCreamIndex = int.Parse(tags[1].Trim());
        orderToppingIndex = int.Parse(tags[2].Trim());
        orderPrice = float.Parse(tags[3].Trim());
    }

    public void DonePressed()
    {
        StartCoroutine(DonePressed2());
    }

    public IEnumerator DonePressed2()
    {
        SceneManager.LoadScene("Counter");
        yield return new WaitForSeconds(0.1f);
        EventManagerScript_Counter.instance.BiscuitFinished(customerIndex);
    }

    public string CalculateScore()
    {
        if (orderDoughIndex == playerDoughIndex &&
            orderCreamIndex == playerCreamIndex &&
            orderToppingIndex == playerToppingIndex &&
            playerCookScore == 2)
        {
            return "Good";
        }
        else
        {
            if (orderDoughIndex == playerDoughIndex &&
                orderCreamIndex == playerCreamIndex &&
                orderToppingIndex == playerToppingIndex &&
                playerCookScore >= 1 &&
                playerCookScore <= 3)
            {
                return "Okay";
            }
            else
            {
                return "Bad";
            }
        }
    }
}
