using UnityEngine;
using DG.Tweening;

public class PlateScript_Counter : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private float yValue;
    private SpriteRenderer _renderer;

    void Awake()
    {
        _renderer = gameObject.GetComponent<SpriteRenderer>();

        Vector3 pos = new Vector3(gameObject.transform.localPosition.x, -10f);
        gameObject.transform.localPosition = pos;
    }

    void Start()
    {
        EventManagerScript_Counter.instance.OnBiscuitFinished.AddListener(Appear);
        EventManagerScript_Counter.instance.OnCustomerServed += Disappear;
    }

    void OnDisable()
    {
        EventManagerScript_Counter.instance.OnBiscuitFinished.RemoveListener(Appear);
        EventManagerScript_Counter.instance.OnCustomerServed -= Disappear;
    }

    public void Appear(int num)
    {
        gameObject.transform.DOKill();

        Vector3 pos = new Vector3(gameObject.transform.localPosition.x, -10f);
        gameObject.transform.localPosition = pos;

        gameObject.transform.DOMoveY(yValue, 0.3f).SetEase(Ease.OutBack);
    }

    public void Disappear()
    {
        gameObject.transform.DOKill();

        Vector3 pos = new Vector3(gameObject.transform.localPosition.x, yValue);
        gameObject.transform.localPosition = pos;
        
        gameObject.transform.DOMoveY(-10f, 0.3f).SetEase(Ease.OutBack);
    }
}
