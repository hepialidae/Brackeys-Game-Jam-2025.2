using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class VaniDoughScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] GameObject vaniDoughOutline;
    [SerializeField] GameObject vaniDoughOutlineB;
    private bool CanPlaceDough;

    void Start()
    {
        vaniDoughOutline.SetActive(false);
        vaniDoughOutlineB.SetActive(false);
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
                vaniDoughOutline.SetActive(true);
            }
            else
            {
                vaniDoughOutlineB.SetActive(true);
            }
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (CanPlaceDough)
        {
            if (GamestateManager.instance.day <= 2)
            {
                vaniDoughOutline.SetActive(false);
            }
            else
            {
                vaniDoughOutlineB.SetActive(false);
            }
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (CanPlaceDough)
        {
            vaniDoughOutline.SetActive(false);
            vaniDoughOutlineB.SetActive(false);
            GamestateManager.instance.ChangeMoney(-5);
            EventManagerScript.instance.ChooseDoughType(0);
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
