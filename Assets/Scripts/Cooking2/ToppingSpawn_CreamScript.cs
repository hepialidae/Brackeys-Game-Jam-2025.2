using UnityEngine;

public class ToppingSpawn_CreamScript : MonoBehaviour
{
    [SerializeField] Sprite[] toppings;
    private SpriteRenderer _renderer;
    private int toppingIndex = 99;

    void Start()
    {
        _renderer = gameObject.GetComponent<SpriteRenderer>();
        _renderer.sprite = null;

        EventManagerScript_Cooking2.instance.OnToppingAddedCream.AddListener(SpawnTopping);
        EventManagerScript_Cooking2.instance.OnTrashPressed += Reset;
    }

    void SpawnTopping(int topping)
    {
        _renderer.sprite = toppings[topping];
        toppingIndex = topping;
    }

    void Reset()
    {
        _renderer.sprite = null;
    }
}
