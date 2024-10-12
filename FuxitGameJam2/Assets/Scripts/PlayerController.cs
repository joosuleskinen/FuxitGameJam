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

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        Physics.gravity *= gravityModifier;

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

        //Sivu
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * Time.deltaTime * horizontalInput * speed);

        //Keep the player in bounds
        if (transform.position.x < xVasenRange)
        {
            transform.position = new Vector2(xVasenRange, transform.position.y);
        }
       

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
    }
}
