using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerScript : MonoBehaviour
{
    public static InputManagerScript instance;
    private PlayerInput _playerInput;
    private InputAction _leftClick;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of InputManagerScript found");
        }
        else
        {
            instance = this;
        }

        _playerInput = GetComponent<PlayerInput>();
        _leftClick = _playerInput.actions["Cooking1/LeftClick"];
    }

    public InputManagerScript GetInstance()
    {
        return instance;
    }

    public bool GetLeftClickPerformed()
    {
        return _leftClick.WasPerformedThisFrame();
    }
}
