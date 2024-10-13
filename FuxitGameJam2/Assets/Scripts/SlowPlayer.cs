using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlowPlayer : MonoBehaviour
{
    private float oldSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject.Find("Player").GetComponent<PlayerController>().SlowSpeed();
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        GameObject.Find("Player").GetComponent<PlayerController>().NormalSpeed();
    }
}
