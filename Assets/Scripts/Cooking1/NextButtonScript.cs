using UnityEngine;
using UnityEngine.EventSystems;

public class NextButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject nextButtonOutline;

    void Start()
    {
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
}
