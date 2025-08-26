using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;

public class CookingBarVertScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float secondsBeforeDisappear = 1.5f;
    [SerializeField] private GameObject cookingBar;
    [SerializeField] GameObject ovenWithBiscuit;
    [SerializeField] GameObject nextButton;
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
        pos.x = -4.1f;
        gameObject.transform.localPosition = pos;
        _rb.linearVelocityX = 0;

        _animator.SetBool("BarStopped", false);

        EventManagerScript.instance.OnTrashPressed += Reset;
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
        if (gameObject.transform.localPosition.x >= 4.24 && BarMoving)
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

        int score = CalculateBarScore(gameObject.transform.localPosition.x);
        EventManagerScript.instance.OnBiscuitPlated.Invoke(score);

        ovenWithBiscuit.SetActive(false);
        nextButton.SetActive(true);

        BarMoving = false;

        yield return new WaitForSeconds(secondsBeforeDisappear);

        Vector3 pos = gameObject.transform.localPosition;
        pos.x = -4.1f;
        gameObject.transform.localPosition = pos;

        cookingBar.SetActive(false);
        gameObject.SetActive(false);
    }

    private int CalculateBarScore(float xPosition)
    {
        // Raw: < -0.59
        // Undercooked: -0.59 -> 0.49
        // Baked: 0.49 -> 1.81 (both inclusive)
        // Overcooked: 1.81 -> 2.91
        // Burnt: >2.91
        if (xPosition < -0.59)
        {
            return 0;
        }
        else
        {
            if (xPosition >= -0.59 && xPosition < 0.49)
            {
                return 1;
            }
            else
            {
                if (xPosition >= 0.49 && xPosition <= 1.81)
                {
                    return 2;
                }
                else
                {
                    if (xPosition > 1.81 && xPosition <= 2.91)
                    {
                        return 3;
                    }
                    else
                    {
                        if (xPosition > 2.91)
                        {
                            return 4;
                        }
                    }
                }
            }
        }

        Debug.LogError("Something's wrong with CalculateBarScore, this shouldn't be possible. X Position: " + xPosition);
        return 0;
    }

    private void Reset()
    {
        StopAllCoroutines();
        BarMoving = false;

        Vector3 pos = gameObject.transform.localPosition;
        pos.x = -4.1f;
        gameObject.transform.localPosition = pos;

        cookingBar.SetActive(false);
        gameObject.SetActive(false);
    }
}
