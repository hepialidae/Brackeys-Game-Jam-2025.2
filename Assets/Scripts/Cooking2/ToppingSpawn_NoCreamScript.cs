using UnityEngine;

public class ToppingSpawn_NoCreamScript : MonoBehaviour
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

        Vector3 newPos = new Vector3(_transform.localPosition.x, -1.74f);
        _transform.localPosition = newPos;

        EventManagerScript_Cooking2.instance.OnToppingAddedNoCream.AddListener(SpawnTopping);
        EventManagerScript_Cooking2.instance.OnCreamAdded.AddListener(ChangeToppingPos);
        EventManagerScript_Cooking2.instance.OnTrashPressed += Reset;
    }

    private void SpawnTopping(int topping)
    {
        Vector3 newPos = new Vector3(_transform.localPosition.x, toppingPos[topping]);
        _transform.localPosition = newPos;

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
