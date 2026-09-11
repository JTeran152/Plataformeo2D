using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5.5f;

    [Header("Detección del suelo")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb2D;
    private float move;
    private bool isGrounded;
    private Animator animator;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Obtiene el movimiento horizontal.
        move = Input.GetAxisRaw("Horizontal");
        rb2D.linearVelocity = new Vector2(
            move * speed,
            rb2D.linearVelocity.y
        );

        // Orienta al personaje según la dirección del movimiento.
        if (move != 0)
        {
            transform.localScale = new Vector3(
                Mathf.Sign(move),
                1,
                1
            );
        }

        // Permite saltar únicamente cuando está sobre el suelo.
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2D.linearVelocity = new Vector2(
                rb2D.linearVelocity.x,
                jumpForce
            );
        }

        // Actualiza las animaciones.
        animator.SetFloat("Speed", Mathf.Abs(move));
        animator.SetFloat("VerticalVelocity", rb2D.linearVelocity.y);
        animator.SetBool("IsGrounded", isGrounded);
    }

    void FixedUpdate()
    {
        // Comprueba si existe suelo debajo del personaje.
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundRadius,
            groundLayer
        );
    }
}