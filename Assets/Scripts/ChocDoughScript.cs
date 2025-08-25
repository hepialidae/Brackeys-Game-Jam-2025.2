using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChocDoughScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject chocDoughOutline;

    void Start()
    {
        chocDoughOutline.SetActive(false);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        chocDoughOutline.SetActive(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        chocDoughOutline.SetActive(false);
    }
}
