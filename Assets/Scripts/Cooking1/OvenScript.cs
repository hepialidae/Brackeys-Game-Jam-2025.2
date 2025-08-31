using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class OvenScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("Oven Variants")]
    [SerializeField] GameObject ovenOutline;
    [SerializeField] GameObject ovenOutlineB;
    [SerializeField] GameObject ovenWithBiscuit;

    [Header("Cooking Bar Functionality")]
    [SerializeField] private CookingBarVertScript cookingBarVertScript;
    [SerializeField] private GameObject cookingBar;
    [SerializeField] private GameObject cookingBarVert;
    private bool CanBake = false;

    void Start()
    {
        ovenOutline.SetActive(false);
        ovenOutlineB.SetActive(false);
        EventManagerScript.instance.OnDoughChosen.AddListener(DoughChosen);
        EventManagerScript.instance.OnTrashPressed += Reset;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (CanBake)
        {
            if (GamestateManager.instance.day <= 2)
            {
                ovenOutline.SetActive(true);
            }
            else
            {
                ovenOutlineB.SetActive(true);
            }
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (CanBake)
        {
            if (GamestateManager.instance.day <= 2)
            {
                ovenOutline.SetActive(false);
            }
            else
            {
                ovenOutlineB.SetActive(false);
            }
        }
    }

    void DoughChosen(int doughNum)
    {
        CanBake = true;
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (cookingBarVertScript.BarMoving == false && CanBake == true)
        {
            ovenOutline.SetActive(false);
            ovenOutlineB.SetActive(false);
            EventManagerScript.instance.BakeDough();
            cookingBar.SetActive(true);
            cookingBarVert.SetActive(true);
            ovenWithBiscuit.SetActive(true);
            CanBake = false;
            cookingBarVertScript.StartCoroutine(cookingBarVertScript.StartBar());
        }
    }

    private void Reset()
    {
        ovenOutline.SetActive(false);
        ovenOutlineB.SetActive(false);
        CanBake = false;
    }
}
