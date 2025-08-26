using UnityEngine;

public class BiscuitSpawnScript : MonoBehaviour
{
    [Header("Doughs")]
    [SerializeField] private Sprite[] VaniDoughs;
    [SerializeField] private Sprite[] StrawDoughs;
    [SerializeField] private Sprite[] ChocDoughs;
    private SpriteRenderer _renderer;

    void Start()
    {
        _renderer = gameObject.GetComponent<SpriteRenderer>();

        SpawnBiscuit();
    }

    void SpawnBiscuit()
    {
        if (OrderTracker.instance.playerDoughIndex == 0)
        {
            _renderer.sprite = VaniDoughs[OrderTracker.instance.playerCookScore];
        }
        else
        {
            if (OrderTracker.instance.playerDoughIndex == 1)
            {
                _renderer.sprite = StrawDoughs[OrderTracker.instance.playerCookScore];
            }
            else
            {
                if (OrderTracker.instance.playerDoughIndex == 2)
                {
                    _renderer.sprite = ChocDoughs[OrderTracker.instance.playerCookScore];
                }
                else
                {
                    if (OrderTracker.instance.playerDoughIndex == 99)
                    {
                        Debug.Log("Default value given for playerDoughIndex (99), default biscuit spawning.");
                        _renderer.sprite = VaniDoughs[2];
                    }
                    else
                    {
                        Debug.LogError("playerDoughIndex is something other than 0, 1, 2, or 99: " + OrderTracker.instance.playerDoughIndex);
                        Debug.LogError("For good measure, here's the cookScore: " + OrderTracker.instance.playerCookScore);
                    }
                }
            }
        }
    }
}
