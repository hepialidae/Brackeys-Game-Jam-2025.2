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
        if (StoryManagerScript.instance.fingerIndex != 0)
        {
            outline.SetActive(true);
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (StoryManagerScript.instance.fingerIndex != 0)
        {
            outline.SetActive(false);
        }
    }

    public void OnClick()
    {
        if (StoryManagerScript.instance.fingerIndex != 0)
        {
            StoryManagerScript.instance.ChooseHand();
        }
    }
}
