using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;

    [SerializeField] private LayerMask jumpableGround;

    private float moveSpeed = 7f;
    private float jumpForce = 9f;
    private float dirX = 0f;

    [SerializeField] private AudioSource jumpSound;

    private enum MovementState {idle, running, jumping, falling }

    private float originalMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
        _rb = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();

        originalMoveSpeed = moveSpeed;
    }





    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(dirX * moveSpeed, _rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSound.Play();
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
        }

        UpdateAnimation();
    }


    public void IncreaseMovementSpeed()
    {
        // You can adjust the factor by which the speed increases
        moveSpeed *= 1.01f;
        Debug.Log("Player movement speed increased to: " + moveSpeed);
    }

    private void UpdateAnimation()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
            
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
            
        }
        else
        {
            state = MovementState.idle;
        }


        if (_rb.velocity.y >.01f)
        {
            state = MovementState.jumping;
        }
        else if (_rb.velocity.y < -.01f)
        {
            state = MovementState.falling;
        }
       
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        //detects if player overlaps on to GroundLayer with early detection before player collide
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);

    }
}
