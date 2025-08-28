using UnityEngine;

public class CustomerScript : MonoBehaviour
{
    [SerializeField] private int myCustomerIndex;
    [SerializeField] private Sprite mySprite;
    private SpriteRenderer _renderer;
    private bool isVisible;

    void Start()
    {
        _renderer = gameObject.GetComponent<SpriteRenderer>();

        EventManagerScript_Counter.instance.OnCustomerSpawned.AddListener(Spawn);

        Disappear();
    }

    private void Spawn(int customer)
    {
        if (customer == myCustomerIndex)
        {
            Appear();
        }
    }

    private void Appear()
    {
        _renderer.sprite = mySprite;
        isVisible = true;
    }

    private void Disappear()
    {
        _renderer.sprite = null;
        isVisible = false;
    }

}
