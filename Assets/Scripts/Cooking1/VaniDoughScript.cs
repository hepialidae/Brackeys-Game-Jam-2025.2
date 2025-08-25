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
        vaniDoughOutline.SetActive(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        vaniDoughOutline.SetActive(false);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (CanPlaceDough)
        {
            EventManagerScript.instance.ChooseDoughType(0);
        }
    }

    void DoughPlaced(int doughNum)
    {
        CanPlaceDough = false;
    }
}
