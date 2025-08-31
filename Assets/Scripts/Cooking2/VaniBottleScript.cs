using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class VaniBottleScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] GameObject vaniBottleOutline;
    [SerializeField] GameObject vaniBottleOutlineB;
    private bool CanPlaceCream = true;

    void Start()
    {
        vaniBottleOutline.SetActive(false);
        vaniBottleOutlineB.SetActive(false);
        CanPlaceCream = true;

        EventManagerScript_Cooking2.instance.OnCreamAdded.AddListener(CreamAdded);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (CanPlaceCream)
        {
            if (GamestateManager.instance.day <= 2)
            {
                vaniBottleOutline.SetActive(true);
            }
            else
            {
                vaniBottleOutlineB.SetActive(true);
            }
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (CanPlaceCream)
        {
            if (GamestateManager.instance.day <= 2)
            {
                vaniBottleOutline.SetActive(false);
            }
            else
            {
                vaniBottleOutlineB.SetActive(false);
            }
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (CanPlaceCream)
        {
            vaniBottleOutline.SetActive(false);
            vaniBottleOutlineB.SetActive(false);
            GamestateManager.instance.ChangeMoney(-2.5f);
            EventManagerScript_Cooking2.instance.CreamAdded(0);
        }
    }

    private void CreamAdded(int creamIndex)
    {
        CanPlaceCream = false;
    }
}
