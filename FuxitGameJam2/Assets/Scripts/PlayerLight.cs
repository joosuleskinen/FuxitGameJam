using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLight : MonoBehaviour
{
    [SerializeField] Light2D bodyLight;
    [SerializeField] Light2D flashLight;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerExit2D(Collider2D collider)
    {
       if (player.GetComponent<Rigidbody2D>().velocity.x > 0f && !gameObject.CompareTag("Exit_door"))
        {
            bodyLight.GetComponent<Light2D>().enabled = true;
            flashLight.GetComponent<Light2D>().enabled = true;
        }

        else if (player.GetComponent<Rigidbody2D>().velocity.x > 0f  && gameObject.CompareTag("Exit_door"))
        {
            bodyLight.GetComponent<Light2D>().enabled = false;
            flashLight.GetComponent<Light2D>().enabled = false;
        }
    }
}
