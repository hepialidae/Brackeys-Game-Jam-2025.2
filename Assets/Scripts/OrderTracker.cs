using UnityEngine;

public class OrderTracker : MonoBehaviour
{
    public static OrderTracker instance { get; private set; }

    // Order variables
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
}
