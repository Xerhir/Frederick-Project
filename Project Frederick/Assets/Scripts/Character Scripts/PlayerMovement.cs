using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 10f;
    
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float jumpForce = 5f;

    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    private bool isGrounded;

    public float dashForce = 10f;
    public float dashDuration = 0.2f;
    private bool isDashing = false;

    public TrailRenderer dashTrail;
    
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         //better jump
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        
        //movement
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y);
        
        //ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        //jump
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        
        // Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && (isGrounded || (rb.velocity.x != 0 && !isGrounded)))
        {
            StartCoroutine(Dash());
        }

        Walk(dir);
    }
    private void Walk(Vector2 dir)
    {
        rb.velocity = (new Vector2(dir.x * speed, rb.velocity.y));
    }


    private IEnumerator Dash()
    {
        isDashing = true;
        dashTrail.emitting = true;

        float originalGravityScale = rb.gravityScale;
        rb.gravityScale = 0f; // Disable gravity during dash

        Vector2 dashDirection = new Vector2(transform.localScale.x, 0f); // Dash in the direction the player is facing
        rb.velocity = dashDirection * dashForce;

        yield return new WaitForSeconds(dashDuration);
        dashTrail.emitting = false;
        dashTrail.Clear();

        rb.velocity = Vector2.zero;
        rb.gravityScale = originalGravityScale; // Restore gravity

        

        yield return new WaitForSeconds(0.2f); // Cooldown between dashes
        isDashing = false;
    }


}

