using UnityEngine;
using UnityEngine.EventSystems;

public class ChocBottleScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] GameObject chocBottleOutline;
    [SerializeField] GameObject chocBottleOutlineB;
    private bool CanPlaceCream = true;

    void Start()
    {
        chocBottleOutline.SetActive(false);
        chocBottleOutlineB.SetActive(false);
        CanPlaceCream = true;

        EventManagerScript_Cooking2.instance.OnCreamAdded.AddListener(CreamAdded);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (CanPlaceCream)
        {
            if (GamestateManager.instance.day <= 2)
            {
                chocBottleOutline.SetActive(true);
            }
            else
            {
                chocBottleOutlineB.SetActive(true);
            }
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (CanPlaceCream)
        {
            if (GamestateManager.instance.day <= 2)
            {
                chocBottleOutline.SetActive(false);
            }
            else
            {
                chocBottleOutlineB.SetActive(false);
            }
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (CanPlaceCream)
        {
            chocBottleOutline.SetActive(false);
            chocBottleOutlineB.SetActive(false);
            GamestateManager.instance.ChangeMoney(-2.5f);
            EventManagerScript_Cooking2.instance.CreamAdded(2);
        }
    }

    private void CreamAdded(int creamIndex)
    {
        CanPlaceCream = false;
    }
}
