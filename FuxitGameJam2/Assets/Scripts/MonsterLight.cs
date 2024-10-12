using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MonsterLight : MonoBehaviour
{
    [SerializeField] Light2D eyeLight;
    [SerializeField] Light2D eye2Light;
    private float hiddenCooldown = 0;
    private float showCooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        hiddenCooldown = 5.0f;
        eyeLight.GetComponent<Light2D>().enabled = false;
        eye2Light.GetComponent<Light2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hiddenCooldown <= 0) 
        {
            eyeLight.GetComponent<Light2D>().enabled = true;
            eye2Light.GetComponent<Light2D>().enabled = true;
            hiddenCooldown = Random.Range(5.0f, 15.0f); 
            showCooldown = Random.Range(1.0f, 5.0f);
        }

        if (showCooldown > 0)
        {
            showCooldown -= Time.deltaTime;
        }

        if (hiddenCooldown > 0 && showCooldown <= 0)
        {
            eyeLight.GetComponent<Light2D>().enabled = false;
            eye2Light.GetComponent<Light2D>().enabled = false;

            hiddenCooldown -= Time.deltaTime;
        }
    }
}
