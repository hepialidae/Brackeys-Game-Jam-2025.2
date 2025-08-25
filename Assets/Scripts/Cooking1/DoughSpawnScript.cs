using UnityEngine;

public class DoughSpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject[] Doughs;
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
        _spriteRenderer.sprite = Doughs[doughNum].gameObject.GetComponent<SpriteRenderer>().sprite;
        doughIndex = doughNum;
    }

    private void BakeDough()
    {
        _spriteRenderer.sprite = null;
    }
}
