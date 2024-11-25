using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed;
    [SerializeField] ParticleSystem Dust;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sr;
    float horizontal;

    [Header("Jump")]
    [SerializeField] float jumpForce;
    [SerializeField] Transform groundCheck;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] int jumpValue;
    bool isGrounded;
    int extraJumps;
    AudioSource jumpSound;




    Vector2 startPosition;
    



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        extraJumps = jumpValue;
        startPosition = transform.position;
        jumpSound = GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMove();
        isGrounded = Physics2D.OverlapCircle
            (groundCheck.position, checkRadius, whatIsGround);

    }
     void Update()
    {
        PlayerJump();
    }

    private void PlayerMove()
    {
        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * speed
            , rb.velocity.y);
        animator.SetBool("Walk", horizontal != 0);
        if (horizontal != 0)
        {
            sr.flipX = horizontal < 0;
            if (isGrounded == true)
            {
                CreateDust();
            }

        }
    }

    private void CreateDust()
    {
        Dust.Play();
    }

    void PlayerJump()
    {
        if(isGrounded == true)
        {
            extraJumps = jumpValue;
            animator.SetBool("Jumping", false);
        }
        if (Input.GetButtonDown("Jump")
            && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
            animator.SetTrigger("TakeOff");
            //jumpSound.Play();
        }
        else if (Input.GetButtonDown("Jump")
       && extraJumps == 0 && isGrounded == true)
        {

            rb.velocity = Vector2.up * jumpForce;
            animator.SetTrigger("TakeOff");
            //jumpSound.Play();

        }

    }

    public void ResetToStart()
    {
        rb.position = startPosition;
    }
}    

