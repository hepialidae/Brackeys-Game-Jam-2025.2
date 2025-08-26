using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TrashButton_Cooking2Script : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] GameObject trashButtonOutline;

    void Start()
    {
        trashButtonOutline.SetActive(false);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        trashButtonOutline.SetActive(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        trashButtonOutline.SetActive(false);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        EventManagerScript_Cooking2.instance.TrashPressed();
        SceneManager.LoadScene("Cooking1");
    }
}
