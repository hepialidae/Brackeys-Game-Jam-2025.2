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
    private bool CanBake = false;

    void Start()
    {
        ovenOutline.SetActive(false);
        EventManagerScript.instance.OnDoughChosen.AddListener(DoughChosen);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        ovenOutline.SetActive(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        ovenOutline.SetActive(false);
    }

    void DoughChosen(int doughNum)
    {
        CanBake = true;
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (cookingBarVertScript.BarMoving == false && CanBake == true)
        {
            EventManagerScript.instance.BakeDough();
            cookingBar.SetActive(true);
            cookingBarVert.SetActive(true);
            ovenWithBiscuit.SetActive(true);
            CanBake = false;
            cookingBarVertScript.StartCoroutine(cookingBarVertScript.StartBar());
        }
    }
}
