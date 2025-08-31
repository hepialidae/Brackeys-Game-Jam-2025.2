using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class FingerScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private int myFingerIndex;
    [SerializeField] private GameObject outline;
    private SpriteRenderer _renderer;

    void Start()
    {
        outline.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (StoryManagerScript.instance.fingerIndex == 0)
        {
            outline.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (StoryManagerScript.instance.fingerIndex == 0)
        {
            outline.SetActive(false);
        }
    }

    public void OnClick()
    {
        if (StoryManagerScript.instance.fingerIndex == 0)
        {
            outline.SetActive(false);
            StoryManagerScript.instance.ChooseFinger(myFingerIndex);
        }
    }

    public void Disappear(int index)
    {
        if (index == myFingerIndex)
        {
            _renderer.sprite = null;
        }
    }
}
