using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public float jumpforce;
    public float gravityModifier;
    public bool isOnGround = true;
    public float horizontalInput;
    public float speed;
    public float xVasenRange = -10; //MUUTETAAN KUN TIEDETAAN
    public float xOikeaRange = 10; //MUUTETAAN KUN TIEDETAAN

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        Physics.gravity *= gravityModifier;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //Hyppy
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            isOnGround = false;
        }

    }

    private void FixedUpdate()
    {
        // Liikkuminen
        horizontalInput = Input.GetAxis("Horizontal");
        playerRb.velocity = new Vector2(horizontalInput * speed, playerRb.velocity.y);

        // k‰vely animaatio
        animator.SetFloat("xVelocity", Math.Abs(playerRb.velocity.x));

        // K‰‰nn‰ animaation vasemmalle tai oikealle
        spriteRenderer.flipX = playerRb.velocity.x < 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
    }
}
