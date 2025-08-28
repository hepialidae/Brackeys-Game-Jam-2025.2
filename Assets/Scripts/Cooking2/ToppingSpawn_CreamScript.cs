using UnityEngine;

public class ToppingSpawn_CreamScript : MonoBehaviour
{
    [SerializeField] Sprite[] toppings;
    [SerializeField] float[] toppingPos;
    private SpriteRenderer _renderer;
    private Transform _transform;
    private int toppingIndex = 99;

    void Start()
    {
        _transform = gameObject.GetComponent<Transform>();
        _renderer = gameObject.GetComponent<SpriteRenderer>();
        _renderer.sprite = null;

        Vector3 newPos = new Vector3(_transform.localPosition.x, -0.9f);
        _transform.localPosition = newPos;

        EventManagerScript_Cooking2.instance.OnToppingAddedCream.AddListener(SpawnTopping);
        EventManagerScript_Cooking2.instance.OnTrashPressed += Reset;
    }

    void SpawnTopping(int topping)
    {
        Vector3 newPos = new Vector3(_transform.localPosition.x, toppingPos[topping]);
        _transform.localPosition = newPos;
        
        _renderer.sprite = toppings[topping];
        toppingIndex = topping;
    }

    void Reset()
    {
        _renderer.sprite = null;
    }
}
