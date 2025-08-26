using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class VaniBottleScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] GameObject vaniBottleOutline;
    private bool CanPlaceCream = true;

    void Start()
    {
        vaniBottleOutline.SetActive(false);
        CanPlaceCream = true;

        EventManagerScript_Cooking2.instance.OnCreamAdded.AddListener(CreamAdded);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (CanPlaceCream)
        {
            vaniBottleOutline.SetActive(true);
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (CanPlaceCream)
        {
            vaniBottleOutline.SetActive(false);
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (CanPlaceCream)
        {
            vaniBottleOutline.SetActive(false);
            EventManagerScript_Cooking2.instance.CreamAdded(0);
        }
    }

    private void CreamAdded(int creamIndex)
    {
        CanPlaceCream = false;
    }
}
