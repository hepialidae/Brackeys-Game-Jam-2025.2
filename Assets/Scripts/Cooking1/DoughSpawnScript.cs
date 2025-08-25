using UnityEngine;

public class DoughSpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject[] RawDoughs;
    [SerializeField] private Sprite[] ChocDoughs;
    [SerializeField] private Sprite[] StrawDoughs;
    [SerializeField] private Sprite[] VaniDoughs;

    private SpriteRenderer _spriteRenderer;
    private int doughIndex = 99;

    void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        EventManagerScript.instance.OnDoughChosen.AddListener(SpawnDough);
        EventManagerScript.instance.OnDoughBaked += BakeDough;
    }

    private void SpawnDough(int doughNum)
    {
        _spriteRenderer.sprite = RawDoughs[doughNum].gameObject.GetComponent<SpriteRenderer>().sprite;
        doughIndex = doughNum;
    }

    private void BakeDough()
    {
        _spriteRenderer.sprite = null;
    }
}
