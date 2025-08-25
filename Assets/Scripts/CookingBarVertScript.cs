using UnityEngine;
using System.Collections;

public class CookingBarVertScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float secondsBeforeDisappear = 1.5f;
    [SerializeField] private GameObject cookingBar;
    public bool BarMoving = false;
    private Rigidbody2D _rb;
    private Animator _animator;

    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();

        // Make sure starting position is at the start of the bar
        cookingBar.SetActive(false);
        gameObject.SetActive(false);
        Vector3 pos = gameObject.transform.localPosition;
        pos.x = 0.425f;
        gameObject.transform.localPosition = pos;

        _animator.SetBool("BarStopped", false);
    }

    void Update()
    {
        // checks if player clicks while bar is moving
        if (InputManagerScript.instance.GetLeftClickPerformed() && BarMoving)
        {
            StartCoroutine(EndBar());
        }

        // checks if bar goes too far
        if (gameObject.transform.localPosition.x >= 8.312)
        {
            StartCoroutine(EndBar());
        }
    }

    private void StartBar()
    {
        gameObject.SetActive(true);
        cookingBar.SetActive(true);
        _animator.SetBool("BarStopped", false);
        BarMoving = true;
        _rb.linearVelocityX = moveSpeed;
    }

    private IEnumerator EndBar()
    {
        _rb.linearVelocityX = 0;
        _animator.SetBool("BarStopped", true);
        BarMoving = false;
        yield return new WaitForSeconds(secondsBeforeDisappear);
        Vector3 pos = gameObject.transform.localPosition;
        pos.x = 0.425f;
        gameObject.transform.localPosition = pos;
        cookingBar.SetActive(false);
        gameObject.SetActive(false);
    }
}
