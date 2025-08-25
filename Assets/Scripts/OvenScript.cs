using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class OvenScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject ovenOutline;

    void Start()
    {
        ovenOutline.SetActive(false);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        ovenOutline.SetActive(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        ovenOutline.SetActive(false);
    }
}
