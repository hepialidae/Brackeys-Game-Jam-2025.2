using UnityEngine;
using UnityEngine.EventSystems;

public class StrawBottleScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] GameObject strawBottleOutline;
    [SerializeField] GameObject strawBottleOutlineB;
    private bool CanPlaceCream = true;

    void Start()
    {
        strawBottleOutline.SetActive(false);
        strawBottleOutlineB.SetActive(false);
        CanPlaceCream = true;

        EventManagerScript_Cooking2.instance.OnCreamAdded.AddListener(CreamAdded);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (CanPlaceCream)
        {
            if (GamestateManager.instance.day <= 2)
            {
                strawBottleOutline.SetActive(true);
            }
            else
            {
                strawBottleOutlineB.SetActive(true);
            }
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (CanPlaceCream)
        {
            if (GamestateManager.instance.day <= 2)
            {
                strawBottleOutline.SetActive(false);
            }
            else
            {
                strawBottleOutlineB.SetActive(false);
            }
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (CanPlaceCream)
        {
            strawBottleOutline.SetActive(false);
            strawBottleOutlineB.SetActive(false);
            GamestateManager.instance.ChangeMoney(-2.5f);
            EventManagerScript_Cooking2.instance.CreamAdded(1);
        }
    }

    private void CreamAdded(int creamIndex)
    {
        CanPlaceCream = false;
    }
}
