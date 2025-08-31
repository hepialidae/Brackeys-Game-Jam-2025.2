using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NextButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private GameObject nextButtonOutline;
    [SerializeField] private GameObject nextButtonOutlineB;

    void Start()
    {
        gameObject.SetActive(false);
        nextButtonOutline.SetActive(false);
        nextButtonOutlineB.SetActive(false);

        EventManagerScript.instance.OnTrashPressed += Reset;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (GamestateManager.instance.day <= 2)
        {
            nextButtonOutline.SetActive(true);
        }
        else
        {
            nextButtonOutlineB.SetActive(true);
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (GamestateManager.instance.day <= 2)
        {
            nextButtonOutline.SetActive(false);
        }
        else
        {
            nextButtonOutlineB.SetActive(false);
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        nextButtonOutline.SetActive(false);
        nextButtonOutlineB.SetActive(false);
        EventManagerScript.instance.NextPressed();
        SceneManager.LoadScene("Cooking2");
    }

    private void Reset()
    {
        nextButtonOutline.SetActive(false);
        nextButtonOutlineB.SetActive(false);
        gameObject.SetActive(false);
    }
}
