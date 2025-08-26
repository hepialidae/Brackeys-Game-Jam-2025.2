using UnityEngine;
using UnityEngine.EventSystems;

public class TrashButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] GameObject trashButtonOutline;
    [SerializeField] Sprite trash;
    private SpriteRenderer _renderer;
    private bool isVisible;

    void Start()
    {
        _renderer = gameObject.GetComponent<SpriteRenderer>();

        EventManagerScript.instance.OnDoughChosen.AddListener(Appear);
        EventManagerScript.instance.OnDoughBaked += Disappear;
        EventManagerScript.instance.OnBiscuitPlated.AddListener(Appear);
        EventManagerScript.instance.OnTrashPressed += Disappear;

        Disappear();
        trashButtonOutline.SetActive(false);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (isVisible)
        {
            trashButtonOutline.SetActive(true);
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (isVisible)
        {
            trashButtonOutline.SetActive(false);
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (isVisible)
        {
            trashButtonOutline.SetActive(false);
            EventManagerScript.instance.TrashPressed();
        }
    }

    private void Appear(int num)
    {
        _renderer.sprite = trash;
        isVisible = true;
    }

    private void Disappear()
    {
        _renderer.sprite = null;
        isVisible = false;
    }
}
