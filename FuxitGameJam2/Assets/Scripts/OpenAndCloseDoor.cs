using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAndCloseDoor : MonoBehaviour
{

    Animator door;
    [SerializeField] GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        door = GetComponent<Animator>();
        door.Play("Door_Open", 0, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (player.GetComponent<Rigidbody2D>().velocity.x > 0f)
        {
            door = GetComponent<Animator>();
            door.Play("Door_Close", 0, 0.0f);
            GetComponent<BoxCollider2D>().isTrigger = false;
            GetComponent<AudioSource>().Play();
        }
    }
}
