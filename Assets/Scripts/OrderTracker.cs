using UnityEngine;

public class OrderTracker : MonoBehaviour
{
    public static OrderTracker instance { get; private set; }

    // Order variables
    public int customerIndex = 99;
    public int orderDoughIndex = 99;
    public int orderCreamIndex = 99;
    public int orderToppingIndex = 99;

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

    private void Reset()
    {
        playerDoughIndex = 99;
        playerCookScore = 99;
        playerCreamIndex = 99;
        playerToppingIndex = 99;
    }
}
