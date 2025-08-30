using UnityEngine;
using DG.Tweening;
using System.Collections;

public class StoryCharacterScript : MonoBehaviour
{
    [SerializeField] private float yValue;
    [SerializeField] private Sprite _sprite;
    private SpriteRenderer _renderer;

    void Awake()
    {
        _renderer = gameObject.GetComponent<SpriteRenderer>();
        Disappear();
    }

    public void PopUpAnim()
    {
        gameObject.transform.DOKill();

        Vector3 pos = new Vector3(gameObject.transform.localPosition.x, -10f);
        gameObject.transform.localPosition = pos;

        gameObject.transform.DOMoveY(yValue, 0.3f).SetEase(Ease.OutBack);
    }

    public void PopDownAnim()
    {
        Vector3 pos = new Vector3(gameObject.transform.localPosition.x, yValue);
        gameObject.transform.localPosition = pos;
        
        gameObject.transform.DOKill();
        gameObject.transform.DOMoveY(-10f, 0.3f).SetEase(Ease.OutBack);
    }

    public void Appear()
    {
        _renderer.sprite = _sprite;
    }

    public void Disappear()
    {
        _renderer.sprite = null;
    }

    private IEnumerator WaitAndDisappear()
    {
        yield return null;
        gameObject.SetActive(false);
    }
}
