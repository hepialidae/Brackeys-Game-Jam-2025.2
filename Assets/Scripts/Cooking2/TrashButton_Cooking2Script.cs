using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TrashButton_Cooking2Script : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] GameObject trashButtonOutline;
    [SerializeField] GameObject trashButtonOutlineB;

    void Start()
    {
        trashButtonOutline.SetActive(false);
        trashButtonOutlineB.SetActive(false);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (GamestateManager.instance.day <= 2)
        {
            trashButtonOutline.SetActive(true);
        }
        else
        {
            trashButtonOutlineB.SetActive(true);
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (GamestateManager.instance.day <= 2)
        {
            trashButtonOutline.SetActive(false);
        }
        else
        {
            trashButtonOutlineB.SetActive(false);
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        EventManagerScript_Cooking2.instance.TrashPressed();
        SceneManager.LoadScene("Cooking1");
    }
}
