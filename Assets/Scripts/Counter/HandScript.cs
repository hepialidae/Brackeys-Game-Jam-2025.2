using UnityEngine;
using UnityEngine.EventSystems;

public class HandScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject outline;

    void Start()
    {
        outline.SetActive(false);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        outline.SetActive(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        outline.SetActive(false);
    }

    public void OnClick()
    {
        StoryManagerScript.instance.ChooseHand();
    }
}
