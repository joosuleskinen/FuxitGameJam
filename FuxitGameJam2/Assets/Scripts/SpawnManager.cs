using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject player;
    public GameObject background;
    private Vector2 spawnPos;
    private float toimi = -7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //player ei ehk toimi
        //while (transform.position.x > -27)
        //{
          

            if (transform.position.x > toimi)
            {
                spawnPos = new Vector2(player.transform.position.x+40, 0);
                Instantiate(background, spawnPos, background.transform.rotation);
                toimi = toimi + 20;
                //continue;
            }

            
        //}
    }
    
}
