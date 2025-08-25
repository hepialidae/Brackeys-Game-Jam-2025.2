using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GamestateManager : MonoBehaviour
{
    public static GamestateManager instance { get; private set; }

    [Header("Game Variables")]
    // 0. dough = (int from 0-2); 0 = vanilla, 1 = strawberry, 2 = chocolate
    // 1. creamColor = (int from 0-2);
    // 2. topping = (int from 0-2);
    Dictionary<string, int> orderValue = new Dictionary<string, int>();

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
