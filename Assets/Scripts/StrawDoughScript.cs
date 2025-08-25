using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class StrawDoughScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject strawDoughOutline;

    void Start()
    {
        strawDoughOutline.SetActive(false);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        strawDoughOutline.SetActive(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        strawDoughOutline.SetActive(false);
    }
}
