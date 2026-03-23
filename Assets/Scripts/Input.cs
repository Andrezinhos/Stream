using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    public static Input instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    InputAction move;
    public Vector2 movement;
    InputAction interaction;
    public bool interact;

    void Start()
    {
        move = InputSystem.actions.FindAction("Move");
        interaction = InputSystem.actions.FindAction("Interact");
    }

    void Update()
    {
        movement = move.ReadValue<Vector2>();
        interact = interaction.WasPressedThisFrame();
    }
}
