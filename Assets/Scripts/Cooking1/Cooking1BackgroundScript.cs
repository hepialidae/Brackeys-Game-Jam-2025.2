using UnityEngine;

public class Cooking1BackgroundScript : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _animator.SetBool("HasBurntBiscuit", false);

        EventManagerScript.instance.OnBiscuitPlated.AddListener(BiscuitPlated);
        EventManagerScript.instance.OnTrashPressed += Reset;
    }

    private void BiscuitPlated(int cookScore)
    {
        if (cookScore == 4)
        {
            _animator.SetBool("HasBurntBiscuit", true);
        }
    }

    private void Reset()
    {
        _animator.SetBool("HasBurntBiscuit", false);
    }
}
