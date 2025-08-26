using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NextButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private GameObject nextButtonOutline;

    void Start()
    {
        gameObject.SetActive(false);
        nextButtonOutline.SetActive(false);

        EventManagerScript.instance.OnTrashPressed += Reset;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        nextButtonOutline.SetActive(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        nextButtonOutline.SetActive(false);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        nextButtonOutline.SetActive(false);
        EventManagerScript.instance.NextPressed();
        SceneManager.LoadScene("Cooking2");
    }

    private void Reset()
    {
        nextButtonOutline.SetActive(false);
        gameObject.SetActive(false);
    }
}
