using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class CookingBarVertScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float secondsBeforeDisappear = 1.5f;
    [SerializeField] private GameObject cookingBar;
    [SerializeField] GameObject ovenWithBiscuit;
    public bool BarMoving = false;
    private Rigidbody2D _rb;
    private Animator _animator;

    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();

        cookingBar.SetActive(false);
        gameObject.SetActive(false);
        _rb.linearVelocityX = 0;
        Vector3 pos = gameObject.transform.localPosition;
        pos.x = -4.109375f;
        gameObject.transform.localPosition = pos;
        _rb.linearVelocityX = 0;

        _animator.SetBool("BarStopped", false);
    }

    void Update()
    {
        // checks if player clicks while bar is moving
        if (InputManagerScript.instance.GetLeftClickPerformed() && BarMoving)
        {
            StopAllCoroutines();
            StartCoroutine(EndBar());
        }

        // checks if bar goes too far
        if (gameObject.transform.localPosition.x >= 8.312)
        {
            StopAllCoroutines();
            StartCoroutine(EndBar());
        }
    }

    public IEnumerator StartBar()
    {
        yield return new WaitForSeconds(0.1f);
        if (BarMoving == false)
        {
            cookingBar.SetActive(true);
            gameObject.SetActive(true);
            _animator.SetBool("BarStopped", false);
            BarMoving = true;
            _rb.linearVelocityX = moveSpeed;
        }
    }

    private IEnumerator EndBar()
    {
        _rb.linearVelocityX = 0;
        _animator.SetBool("BarStopped", true);
        ovenWithBiscuit.SetActive(false);
        yield return new WaitForSeconds(secondsBeforeDisappear);
        BarMoving = false;
        Vector3 pos = gameObject.transform.localPosition;
        pos.x = -4.109375f;
        gameObject.transform.localPosition = pos;
        cookingBar.SetActive(false);
        gameObject.SetActive(false);
    }
}
