using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Animator anima;   
    InputAction move;
    Rigidbody2D rb;
    SpriteRenderer srender;
    public float speed = 5;
    public bool isLeft = false;

    void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
        move = InputSystem.actions.FindAction("Move");
        anima = transform.GetComponent<Animator>();
        srender = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector2 dir = move.ReadValue<Vector2>();
        
        rb.linearVelocity = dir;
        if (dir.magnitude > 0)
        {
            anima.SetBool("walking", true);
            dir = dir.normalized;

            if (dir.x < 0 && !isLeft)
            {
                srender.flipX = true;
                isLeft = true;
            }
            else if (dir.x > 0 && isLeft)
            {
                srender.flipX = false;
                isLeft = false;
            }

            }
            else anima.SetBool("walking", false);
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
            GameManager.instance.panel.SetActive(true);
        }
        Debug.Log("Entrou na area");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Acess"))
        {
            GameManager.instance.panel.SetActive(false);
        }
        Debug.Log("Entrou na area");
    }
}
