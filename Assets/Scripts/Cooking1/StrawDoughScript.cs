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
        EventManagerScript.instance.OnTrashPressed += Reset;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (CanPlaceDough)
        {
            strawDoughOutline.SetActive(true);
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (CanPlaceDough)
        {
            strawDoughOutline.SetActive(false);
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (CanPlaceDough)
        {
            strawDoughOutline.SetActive(false);
            EventManagerScript.instance.ChooseDoughType(1);
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
