using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CustomerScript : MonoBehaviour, IPointerClickHandler
{
    [Header("Ink Files")]
    [SerializeField] private TextAsset defaultOrders;
    [SerializeField] private TextAsset specialOrders;

    [Header("Customer Info")]
    [SerializeField] private int myCustomerIndex;
    [SerializeField] private Sprite mySprite;
    private SpriteRenderer _renderer;
    private bool isVisible = false;
    private bool seesOrder = false;

    void Start()
    {
        _renderer = gameObject.GetComponent<SpriteRenderer>();

        EventManagerScript_Counter.instance.OnRandomCustomerSpawned.AddListener(Spawn);
        EventManagerScript_Counter.instance.OnBiscuitFinished.AddListener(BiscuitFinished);

        Disappear();
    }

    private void Spawn(int customer)
    {
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

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (seesOrder && isVisible)
        {
            string score = OrderTracker.instance.CalculateScore();
            switch (score)
            {
                case "Good":
                    int index = Random.Range(1, 4);
                    DialogueManager.GetInstance().EnterDialogueMode(specialOrders, $"Good{index}");
                    break;
                case "Okay":
                    DialogueManager.GetInstance().EnterDialogueMode(specialOrders, $"Okay");
                    break;
                case "Bad":
                    DialogueManager.GetInstance().EnterDialogueMode(specialOrders, $"Bad");
                    break;
            }
        }
    }

    private void Appear()
    {
        _renderer = gameObject.GetComponent<SpriteRenderer>();
        _renderer.sprite = mySprite;
        isVisible = true;
    }

    private void Disappear()
    {
        _renderer = gameObject.GetComponent<SpriteRenderer>();
        _renderer.sprite = null;
        isVisible = false;
    }

    private void BiscuitFinished(int customer)
    {
        Debug.Log("BiscuitFinished in CustomerScript activated.");
        EventManagerScript_Counter.instance.OnCustomerServed += Disappear;
        if (customer == myCustomerIndex)
        {
            seesOrder = true;
            Appear();
        }
    }

    private string GetOrder(int day)
    {
        Debug.Log("Day is: " + day);
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
                return $"Special{orderNum3}";
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
