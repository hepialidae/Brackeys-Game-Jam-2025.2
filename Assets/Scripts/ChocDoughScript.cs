using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChocDoughScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] GameObject chocDoughOutline;
    private bool CanPlaceDough;

    void Start()
    {
        chocDoughOutline.SetActive(false);
        CanPlaceDough = true;
        EventManagerScript.instance.OnDoughChosen.AddListener(DoughPlaced);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        chocDoughOutline.SetActive(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        chocDoughOutline.SetActive(false);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
       if (CanPlaceDough)
        {
            EventManagerScript.instance.ChooseDoughType(2);
        }
    }

    void DoughPlaced(int doughNum)
    {
        CanPlaceDough = false;
    }
}
