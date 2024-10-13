using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DropPlayer : MonoBehaviour
{
    private float cooldown;

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
        GameObject.Find("GroundCollider").GetComponent<Collider2D>().enabled = false;
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        GameObject.Find("GroundCollider").GetComponent<Collider2D>().enabled = true;
    }
}