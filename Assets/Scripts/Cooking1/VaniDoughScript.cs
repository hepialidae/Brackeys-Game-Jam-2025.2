using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class VaniDoughScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] GameObject vaniDoughOutline;
    private bool CanPlaceDough;

    void Start()
    {
        vaniDoughOutline.SetActive(false);
        CanPlaceDough = true;
        EventManagerScript.instance.OnDoughChosen.AddListener(DoughPlaced);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (CanPlaceDough)
        {
            vaniDoughOutline.SetActive(true);
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (CanPlaceDough)
        {
            vaniDoughOutline.SetActive(false);
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (CanPlaceDough)
        {
            EventManagerScript.instance.ChooseDoughType(0);
            vaniDoughOutline.SetActive(false);
        }
    }

    void DoughPlaced(int doughNum)
    {
        CanPlaceDough = false;
    }
}
