using UnityEngine;

public class GamestateManager : MonoBehaviour
{
    public static GamestateManager instance { get; private set; }

    [Header("Game Variables")]
    public int day = 1;
    public float money = 0;
    public int customersPerDay = 1;

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

    public void ChangeMoney(float amount)
    {
        money += amount;
        MoneyButtonScript.instance.RunMoneyChanged(amount);
    }

    public void NextDay()
    {
        day++;
        // CustomerManagerScript.instance.StartSpawnCustomerFlow();
    }
}
