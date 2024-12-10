using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed;
    [SerializeField] ParticleSystem Dust;
    [SerializeField] AudioClip footstepSound;
    [SerializeField] float footstepInterval = 0.5f;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sr;
    AudioSource audioSource;
    float horizontal;
    bool isPlayingFootsteps = false;

    [Header("Jump")]
    [SerializeField] float jumpForce;
    [SerializeField] Transform groundCheck;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] int jumpValue;
    bool isGrounded;
    int extraJumps;

    Vector2 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        extraJumps = jumpValue;
        startPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        PlayerMove();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    void Update()
    {
        PlayerJump();
    }

    private void PlayerMove()
    {
        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        animator.SetBool("Walk", horizontal != 0);

        if (horizontal != 0)
        {
            sr.flipX = horizontal < 0;
            if (isGrounded)
            {
                CreateDust();
                if (!isPlayingFootsteps)
                {
                    StartCoroutine(PlayFootsteps());
                }
            }
        }
        else
        {
            isPlayingFootsteps = false;
        }
    }

    private IEnumerator PlayFootsteps()
    {
        isPlayingFootsteps = true;
        while (horizontal != 0 && isGrounded)
        {
            audioSource.PlayOneShot(footstepSound);
            yield return new WaitForSeconds(footstepInterval);
        }
        isPlayingFootsteps = false;
    }

    private void CreateDust()
    {
        Dust.Play();
    }

    void PlayerJump()
    {
        if (isGrounded)
        {
            extraJumps = jumpValue;
            animator.SetBool("Jumping", false);
        }
        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            extraJumps--;
            animator.SetTrigger("TakeOff");
        }
    }

    public void ResetToStart()
    {
        rb.position = startPosition;
    }
}
