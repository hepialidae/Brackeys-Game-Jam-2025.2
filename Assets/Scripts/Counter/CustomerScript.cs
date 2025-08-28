using UnityEngine;
using System.Collections;

public class CustomerScript : MonoBehaviour
{
    [Header("Ink Files")]
    [SerializeField] private TextAsset defaultOrders;
    [SerializeField] private TextAsset specialOrders;

    [Header("Customer Info")]
    [SerializeField] private int myCustomerIndex;
    [SerializeField] private Sprite mySprite;
    private SpriteRenderer _renderer;
    private bool isVisible;
    private bool seesOrder;

    void Start()
    {
        _renderer = gameObject.GetComponent<SpriteRenderer>();

        EventManagerScript_Counter.instance.OnCustomerSpawned.AddListener(Spawn);

        Disappear();
    }

    private void Spawn(int customer)
    {
        Debug.Log("Spawn recieved");
        StartCoroutine(Wait());

        if (customer == myCustomerIndex)
        {
            Appear();

            string orderString = GetOrder(GamestateManager.instance.day);
            if (orderString.Contains("Default"))
            {
                Debug.Log("Got the order: " + orderString);
                DialogueManager.GetInstance().EnterDialogueMode(defaultOrders, orderString);
            }
            else
            {
                if (orderString.Contains("Special"))
                {
                    DialogueManager.GetInstance().EnterDialogueMode(specialOrders, orderString);
                }
                else
                {
                    Debug.Log("OrderString does not contain Default or Special. Somehow. Here: " + orderString);
                }
            }
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

    private string GetOrder(int day)
    {
        switch (day)
        {
            case 1:
                int orderNum = Random.Range(1, 13);
                return $"Default{orderNum}";
            case 2:
                int probabilityNum = Random.Range(1, 11);
                if (probabilityNum <= 2) // 20% chance for special order
                {
                    int orderNum2 = Random.Range(1, 4);
                    return $"Special{orderNum2}";
                }
                else
                {
                    int orderNum2 = Random.Range(1, 13);
                    return $"Default{orderNum2}";
                }
            case 3:
                int probabilityNum2 = Random.Range(1, 11);
                if (probabilityNum2 <= 3) // 30% chance for special order
                {
                    int orderNum2 = Random.Range(1, 4);
                    return $"Special{orderNum2}";
                }
                else
                {
                    int orderNum2 = Random.Range(1, 13);
                    return $"Default{orderNum2}";
                }
            case 4:
                int orderNum3 = Random.Range(1, 4);
                return $"Default{orderNum3}";
            default:
                Debug.Log("Day is something other than 1-4. Day: " + day);
                return "Default1";
        }
    }

    private IEnumerator Wait()
    {
        yield return null;
    }
}
