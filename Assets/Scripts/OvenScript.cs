using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class OvenScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("Oven Variants")]
    [SerializeField] GameObject ovenOutline;
    [SerializeField] GameObject ovenWithBiscuit;

    [Header("Cooking Bar Functionality")]
    [SerializeField] private CookingBarVertScript cookingBarVertScript;
    [SerializeField] private GameObject cookingBar;
    [SerializeField] private GameObject cookingBarVert;

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

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (cookingBarVertScript.BarMoving == false)
        {
            cookingBar.SetActive(true);
            cookingBarVert.SetActive(true);
            ovenWithBiscuit.SetActive(true);
            cookingBarVertScript.StartCoroutine(cookingBarVertScript.StartBar());
        }
    }
}
