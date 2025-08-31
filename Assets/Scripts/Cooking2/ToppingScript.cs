using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToppingScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("Topping Features")]
    [SerializeField] GameObject toppingOutline;
    [SerializeField] GameObject toppingOutlineB;
    [SerializeField] private int toppingIndex;
    [SerializeField] private float toppingPrice;

    [Header("Variables")]
    [SerializeField] private bool CanAddTopping = true;
    [SerializeField] private bool WhippedCreamAdded = false;

    void Start()
    {
        toppingOutline.SetActive(false);
        toppingOutlineB.SetActive(false);

        EventManagerScript_Cooking2.instance.OnCreamAdded.AddListener(CreamAdded);
        EventManagerScript_Cooking2.instance.OnToppingAddedCream.AddListener(ToppingAdded);
        EventManagerScript_Cooking2.instance.OnToppingAddedNoCream.AddListener(ToppingAdded);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (CanAddTopping)
        {
            if (GamestateManager.instance.day <= 2)
            {
                toppingOutline.SetActive(true);
            }
            else
            {
                toppingOutlineB.SetActive(true);
            }
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (CanAddTopping)
        {
            if (GamestateManager.instance.day <= 2)
            {
                toppingOutline.SetActive(false);
            }
            else
            {
                toppingOutlineB.SetActive(false);
            }
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (CanAddTopping)
        {
            toppingOutline.SetActive(false);
            toppingOutlineB.SetActive(false);
            GamestateManager.instance.ChangeMoney(-toppingPrice);

            if (WhippedCreamAdded)
            {
                EventManagerScript_Cooking2.instance.ToppingAddedCream(toppingIndex);
            }
            else
            {
                EventManagerScript_Cooking2.instance.ToppingAddedNoCream(toppingIndex);
            }
        }
    }

    private void ToppingAdded(int topping)
    {
        CanAddTopping = false;
    }

    private void CreamAdded(int cream)
    {
        WhippedCreamAdded = true;
    }
}
