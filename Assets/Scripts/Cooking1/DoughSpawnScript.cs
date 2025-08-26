using UnityEngine;

public class DoughSpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject[] RawDoughs;
    [SerializeField] private Sprite[] ChocDoughs;
    [SerializeField] private Sprite[] StrawDoughs;
    [SerializeField] private Sprite[] VaniDoughs;

    private SpriteRenderer _spriteRenderer;
    private int doughIndex = 99;
    private int cookScore = 99;

    void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        EventManagerScript.instance.OnDoughChosen.AddListener(SpawnDough);
        EventManagerScript.instance.OnDoughBaked += BakeDough;
        EventManagerScript.instance.OnBiscuitPlated.AddListener(PlateBiscuit);
        EventManagerScript.instance.OnNextPressed += NextPressed;
        EventManagerScript.instance.OnTrashPressed += Reset;
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

    private void PlateBiscuit(int cookedLevel)
    {
        Debug.Log("CookedLevel: " + cookedLevel);
        if (doughIndex == 0)
        {
            _spriteRenderer.sprite = VaniDoughs[cookedLevel];
            cookScore = cookedLevel;
        }
        else
        {
            if (doughIndex == 1)
            {
                _spriteRenderer.sprite = StrawDoughs[cookedLevel];
                cookScore = cookedLevel;
            }
            else
            {
                if (doughIndex == 2)
                {
                    _spriteRenderer.sprite = ChocDoughs[cookedLevel];
                    cookScore = cookedLevel;
                }
                else
                {
                    Debug.LogError("PlateBiscuit() cannot plate. Dough Index: " + doughIndex + "; cookedLevel: " + cookedLevel);
                }
            }
        }
    }

    private void NextPressed()
    {
        Debug.Log(doughIndex + " " + cookScore);
        OrderTracker.instance.playerDoughIndex = doughIndex;
        OrderTracker.instance.playerCookScore = cookScore;
    }

    private void Reset()
    {
        doughIndex = 99;
        cookScore = 99;
        _spriteRenderer.sprite = null;
    }
}
