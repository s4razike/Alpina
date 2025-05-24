using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

public static PlayerMovement instance;

    [Header("Basic")]
    public float moveSpeed = 5f;
    public Rigidbody2D theRB;
    public float jumpForce = 10f;
    private SpriteRenderer theSR;

    [Header("Salto")]
    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    private bool canDoubleJump;

    [Header("Dash")]
    public float dashSpeed = 15f;
    public float dashDuration = 0.2f;
    [HideInInspector]public bool isDashing = false;
    private float dashTimer = 0f;
    private Vector2 dashDirection;
    private bool canDash = true; // Control si el jugador puede usar dash

    // Knockback y otros
    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    [Header("Flotación")]
    public float floatDuration = 3f;
    public float floatGravityScale = 0.2f;
    private bool isFloating = false;
    private float floatTimer = 0f;
    private float originalGravityScale;

    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        originalGravityScale = theRB.gravityScale;
    }

    void Update()
    {
        if (knockBackCounter <= 0)
        {
            HandleJump();
            HandleFastFall();
            UpdateDash();
            UpdateFloat();
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
            // Lógica de knockback...
        }

        UpdateSpriteDirection();
    }

    void FixedUpdate()
    {
        if (knockBackCounter > 0) return;

        if (isDashing)
        {
            theRB.velocity = dashDirection * dashSpeed;
        }
        else
        {
            float moveInput = Input.GetAxis("Horizontal");
            theRB.velocity = new Vector2(moveInput * moveSpeed, theRB.velocity.y);
        }
    }

    private void HandleJump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, whatIsGround);

        if (isGrounded)
        {
            canDoubleJump = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
            }
            else if (canDoubleJump)
            {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                canDoubleJump = false;
            }
        }
    }

    private void HandleFastFall()
    {
        if (Input.GetKey(KeyCode.S) && !isGrounded)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, -jumpForce * 2);
        }
    }

    private void UpdateSpriteDirection()
    {
        if (theRB.velocity.x < 0)
        {
            theSR.flipX = true;
        }
        else if (theRB.velocity.x > 0)
        {
            theSR.flipX = false;
        }
    }

    private void UpdateDash()
    {
        if (isDashing)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0f)
            {
                isDashing = false;
            }
        }
    }

    // Método público para activar el dash desde el sistema de cartas
    public void Dash()
    {
        if (!canDash || isDashing) return;
        
        isDashing = true;
        dashTimer = dashDuration;
        
        // Determinar dirección del dash
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        
        if (horizontalInput != 0 || verticalInput != 0)
        {
            dashDirection = new Vector2(horizontalInput, verticalInput).normalized;
        }
        else
        {
            // Si no hay input, dash en la dirección que mira el personaje
            dashDirection = theSR.flipX ? Vector2.left : Vector2.right;
        }
    }

    // Métodos para controlar la disponibilidad del dash
    public void EnableDash() => canDash = true;
    public void DisableDash() => canDash = false;

    // Añade este nuevo método para manejar la flotación
    private void UpdateFloat()
    {
    if (isFloating)
    {
        floatTimer -= Time.deltaTime;
        
        // Reduce la gravedad mientras flota
        theRB.gravityScale = floatGravityScale;
        
        if (floatTimer <= 0f)
        {
            StopFloat();
        }
    }
    }
    public void StartFloat()
    {
    if (isFloating) return;
    
    isFloating = true;
    floatTimer = floatDuration;
    theRB.gravityScale = floatGravityScale;
    
    Debug.Log("Iniciando flotación");
    }
    public void StopFloat()
    {
    isFloating = false;
    theRB.gravityScale = originalGravityScale;
    theRB.velocity = new Vector2(theRB.velocity.x, -jumpForce * 5);
    
    Debug.Log("Deteniendo flotación");
    }    
} 
