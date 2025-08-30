using UnityEngine;

public class ToppingSpawnCream_Counter : MonoBehaviour
{
    [SerializeField] Sprite[] toppings;
    [SerializeField] float[] toppingPos;
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
        if (OrderTracker.instance.playerCreamIndex != 99 && OrderTracker.instance.playerToppingIndex != 99)
        {
            int toppingIndex = OrderTracker.instance.playerToppingIndex;
            _renderer.sprite = toppings[toppingIndex];

            Vector3 newPos = new Vector3(gameObject.transform.localPosition.x, toppingPos[toppingIndex]);
            gameObject.transform.localPosition = newPos;
        }

        if (OrderTracker.instance.playerToppingIndex == 99)
        {
            _renderer.sprite = null;
        }
    }
}
