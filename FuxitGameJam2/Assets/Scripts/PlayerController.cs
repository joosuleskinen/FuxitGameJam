using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering.Universal;

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
    [SerializeField] Light2D flashLight;
    [SerializeField] GameObject groundCollider;
    private bool lightRotatedLeft = false;
    private bool lightRotatedRight = true;
    private float cooldown = 0;

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
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && cooldown <= 0)
        {
            playerRb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            isOnGround = false;
        }

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
        // Liikkuminen
        horizontalInput = Input.GetAxis("Horizontal");
        playerRb.velocity = new Vector2(horizontalInput * speed, playerRb.velocity.y);

        // "Maa" pelaajan alla liikkuu pelaajan alapuolella
        if (groundCollider.transform.position.x != playerRb.position.x)
        {
            groundCollider.transform.position = new Vector2(playerRb.position.x, groundCollider.transform.position.y);
        }

        // k‰vely animaatio
        animator.SetFloat("xVelocity", Math.Abs(playerRb.velocity.x));

        // K‰‰nn‰ animaation vasemmalle tai oikealle
        spriteRenderer.flipX = playerRb.velocity.x < 0f;

        // Valo vasemmalle
        if (playerRb.velocity.x < 0f && !lightRotatedLeft)
        {
            flashLight.GetComponent<Light2D>().transform.Rotate(0, 0, 180);
            lightRotatedLeft = true;
            lightRotatedRight = false;
        }

        // Valo oikealle
        if (playerRb.velocity.x > 0f && !lightRotatedRight)
        {
            flashLight.GetComponent<Light2D>().transform.Rotate(0, 0, -180);
            lightRotatedRight = true;
            lightRotatedLeft = false;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
        cooldown = 0.15f;
    }
}
