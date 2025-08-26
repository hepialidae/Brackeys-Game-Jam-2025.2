using UnityEngine;

public class ToppingSpawn_NoCreamScript : MonoBehaviour
{
    [SerializeField] Sprite[] toppings;
    private SpriteRenderer _renderer;

    private int toppingIndex = 99;

    void Start()
    {
        _renderer = gameObject.GetComponent<SpriteRenderer>();
        _renderer.sprite = null;

        EventManagerScript_Cooking2.instance.OnToppingAddedNoCream.AddListener(SpawnTopping);
        EventManagerScript_Cooking2.instance.OnCreamAdded.AddListener(ChangeToppingPos);
        EventManagerScript_Cooking2.instance.OnTrashPressed += Reset;
    }

    private void SpawnTopping(int topping)
    {
        _renderer.sprite = toppings[topping];
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
