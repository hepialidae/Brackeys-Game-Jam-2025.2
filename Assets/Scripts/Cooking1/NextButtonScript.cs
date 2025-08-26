using UnityEngine;
using UnityEngine.EventSystems;

public class NextButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private GameObject nextButtonOutline;

    void Start()
    {
        gameObject.SetActive(false);
        nextButtonOutline.SetActive(false);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        nextButtonOutline.SetActive(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        nextButtonOutline.SetActive(false);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        EventManagerScript.instance.NextPressed();
    }
}
