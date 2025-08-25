using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class VaniDoughScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject vaniDoughOutline;

    void Start()
    {
        vaniDoughOutline.SetActive(false);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        vaniDoughOutline.SetActive(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        vaniDoughOutline.SetActive(false);
    }
}
