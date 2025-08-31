using UnityEngine;
using UnityEngine.EventSystems;

public class DoneButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] GameObject doneButtonOutline;
    [SerializeField] GameObject doneButtonOutlineB;

    private int creamIndex = 99;
    private int toppingIndex = 99;

    void Start()
    {
        doneButtonOutline.SetActive(false);
        doneButtonOutlineB.SetActive(false);

        EventManagerScript_Cooking2.instance.OnCreamAdded.AddListener(CreamAdded);
        EventManagerScript_Cooking2.instance.OnToppingAddedCream.AddListener(ToppingAdded);
        EventManagerScript_Cooking2.instance.OnToppingAddedNoCream.AddListener(ToppingAdded);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (GamestateManager.instance.day <= 2)
        {
            doneButtonOutline.SetActive(true);
        }
        else
        {
            doneButtonOutlineB.SetActive(true);
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (GamestateManager.instance.day <= 2)
        {
            doneButtonOutline.SetActive(false);
        }
        else
        {
            doneButtonOutlineB.SetActive(false);
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("CreamIndex: " + creamIndex + "; ToppingIndex: " + toppingIndex);
        OrderTracker.instance.playerCreamIndex = creamIndex;
        OrderTracker.instance.playerToppingIndex = toppingIndex;
        OrderTracker.instance.DonePressed();
    }

    private void CreamAdded(int cream)
    {
        creamIndex = cream;
    }

    private void ToppingAdded(int topping)
    {
        toppingIndex = topping;
    }
}
