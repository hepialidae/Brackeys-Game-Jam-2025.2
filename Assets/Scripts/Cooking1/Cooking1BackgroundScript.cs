using UnityEngine;

public class Cooking1BackgroundScript : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _animator.SetBool("HasBurntBiscuit", false);
        
        EventManagerScript.instance.OnBiscuitPlated.AddListener(BiscuitPlated);
    }

    private void BiscuitPlated(int cookScore)
    {
        if (cookScore == 4)
        {
            _animator.SetBool("HasBurntBiscuit", true);
        }
    }
}
