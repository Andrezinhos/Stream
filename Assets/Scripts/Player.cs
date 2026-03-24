using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    
    InputAction move;
    Rigidbody2D rb;
    public float speed = 5;

    void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
        move = InputSystem.actions.FindAction("Move");
    }

    void FixedUpdate()
    {
        //read value
        Vector2 dir = move.ReadValue<Vector2>();

        //apply to player
        rb.linearVelocity = new Vector2(dir.x * speed, dir.y * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Acess"))
        {

        }
        Debug.Log("Entrou na area");
    }
}
