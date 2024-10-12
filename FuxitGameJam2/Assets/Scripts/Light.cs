using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Light : MonoBehaviour
{
    public Light2D playerLight;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        playerLight.GetComponent<Light2D>().enabled = false;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (player.GetComponent<Rigidbody2D>().velocity.x > 0f)
        {
            playerLight.GetComponent<Light2D>().enabled = true;
        }
    }
}
