using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;

    public Animator anim;

    public float jumpForce = 20f;
    public Transform feet;
    public Transform face;
    public LayerMask groundLayers;

    public AudioClip clip;
    public AudioSource source;
    public float nextSoundTime = 0;

    [HideInInspector] public bool isFacingRight = true;

    float mx;

    // Start is called before the first frame update
    private void Start()
    {
        mx = 0.7f;
    }

    // Update is called once per frame
    private void Update()
    {
        Collider2D faceCheck = Physics2D.OverlapCircle(face.position, 0.2f, groundLayers);
        if (faceCheck != null)
        {
            if (Input.GetButton("Jump") && !IsGrounded())
            {
                mx = -mx;
                source.PlayOneShot(clip, 0.5f);
                Jump();
            } else
            {
                mx = -mx;
            }
        }
        //mx = Input.GetAxisRaw("Horizontal");

        if (Input.GetButton("Jump") && IsGrounded())
        {
            Jump();
        }

        if (Mathf.Abs(mx) > 0.05f)
        {
            anim.SetBool("isRunning", true);
        } else
        {
            anim.SetBool("isRunning", false);
        }

        if (mx > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            isFacingRight = true;
        } else if (mx < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            isFacingRight = false;
        }

        anim.SetBool("isGrounded", IsGrounded());
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);

        rb.velocity = movement;
    }
    private void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);

        if (Time.time >= nextSoundTime)
        {
            source.PlayOneShot(clip, 0.5f);
        }
        rb.velocity = movement;
        nextSoundTime = Time.time + clip.length;
    }

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.3f, groundLayers);

        if (groundCheck != null)
        {
            return true;
        }

        return false;
    }
}
