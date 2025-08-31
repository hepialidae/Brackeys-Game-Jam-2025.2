using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChocDoughScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] GameObject chocDoughOutline;
    [SerializeField] GameObject chocDoughOutlineB;
    private bool CanPlaceDough;

    void Start()
    {
        chocDoughOutline.SetActive(false);
        chocDoughOutlineB.SetActive(false);
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
                chocDoughOutline.SetActive(true);
            }
            else
            {
                chocDoughOutlineB.SetActive(true);
            }
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (CanPlaceDough)
        {
            if (GamestateManager.instance.day <= 2)
            {
                chocDoughOutline.SetActive(false);
            }
            else
            {
                chocDoughOutlineB.SetActive(false);
            }
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (CanPlaceDough)
        {
            chocDoughOutline.SetActive(false);
            chocDoughOutlineB.SetActive(false);
            GamestateManager.instance.ChangeMoney(-5);
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
