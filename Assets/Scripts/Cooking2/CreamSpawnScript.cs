using UnityEngine;

public class CreamSpawnScript : MonoBehaviour
{
    [Header("Whipped Cream Sprites")]
    [SerializeField] Sprite[] creams;
    private SpriteRenderer _renderer;

    void Start()
    {
        _renderer = gameObject.GetComponent<SpriteRenderer>();

        _renderer.sprite = null;

        EventManagerScript_Cooking2.instance.OnCreamAdded.AddListener(SpawnCream);
    }

    void SpawnCream(int creamIndex)
    {
        _renderer.sprite = creams[creamIndex];
    }
}
