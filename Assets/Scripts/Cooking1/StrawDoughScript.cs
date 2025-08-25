using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class StrawDoughScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] GameObject strawDoughOutline;
    private bool CanPlaceDough;

    void Start()
    {
        strawDoughOutline.SetActive(false);
        CanPlaceDough = true;
        EventManagerScript.instance.OnDoughChosen.AddListener(DoughPlaced);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        strawDoughOutline.SetActive(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        strawDoughOutline.SetActive(false);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (CanPlaceDough)
        {
            EventManagerScript.instance.ChooseDoughType(1);
        }
    }

    void DoughPlaced(int doughNum)
    {
        CanPlaceDough = false;
    }
}
