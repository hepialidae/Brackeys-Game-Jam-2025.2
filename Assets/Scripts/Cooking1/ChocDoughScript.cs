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
        EventManagerScript.instance.OnTrashPressed += Reset;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (CanPlaceDough)
        {
            chocDoughOutline.SetActive(true);
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (CanPlaceDough)
        {
            chocDoughOutline.SetActive(false);
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (CanPlaceDough)
        {
            chocDoughOutline.SetActive(false);
            EventManagerScript.instance.ChooseDoughType(2);
        }
    }

    void DoughPlaced(int doughNum)
    {
        CanPlaceDough = false;
    }

    private void Reset()
    {
        CanPlaceDough = true;
    }
}
