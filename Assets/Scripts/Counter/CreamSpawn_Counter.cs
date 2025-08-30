using UnityEngine;

public class CreamSpawn_Counter : MonoBehaviour
{
    [SerializeField] Sprite[] creams;
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
        if (OrderTracker.instance.playerCreamIndex != 99)
        {
            _renderer.sprite = creams[OrderTracker.instance.playerCreamIndex];
        }
        else
        {
            _renderer.sprite = null;
        }
    }
}
