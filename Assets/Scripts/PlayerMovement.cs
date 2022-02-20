using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator animator;
    [SerializeField] private LayerMask jumpableGround;
    private float x = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private Text levelText;
    private enum movementState { idle, running, jumping, falling }
    [SerializeField] private AudioSource jumpSound;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        animationUpdate();
    }

    private void animationUpdate()
    {
        movementState state;

        if (x > 0f)
        {
            state = movementState.running;
            transform.localScale = new Vector2(0.6f, 0.6f);
        }   
        else if (x < 0f)
        {
            state = movementState.running;
            transform.localScale = new Vector2(-0.6f, 0.6f);
        }
        else
        {
            state = movementState.idle;
        }

        if(rb.velocity.y > .1f)
        {
            state = state = movementState.jumping;
        }else if (rb.velocity.y < -.1f)
        {
            state = state = movementState.falling;
        }

        animator.SetInteger("state", (int)state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Level1"))
        {
            levelText.text = "LEVEL 1";
        }else if(collision.gameObject.CompareTag("Level2"))
        {
            levelText.text = "LEVEL 2";
        }else if (collision.gameObject.CompareTag("Level3"))
        {
            levelText.text = "LEVEL 3";
        }
    }
}
