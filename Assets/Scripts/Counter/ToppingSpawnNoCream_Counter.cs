using UnityEngine;

public class ToppingSpawnNoCream_Counter : MonoBehaviour
{
    [Header("Baked/Overcooked/Burnt")]
    [SerializeField] private Sprite[] toppings;
    [SerializeField] private float[] toppingsPos;

    [Header("Undercooked")]
    [SerializeField] private Sprite[] toppingsUndercooked;
    [SerializeField] private float[] toppingsPosUndercooked;

    [Header("Raw")]
    [SerializeField] private Sprite[] toppingsRaw;
    [SerializeField] private float[] toppingsPosRaw;
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
        if (OrderTracker.instance.playerCreamIndex == 99 && OrderTracker.instance.playerToppingIndex != 99)
        {
            int toppingIndex = OrderTracker.instance.playerToppingIndex;
            switch (OrderTracker.instance.playerCookScore)
            {
                case 0:
                    _renderer.sprite = toppingsRaw[toppingIndex];

                    Vector3 newPos = new Vector3(gameObject.transform.localPosition.x, toppingsPosRaw[toppingIndex]);
                    gameObject.transform.localPosition = newPos;
                    break;
                case 1:
                    _renderer.sprite = toppingsUndercooked[toppingIndex];

                    Vector3 newPos2 = new Vector3(gameObject.transform.localPosition.x, toppingsPosUndercooked[toppingIndex]);
                    gameObject.transform.localPosition = newPos2;
                    break;
                case 99:
                    Debug.LogWarning("playerCookScore is 99...somehow.");
                    break;
                default:
                    _renderer.sprite = toppings[toppingIndex];

                    Vector3 newPos3 = new Vector3(gameObject.transform.localPosition.x, toppingsPos[toppingIndex]);
                    gameObject.transform.localPosition = newPos3;
                    break;
            }
        }

        if (OrderTracker.instance.playerToppingIndex == 99)
        {
            _renderer.sprite = null;
        }
    }
}
