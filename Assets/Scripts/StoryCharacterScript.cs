using UnityEngine;
using DG.Tweening;

public class StoryCharacterScript : MonoBehaviour
{
    [SerializeField] private float yValue;
    private Transform _transform;

    void Start()
    {
        _transform = gameObject.GetComponent<Transform>();

        gameObject.SetActive(false);
    }

    public void PopUp()
    {
        Vector3 pos = new Vector3(gameObject.transform.localPosition.x, -6.33f);
        gameObject.transform.localPosition = pos;
        
        gameObject.transform.DOMoveY(yValue, 0.3f).SetEase(Ease.OutBack);
    }
}
