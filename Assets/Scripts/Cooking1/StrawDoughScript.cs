using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class StrawDoughScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] GameObject strawDoughOutline;
    [SerializeField] GameObject strawDoughOutlineB;
    private bool CanPlaceDough;

    void Start()
    {
        strawDoughOutline.SetActive(false);
        strawDoughOutlineB.SetActive(false);
        CanPlaceDough = true;
        EventManagerScript.instance.OnDoughChosen.AddListener(DoughPlaced);
        EventManagerScript.instance.OnTrashPressed += Reset;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (CanPlaceDough)
        {
            if (GamestateManager.instance.day <= 2)
            {
                strawDoughOutline.SetActive(true);
            }
            else
            {
                strawDoughOutlineB.SetActive(true);
            }
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (CanPlaceDough)
        {
            if (GamestateManager.instance.day <= 2)
            {
                strawDoughOutline.SetActive(false);
            }
            else
            {
                strawDoughOutlineB.SetActive(false);
            }
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (CanPlaceDough)
        {
            strawDoughOutline.SetActive(false);
            strawDoughOutlineB.SetActive(false);
            GamestateManager.instance.ChangeMoney(-5);
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
