using UnityEngine;

public class BiscuitSpawn_Counter : MonoBehaviour
{
    [SerializeField] Sprite[] vaniDoughs;
    [SerializeField] Sprite[] strawDoughs;
    [SerializeField] Sprite[] chocDoughs;
    private SpriteRenderer _renderer;

    void Awake()
    {
        _renderer = gameObject.GetComponent<SpriteRenderer>();
        _renderer.sprite = null;
    }

    void Start()
    {
        EventManagerScript_Counter.instance.OnBiscuitFinished.AddListener(Spawn);
    }

    void OnDisable()
    {
        EventManagerScript_Counter.instance.OnBiscuitFinished.RemoveListener(Spawn);
    }

    private void Spawn(int num)
    {
        int doughIndex = OrderTracker.instance.playerDoughIndex;
        int cookScore = OrderTracker.instance.playerCookScore;

        switch (doughIndex)
        {
            case 0:
                _renderer.sprite = vaniDoughs[cookScore];
                break;
            case 1:
                _renderer.sprite = strawDoughs[cookScore];
                break;
            case 2:
                _renderer.sprite = chocDoughs[cookScore];
                break;
            case 99:
                _renderer.sprite = null;
                break;
        }
    }
}
