using UnityEngine;

public class ToppingSpawn_NoCreamScript : MonoBehaviour
{
    [SerializeField] Sprite[] toppings;
    [SerializeField] Sprite[] toppingsUnderBaked;
    [SerializeField] Sprite[] toppingsRaw;
    [SerializeField] float[] toppingPos;
    [SerializeField] float[] toppingUnderBakedPos;
    [SerializeField] float[] toppingRawPos;
    private SpriteRenderer _renderer;
    private Transform _transform;

    private int toppingIndex = 99;

    void Start()
    {
        _transform = gameObject.GetComponent<Transform>();
        _renderer = gameObject.GetComponent<SpriteRenderer>();
        _renderer.sprite = null;

        Vector3 newPos = new Vector3(_transform.localPosition.x, -1.74f);
        _transform.localPosition = newPos;

        EventManagerScript_Cooking2.instance.OnToppingAddedNoCream.AddListener(SpawnTopping);
        EventManagerScript_Cooking2.instance.OnCreamAdded.AddListener(ChangeToppingPos);
        EventManagerScript_Cooking2.instance.OnTrashPressed += Reset;
    }

    private void SpawnTopping(int topping)
    {
        switch (OrderTracker.instance.playerCookScore)
        {
            case 0:
                Vector3 newPos = new Vector3(_transform.localPosition.x, toppingRawPos[topping]);
                _transform.localPosition = newPos;

                _renderer.sprite = toppingsRaw[topping];
                break;
            case 1:
                Vector3 newPos1 = new Vector3(_transform.localPosition.x, toppingUnderBakedPos[topping]);
                _transform.localPosition = newPos1;

                _renderer.sprite = toppingsUnderBaked[topping];
                break;
            case 99:
                Debug.LogWarning("playerCookScore is 99.");
                break;
            default:
                Vector3 newPosDef = new Vector3(_transform.localPosition.x, toppingPos[topping]);
                _transform.localPosition = newPosDef;

                _renderer.sprite = toppings[topping];
                break;
        }
        
        toppingIndex = topping;
    }

    private void ChangeToppingPos(int cream)
    {
        if (toppingIndex != 99)
        {
            EventManagerScript_Cooking2.instance.ToppingAddedCream(toppingIndex);
            _renderer.sprite = null;
        }
    }

    void Reset()
    {
        _renderer.sprite = null;
    }
}
