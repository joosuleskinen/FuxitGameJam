using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RandomLight : MonoBehaviour
{
    [SerializeField] Light2D Light;
    
    private float hiddenCooldown = 0;
    private float showCooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        hiddenCooldown = 5.0f;
        Light.GetComponent<Light2D>().enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hiddenCooldown <= 0 && transform.position.x <= 790)
        {
            Light.GetComponent<Light2D>().enabled = true;
            
            hiddenCooldown = Random.Range(0.5f, 1.5f);
            showCooldown = Random.Range(0.2f, 0.6f);
        }

        if (showCooldown > 0)
        {
            showCooldown -= Time.deltaTime;
        }

        if (hiddenCooldown > 0 && showCooldown <= 0)
        {
            Light.GetComponent<Light2D>().enabled = false;
            

            hiddenCooldown -= Time.deltaTime;
        }
    }
}
