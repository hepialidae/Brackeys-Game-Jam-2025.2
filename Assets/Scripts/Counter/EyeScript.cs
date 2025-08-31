using UnityEngine;
using UnityEngine.EventSystems;

public class EyeScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject outline;

    void Start()
    {
        outline.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        outline.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        outline.SetActive(false);
    }

    public void OnClick()
    {
        StoryManagerScript.instance.ChooseEye();
    }
}
